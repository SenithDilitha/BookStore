using Microsoft.AspNetCore.Mvc;
using ShoppingCartService.Domain.Entities;
using ShoppingCartService.Domain.Interfaces;

namespace ShoppingCartService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShoppingCartController : ControllerBase
{
    private readonly IShoppingCartService _shoppingCartService;

    public ShoppingCartController(IShoppingCartService shoppingCartService)
    {
        _shoppingCartService = shoppingCartService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems()
    {
        var cartItems = await _shoppingCartService.GetCartItemsAsync();
        return Ok(cartItems);
    }

    [HttpPost]
    public async Task<ActionResult> AddCartItem([FromBody] CartItem item)
    {
        await _shoppingCartService.AddCartItemAsync(item);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> RemoveCartItem(int id)
    {
        await _shoppingCartService.RemoveCartItemAsync(id);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCartItem(int id, [FromBody] CartItem item)
    {
        item.Id = id;
        await _shoppingCartService.UpdateCartItemAsync(item);
        return Ok();
    }
}