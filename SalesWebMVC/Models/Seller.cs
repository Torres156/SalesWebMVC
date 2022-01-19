using System.ComponentModel.DataAnnotations;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size be should be between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthData { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        [Range(100,50000, ErrorMessage = "{0} must be from {1} to {2}")]
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
