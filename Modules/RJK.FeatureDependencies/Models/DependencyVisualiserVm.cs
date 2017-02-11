using System.Collections.Generic;
using Newtonsoft.Json;

namespace RJK.FeatureDependencies.Models
{
    public class DependencyVisualiserVm
    {
        public DependencyVisualiserVm()
        {
            Nodes = new List<NodesModel>();
            Edges = new List<EdgesModel>();
        }

        [JsonProperty("nodes")]
        public List<NodesModel> Nodes { get; set; }

        public class NodesModel
        {
            [JsonProperty("id")]
            public string Id { get; set; }
            [JsonProperty("label")]
            public string Label { get; set; }
        }

        [JsonProperty("edges")]
        public List<EdgesModel> Edges { get; set; }

        public class EdgesModel
        {
            [JsonProperty("from")]
            public string From { get; set; }
            [JsonProperty("to")]
            public string To { get; set; }
        }
    }
}