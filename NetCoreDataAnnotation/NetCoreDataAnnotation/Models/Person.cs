using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDataAnnotation.Models
{
    public class Person
    {
        public int Id { get; set; }

        [StringLength( 50, ErrorMessage = "Name cannot be longer than 50 characters." )]
        public string Name { get; set; }

        [NotMapped]
        public List<Place> VisitedPlaces { get; set; }
    }
}