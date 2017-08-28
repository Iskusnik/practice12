using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice12
{
    class Program
    {
        /// <summary> (5,2)
        /// 1. Сравнение по количеству пересылок и сравнений
        /// 2. Неупорядоченный, по возрастанию, по убыванию
        /// 3.
        /// 
        /// 5.	Сортировка с помощью двоичного дерева.
        /// 2.	Сортировка перемешиванием.
        /// </summary>
        /// <param name="args"></param>
        /// 


        static int[] BinTreeSort(int[] arr)
        {
            return arr;
        }

        static int[] CocktailSort(int[] arr, out int compar, out int swps)
        {
            int l = 0, r = arr.Length - 1; //границы неотсортированной части
            int temp, comparisons = 0, swaps = 0;

            while (l <= r)
            {
                for (int i = l; i < r; i++)
                {
                    comparisons++;
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swaps++;
                    }
                }
                r--;

                for (int i = r; i > l; i--)
                {
                    comparisons++;
                    if (arr[i] < arr[i - 1])
                    {
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swaps++;
                    }
                }
                l++;
            }
            compar = comparisons;
            swps = swaps;
            return arr;
        }

        static void PrintArray(int[] arr)
        {
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
                Console.Write(" " + arr[i].ToString());
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Random r = new Random();
            int compares, swaps;
            Console.WriteLine("Ввод количества элементов");
            int n = int.Parse(Console.ReadLine());
            int[] info = new int[n];
            int[] sort1 = new int[n]; 
            int[] sort2 = new int[n]; 
            Console.WriteLine("0 - Ручное заполнение");
            if (0 == int.Parse(Console.ReadLine()))
                for (int i = 0; i < n; i++)
                {
                    info[i] = int.Parse(Console.ReadLine());
                    sort1[i] = info[i];
                    sort2[i] = info[i];
                }
            else
                for (int i = 0; i < n; i++)
                {
                    info[i] = r.Next(-100, 101);
                    sort1[i] = info[i];
                    sort2[i] = info[i];
                }
            
            
            Console.Clear();
            PrintArray(info);

            Console.WriteLine("Любая клавиша для продолжения");
            Console.ReadKey();

            Console.WriteLine("Сортировка неупорядоченного массива");
            Console.WriteLine("Сортировка перемешиванием");

            info = CocktailSort(info, out compares, out swaps);
            PrintArray(info);

        }
    }
}
