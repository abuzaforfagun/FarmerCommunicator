using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmmerCommunicatorFinal.Models;
using FarmmerCommunicatorFinal.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace FarmmerCommunicatorFinal.Controllers
{
    public class BuyerController : Controller
    {
        ApplicationDbContext _context;

        public BuyerController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Buyer
        public ActionResult Index()
        {
            var viewModel = new BuyerDashboardViewModel();
            var BuyerId = User.Identity.GetUserId();
            viewModel.Buyer = _context.Users.Single(u => u.Id == BuyerId);
            viewModel.CurrentDeals = _context.Deals.Include(d=>d.Product).Include(p=>p.Product.Farmer).
                Where(d => d.BuyerId == BuyerId).
                Where(d => d.Status == "Approved").ToList();
            viewModel.DealsWaitingForApproval = _context.Deals.Include(d => d.Product).Include(p=>p.Product.Farmer)
                .Where(d => d.BuyerId == BuyerId).
                Where(d => d.Status == "Waiting").ToList();
            
            return View(viewModel);
        }

        public ActionResult Rate(int Id, string message=null)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            var deal = _context.Deals.Include(d => d.Product).Include(p=>p.Product.Category).Include(p=>p.Buyer).Single(d => d.Id == Id);
            //var deal = _context.Deals.Single(d => d.Id == Id);
            var rate = new Rate();
            rate.Deal = deal;
            var viewModel = new RateUserViewModel();
            viewModel.Rate = rate;
            viewModel.Rate.Deal = deal;
            viewModel.Rate.DealId = deal.Id;
            viewModel.RateValues = new List<string>() { "1", "2", "3", "4", "5" };

            var Farmer = _context.Users.Single(u => u.Id == deal.FarmerId);
            viewModel.User = Farmer;
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
            viewModel.User = _context.Users.Single(u => u.Id == viewModel.Rate.Deal.FarmerId);
            viewModel.Rate.UserId = viewModel.User.Id;
            viewModel.Rate.User = viewModel.User;

            //var _rate = _context.Rates.SingleOrDefault(r => r.UserId == viewModel.User.Id);
            var _rate = _context.Rates.SingleOrDefault(r => r.UserId == viewModel.User.Id && r.DealId == viewModel.Rate.DealId);
            //var _rate = _context.Rates.Where(r => r.UserId == viewModel.User.Id).Where(r => r.DealId == viewModel.Rate.DealId).ToList();

            if (_rate == null)
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

        public ActionResult RequestProduct()
        {
            BuyerRequestProductViewModel viewModel = new BuyerRequestProductViewModel();
            viewModel.Categories = _context.Categories.ToList();
            return View(viewModel);
        }

        public ActionResult SaveRequest(BuyerRequestProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return HttpNotFound();
            var id = User.Identity.GetUserId();
            viewModel.BuyerRequest.BuyerId = id;
            viewModel.BuyerRequest.Buyer = _context.Users.Single(u => u.Id == id);
            DateTime date = new DateTime();
            viewModel.BuyerRequest.AddedDate = DateTime.Now;
            _context.BuyerRequests.Add(viewModel.BuyerRequest);
            _context.SaveChanges();
            return RedirectToAction("UserRequest", new { message = "Request added" });
        }

        public ActionResult UserRequest()
        {
            SingleBuyerRequests viewModel = new SingleBuyerRequests();
            var id = User.Identity.GetUserId();

            viewModel.Requests = _context.BuyerRequests.Where(r => r.BuyerId == id).ToList();
            return View(viewModel);
        }

        public ActionResult RemoveRequest(int id)
        {
            var request = _context.BuyerRequests.SingleOrDefault(r => r.Id == id);
            if (request == null)
                return HttpNotFound();
            _context.BuyerRequests.Remove(request);
            _context.SaveChanges();

            return RedirectToAction("UserRequest", new { message = "Request added" });

        }

        [AllowAnonymous]
        public ActionResult ProductRequests()
        {
            SingleBuyerRequests requests = new SingleBuyerRequests();
            requests.Requests = _context.BuyerRequests.Include(b=>b.Buyer).ToList().OrderByDescending(r => r.AddedDate).ToList();

            return View(requests);
        }
    }
}