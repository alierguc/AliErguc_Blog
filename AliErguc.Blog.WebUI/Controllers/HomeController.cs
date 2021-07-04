using AliErguc.Blog.Business.Interfaces;
using AliErguc.Blog.WebUI.ApiServices.Interfaces;
using AliErguc.Blog.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AliErguc.Blog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogApiServices _blogApiServices;

        public HomeController(ILogger<HomeController> logger,IBlogApiServices blogApiServices)
        {
            _logger = logger;
            _blogApiServices = blogApiServices;
        }

        public async Task<IActionResult> BlogDetail(int id)
        {
            return View(await _blogApiServices.GetByIdAsync(id));
        }

        public async Task<IActionResult> Index()
        {
            return View(await _blogApiServices.GetAllAsync());
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
