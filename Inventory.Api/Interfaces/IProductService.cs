using Inventory.Api.DTOs;

namespace Inventory.Api.Interfaces;

public interface IProductService
{
    Task<List<ProductReadDto>> GetAllAsync();
    Task<ProductReadDto> CreateAsync(ProductCreateDto dto);
}