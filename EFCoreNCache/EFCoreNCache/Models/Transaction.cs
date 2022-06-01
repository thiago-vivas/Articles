using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreNCache.Models
{
    [Serializable]
   public class Transaction
    {
        public int Id { get; set; }

        public Consumer Consumer { get; set; }
        public int ConsumerId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
