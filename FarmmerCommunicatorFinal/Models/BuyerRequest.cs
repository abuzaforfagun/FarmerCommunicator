using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmmerCommunicatorFinal.Models
{
    public class BuyerRequest
    {
        public int Id { get; set; }
        [Display(Name = "Category")]

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string BuyerId { get; set; }
        public ApplicationUser Buyer { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Display(Name="Added Date")]
        public DateTime AddedDate { get; set; }
    }
}