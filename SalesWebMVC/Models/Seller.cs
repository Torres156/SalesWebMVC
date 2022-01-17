﻿namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthData { get; set; }
        public double BaseSalary { get; set; }        
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        { }

        public Seller(int id, string name, string email, DateTime birthData, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthData = birthData;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)        
           => Sales.Add(sr);
        

        public void RemoveSales(SalesRecord sr)
            => Sales.Remove(sr);

        public double TotalSales(DateTime initial, DateTime final)
            => Sales.Where(i => i.Date >= initial && i.Date <= final).Sum(i => i.Amount);
    }
}