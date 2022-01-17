using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        readonly SalesWebMVCContext _context;

        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
            => _context.Sellers.ToList();

        public void Insert(Seller obj)
        {
            _context.Sellers.Add(obj);
            _context.SaveChanges();
        }

        public void Remove(Seller obj)
        {
            _context.Sellers.Remove(obj);
            _context.SaveChanges();
        }
    }
}
