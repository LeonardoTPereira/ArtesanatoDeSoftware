using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public class BreadthFirstTraversal : TraversalStrategy
    {
        private Queue<Vertex> verticesToVisit;

        public BreadthFirstTraversal(AbstractGraph graph)
        {
            Graph = graph;
            Path = new List<Vertex>();
            VisitedVertices = new bool[graph.Vertices.Count];
            for (int i = 0; i < VisitedVertices.Length; i++)
            {
                VisitedVertices[i] = false;
            }
            verticesToVisit = new Queue<Vertex>();
        }

        public override void TraverseGraph(Vertex source)
        {
            int sourceIndex = Graph.Vertices.IndexOf(source);
            VisitedVertices[sourceIndex] = true;
            verticesToVisit.Enqueue(source);
            VisitVerticesInQueue();
            PrintPath();
        }

        private void VisitVerticesInQueue()
        {
            Vertex current;
            while (verticesToVisit.Count > 0)
            {
                current = verticesToVisit.Dequeue();
                Path.Add(current);
                Vertex adjacent = Graph.GetFirstConnectedVertex(current);
                VisitAdjacentVertices(current, adjacent);
            }
        }

        private void VisitAdjacentVertices(Vertex current, Vertex adjacent)
        {
            while (adjacent != null)
            {
                int adjacentIndex = Graph.Vertices.IndexOf(adjacent);
                if (!VisitedVertices[adjacentIndex])
                {
                    VisitedVertices[adjacentIndex] = true;
                    verticesToVisit.Enqueue(adjacent);
                }
                adjacent = Graph.GetNextConnectedVertex(current, adjacent);
            }
        }

        public override void PrintPath()
        {
            foreach (var vertex in Path)
            {
                Console.WriteLine(vertex);
            }
        }
    }
}
