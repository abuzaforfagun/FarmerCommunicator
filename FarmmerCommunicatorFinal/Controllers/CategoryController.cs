using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmmerCommunicatorFinal.Models;
using FarmmerCommunicatorFinal.ViewModels;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace FarmmerCommunicatorFinal.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext _context;

        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Category


        public ActionResult Index(int CatId, string message = null)
        {
            var products = new SingleCategoryProductListViewModel();
            products.Products = _context.Products.Include(p => p.Farmer).Where(p => p.CategoryId == CatId).Where(p => p.IsDisplay == 0).ToList();
            products.Category = _context.Categories.SingleOrDefault(c => c.Id == CatId);
            products.Message = message;
            return View(products);
        }

        public ActionResult DealRequest(int Id)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            var deal = new Deal();
            var product = _context.Products.Single(p => p.Id == Id);
            var buyerId = User.Identity.GetUserId();
            var buyer = _context.Users.Single(u => u.Id == buyerId);

            deal.FarmerId = product.FarmerId;
            deal.Product = product;
            deal.BuyerId = buyerId;
            deal.Buyer = buyer;
            deal.Status = "Waiting";
            deal.Date = DateTime.Now;
            _context.Deals.Add(deal);
            _context.SaveChanges();
            //ViewBag.Message = "Deal request sent";
            TempData["Message"] = "Deal request sent";
            return RedirectToAction("Index", new { @CatId = product.CategoryId });
            
        }
    }
}