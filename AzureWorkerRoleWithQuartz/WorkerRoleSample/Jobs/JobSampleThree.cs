using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerRoleSample.Business;

namespace WorkerRoleSample.Jobs
{
    public class JobSampleThree : IJob
    {
        private BusinessSample _business;

        public JobSampleThree()
        {
            _business = new BusinessSample( this.GetType().ToString() );
        }

        public async Task Execute( IJobExecutionContext context )
        {
            await _business.Ping();
        }
    }
}