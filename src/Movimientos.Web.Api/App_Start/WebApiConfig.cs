using Movimientos.Web.Common;
using Movimientos.Web.Common.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;

namespace Movimientos.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ConfigureRouting(config);
        }

        private static void ConfigureRouting(HttpConfiguration config)
        {
            //config.Routes.MapHttpRoute(
            //    name: "legacyRoute",
            //    routeTemplate: "TeamTaskService.asmx",
            //    defaults: null,
            //    constraints: null,
            //    handler: new LegacyAuthenticationMessageHandler(WebContainerManager.Get<ILogManager>())
            //    {
            //        InnerHandler = new LegacyMessageHandler { InnerHandler = new HttpControllerDispatcher(config) }
            //    });


            var constraintsResolver = new DefaultInlineConstraintResolver();
            constraintsResolver.ConstraintMap.Add("apiVersionConstraint", typeof(ApiVersionConstraint));
            config.MapHttpAttributeRoutes(constraintsResolver);


            config.Services.Replace(typeof(IHttpControllerSelector),
                new NamespaceHttpControllerSelector(config));
        }

    }
}
