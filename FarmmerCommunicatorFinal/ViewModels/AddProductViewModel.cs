using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmmerCommunicatorFinal.Models;

namespace FarmmerCommunicatorFinal.ViewModels
{
    public class AddProductViewModel
    {
        public List<Category> Categories { get; set; }
        public Product Product { get; set; }
        public HttpPostedFileBase Image { get; set; }
    }
}