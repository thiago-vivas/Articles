using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureRedisCache2.Models
{
    [Serializable]
    public class SampleObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}