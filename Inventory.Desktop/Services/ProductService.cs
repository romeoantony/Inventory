using Inventory.Desktop.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace Inventory.Desktop.Services;

public class ProductService
{
    private readonly HttpClient _client = new()
    {
        BaseAddress = new Uri("https://localhost:7141/")
    };
    public async Task<List<Product>> GetProductsAsync() 
        => await _client.GetFromJsonAsync<List<Product>>("api/products") ?? [];
    
}