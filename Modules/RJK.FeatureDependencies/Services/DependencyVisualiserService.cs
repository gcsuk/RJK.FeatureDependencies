using System.Linq;
using Orchard.Environment.Extensions;
using RJK.FeatureDependencies.Models;

namespace RJK.FeatureDependencies.Services
{
    public class DependencyVisualiserService : IDependencyVisualiserService
    {
        private readonly IExtensionManager _extensionManager;

        public DependencyVisualiserService(IExtensionManager extensionManager)
        {
            _extensionManager = extensionManager;
        }

        public DependencyVisualiserVm GetData(string filter = "")
        {
            var result = new DependencyVisualiserVm();

            var allFeatures = _extensionManager.AvailableFeatures().ToList();

            foreach (var featureDescriptor in allFeatures)
            {
                // Store full name including namespace as unique identifier, and user-friendly 
                result.Nodes.Add(new DependencyVisualiserVm.NodesModel
                {
                    Id = featureDescriptor.Id, // A unique identifier
                    Label = featureDescriptor.Name // Full name including namespace
                });
            }

            foreach (var featureDescriptor in allFeatures)
            {
                foreach (var featureDescriptorDependency in featureDescriptor.Dependencies)
                {
                    var parent = result.Nodes.SingleOrDefault(n => n.Id == featureDescriptorDependency);

                    if (parent != null)
                    {
                        result.Edges.Add(new DependencyVisualiserVm.EdgesModel
                        {
                            From = featureDescriptor.Id,
                            To = featureDescriptorDependency
                        });
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(filter))
            {
                result.Nodes = result.Nodes.Where(n => n.Id.Contains(filter)).ToList();
                result.Edges = result.Edges.Where(e => e.From.Contains(filter)).ToList();
            }

            return result;
        }
    }
}