using Microsoft.EntityFrameworkCore;
using MilkTeaWebsite.DAL.Context;
using MilkTeaWebsite.DAL.Interfaces;
using MilkTeaWebsite.Entity.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilkTeaWebsite.DAL.Implements
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Cart?> GetActiveCartByCustomerIdAsync(int customerId)
        {
            var cart = await _dbSet
                .Include(c => c.CartItems.Where(ci => !ci.IsDeleted))
                    .ThenInclude(ci => ci.Product)
                .Where(c => c.CustomerId == customerId 
                    && !c.IsDeleted 
                    && (c.ExpiresAt == null || c.ExpiresAt > DateTime.UtcNow))
                .FirstOrDefaultAsync();
            
            return cart;
        }

        public async Task<Cart?> GetCartWithItemsAsync(int cartId)
        {
            return await _dbSet
                .Include(c => c.CartItems.Where(ci => !ci.IsDeleted))
                    .ThenInclude(ci => ci.Product)
                        .ThenInclude(p => p.Category)
                .FirstOrDefaultAsync(c => c.Id == cartId && !c.IsDeleted);
        }
    }
}
