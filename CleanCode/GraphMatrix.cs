using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public class GraphMatrix : DigraphMatrix
    {
        public GraphMatrix() : base()
        {
        }

        public GraphMatrix(List<Vertex> vertices) : base(vertices)
        {
        }

        public GraphMatrix(float[,] adjacencyMatrix, List<Vertex> vertices) : base(adjacencyMatrix, vertices)
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
