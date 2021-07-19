using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public abstract class AbstractGraph
    {
        private List<Vertex> vertices;

        protected AbstractGraph(List<Vertex> vertices)
        {
            Vertices = vertices;
        }

        protected AbstractGraph()
        {
            Vertices = new List<Vertex>();
        }

        public abstract void AddEdge(Vertex source, Vertex destination, float weight);

        public abstract void PrintEdges();

        public abstract Vertex GetFirstConnectedVertex(Vertex source);
        public abstract Vertex GetNextConnectedVertex(Vertex source, Vertex currentConnected);

        public List<Vertex> Vertices { get => vertices; set => vertices = value; }
    }
}
