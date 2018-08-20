using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerRoleSample.Repository;

namespace WorkerRoleSample.Business
{
    public class BusinessSample
    {
        private string _jobName;
        private SampleContext _sampleContext;

        public BusinessSample( string jobName )
        {
            _jobName = jobName;
            _sampleContext = new SampleContext();
        }

        public Task Ping()
        {
            _sampleContext.LogSample.Add( new LogSample
            {
                JobName = _jobName,
                LogDate = DateTime.Now
            } );
            return
              _sampleContext.SaveChangesAsync();
        }
    }
}