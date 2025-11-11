using MilkTeaWebsite.Entity.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MilkTeaWebsite.BLL.Interfaces
{
    public interface ICartService
    {
        Task<Cart?> GetActiveCartAsync(int customerId);
        Task<Cart> AddToCartAsync(int customerId, int productId, int quantity, string? size, string? topping, string? note);
        Task UpdateCartItemAsync(int cartItemId, int quantity);
        Task RemoveFromCartAsync(int cartItemId);
        Task ClearCartAsync(int cartId);
        Task<decimal> GetCartTotalAsync(int cartId);
    }
}
