using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMediatr.Services;
using MediatR;
using WebAppMediatr.Messages;
using System.Threading.Tasks;
using WebAppMediatr.Models;

namespace WebAppMediatr.Controllers
{
    public class HomeController  : Controller
    {
        
        public IMediator _mediator = null;
        private async Task<Profile >SaveProfile(Profile profilo)
        {
            var profiloSalvato = await _mediator.Send(new ProfileSaveRequest() { ProfiloDaSalvare = profilo });
            return profiloSalvato;
        }


        public HomeController( IMediator mediator)
        {
            
            _mediator = mediator;
        }

        public ActionResult Profile(int id)
        {
            ProfileViewModel vm = new ProfileViewModel();
            vm.profile = _mediator.Send(new ProfileGetRequest() { Id = id }).GetAwaiter().GetResult();
            vm.quotes = _mediator.Send(new QuotesGetQuotesRequest() { Id = id }).GetAwaiter().GetResult();
            return View(vm);

        }
        [HttpPost]
        public async Task<ActionResult> Index(ProfileViewModel vm)
        {
            var profilo = SaveProfile(new Models.Profile() { name = vm.profile.name, Age = 47 }).Result;
            vm.profile = profilo;
            return View(vm);
        }
        public async Task<ActionResult> Index()
        {
          
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}