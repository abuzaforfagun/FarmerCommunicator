using FarmmerCommunicatorFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmmerCommunicatorFinal.ViewModels
{
    public class FarmerProfile
    {
        public ApplicationUser Farmer { get; set; }
        public List<Product> Products { get; set; }
    }
}