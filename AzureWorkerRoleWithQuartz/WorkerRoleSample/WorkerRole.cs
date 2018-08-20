using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Quartz;
using Quartz.Impl;
using WorkerRoleSample.Jobs;

namespace WorkerRoleSample
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent( false );
        private IScheduler scheduler;

        public override void Run()
        {
            Trace.TraceInformation( "WorkerRoleSample is running" );

            try
            {
                this.RunAsync( this.cancellationTokenSource.Token ).Wait();
            }
            finally
            {
                this.runCompleteEvent.Set();
            }
        }

        private void ConfigureScheduler()
        {
            var scheduleFactory = new StdSchedulerFactory();
            scheduler = scheduleFactory.GetScheduler().Result;

            IJobDetail job = new JobDetailImpl( "Sample1", typeof( JobSampleOne ) );
            IJobDetail jobTwo = new JobDetailImpl( "Sample2", typeof( JobSampleTwo ) );
            IJobDetail jobThree = new JobDetailImpl( "Sample3", typeof( JobSampleThree ) );
            ITrigger trigger = TriggerBuilder.Create()
                .WithSchedule( SimpleScheduleBuilder.RepeatMinutelyForever( 10 ) )
                   .StartAt( DateTime.Now.AddMinutes( 1 ) )
                   .Build();
            ITrigger triggerTwo = TriggerBuilder.Create()
                .WithSchedule( SimpleScheduleBuilder.RepeatMinutelyForever( 6 ) )
                   .StartAt( DateTime.Now.AddMinutes( 4 ) )
                   .Build();
            ITrigger triggerThree = TriggerBuilder.Create()
                .WithSchedule( SimpleScheduleBuilder.RepeatMinutelyForever( 8 ) )
                   .StartAt( DateTime.Now.AddMinutes( 7 ) )
                   .Build();

            scheduler.ScheduleJob( job, trigger );
            scheduler.ScheduleJob( jobTwo, triggerTwo );
            scheduler.ScheduleJob( jobThree, triggerThree );

            scheduler.Start();
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at https://go.microsoft.com/fwlink/?LinkId=166357.

            bool result = base.OnStart();
            ConfigureScheduler();
            Trace.TraceInformation( "WorkerRoleSample has been started" );

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation( "WorkerRoleSample is stopping" );

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            base.OnStop();

            Trace.TraceInformation( "WorkerRoleSample has stopped" );
        }

        private async Task RunAsync( CancellationToken cancellationToken )
        {
            // TODO: Replace the following with your own logic.
            while ( !cancellationToken.IsCancellationRequested )
            {
                Trace.TraceInformation( "Working" );
                await Task.Delay( 1000 );
            }
        }
    }
}