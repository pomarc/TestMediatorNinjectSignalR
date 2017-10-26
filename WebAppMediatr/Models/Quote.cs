using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMediatr.Models
{
    public class Quote
    {
        public DateTime QuoteDate { get; set; }
        public int Id { get; set; }

        public string Car { get; set; }
        public int Price { get; set; }
    }
}