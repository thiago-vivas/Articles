using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCalculator.Models
{
    public class CompoundInterestModel
    {
        [Display( Name = "Result - A" )]
        public double Result { get; set; }

        [Display( Name = "Initial Investment - P" )]
        public double Investment { get; set; }

        [Display( Name = "Interest Rate - r" )]
        public double InterestRate { get; set; }

        [Display( Name = "Period of Time - n" )]
        public int TimePeriod { get; set; }
    }
}