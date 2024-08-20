using ShoppingCartService.Domain.Entities;

namespace ShoppingCartService.Domain.Interfaces;

public interface IShoppingCartService
{
    Task<IEnumerable<CartItem>> GetCartItemsAsync();
    Task AddCartItemAsync(CartItem item);
    Task RemoveCartItemAsync(int id);
    Task UpdateCartItemAsync(CartItem item);
}