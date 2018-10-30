using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmmerCommunicatorFinal.Models;
using FarmmerCommunicatorFinal.ViewModels;
using System.Security.Principal;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.IO;

namespace FarmmerCommunicatorFinal.Controllers
{
    [Authorize(Roles = "Farmer")]
    public class FarmerController : Controller
    {
        ApplicationDbContext _context;
        // GET: Farmer

        public FarmerController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Approve(int Id)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            var deal = _context.Deals.Single(d => d.Id == Id);
            deal.Status = "Approved";
            _context.SaveChanges();
            return RedirectToAction("Index", new { message = "Deal approved" });
        }

        public ActionResult DeleteDeal(int Id)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            var deal = _context.Deals.Single(d => d.Id == Id);
            _context.Deals.Remove(deal);
            _context.SaveChanges();
            return RedirectToAction("Index", new { message = "Deal Request Deleted" });
        }
        

        public ActionResult Index(string message = "")
        {
            var viewModel = new FarmerDashboardViewModel();

            viewModel.Message = message;

            var UserId = User.Identity.GetUserId();
            viewModel.AllProducts = _context.Products.Include(p=>p.Category).
                Where(p => p.FarmerId == UserId).ToList();

            viewModel.WaitingForApproval = _context.Deals.Include(d=>d.Product).Include(p => p.Product.Category).
                Include(d => d.Buyer).Where(d => d.Status == "Waiting").Where(d=>d.FarmerId==UserId).ToList();

            viewModel.CurrentDeals = _context.Deals.Include(d => d.Product).
                Include(p=>p.Product.Category).Include(d=>d.Buyer).Where(d => d.Status == "Approved").ToList();


            return View(viewModel);
        }
        public ActionResult Add()
        {
            var viewModel = new AddProductViewModel();
            viewModel.Categories = _context.Categories.ToList();

            return View(viewModel);
        }

        public ActionResult Unpublish(int Id)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            var product = _context.Products.Single(p => p.Id == Id);
            product.IsDisplay = 1;
            _context.SaveChanges();
            return RedirectToAction("Index", new { message = "Product unpublished" });
        }

        public ActionResult Publish(int Id)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            var product = _context.Products.Single(p => p.Id == Id);
            product.IsDisplay = 0;
            _context.SaveChanges();
            return RedirectToAction("Index", new { message = "Product Published" });
        }

        public ActionResult Save(AddProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {

                var id = User.Identity.GetUserId();
                productViewModel.Product.FarmerId = id;
                productViewModel.Product.AddedDate = DateTime.Now;

                var file = productViewModel.Image;
                if (file != null)
                {
                    var unique = DateTime.Now.Ticks;
                    string pic = unique+"_" +System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Content/Images/Products"), pic);
                    file.SaveAs(path);
                    productViewModel.Product.ImageUrl = "Content/Images/Products/"+pic;
                }

                _context.Products.Add(productViewModel.Product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", new { message = "New product added" });
            
        }

        public ActionResult Rate(int Id, string message=null)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            var deal = _context.Deals.Include(d => d.Product).Include(p=>p.Product.Category).Include(p=>p.Buyer).Single(d => d.Id == Id);
            var rate = new Rate();
            rate.Deal = deal;
            var viewModel = new RateUserViewModel();
            viewModel.Rate = rate;
            viewModel.Rate.Deal = deal;
            viewModel.Rate.DealId = deal.Id;
            viewModel.RateValues = new List<string>() { "1", "2", "3", "4", "5" };
            viewModel.Message = message;

            return View(viewModel);
        }

        public ActionResult SaveRate(RateUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            viewModel.Rate.Deal = _context.Deals.Single(d => d.Id == viewModel.Rate.DealId);
            viewModel.Rate.UserId = viewModel.Rate.Deal.BuyerId;
            var _rate = _context.Rates.SingleOrDefault(r => r.UserId == viewModel.Rate.Deal.BuyerId && r.DealId == viewModel.Rate.DealId);
            if(_rate == null)
            {
                _context.Rates.Add(viewModel.Rate);
                _context.SaveChanges();
            }
            else
            {
                _rate.RateValue = viewModel.Rate.RateValue;
                _context.SaveChanges();
            }

            return RedirectToAction("Index", new { message = "Rate added" });
        }
        [AllowAnonymous]
        public ActionResult Profile(string id)
        {

            var products = _context.Products.Where(p => p.FarmerId == id).ToList();
            var farmer = _context.Users.Single(u => u.Id == id);
            FarmerProfile profile = new FarmerProfile();
            profile.Products = products;
            profile.Farmer = farmer;

            return View(profile);
        }
    }
}