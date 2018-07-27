using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FarmmerCommunicatorFinal.Models
{
    public class Product
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }

        [Display(Name="Image")]
        public string ImageUrl { get; set; }
        public ApplicationUser Farmer { get; set; }
        public string FarmerId
        {
            get;
            set;
        }

        public string FarmerRate
        {
            get
            {
                ApplicationDbContext _context = new ApplicationDbContext();
                var _rates = _context.Rates.Where(r => r.UserId == FarmerId).ToList();
                if (_rates.Count == 0)
                    return "No review yet";
                int totalReview = 0;
                double totalRate = 0;
                for(int i = 0; i < _rates.Count; i++)
                {
                    totalReview++;
                    totalRate += _rates[i].RateValue;

                }

                return System.Math.Round(totalRate / totalReview, 2).ToString();
            }
        }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public int IsDisplay { get; set; } // 0 for not display 1 for display
        public int Price { get; set; }

    }
}