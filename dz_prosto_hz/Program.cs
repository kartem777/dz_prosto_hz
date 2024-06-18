using Microsoft.EntityFrameworkCore;

namespace dz_prosto_hz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var manager1 = new Manager { ManagerName = "John Doe" };
                var manager2 = new Manager { ManagerName = "Jane Smith" };

                var customer1 = new Customer { CustomerName = "Company A" };
                var customer2 = new Customer { CustomerName = "Company B" };

                var product1 = new Product
                {
                    ProductName = "Pen",
                    ProductType = "Stationery",
                    Quantity = 100,
                    CostPrice = 1.57
                };
                var product2 = new Product
                {
                    ProductName = "Notebook",
                    ProductType = "Stationery",
                    Quantity = 200,
                    CostPrice = 2.75
                };

                db.Managers.AddRange(manager1, manager2);
                db.Customers.AddRange(customer1, customer2);
                db.Products.AddRange(product1, product2);

                db.SaveChanges();

                var sale1 = new Sale
                {
                    ProductId = product1.ProductId,
                    ManagerId = manager1.ManagerId,
                    CustomerId = customer1.CustomerId,
                    QuantitySold = 10,
                    UnitPrice = 2.45,
                    SaleDate = DateTime.Now
                };
                var sale2 = new Sale
                {
                    ProductId = product2.ProductId,
                    ManagerId = manager2.ManagerId,
                    CustomerId = customer2.CustomerId,
                    QuantitySold = 15,
                    UnitPrice = 2.64,
                    SaleDate = DateTime.Now
                };

                db.Sales.AddRange(sale1, sale2);
                db.SaveChanges();


                var sales = db.Sales
                    .Include(s => s.Product)
                    .Include(s => s.Manager)
                    .Include(s => s.Customer)
                    .ToList();

                foreach (var sale in sales)
                {
                    Console.WriteLine($"{sale.SaleDate}: {sale.Manager.ManagerName} sold {sale.QuantitySold} {sale.Product.ProductName}(s) to {sale.Customer.CustomerName} at {sale.UnitPrice} each.");
                }
            }
        }
    }
}
