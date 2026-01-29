namespace Inventory.Api.Controllers;

using Inventory.Api.DTOs;
using Inventory.Api.Interfaces;
using Inventory.Api.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;
    public ProductsController(IProductService service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<IActionResult> GetProductsAsync() 
        => Ok(await _service.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(ProductCreateDto dto) 
        => Ok(await _service.CreateAsync(dto));
}