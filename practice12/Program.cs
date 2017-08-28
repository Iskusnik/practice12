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
        /// 5.	Сортировка с помощью двоичного дерева.
        /// 2.	Сортировка перемешиванием.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Random r = new Random();
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
            Console.WriteLine();
            for (int i = 0; i < n; i++)
                Console.Write(" " + info[i].ToString());

            Console.WriteLine("Любая клавиша для продолжения");
            Console.ReadKey();
        }
    }
}
