namespace SalesWebMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        { }

        public Department(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public void AddSeller(Seller seller)
            => Sellers.Add(seller);

        public void RemoveSeller(Seller seller)
            => Sellers.Remove(seller);

        public double TotalSales(DateTime initial, DateTime final)
            => Sellers.Sum(i => i.TotalSales(initial, final));
    }
}
