using System;
using System.Collections.Generic;
using System.Text;

namespace Pract_Task_8
{
    //Класс, реализующий алгоритм поиска двусвязных компонент в графе
    //С помощью обхода в глубину
    class ConnectedComps
    {
        private bool[] marked;
        private int[] id;
        private int[] low;
        private int count;
        private Stack<Edge> edges;
        private Stack<Edge> usedEdges;
        public List<Edge>[] Blocks { get; }
        private int blockIndex;
        private List<int> cutpoints;

        public ConnectedComps(Graph G)
        {
            marked = new bool[G.GetVertices()];
            id = new int[G.GetVertices()];
            low = new int[G.GetVertices()];
            count = 0;
            Blocks = new List<Edge>[G.GetVertices()];
            for (int i = 0; i < G.GetVertices(); i++)
                Blocks[i] = new List<Edge>();
            blockIndex = -1;
            cutpoints = new List<int>();
            edges = new Stack<Edge>();
            usedEdges = new Stack<Edge>();

            for (int i = 0; i < G.GetVertices(); i++)
                if (!marked[i]) 
                {
                    blockIndex++; 
                    DFS(G, i, -1);
                    while (edges.Count > 0)
                        if (!usedEdges.Contains(edges.Peek())) { Blocks[blockIndex].Add(edges.Peek()); usedEdges.Push(edges.Pop()); }
                        else edges.Pop();
                }

        }

        private void DFS(Graph G, int curr, int prev)
        {
            count++;
            id[curr] = count;
            low[curr] = count;
            int children = 0;
            marked[curr] = true;
            foreach (int i in G.GetAdj(curr))
            {
                if (i ==prev) continue;
                if (marked[i])
                {
                    edges.Push(GetEdge(curr, i));
                    low[curr] = Math.Min(low[curr], id[i]);
                }
                else
                {
                    edges.Push(GetEdge(curr, i));
                    DFS(G, i, curr);
                    children++;
                    low[curr] = Math.Min(low[curr], low[i]) ;
                    if (prev != -1 && low[i] >= id[curr])
                    {
                        cutpoints.Add(curr);
                        while (!edges.Peek().Equals(GetEdge(curr, i)))
                            if (!Blocks[blockIndex].Contains(edges.Peek())&&!usedEdges.Contains(edges.Peek())) { Blocks[blockIndex].Add(edges.Peek());  usedEdges.Push(edges.Pop()); }
                            else edges.Pop();
                        usedEdges.Push(edges.Peek());
                        Blocks[blockIndex].Add(edges.Pop());
                        blockIndex++;
                    }
                }
            }
            if (prev == -1 && children >= 2)
            {
                cutpoints.Add(curr);
                while (!edges.Peek().Equals(GetEdge(curr, prev)))
                    if (!Blocks[blockIndex].Contains(edges.Peek()) && !usedEdges.Contains(edges.Peek())) { Blocks[blockIndex].Add(edges.Peek()); usedEdges.Push(edges.Pop()); }
                    else edges.Pop();
                usedEdges.Push(edges.Peek());
                Blocks[blockIndex].Add(edges.Pop());
                blockIndex++;
            }
        }

        private Edge GetEdge(int a, int b)
        {
            return new Edge(a, b);
        }

    }
}
