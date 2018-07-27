using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmmerCommunicatorFinal.Models
{
    public class BuyingPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }
        public DateTime AddedDate { get; set; }
        public string Description { get; set; }

    }
}