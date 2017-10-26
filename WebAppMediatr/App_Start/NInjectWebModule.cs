
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Web.Infrastructure.DynamicModuleHelper;

using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using WebAppMediatr.App_Start;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]
namespace WebAppMediatr.App_Start
{




    using System;
        using System.Reflection;
        using System.Web;

        using Microsoft.Web.Infrastructure.DynamicModuleHelper;

        using Ninject;
        using Ninject.Web.Common;
        using Ninject.Web.Common.WebHost;
    using WebAppMediatr.Services;
    using MediatR;
    using WebAppMediatr.Models;
    using WebAppMediatr.Messages;

    /// <summary>
    /// Bootstrapper for the application.
    /// </summary>
    public static class NinjectWebCommon
        {
            private static readonly Bootstrapper bootstrapper = new Bootstrapper();

            /// <summary>
            /// Starts the application
            /// </summary>
            public static void Start()
            {
                DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
                DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
                bootstrapper.Initialize(CreateKernel);
            }

            /// <summary>
            /// Stops the application.
            /// </summary>
            public static void Stop()
            {
                bootstrapper.ShutDown();
            }

            /// <summary>
            /// Creates the kernel that will manage your application.
            /// </summary>
            /// <returns>The created kernel.</returns>
            private static IKernel CreateKernel()
            {
                var kernel = new StandardKernel();
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();


                RegisterServices(kernel);
                return kernel;
            }

            /// <summary>
            /// Load your modules or register your services here!
            /// </summary>
            /// <param name="kernel">The kernel.</param>
            private static void RegisterServices(IKernel kernel)
            {
            kernel.Bind<IProfileService>().To<ProfileServiceUno>();
            kernel.Bind<IRequestHandler<ProfileSaveRequest, Profile>>().To<ProfileServiceUno>();
        //    kernel.Bind<IRequestHandler<ProfileSaveRequest, Profile>>().To<ProfileServiceDue>();
            kernel.Bind<IRequestHandler<ProfileGetRequest, Profile>>().To<ProfileServiceUno>();
            kernel.Bind<IAsyncNotificationHandler<ProfileSavedNotification>>().To<RemoteQuueueService>();
            kernel.Bind<IRequestHandler<QuotesGetQuotesRequest, List<Quote>>>().To<QuoteService>();

            kernel.Bind<IAsyncNotificationHandler<ProfileSavedNotification>>().To<RemoteWSService>();

            kernel.Bind<IMediator>().To<Mediator>();
         

            kernel.Bind<SingleInstanceFactory>().ToMethod(ctx => t => ctx.Kernel.TryGet(t));
            kernel.Bind<MultiInstanceFactory>().ToMethod(ctx => t => ctx.Kernel.GetAll(t));

            
            


            kernel.Load(Assembly.GetExecutingAssembly());
            }
        }
    }
 