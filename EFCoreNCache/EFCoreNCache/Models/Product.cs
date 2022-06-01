using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreNCache.Models
{
    [Serializable]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Store Store { get; set; }
        public int? StoreId { get; set; }
    }
}
