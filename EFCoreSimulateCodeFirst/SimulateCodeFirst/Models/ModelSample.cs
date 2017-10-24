using System.ComponentModel.DataAnnotations;

namespace SimulateCodeFirst.Models
{
   public class ModelSample
    {
        [Key]
        public int IdModelSample { get; set; }
        public string DescriptionModelSample { get; set; }
    }
}
