using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_prosto_hz
{

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public int Quantity { get; set; }
        public double CostPrice { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }

    public class Manager
    {
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }

    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }

    public class Sale
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int ManagerId { get; set; }
        public int CustomerId { get; set; }
        public int QuantitySold { get; set; }
        public double UnitPrice { get; set; }
        public DateTime SaleDate { get; set; }

        public Product Product { get; set; }
        public Manager Manager { get; set; }
        public Customer Customer { get; set; }
    }

}
