using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmmerCommunicatorFinal.Models;

namespace FarmmerCommunicatorFinal.ViewModels
{
    public class BuyerDashboardViewModel
    {
        public ApplicationUser Buyer { get; set; }
        public List<Deal> DealsWaitingForApproval { get; set; }
        public List<Deal> CurrentDeals { get; set; }

        public string Rate
        {
            get
            {
                ApplicationDbContext _context = new ApplicationDbContext();
                var rates = _context.Rates.Where(r => r.UserId == Buyer.Id).ToList();
                if (rates.Count == 0)
                    return "No rate yet";
                int totalReview = 0;
                double totalRate = 0;
                for (int i = 0; i < rates.Count; i++)
                {
                    totalReview++;
                    totalRate += rates[i].RateValue;

                }

                return System.Math.Round(totalRate / totalReview, 2).ToString();
            }

        }
        public string Message { get; set; }

    }
}