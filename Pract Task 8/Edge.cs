using System;
using System.Collections.Generic;
using System.Text;

namespace Pract_Task_8
{
    class Edge
    {
        public int v1;
        public int v2;

        public Edge(int a, int b)
        {
            v1 = a;
            v2 = b;
        }

        public override string ToString()
        {
            return $"{v1}-{v2}";
        }
        public override bool Equals(object obj)
        {
            Edge secondEdge = obj as Edge;
            return (this.v1==secondEdge.v1||this.v1==secondEdge.v2)&&(this.v2==secondEdge.v1||this.v2==secondEdge.v2);
        }
    }
}
