using Inventory.Desktop.Models;
using Inventory.Desktop.Services;
using System.Collections.ObjectModel;

namespace Inventory.Desktop.ViewModels;

public class ProductViewModel : BaseViewModel
{
    private readonly ProductService _service = new();

    public ObservableCollection<Product> Products { get; } = new();

    public async Task LoadAsync()
    {
        Products.Clear();
        
        var items = await _service.GetProductsAsync();

        foreach (var item in items)
            Products.Add(item);
    }
}