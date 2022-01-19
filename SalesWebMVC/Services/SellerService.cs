using SalesWebMVC.Data;
using SalesWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Exceptions;

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
            if (obj == null)
                return;

            _context.Sellers.Remove(obj);
            _context.SaveChanges();
        }

        public void Remove(int Id)
        {
            var seller = FindById(Id);
            Remove(seller);
        }

        public Seller FindById(int Id)
            => _context.Sellers.Include(i => i.Department).FirstOrDefault(i => i.Id == Id);

        public void Update(Seller seller)
        {
            if (!_context.Sellers.Any(i => i.Id == seller.Id))
            {
                throw new NotFoundException("Id not found!");
            }

            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
   
        }
    }
}
