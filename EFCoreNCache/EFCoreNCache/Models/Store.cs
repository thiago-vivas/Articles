using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreNCache.Models
{
    [Serializable]
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public ICollection<Product> AvailableProducts { get; set; }
        public ICollection<Consumer> RegularConsumers { get; set; }
    }
}
