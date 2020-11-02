using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Routes.Constraints
{
    public class MainConstraint : IRouteConstraint
    {
        private string[] DenyUrls;
        public MainConstraint(string[] DenyUrls)
        {
            this.DenyUrls = DenyUrls;
        }

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            foreach(var url in DenyUrls)
            {
                if (httpContext.Request.Path.Value.Contains(url)) return false;
            }
            return true;
        }
    }
}
