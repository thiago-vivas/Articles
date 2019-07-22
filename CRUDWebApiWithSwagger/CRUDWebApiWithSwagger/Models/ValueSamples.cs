using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiWithSwagger.Models
{
    public class ValueSamples
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}