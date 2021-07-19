using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public abstract class TraversalStrategy
    {
        private List<Vertex> path;
        private AbstractGraph graph;
        private bool[] visitedVertices;

        public List<Vertex> Path { get => path; set => path = value; }
        public AbstractGraph Graph { get => graph; set => graph = value; }
        public bool[] VisitedVertices { get => visitedVertices; set => visitedVertices = value; }

        public abstract void TraverseGraph(Vertex source);
        public abstract void PrintPath();
    }
}
