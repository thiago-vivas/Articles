using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDataAnnotation.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        [DisplayFormat( NullDisplayText = "Null name" )]
        public string Name { get; set; }
    }
}