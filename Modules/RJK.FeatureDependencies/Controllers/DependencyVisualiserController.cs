using System.Web.Mvc;
using Orchard;
using RJK.FeatureDependencies.Services;

namespace RJK.FeatureDependencies.Controllers
{
    public class DependencyVisualiserController : Controller
    {
        private readonly IWorkContextAccessor _workContextAccessor;
        private readonly IDependencyVisualiserService _dependencyVisualiserService;

        public DependencyVisualiserController(IWorkContextAccessor workContextAccessor, IDependencyVisualiserService dependencyVisualiserService)
        {
            _workContextAccessor = workContextAccessor;
            _dependencyVisualiserService = dependencyVisualiserService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var filter = _workContextAccessor.GetContext().HttpContext.Request.QueryString["filter"];

            return View(_dependencyVisualiserService.GetData(filter ?? ""));
        }
    }
}