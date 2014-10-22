using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Movimientos.Web.Common.Routing
{
    public class ApiVersion2RoutePrefixAttribute : RoutePrefixAttribute
    {
        private const string RouteBase = "api/{apiVersion:apiVersionConstraint(v2)}";
        private const string PrefixRouteBase = RouteBase + "/";

        public ApiVersion2RoutePrefixAttribute(string routePrefix)
            : base(String.IsNullOrWhiteSpace(routePrefix) ? RouteBase : PrefixRouteBase + routePrefix)
        {

        }
    }
}