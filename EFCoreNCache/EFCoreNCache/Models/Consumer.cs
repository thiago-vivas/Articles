using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreNCache.Models
{
    [Serializable]
    public class Consumer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Store FavouriteStore { get; set; }
        public int? FavouriteStoreId { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
