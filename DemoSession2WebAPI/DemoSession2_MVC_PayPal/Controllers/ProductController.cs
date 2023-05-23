using DemoSession2_MVC_PayPal.Service;
using Microsoft.AspNetCore.Mvc;

namespace DemoSession2_MVC_PayPal.Controllers;
[Route("product")]
public class ProductController : Controller
{
    private ProductService productService;
    public ProductController(ProductService _productService)
    {
        productService = _productService;
    }
    [Route("~/")]
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        ViewBag.product = productService.GetListProduct();
        return View();
    }
}
