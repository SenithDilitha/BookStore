using System.Text.Json;
using ShoppingCartService.Domain.Entities;
using ShoppingCartService.Domain.Interfaces;

namespace ShoppingCartService.Infrastructure.Data;

public class CartItemRepository : ICartItemRepository
{
    private readonly string _filePath = "D:\\Interviews\\Assignments\\BookStoreBackEnd\\ShoppingCartService\\ShoppingCartService.Infrastructure\\Data\\CartItems.json";

    public async Task<IEnumerable<CartItem>> GetCartItemsAsync()
    {
        return await ReadCartItemsFromFileAsync();
    }

    public async Task AddCartItemAsync(CartItem item)
    {
        var cartItems = await ReadCartItemsFromFileAsync();
        var list = cartItems.ToList();
        list.Add(item);
        await WriteCartItemsToFileAsync(list);
    }

    public async Task RemoveCartItemAsync(int id)
    {
        var cartItems = await ReadCartItemsFromFileAsync();
        var list = cartItems.Where(i => i.Id != id).ToList();
        await WriteCartItemsToFileAsync(list);
    }

    public async Task UpdateCartItemAsync(CartItem item)
    {
        var cartItems = await ReadCartItemsFromFileAsync();
        var list = cartItems.ToList();
        var index = list.FindIndex(i => i.Id == item.Id);
        if (index >= 0)
        {
            list[index] = item;
            await WriteCartItemsToFileAsync(list);
        }
    }

    private async Task<IEnumerable<CartItem>> ReadCartItemsFromFileAsync()
    {
        if (!File.Exists(_filePath)) return Enumerable.Empty<CartItem>();

        var json = await File.ReadAllTextAsync(_filePath);
        return JsonSerializer.Deserialize<IEnumerable<CartItem>>(json) ?? Enumerable.Empty<CartItem>();
    }

    private async Task WriteCartItemsToFileAsync(IEnumerable<CartItem> cartItems)
    {
        var json = JsonSerializer.Serialize(cartItems, new JsonSerializerOptions {WriteIndented = true});
        await File.WriteAllTextAsync(_filePath, json);
    }
}