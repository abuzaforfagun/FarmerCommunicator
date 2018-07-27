using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FarmmerCommunicatorFinal.Models;

namespace FarmmerCommunicatorFinal.Models
{
    public class Buyer:Person
    {
        public List<BuyingPost> BuyingPosts { get; set; }
    }
}