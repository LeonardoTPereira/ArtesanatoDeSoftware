using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public class DepthFirstTraversal : TraversalStrategy
    {
        public DepthFirstTraversal(AbstractGraph graph)
        {
            Graph = graph;
            Path = new List<Vertex>();
            VisitedVertices = new bool[graph.Vertices.Count];
            for (int i = 0; i < VisitedVertices.Length; i++)
            {
                VisitedVertices[i] = false;
            }
        }

        public override void TraverseGraph(Vertex source)
        {
            DepthFirstTraversalRecursion(source);
            PrintPath();
        }

        public override void PrintPath()
        {
            foreach (var vertex in Path)
            {
                Console.WriteLine(vertex);
            }
        }

        private void DepthFirstTraversalRecursion(Vertex current)
        {
            int currentIndex = Graph.Vertices.IndexOf(current);
            VisitedVertices[currentIndex] = true;
            Path.Add(current);
            Vertex adjacent = Graph.GetFirstConnectedVertex(current);
            while(adjacent != null)
            {
                int adjacentIndex = Graph.Vertices.IndexOf(adjacent);
                if(!VisitedVertices[adjacentIndex])
                {
                    DepthFirstTraversalRecursion(adjacent);
                }
                adjacent = Graph.GetNextConnectedVertex(current, adjacent);
            }
        }
    }
}
