using System;
using System.Collections.Generic;

namespace Pract_Task_8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] G1 = Graph1(9);
            Graph tekGraph = new Graph(G1);

            ConnectedComps cc = new ConnectedComps(tekGraph);
            

            foreach (List<Edge> x in cc.Blocks)

                if (x.Count > 0) 
                {
                    Console.Write($"Блок:  ");
                    foreach (Edge a in x) Console.Write(a+"; ");
                    Console.WriteLine();
                } 
                
        }


        static int[,] Graph1(int n)
        {
            int[,] temp = new int[n, n];
            temp[0, 4] = 1;
            temp[4, 0] = 1;
            temp[5, 0] = 1;
            temp[0, 5] = 1;
            temp[6, 0] = 1;
            temp[0, 6] = 1;
            temp[1, 2] = 1;
            temp[2, 1] = 1;
            temp[1, 3] = 1;
            temp[3, 1] = 1;
            temp[2, 3] = 1;
            temp[3, 2] = 1;
            temp[2, 4] = 1;
            temp[4, 2] = 1;
            temp[3, 4] = 1;
            temp[4, 3] = 1;
            temp[4, 5] = 1;
            temp[5, 4] = 1;
            temp[5, 7] = 1;
            temp[7, 5] = 1;
            temp[6, 7] = 1;
            temp[7, 6] = 1;
            temp[6, 8] = 1;
            temp[8, 6] = 1;
            return temp;
        }

        
    }
}
