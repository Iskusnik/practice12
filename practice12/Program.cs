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


        static int[] BinTreeSort(int[] arr, out int compar, out int swps)
        {
            TreeNode top = new TreeNode(arr[0]);
            TreeNode mark = top;
            bool check = false;
            int compares = 0, swaps = 0;

            #region Создание дерева
            for (int i = 1; i < arr.Length; i++)
            {
                mark = top;
                check = false;

                while (!check)
                {
                    if (arr[i] <= mark.info)
                    {
                        compares++;
                        if (mark.left == null)
                        {
                            mark.left = new TreeNode(arr[i], mark);
                            check = true;
                            swaps++;
                        }
                        else
                            mark = mark.left;
                    }
                    else
                        if (mark.right == null)
                    {
                        mark.right = new TreeNode(arr[i], mark);
                        check = true;
                        swaps++;
                    }
                    else
                        mark = mark.right;
                }
                check = false;
            }
            #endregion

            #region Сбор дерева
            mark = top;
            for (int i = 0; i < arr.Length; i++)
            {
                check = false;

                while (!check)
                {
                    if (mark.left != null && !mark.left.visited)
                        mark = mark.left;
                    else
                        if (mark.right != null && !mark.right.visited)
                    {

                        swaps++;
                        arr[i] = mark.info;
                        mark.visited = true;
                        mark = mark.right;
                        check = true;
                    }
                    else
                    {
                        if (!mark.visited)
                        {
                            swaps++;
                            arr[i] = mark.info;
                            mark.visited = true;
                            check = true;
                        }
                        mark = mark.father;
                    }
                }


            }
            #endregion

            swps = swaps;
            compar = compares;
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
                        arr[i] = arr[i - 1];
                        arr[i - 1] = temp;
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

            #region Сортировка неупорядоченного массива
            Console.WriteLine("Сортировка неупорядоченного массива");
            Console.WriteLine("Исходный массив");
            PrintArray(info);
            Console.WriteLine("");

            Console.WriteLine("Сортировка перемешиванием");
            sort1 = CocktailSort(sort1, out compares, out swaps);
            PrintArray(sort1);
            Console.WriteLine("Сравнений - {0}, перестановок - {1}", compares, swaps);

            Console.WriteLine("");

            Console.WriteLine("Сортировка бинарным дереовом");
            sort2 = BinTreeSort(sort2, out compares, out swaps);
            PrintArray(sort2);
            Console.WriteLine("Сравнений - {0}, перестановок - {1}", compares, swaps);

            Console.WriteLine("Любая клавиша для продолжения");
            Console.ReadKey();
            #endregion

            #region Сортировка упорядоченного по возрастанию массива
            Console.WriteLine("Сортировка упорядоченного по возрастанию массива");
            for (int i = 0; i < n; i++)
            {
                info[i] = i;
                sort1[i] = info[i];
                sort2[i] = info[i];
            }
            Console.WriteLine("Исходный массив");
            PrintArray(info);
            Console.WriteLine("");

            Console.WriteLine("Сортировка перемешиванием");
            sort1 = CocktailSort(sort1, out compares, out swaps);
            PrintArray(sort1);
            Console.WriteLine("Сравнений - {0}, перестановок - {1}", compares, swaps);

            Console.WriteLine("");

            Console.WriteLine("Сортировка бинарным дереовом");
            sort2 = BinTreeSort(sort2, out compares, out swaps);
            PrintArray(sort2);
            Console.WriteLine("Сравнений - {0}, перестановок - {1}", compares, swaps);
            Console.WriteLine("Любая клавиша для продолжения");
            Console.ReadKey();
            #endregion

            #region Сортировка упорядоченного по убыванию массива
            Console.WriteLine("Сортировка упорядоченного по убыванию массива");
            for (int i = 0; i < n; i++)
            {
                info[i] = -i;
                sort1[i] = info[i];
                sort2[i] = info[i];
            }
            Console.WriteLine("Исходный массив");
            PrintArray(info);
            Console.WriteLine("");

            Console.WriteLine("Сортировка перемешиванием");
            sort1 = CocktailSort(sort1, out compares, out swaps);
            PrintArray(sort1);
            Console.WriteLine("Сравнений - {0}, перестановок - {1}", compares, swaps);

            Console.WriteLine("");

            Console.WriteLine("Сортировка бинарным дереовом");
            sort2 = BinTreeSort(sort2, out compares, out swaps);
            PrintArray(sort2);
            Console.WriteLine("Сравнений - {0}, перестановок - {1}", compares, swaps);
            Console.WriteLine("Любая клавиша для завершения");
            Console.ReadKey();
            #endregion

        }
    }
}
