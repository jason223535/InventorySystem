using InventorySystem.Models;
using InventorySystem.Repositories;
using InventorySystem.Utils;

namespace InventorySystem.Services;

public class InventoryService
{
    private readonly IProductRepository _productRepository;

    public InventoryService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    //使用EmailNotifier
    INotifier emailNotifier = new EmailNotifier();
    NotificationService emailService = new NotificationService(emailNotifier);
    
    
    
    public List<Product> GetAllProducts()
    {
        try
        {
            //呼叫介面，而非實作(DI)
            List<Product> products = _productRepository.GetAllProducts();
            if (!products.Any())
            {
                Console.WriteLine("No products found");
            }
            
            EmailNotifier emailNotifier = new EmailNotifier();
            NotificationService emailService = new NotificationService(emailNotifier);
            emailService.NotifyUser("Jason", "查詢完成");
            return products;
        }
        catch (Exception e)
        {
            Console.WriteLine($"讀取產品列表失敗: {e.Message}");
            return new List<Product>();
        }
    }
}