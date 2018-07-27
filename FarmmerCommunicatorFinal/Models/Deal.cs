using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmmerCommunicatorFinal.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FarmmerCommunicatorFinal.Models
{
    public class Deal
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        
        public string FarmerId { get; set; }

        public ApplicationUser Buyer { get; set; }
        public string BuyerId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

    }
}