using System;
using System.Collections.Generic;
using System.Text;

namespace Pract_Task_8
{
    //Класс, реализующий алгоритм поиска двусвязных компонент в графе
    //С помощью двойного обхода в глубину
    class ConnectedComps
    {
        private bool[] marked;
        private int[] id;
        private int[] low;
        private int count;
        public List<Edge>[] Blocks { get; set; }
        private int blockIndex;

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

            for (int i = 0; i < G.GetVertices(); i++)
                if(!marked[i]) DFS(G, i, -1);

            marked = new bool[G.GetVertices()];

            for (int i = 0; i < G.GetVertices(); i++)
                if (!marked[i]) { blockIndex++; DFS2(G, i, blockIndex, -1); }
        }

        private void DFS(Graph G, int curr, int prev)
        {
            count++;
            id[curr] = count;
            low[curr] = count;
            marked[curr] = true;
            foreach (int i in G.GetAdj(curr))
            {
                if (i ==prev) continue;
                if (marked[i])
                {
                    low[curr] = Math.Min(low[curr], id[i]);
                }
                else
                {
                    DFS(G, i, curr);
                    low[curr] = Math.Min(low[curr], low[i]) ;
                }
            }
        }

        private void DFS2(Graph G, int curr, int tekBlock, int prev)
        {
            marked[curr] = true;
            foreach (int x in G.GetAdj(curr))
            {
                if (x.Equals(prev)) continue;
                if (!marked[x])
                {
                    if (low[x]>=id[curr])
                    {
                        DFS2(G, x, tekBlock, curr);
                        tekBlock++;
                        Blocks[tekBlock].Add(GetEdge(curr, x));
                    }
                    else
                    {
                        DFS2(G, x, tekBlock, curr);
                        Blocks[tekBlock].Add(GetEdge(curr, x));
                    }
                }
                else
                {
                    if (id[x] < id[curr]) Blocks[tekBlock].Add(GetEdge(curr, x));
                }
            }
        }


        private Edge GetEdge(int a, int b)
        {
            return new Edge(a, b);
        }

    }
}
