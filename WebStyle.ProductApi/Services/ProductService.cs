﻿using AutoMapper;
using WebStyle.ProductApi.DTOs;
using WebStyle.ProductApi.Models;
using WebStyle.ProductApi.Repositories;

namespace WebStyle.ProductApi.Services;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private IProductRepository _productRepository;

    public ProductService(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var productsEntity =  await _productRepository.GetAll();
        return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
    }
    public async Task<ProductDTO> GetProductById(int id)
    {
        var productsEntity = await _productRepository.GetById(id);
        return _mapper.Map<ProductDTO>(productsEntity);
    }
    public async Task AddProduct(ProductDTO productDto)
    {
        var productEntity = _mapper.Map<Product>(productDto);
        await _productRepository.Create(productEntity);
        productDto.Id = productEntity.Id;
    }
    public async Task UpdateProduct(ProductDTO productDto)
    {
        var categoryEntity = _mapper.Map<Product>(productDto);
        await _productRepository.Update(categoryEntity);
    }
    public async Task RemoveProduct(int id)
    {
        var productEntity = await _productRepository.GetById(id);
        await _productRepository.Delete(productEntity.Id);
    }
}
