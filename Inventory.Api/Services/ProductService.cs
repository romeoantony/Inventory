using Inventory.Api.Data;
using Inventory.Api.DTOs;
using Inventory.Api.Interfaces;
using Inventory.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Api.Services;

public class ProductService : IProductService
{
    private readonly InventoryDbContext _context;
    public ProductService(InventoryDbContext context)
    {
        _context = context;
    }
    public async Task<List<ProductReadDto>> GetAllAsync()
    {
        return await _context.Products
            .Select(p => new ProductReadDto
            {
                Id = p.Id,
                Name = p.Name,
                Category = p.Category,
                Price = p.Price,
                Stock = p.Stock
            }).ToListAsync();
    }
    public async Task<ProductReadDto> CreateAsync(ProductCreateDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Category = dto.Category,
            Price = dto.Price,
            Stock = dto.Stock
        };

        _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return new ProductReadDto
        {
            Id = product.Id,
            Name = product.Name,
            Category = product.Category,
            Price = product.Price,
            Stock = product.Stock
        };
    }
}