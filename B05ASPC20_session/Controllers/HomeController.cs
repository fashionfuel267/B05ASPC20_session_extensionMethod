using B05ASPC20_session.Models;
using B05ASPC20_session.SessionUtility;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace B05ASPC20_session.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SHoppingCart sHoppingCart;
        public HomeController(ILogger<HomeController> logger, SHoppingCart sHoppingCart)
        {
            _logger = logger;
            this.sHoppingCart = sHoppingCart;
        }

        public IActionResult Index()
        {
         string sessionId=   HttpContext.Session.Id ;
            ViewBag.SessionId = sessionId ;
            List<Cart> listcart =new List<Cart>();
            if (HttpContext.Session.GetObjInSession<Cart>("cart")!=null)
            {
                  listcart = HttpContext.Session.GetObjInSession<Cart>("cart");
               
            }
            return View(listcart);
        }

        public IActionResult AddToCart(string? name, int? Qty)
        {
            sHoppingCart.AddToCart(name ?? "Not assigned", Qty ?? 1);
            HttpContext.Session.SetObjInSession("cart", sHoppingCart.CartItems);
           return RedirectToAction("Index");
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
}
