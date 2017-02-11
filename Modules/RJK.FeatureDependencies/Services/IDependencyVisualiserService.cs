using Orchard;
using RJK.FeatureDependencies.Models;

namespace RJK.FeatureDependencies.Services
{
    public interface IDependencyVisualiserService : IDependency
    {
        DependencyVisualiserVm GetData(string filter = "");
    }
}