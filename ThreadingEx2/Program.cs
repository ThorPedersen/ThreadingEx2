using System;
using System.Threading;

namespace FindSmallest
{
    class Program
    {

        private static readonly int[][] Data = new int[][]{
            new[]{1,5,4,2}, 
            new[]{3,2,4,11,4},
            new[]{33,2,3,-1, 10},
            new[]{3,2,8,9,-1},
            new[]{1, 22,1,9,-3, 5}
        };

       

        private static int FindSmallest(int[] numbers)
        {
            if (numbers.Length < 1)
            {
                throw new ArgumentException("There must be at least one element in the array");
            }

            int smallestSoFar = numbers[0];
            foreach (int number in numbers)
            {
                if (number < smallestSoFar)
                {
                    smallestSoFar = number;
                }
            }
            return smallestSoFar;
        }

        public static void Loopingthreads()
       {
          //int i;
          //foreach (int[] d in Data)
          //{

          //   Thread t1 = new Thread(() =>
          //   {
          //      int smallest = FindSmallest(d);
          //      Console.WriteLine("Tråd " + i + ": " + String.Join(", ", d) + "\nMindste værdi -> " + smallest + "\t");
          //   });

          //   t1.Start();
          //   i++;

          //}
       }

        static void Main()
        {

           //Loopingthreads();

           int i = 1;
            foreach (int[] d in Data)
            {

               Thread t1 = new Thread(() =>
               {
                  int smallest = FindSmallest(d);
                  Console.WriteLine("Tråd " + i + ": " + String.Join(", ", d) + "\nMindste værdi -> " + smallest + "\t");
               });

               t1.Start();
               i++;

            }
        }
    }
}
