using System;
using System.Threading;
using System.Collections;


namespace Lab_2
{
    class Lab_2
    {
        static public List<int> result = new List<int>();
        static object lokerOne = new object();
        static object lokerTwo = new object();
        static public bool t = true;
        static int c = 0;
        static void Main(string[] args)
        {

            Thread sortTh = new Thread(ListSort);
            sortTh.Start();
            Thread num = new Thread(NumberToList);
            num.Start();

            Thread.Sleep(6000);

            Console.WriteLine("Task 2");
            for (int i = 1; i < 6; i++)
            {
                Thread myThread = new(Constukt);
                myThread.Name = $"Thread {i} ";
                myThread.Start();
            }

        }
        static void NumberToList()
        {
            lock (lokerOne)
            {
                while (true)
                {
                    Console.WriteLine("Write number");
                    var n = Console.ReadLine();
                    if (int.TryParse(n, out int number))
                    {
                        result.Add(number);

                    }
                    else if (!n.All(char.IsDigit))
                    {
                        Console.WriteLine("Invalid format string");
                    }
                    else { t = false; break; }
                }

                Console.WriteLine("List Sorted");
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }


        }

        static void ListSort()
        {
            while (t)
            {
                result.Sort();
                Thread.Sleep(3000);
            }
        }



        static void Constukt()
        {
            lock (lokerTwo)
            {
                int k = 0;
                while (k < 5)
                {
                    C_metod(c);
                    Console.WriteLine($"{Thread.CurrentThread.Name}" + "Finish construction ");
                    Console.WriteLine($"{Thread.CurrentThread.Name}" + "Constracted = " + k);
                    k++;
                }
            }
        }
        static void C_metod(int cn)
        {

            int a = 0, b = 0;
            a = A_metod(a);
            b = B_metod(b);
            cn = Math.Abs(b + a);
            Console.WriteLine($"{Thread.CurrentThread.Name}" + "Asscembel in C ");
            Thread.Sleep(3000);

        }
        static int B_metod(int bn)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}" + "Asscembel in B ");
            bn = 1;
            Thread.Sleep(2000);
            return bn;
        }
        static int A_metod(int an)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}" + "Asscembel in A ");
            an = 1;
            Thread.Sleep(1000);
            return an;
        }



    }

}
