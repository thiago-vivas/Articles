using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDataAnnotation.Models
{
    public class TripManager
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey( "HotelID" )]
        public Hotel Hotel { get; set; }

        public int HotelID { get; set; }

        [ForeignKey( "CarID" )]
        public Car Car { get; set; }

        public int CarID { get; set; }

        [DataType( DataType.Date )]
        public DateTime CheckInDate { get; set; }

        [DataType( DataType.Date )]
        public DateTime CheckOutDate { get; set; }

        [Column( "TodaysPrice" )]
        [Range( 10.30, 46.60 )]
        public double Price { get; set; }

        public Person Responsable { get; set; }
    }
}