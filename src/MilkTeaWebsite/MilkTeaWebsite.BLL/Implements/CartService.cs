using MilkTeaWebsite.BLL.Interfaces;
using MilkTeaWebsite.DAL.Interfaces;
using MilkTeaWebsite.Entity.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MilkTeaWebsite.BLL.Implements
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Cart?> GetActiveCartAsync(int customerId)
        {
            return await _unitOfWork.Carts.GetActiveCartByCustomerIdAsync(customerId);
        }

        public async Task<Cart> AddToCartAsync(int customerId, int productId, int quantity, string? size, string? topping, string? note)
        {
            // Get or create active cart
            var cart = await _unitOfWork.Carts.GetActiveCartByCustomerIdAsync(customerId);
            if (cart == null)
            {
                cart = new Cart
                {
                    CustomerId = customerId,
                    CreatedAt = DateTime.UtcNow,
                    ExpiresAt = DateTime.UtcNow.AddDays(7) // Cart expires in 7 days
                };
                await _unitOfWork.Carts.AddAsync(cart);
                await _unitOfWork.SaveChangesAsync();
            }

            // Get product
            var product = await _unitOfWork.Products.GetByIdAsync(productId);
            if (product == null || !product.IsAvailable)
                throw new Exception("Product not available");

            // Determine base price from size
            size = size?.ToUpper() ?? "M"; // Default to M if not specified
            decimal basePrice = size switch
            {
                "S" => product.PriceS,
                "M" => product.PriceM,
                "L" => product.PriceL,
                _ => product.PriceM
            };

            // Calculate topping price
            decimal toppingPrice = 0;
            if (!string.IsNullOrWhiteSpace(topping))
            {
                var toppingNames = topping.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(t => t.Trim())
                    .Where(t => !string.IsNullOrWhiteSpace(t))
                    .ToList();

                if (toppingNames.Any())
                {
                    var allToppings = await _unitOfWork.Toppings.GetAllAsync();
                    foreach (var toppingName in toppingNames)
                    {
                        var toppingEntity = allToppings.FirstOrDefault(t => 
                            t.ToppingName.Equals(toppingName, StringComparison.OrdinalIgnoreCase) && 
                            t.IsAvailable);
                        if (toppingEntity != null)
                        {
                            toppingPrice += toppingEntity.ToppingPrice;
                        }
                    }
                }
            }

            // Calculate total price
            decimal totalPrice = (basePrice + toppingPrice) * quantity;

            // Check if same item exists in cart
            var existingItem = cart.CartItems.FirstOrDefault(ci => 
                ci.ProductId == productId && 
                ci.Size == size && 
                ci.SelectedToppings == topping);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                existingItem.TotalPrice = (existingItem.BasePrice + existingItem.ToppingPrice) * existingItem.Quantity;
                existingItem.UpdatedAt = DateTime.UtcNow;
                _unitOfWork.CartItems.Update(existingItem);
            }
            else
            {
                var cartItem = new CartItem
                {
                    CartId = cart.Id,
                    ProductId = productId,
                    Quantity = quantity,
                    Size = size,
                    BasePrice = basePrice,
                    ToppingPrice = toppingPrice,
                    TotalPrice = totalPrice,
                    SelectedToppings = topping,
                    Note = note,
                    CreatedAt = DateTime.UtcNow
                };
                await _unitOfWork.CartItems.AddAsync(cartItem);
            }

            await _unitOfWork.SaveChangesAsync();
            return await _unitOfWork.Carts.GetCartWithItemsAsync(cart.Id) ?? cart;
        }

        public async Task UpdateCartItemAsync(int cartItemId, int quantity)
        {
            var cartItem = await _unitOfWork.CartItems.GetByIdAsync(cartItemId);
            if (cartItem == null)
                throw new Exception("Cart item not found");

            if (quantity <= 0)
            {
                await RemoveFromCartAsync(cartItemId);
                return;
            }

            cartItem.Quantity = quantity;
            // CRITICAL: Recalculate TotalPrice when quantity changes
            cartItem.TotalPrice = (cartItem.BasePrice + cartItem.ToppingPrice) * quantity;
            cartItem.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.CartItems.Update(cartItem);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveFromCartAsync(int cartItemId)
        {
            var cartItem = await _unitOfWork.CartItems.GetByIdAsync(cartItemId);
            if (cartItem == null)
                throw new Exception("Cart item not found");

            cartItem.IsDeleted = true;
            cartItem.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.CartItems.Update(cartItem);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task ClearCartAsync(int cartId)
        {
            var cartItems = await _unitOfWork.CartItems.GetCartItemsByCartIdAsync(cartId);
            foreach (var item in cartItems)
            {
                item.IsDeleted = true;
                item.UpdatedAt = DateTime.UtcNow;
            }
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<decimal> GetCartTotalAsync(int cartId)
        {
            var cartItems = await _unitOfWork.CartItems.GetCartItemsByCartIdAsync(cartId);
            return cartItems.Sum(ci => ci.TotalPrice);
        }
    }
}
