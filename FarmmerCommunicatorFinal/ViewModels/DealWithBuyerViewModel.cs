using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmmerCommunicatorFinal.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FarmmerCommunicatorFinal.ViewModels
{
    public class DealWithBuyerViewModel
    {
        public Deal Deal { get; set; }
        public IdentityUser Buyer { get; set; }
    }
}