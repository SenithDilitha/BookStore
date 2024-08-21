using ShoppingCartService.Domain.Entities;
using ShoppingCartService.Domain.Interfaces;

namespace ShoppingCartService.Application.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly ICartItemRepository _cartItemRepository;

    public ShoppingCartService(ICartItemRepository cartItemRepository)
    {
        _cartItemRepository = cartItemRepository;
    }

    public Task<IEnumerable<CartItem>> GetCartItemsAsync()
    {
        return _cartItemRepository.GetCartItemsAsync();
    }

    public Task AddCartItemAsync(CartItem item)
    {
        return _cartItemRepository.AddCartItemAsync(item);
    }

    public Task RemoveCartItemAsync(int id)
    {
        return _cartItemRepository.RemoveCartItemAsync(id);
    }

    public Task UpdateCartItemAsync(CartItem item)
    {
        return _cartItemRepository.UpdateCartItemAsync(item);
    }
}