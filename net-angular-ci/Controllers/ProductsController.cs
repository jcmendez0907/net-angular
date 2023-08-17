using Microsoft.AspNetCore.Mvc;
using net_angular_ci.Models;
using net_angular_ci.Services;

namespace net_angular_ci.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Product> Get()
    {
        ProductService productService = new ProductService();
        var Products = productService.GetProducts();
        return Products;
    }
}

