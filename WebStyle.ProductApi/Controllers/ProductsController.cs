﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStyle.ProductApi.DTOs;
using WebStyle.ProductApi.Models;
using WebStyle.ProductApi.Services;

namespace WebStyle.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> get()
        {
            var produtosDto = await _productService.GetProducts();
            if (produtosDto == null)
            {
                return NotFound("Products not found");
            }
            return Ok(produtosDto);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> get(int id)
        {
            var produtoDto = await _productService.GetProductById(id);
            if (produtoDto == null)
            {
                return NotFound("Product not found");
            }
            return Ok(produtoDto);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO produtoDto)
        {
            if (produtoDto == null)
                return BadRequest("Data Invalid");

            await _productService.AddProduct(produtoDto);

            return new CreatedAtRouteResult("GetProduct",
                new { id = produtoDto.Id }, produtoDto);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO produtoDto)
        {
            if (id != produtoDto.Id)
            {
                return BadRequest("Data invalid");
            }

            if (produtoDto == null)
                return BadRequest("Data invalid");

            await _productService.UpdateProduct(produtoDto);

            return Ok(produtoDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var produtoDto = await _productService.GetProductById(id);

            if (produtoDto == null)
            {
                return NotFound("Product not found");
            }

            await _productService.RemoveProduct(id);

            return Ok(produtoDto);

        }

    }
}