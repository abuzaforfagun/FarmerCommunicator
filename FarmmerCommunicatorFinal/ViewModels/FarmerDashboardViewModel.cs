using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmmerCommunicatorFinal.Models;

namespace FarmmerCommunicatorFinal.ViewModels
{
    public class FarmerDashboardViewModel
    {
        public List<Product> AllProducts { get; set; }
        public List<Deal> WaitingForApproval { get; set; }
        public List<Deal> CurrentDeals { get; set; }
        public string Message { get; set; }
    }
}