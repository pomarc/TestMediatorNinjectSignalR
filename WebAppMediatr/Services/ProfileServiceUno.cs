using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppMediatr.Messages;
using WebAppMediatr.Models;

namespace WebAppMediatr.Services
{
    public class ProfileServiceUno : IProfileService,
        IRequestHandler<ProfileSaveRequest, Profile>, 
        IRequestHandler<ProfileGetRequest,Profile>
    {
        [Ninject.Inject]
        public IMediator _mediator { get; set; }
         
        public int Age { get; set; }

        public string CalculateClass()
        {
            return "prima classe";
        }

        public Profile Save(Profile profilodasalvare)
        {   //simulo il salvataggio
            profilodasalvare.Id = 100;
            return profilodasalvare;
        }
      

        public Profile GetById(int id)
        {
            return new Profile() { Id = id, Age = 23, name = "Victoria" };
        }


        public Profile Handle(ProfileGetRequest message)
        {
            return GetById(message.Id);
        }
        public Profile Handle(ProfileSaveRequest message)
        {
            var profiloSalvato = Save(message.ProfiloDaSalvare);
         
           
            //broadcasto il salvataggio
            ProfileSavedNotification _prof = new ProfileSavedNotification();
            _prof.profilo = profiloSalvato;
            _mediator.Publish<ProfileSavedNotification>(_prof);

            return profiloSalvato;

        }
    }
}