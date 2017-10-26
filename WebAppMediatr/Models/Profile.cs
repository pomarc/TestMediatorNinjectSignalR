using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMediatr.Models
{
    public class Profile
    {
        public int Age { get; set; }
        public int Id { get; set; }
        public string name { get; set; }
    }
}