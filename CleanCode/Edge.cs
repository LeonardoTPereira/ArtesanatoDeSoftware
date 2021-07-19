using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public class Edge
    {
        private Vertex destination;
        private float weight;

        public Edge(Vertex destination, float weight)
        {
            Destination = destination;
            Weight = weight;
        }

        public Vertex Destination { get => destination; set => destination = value; }
        public float Weight { get => weight; set => weight = value; }

        public override string ToString()
        {
            string edgeString = "Destination: " + Destination.ToString();
            edgeString += " - Weight: " + Weight;
            return edgeString;
        }
    }
}
