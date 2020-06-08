using System;
using System.Collections.Generic;

namespace Pract_Task_8
{
    class Program
    {
        static void Main(string[] args)
        {

            ListGraphTypes();
            Console.WriteLine();
            bool stop = false;
            do
            {
                Console.WriteLine("Выберите граф для проверки:");
                int operation = EnterIntNumber();
                switch (operation)
                {
                    case 0:
                        {
                            stop = true;
                            break;
                        }
                    case 1:
                        {
                            int[,] G = Graph1();
                            FindBlocks(G);
                            break;
                        }
                    case 2:
                        {
                            int[,] G = Graph2();
                            FindBlocks(G);
                            Console.WriteLine();
                            break;
                        }
                    case 3:
                        {
                            int[,] G = Graph3();
                            FindBlocks(G);
                            Console.WriteLine();
                            break;
                        }
                    case 4:
                        {
                            int[,] G = Graph4();
                            FindBlocks(G);
                            Console.WriteLine();
                            break;
                        }
                    case 5:
                        {
                            int[,] G = Graph5();
                            FindBlocks(G);
                            Console.WriteLine();
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            ListGraphTypes();
                            Console.WriteLine();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Введено некорректное значение!");
                            Console.WriteLine();
                            break;
                        }
                }

            } while (!stop);
        }

        static int EnterIntNumber()
        {
            bool ok;
            int n;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out n);
                if (!ok) Console.WriteLine("Ошибка ввода, введите целое неотрицательное число");
            } while (!ok);
            return n;
        }

        static void ListGraphTypes()
        {
            Console.WriteLine(@"1 - Связный граф, n = 9, 3 блока
2 - Несвязный граф (две компоненты связности с n = 3), два блока
3 - Одна вершина (n = 1)
4 - Связный граф, n = 4, один блок
5 - Пустой граф
6 - Очистить консоль
0 - Завершить работу");
        }

        static void FindBlocks(int[,] G1)
        {
            for (int i = 0; i < G1.GetLength(0); i++)
            {
                for (int j = 0; j < G1.GetLength(1); j++)
                    Console.Write(G1[i, j] + "  ");
                Console.WriteLine();
            }
            Graph tekGraph = new Graph(G1);

            if(tekGraph.GetVertices() == 0)
            {
                Console.WriteLine("Ошибка! Заданный граф не имеет ни одной вершины");
                return;
            }

            if(tekGraph.edgeCounter == 0)
            {
                Console.WriteLine("Граф состоит из несвязанных ребрами вершин!");
            }

            ConnectedComps cc = new ConnectedComps(tekGraph);


            foreach (List<Edge> x in cc.Blocks)

                if (x.Count > 0)
                {
                    Console.Write($"Блок:  ");
                    foreach (Edge a in x) Console.Write(a + "; ");
                    Console.WriteLine();
                }

            for (int i = 0; i<tekGraph.GetVertices(); i++)
            {
                if (tekGraph.GetAdj(i).Count == 0) Console.WriteLine($"Вершина {i} является отдельным блоком");
            }
        }




        //Связный граф, n = 9, 3 блока
        static int[,] Graph1()
        {
            int[,] temp = new int[9, 9];
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

        //Несвязный граф (две компоненты связности с n = 3), два блока
        static int[,] Graph2()
        {
            int[,] G = new int[6, 6];
            G[0, 1] = 1;
            G[1, 0] = 1;
            G[0, 2] = 1;
            G[2, 0] = 1;
            G[1, 2] = 1;
            G[2, 1] = 1;
            G[3, 4] = 1;
            G[4, 3] = 1;
            G[3, 5] = 1;
            G[5, 3] = 1;
            G[4, 5] = 1;
            G[5, 4] = 1;
            return G;
        }
        
        //Одна вершина (n = 1)
        static int[,] Graph3()
        {
            int[,] G = new int[1, 1];
            return G;
        }

        //Связный граф, n = 4, один блок
        static int[,] Graph4()
        {
            int[,] G = new int[4, 4];
            G[0, 1] = 1;
            G[1, 0] = 1;
            G[0, 3] = 1;
            G[3, 0] = 1;
            G[1, 2] = 1;
            G[2, 1] = 1;
            G[2, 3] = 1;
            G[3, 2] = 1;
            return G;

        }

        //Пустой граф
        static int[,] Graph5()
        {
            int[,] G = new int[0, 0];
            return G;
        }
    }
}

