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

            // Calculate topping price (includes per-topping quantity)
            decimal toppingPrice = 0;
            if (!string.IsNullOrWhiteSpace(topping))
            {
                var toppingSelections = topping
                    .Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(t => ParseToppingSelection(t))
                    .Where(t => t.HasValue)
                    .Select(t => t!.Value)
                    .ToList();

                if (toppingSelections.Any())
                {
                    var allToppings = await _unitOfWork.Toppings.GetAllAsync();
                    foreach (var selection in toppingSelections)
                    {
                        var toppingEntity = allToppings.FirstOrDefault(t =>
                            t.ToppingName.Equals(selection.Name, StringComparison.OrdinalIgnoreCase) &&
                            t.IsAvailable);

                        if (toppingEntity != null)
                        {
                            toppingPrice += toppingEntity.ToppingPrice * selection.Quantity;
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
            cartItem.UpdatedAt = DateTime.UtcNow;
            cartItem.TotalPrice = (cartItem.BasePrice + cartItem.ToppingPrice) * cartItem.Quantity;
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

        private static (string Name, int Quantity)? ParseToppingSelection(string? rawValue)
        {
            if (string.IsNullOrWhiteSpace(rawValue))
            {
                return null;
            }

            var trimmed = rawValue.Trim();
            if (trimmed.Length == 0)
            {
                return null;
            }

            var lastXIndex = trimmed.LastIndexOf('x');
            var quantity = 1;
            var name = trimmed;

            if (lastXIndex > 0 && lastXIndex + 1 < trimmed.Length)
            {
                var quantityPart = trimmed[(lastXIndex + 1)..].Trim();
                if (int.TryParse(quantityPart, out var parsedQty) && parsedQty > 0)
                {
                    quantity = parsedQty;
                    name = trimmed[..lastXIndex].Trim();
                }
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            return (name, quantity);
        }
    }
}
