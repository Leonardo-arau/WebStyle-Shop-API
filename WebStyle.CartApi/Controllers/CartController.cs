using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStyle.CartApi.DTOs;
using WebStyle.CartApi.Repositories;

namespace WebStyle.CartApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly ICartRepository _repository;

    public CartController(ICartRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("getcart/{id}")]
    public async Task<ActionResult<CartDTO>> GetByUserId(string userId)
    {
        var cartDto = await _repository.GetCartByUserIdAsync(userId);

        if (cartDto is null)
            return NotFound();

        return Ok(cartDto);
        
    }

    [HttpPost("addcart")]
    public async Task<ActionResult<CartDTO>> AddCart(CartDTO cartDto)
    {
        var cart = await _repository.UpdateCartAsync(cartDto);

        if (cart is null)
            return NotFound();

        return Ok(cart);

    }

    [HttpPut("updatecart")]
    public async Task<ActionResult<CartDTO>> UpdateCart(CartDTO cartDto)
    {
        var cart = await _repository.UpdateCartAsync(cartDto);
        if (cart == null) return NotFound();
        return Ok(cart);
    }

    [HttpDelete("deletecart/{id}")]
    public async Task<ActionResult<bool>> DeleteCart(int id)
    {
        var status =  await _repository.DeleteItemCartAsync(id);

        if(!status)
            return BadRequest();

        return Ok(status);
    }
}
