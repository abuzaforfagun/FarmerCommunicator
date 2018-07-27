using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmmerCommunicatorFinal.Models;

namespace FarmmerCommunicatorFinal.ViewModels
{
    public class RateUserViewModel
    {
        public Rate Rate { get; set; }
        public List<string> RateValues { get; set; }
        public bool isAllReadyRate { get; set; }
        public ApplicationUser User { get; set; }
        public string Message { get; set; }

    }
}