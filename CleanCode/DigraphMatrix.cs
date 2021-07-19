using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public class DigraphMatrix : AbstractGraph
    {
        private float[,] adjacencyMatrix;

        public DigraphMatrix(float[,] adjacencyMatrix, List<Vertex> vertices) : base(vertices)
        {
            AdjacencyMatrix = adjacencyMatrix;
        }

        public override void AddEdge(Vertex source, Vertex destination, float weight)
        {
            if (!EdgeExists(source, destination))
            {
                int sourceIndex = Vertices.IndexOf(source);
                int destinationIndex = Vertices.IndexOf(destination);
                AdjacencyMatrix[sourceIndex, destinationIndex] = weight;
            }
        }

        public bool EdgeExists(Vertex source, Vertex destination)
        {
            float weight;
            int sourceIndex = Vertices.IndexOf(source);
            int destinationIndex = Vertices.IndexOf(destination);
            weight = AdjacencyMatrix[sourceIndex, destinationIndex];
            if (weight > 0)
            {
                return true;
            }
            return false;
        }

        public DigraphMatrix() : base()
        {
            AdjacencyMatrix = new float[0,0];
        }

        public DigraphMatrix(List<Vertex> vertices) : base(vertices)
        {
            AdjacencyMatrix = new float[Vertices.Count, Vertices.Count];
            InitializeMatrix();
        }

        private void InitializeMatrix()
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                for (int j = 0; j < Vertices.Count; j++)
                {
                    adjacencyMatrix[i, j] = 0;
                }
            }
        }

        public float[,] AdjacencyMatrix { get => adjacencyMatrix; set => adjacencyMatrix = value; }

        public override void PrintEdges()
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                for (int j = 0; j < Vertices.Count; j++)
                {
                    Console.Write(AdjacencyMatrix[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }

        public float GetDistance(Vertex source, Vertex destination)
        {
            float distance;
            int sourceIndex = Vertices.IndexOf(source);
            int destinationIndex = Vertices.IndexOf(destination);
            distance = AdjacencyMatrix[sourceIndex, destinationIndex];
            return distance;
        }

        public override Vertex GetFirstConnectedVertex(Vertex source)
        {
            int sourceIndex = Vertices.IndexOf(source);
            for (int i = 0; i < Vertices.Count; i++)
            {
                if(AdjacencyMatrix[sourceIndex, i] > 0)
                {
                    return Vertices[i];
                }
            }
            return null;
        }

        public override Vertex GetNextConnectedVertex(Vertex source, Vertex currentConnected)
        {
            int sourceIndex = Vertices.IndexOf(source);
            int currentConnectedIndex = Vertices.IndexOf(currentConnected);
            for (int i = (currentConnectedIndex+1); i < Vertices.Count; i++)
            {
                if (AdjacencyMatrix[sourceIndex, i] > 0)
                {
                    return Vertices[i];
                }
            }
            return null;
        }
    }
}
