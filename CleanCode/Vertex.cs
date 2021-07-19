using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    public class Vertex
    {
        private int value;
        private string name;

        public Vertex(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public int Value { get => value; set => this.value = Math.Abs(value); }
        public string Name { get => name; set => name = value; }

        public override string ToString()
        {
            string vertexString = "Name: " + Name;
            return vertexString;
        }
    }
}
