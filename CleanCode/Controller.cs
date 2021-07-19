using System;
using System.Collections.Generic;

namespace CleanCode
{
    class Controller
    {
        private const int totalVertices = 5;

        static void Main()
        {
            List<Vertex> vertices;
            AbstractGraph graph;
            vertices = CreateTestVertices();
            TraversalStrategy traversal;
            int graphType = Convert.ToInt32(Console.ReadLine());

            if (CheckGraphType(graphType))
            {
                graph = new GraphList(vertices);
            }
            else
            {
                graph = new GraphMatrix(vertices);
            }

            CreateTestEdges(graph, vertices);

            traversal = new DepthFirstTraversal(graph);
            traversal.TraverseGraph(vertices[0]);

            traversal = new BreadthFirstTraversal(graph);
            traversal.TraverseGraph(vertices[0]);

            Console.ReadKey();
        }

        private static bool CheckGraphType(int graphType)
        {
            return graphType == 0;
        }

        private static void CreateTestEdges(AbstractGraph graph, 
            List<Vertex> vertices)
        {
            graph.AddEdge(vertices[0], vertices[1], 2);
            graph.AddEdge(vertices[1], vertices[3], 1);
            graph.AddEdge(vertices[0], vertices[2], 3);
            graph.AddEdge(vertices[2], vertices[4], 4);
        }

        private static List<Vertex> CreateTestVertices()
        {
            List<Vertex> vertices = new List<Vertex>();
            for (int i = 0; i < totalVertices; i++)
            {
                vertices.Add(new Vertex(i, "Vertex "+i));
            }
            return vertices;
        }
    }
}
