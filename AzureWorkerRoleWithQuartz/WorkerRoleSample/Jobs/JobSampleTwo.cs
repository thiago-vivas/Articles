using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerRoleSample.Business;

namespace WorkerRoleSample.Jobs
{
    public class JobSampleTwo : IJob
    {
        private BusinessSample _business;

        public JobSampleTwo()
        {
            _business = new BusinessSample( this.GetType().ToString() );
        }

        public async Task Execute( IJobExecutionContext context )
        {
            await _business.Ping();
        }
    }
}