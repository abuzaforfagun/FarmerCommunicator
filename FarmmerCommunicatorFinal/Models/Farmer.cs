using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmmerCommunicatorFinal.Models;

namespace FarmmerCommunicatorFinal.Models
{
    public class Farmer:Person
    {
        public List<Product> Products { get; set; }

    }
}