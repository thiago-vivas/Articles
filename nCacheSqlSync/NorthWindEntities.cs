using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nCacheSqlSync
{
    public class NorthWindEntities
    {
        [Serializable]
        public class Company
        {
            public string Id { get; set; }
            public string ExternalId { get; set; }
            public string Name { get; set; }
            public Contact Contact { get; set; }
            public Address Address { get; set; }
            public string Phone { get; set; }
            public string Fax { get; set; }
        }

        [Serializable]
        public class Address
        {
            public string Line1 { get; set; }
            public string Line2 { get; set; }
            public string City { get; set; }
            public string Region { get; set; }
            public string PostalCode { get; set; }
            public string Country { get; set; }
        }

        [Serializable]
        public class Contact
        {
            public string Name { get; set; }
            public string Title { get; set; }
        }

        [Serializable]
        public class Category
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        [Serializable]
        public class Order
        {
            public int OrderID { get; set; }
            public string CustomerID { get; set; }
            public int EmployeeID { get; set; }
            public DateTime OrderDate { get; set; }
            public DateTime RequiredDate { get; set; }
            public DateTime ShippedDate { get; set; }
            public int ShipVia { get; set; }
            public decimal Freight { get; set; }
            public string ShipName { get; set; }
            public string ShipAddress { get; set; }
            public string ShipCity { get; set; }
            public string ShipRegion { get; set; }
            public string ShipPostalCode { get; set; }
            public string ShipCountry { get; set; }
        }

        [Serializable]
        public class Product
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public int SupplierID { get; set; }
            public int CategoryID { get; set; }
            public string QuantityPerUnit { get; set; }
            public decimal UnitPrice { get; set; }
            public short UnitsInStock { get; set; }
            public short UnitsOnOrder { get; set; }
            public short ReorderLevel { get; set; }
            public bool Discontinued { get; set; }

        }

        [Serializable]
        public class Supplier
        {
            public string Id { get; set; }
            public Contact Contact { get; set; }
            public string Name { get; set; }
            public Address Address { get; set; }
            public string Phone { get; set; }
            public string Fax { get; set; }
            public string HomePage { get; set; }
        }

        [Serializable]
        public class Employee
        {
            public string Id { get; set; }
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string Title { get; set; }
            public Address Address { get; set; }
            public DateTime HiredAt { get; set; }
            public DateTime Birthday { get; set; }
            public string HomePhone { get; set; }
            public string Extension { get; set; }
            public string ReportsTo { get; set; }
            public List<string> Notes { get; set; }

            public List<string> Territories { get; set; }
        }

        [Serializable]
        public class Region
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public List<Territory> Territories { get; set; }
        }

        [Serializable]
        public class Territory
        {
            public string Code { get; set; }
            public string Name { get; set; }
        }

        [Serializable]
        public class Shipper
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
        }
    }
}
