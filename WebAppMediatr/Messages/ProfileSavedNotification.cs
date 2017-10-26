using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediatR;
using WebAppMediatr.Models;

namespace WebAppMediatr.Messages
{
    public class ProfileSavedNotification:INotification
    {
      public  Profile profilo { get; set; }
    }
}