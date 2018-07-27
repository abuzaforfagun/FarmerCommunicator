using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmmerCommunicatorFinal.Models;
using FarmmerCommunicatorFinal.ViewModels;

namespace FarmmerCommunicatorFinal.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var viewModel = new HomeViewModel();
            viewModel.Categories = _context.Categories.ToList();
            return View(viewModel);
        }
        
    }
}