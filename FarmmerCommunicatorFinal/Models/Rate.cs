using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmmerCommunicatorFinal.Models
{
    public class Rate
    {
        public int Id { get; set; }
        public double RateValue { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Deal Deal { get; set; }
        public int DealId { get; set; }

    }
}