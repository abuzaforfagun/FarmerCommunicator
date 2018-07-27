using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmmerCommunicatorFinal.Models;

namespace FarmmerCommunicatorFinal.ViewModels
{
    public class BuyerRequestProductViewModel
    {
        public BuyerRequest BuyerRequest { get; set; }
        public List<Category> Categories { get; set; }
    }
}