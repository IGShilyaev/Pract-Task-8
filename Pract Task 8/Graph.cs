using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Pract_Task_8
{
    //Граф, представленный в виде списка смежных вершин для каждой отдельной
    class Graph
    {
        private int vert;
        public int edgeCounter;
        private List<int>[] adj;

        public Graph(int[,] matrix)
        {
            //Инициализация
            this.vert = matrix.GetLength(0);
            edgeCounter = 0;
            foreach (int x in matrix) edgeCounter += x;
            edgeCounter = edgeCounter / 2;

            adj = new List<int>[vert];
            for(int v = 0; v < vert; v++)
            {
                adj[v] = new List<int>();
            }

            //Заполнение
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] == 1) adj[i].Add(j);

        }

        public int GetVertices()
        {
            return vert;
        }

        public List<int> GetAdj(int a)
        {
            return adj[a];
        }

    }
}
