using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppMediatr.Models;

namespace WebAppMediatr.Messages
{
    public class ProfileGetRequest:IRequest<Profile>
    {
        public int Id { get; set; }

    }
}