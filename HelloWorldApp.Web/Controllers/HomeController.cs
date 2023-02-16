using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HelloWorldApp.Web.Models;

namespace HelloWorldApp.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index() 
    {
        MyMath m = new MyMath() { N1 = 10, N2 = 5, Result = 15 };
        return View(m); 
    }
        [HttpPost]
        public IActionResult Index(MyMath m) 
    {
        ModelState.Clear(); 
        m.Result = m.N1 + m.N2; 
        return View(m);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
