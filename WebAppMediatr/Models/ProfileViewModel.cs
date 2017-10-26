using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMediatr.Models
{
    public class ProfileViewModel
    {
        public Profile profile { get; set; }
        public List<Quote> quotes { get; set; }
    }
}