using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmmerCommunicatorFinal.Models;

namespace FarmmerCommunicatorFinal.ViewModels
{
    public class SingleCategoryProductListViewModel
    {
        public List<Product> Products { get; set; }
        public Category Category { get; set; }
        public string Message { get; set; }
    }
}