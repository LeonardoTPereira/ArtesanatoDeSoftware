using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public class DigraphList : AbstractGraph
    {
        private List<List<Edge>> adjacencyList;

        public DigraphList(List<List<Edge>> adjacencyList, List<Vertex> vertices) : base(vertices)
        {
            AdjacencyList = adjacencyList;
        }

        public override void AddEdge(Vertex source, Vertex destination, float weight)
        {
            if (!EdgeExists(source, destination))
            {
                int sourceIndex = Vertices.IndexOf(source);
                AdjacencyList[sourceIndex].Add(new Edge(destination, weight));
            }
        }

        public bool EdgeExists(Vertex source, Vertex destination)
        {
            int sourceIndex = Vertices.IndexOf(source);
            List<Edge> sourceEdges = AdjacencyList[sourceIndex];
            foreach(Edge edge in sourceEdges)
            {
                if (edge.Destination.Equals(destination))
                {
                    return true;
                }
            }
            return false;
        }

        public DigraphList() : base()
        {
            AdjacencyList = new List<List<Edge>>();
        }

        public DigraphList(List<Vertex> vertices) : base(vertices)
        {
            InitializeAdjacencyList();
        }

        private void InitializeAdjacencyList()
        {
            AdjacencyList = new List<List<Edge>>();
            for (int i = 0; i < Vertices.Count; i++)
            {
                AdjacencyList.Add(new List<Edge>());
            }
        }

        public List<List<Edge>> AdjacencyList { get => adjacencyList; set => adjacencyList = value; }

        public override void PrintEdges()
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                for (int j = 0; j < AdjacencyList[i].Count; j++)
                {
                    Console.Write(AdjacencyList[i][j] + " ");
                }
                Console.WriteLine("");
            }
        }

        public float GetDistance(Vertex source, Vertex destination)
        {
            int sourceIndex = Vertices.IndexOf(source);
            List<Edge> sourceEdges = AdjacencyList[sourceIndex];
            foreach (Edge edge in sourceEdges)
            {
                if (edge.Destination.Equals(destination))
                {
                    return edge.Weight;
                }
            }
            return -1;
        }

        public override Vertex GetFirstConnectedVertex(Vertex source)
        {
            int sourceIndex = Vertices.IndexOf(source);
            if(AdjacencyList[sourceIndex].Count == 0)
            {
                return null;
            }
            else
            {
                return AdjacencyList[sourceIndex][0].Destination;
            }
        }

        public override Vertex GetNextConnectedVertex(Vertex source, Vertex currentConnected)
        {
            int sourceIndex = Vertices.IndexOf(source);
            int currentIndexInList = 0;
            Vertex adjacent = AdjacencyList[sourceIndex][currentIndexInList].Destination;
            while (!adjacent.Equals(currentConnected))
            {
                adjacent = AdjacencyList[sourceIndex][currentIndexInList].Destination;
                currentIndexInList++;
            }
            currentIndexInList++;
            if(AdjacencyList[sourceIndex].Count > currentIndexInList)
            {
                return AdjacencyList[sourceIndex][currentIndexInList].Destination;
            }
            return null;
        }
    }
}
