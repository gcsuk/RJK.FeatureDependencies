using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace RJK.FeatureDependencies.Providers
{
    public class DependencyVisualiserRouteProvider : IRouteProvider
    {
        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[]
            {
                new RouteDescriptor
                {
                    Route = new Route(
                        "Dependencies",
                        new RouteValueDictionary
                        {
                            {"area", "RJK.FeatureDependencies"},
                            {"controller", "DependencyVisualiser"},
                            {"action", "Index"}
                        },
                        new RouteValueDictionary(), //constraints (none here)
                        new RouteValueDictionary
                        {
                            {"area", "RJK.FeatureDependencies"}
                        },
                        new MvcRouteHandler())
                }
            };
        }

        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }
    }
}