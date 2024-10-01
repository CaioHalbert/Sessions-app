using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Sessions_app.Dtos;
using Sessions_app.Models;
using Sessions_app.Repositorys.Iterfaces;
using System.Diagnostics;

namespace Sessions_app.Controllers
{
    public class HomeController : Controller
    {
        public const string SessionName = "_Nome";
        public const string SessionKey = "_isAuth";

        private readonly ILogger<HomeController> _logger;
        private readonly IUserAuth userAuth;

        public HomeController(ILogger<HomeController> logger, IUserAuth repository)
        {
            userAuth = repository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.SessionName = HttpContext.Session.GetString(SessionName);
            ViewBag.SessionKey = HttpContext.Session.GetInt32(SessionKey);

            return View();
        }
        public async Task<IActionResult> Login(UserLoginDto request) 
        {
            try
            {
                var auth = await userAuth.GetUserByEmail(request);
                if (auth == null) 
                {
                    return RedirectToAction("Error");
                }

                HttpContext.Session.SetString(SessionName, auth.Email);
                HttpContext.Session.SetInt32(SessionKey, 1);

                return RedirectToAction("Index");
            }
            catch (Exception ex) 
            {
                return RedirectToAction("Error");
            }
        }

        public IActionResult RegisterPage() { return View(); }

        public async Task<IActionResult> Register(UserRegisterDto request) 
        {
            try
            {
                var response = await userAuth.CreateUser(request);
                if (response == null)
                {
                    return RedirectToAction("Error");
                }
                HttpContext.Session.SetString(SessionName, response.Email);
                HttpContext.Session.SetInt32(SessionKey, 1);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
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
