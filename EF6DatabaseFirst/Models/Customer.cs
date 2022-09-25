﻿using System;
using System.Collections.Generic;

namespace EF6DatabaseFirst.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
            CustomerTypes = new HashSet<CustomerDemographic>();
        }

        public string CustomerId { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<CustomerDemographic> CustomerTypes { get; set; }
    }
}
