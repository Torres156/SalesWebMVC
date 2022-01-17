using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private SalesWebMVCContext _context;

        public SeedingService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public void Seed()
        {

            _context.Database.EnsureCreated();


            if (_context.Department.Any() ||
                _context.Sellers.Any() ||
                _context.Sales.Any())
                return; // DB has been seeded

            var departments = new List<Department>();
            departments.Add(new Department(1, "Computers"));
            departments.Add(new Department(2, "Electronics"));
            departments.Add(new Department(3, "Fashion"));
            departments.Add(new Department(4, "Books"));

            var sellers = new List<Seller>();
            sellers.Add(new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000, departments[0]));
            sellers.Add(new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500, departments[1]));
            sellers.Add(new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200, departments[0]));
            sellers.Add(new Seller(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000, departments[3]));
            sellers.Add(new Seller(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000, departments[2]));
            sellers.Add(new Seller(6, "Alex Pink", "alexp@gmail.com", new DateTime(1997, 3, 4), 3000, departments[1]));

            var sales = new List<SalesRecord>();
            sales.Add(new SalesRecord(1, new DateTime(2018, 09, 25), 11000, SaleStatus.Billed, sellers[0]));
            sales.Add(new SalesRecord(2, new DateTime(2018, 09, 26), 11000, SaleStatus.Billed, sellers[3]));
            sales.Add(new SalesRecord(3, new DateTime(2018, 09, 27), 11000, SaleStatus.Billed, sellers[1]));
            sales.Add(new SalesRecord(4, new DateTime(2018, 09, 28), 11000, SaleStatus.Billed, sellers[1]));
            sales.Add(new SalesRecord(5, new DateTime(2018, 09, 29), 11000, SaleStatus.Billed, sellers[2]));
            sales.Add(new SalesRecord(6, new DateTime(2018, 10, 2), 11000, SaleStatus.Billed, sellers[5]));
            sales.Add(new SalesRecord(7, new DateTime(2018, 10, 4), 11000, SaleStatus.Billed, sellers[0]));

            _context.AddRange(departments);
            _context.AddRange(sellers);
            _context.AddRange(sales);

            _context.SaveChanges();
        }
    }
}
