using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMediatr.Models;

namespace WebAppMediatr.Services
{
    public interface IProfileService
    {
          int Age{ get; set; }
        string CalculateClass();

    }
}
