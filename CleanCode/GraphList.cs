using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public class GraphList : DigraphList
    {
        public GraphList() : base()
        {
        }

        public GraphList(List<Vertex> vertices) : base(vertices)
        {
        }

        public GraphList(List<List<Edge>> adjacencyList, List<Vertex> vertices) : base(adjacencyList, vertices)
        {
        }

        public override void AddEdge(Vertex source,
            Vertex destination, float weight)
        {
            base.AddEdge(source, destination, weight);
            base.AddEdge(destination, source, weight);
        }
    }
}
