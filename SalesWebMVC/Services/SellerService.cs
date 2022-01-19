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

        public async Task<List<Seller>> FindAllAsync()
            => await _context.Sellers.ToListAsync();

        public async Task InsertAsync(Seller obj)
        {
            _context.Sellers.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Seller obj)
        {
            if (obj == null)
                return;

            try
            {
                _context.Sellers.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                throw new IntegratyException(e.Message);
            }
        }

        public async void Remove(int Id)
        {
            var seller = await FindByIdAsync(Id);
            await Remove(seller);
        }

        public async Task<Seller> FindByIdAsync(int Id)
            => await _context.Sellers.Include(i => i.Department).FirstOrDefaultAsync(i => i.Id == Id);

        public async Task UpdateAsync(Seller seller)
        {
            if (!_context.Sellers.Any(i => i.Id == seller.Id))
            {
                throw new NotFoundException("Id not found!");
            }

            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
   
        }
    }
}
