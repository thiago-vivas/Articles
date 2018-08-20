using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerRoleSample.Business;

namespace WorkerRoleSample.Jobs
{
    public class JobSampleOne : IJob
    {
        private BusinessSample _business;

        public JobSampleOne()
        {
            _business = new BusinessSample( this.GetType().ToString() );
        }

        public Task Execute( IJobExecutionContext context )
        {
            return _business.Ping();
        }
    }
}