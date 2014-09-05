using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

      static void Main()
      {
         //Loopingthreads();

         //int i = 1;
         // foreach (int[] d in Data)
         // {

         //    Thread t1 = new Thread(() =>
         //    {
         //       int smallest = FindSmallest(d);
         //       Console.WriteLine("Tråd " + i + ": " + String.Join(", ", d) + "\nMindste værdi -> " + smallest + "\t");
         //       i++;
         //    });

         //    t1.Start();

         // }
         //int i = 1;
         List<Task<int>> minAndenOpgs = new List<Task<int>>();

         foreach (int[] d in Data)
         {
            Task<int> minAndenOpg = new Task<int>(() =>
            {
               int tempResult = FindSmallest(d);
               Console.WriteLine(String.Join(", ", d) + "\nMindste værdi -> " + tempResult + "\t");
               return tempResult;
               
            });
            minAndenOpg.Start();
            minAndenOpgs.Add(minAndenOpg);
            //minAndenOpg.Start();

            //Thread t = new Thread(() =>
            //{          
            //   int tempResult = FindSmallest(d);
            //   Console.WriteLine(String.Join(", ", d) + "\nMindste værdi -> " + tempResult + "\t");
            //});

            //t.Start();
         }

         Task.WaitAll(minAndenOpgs.ToArray());
         int smallest = minAndenOpgs[0].Result;

         foreach (Task<int> t in minAndenOpgs)
         {
            if (t.Result < smallest)
            {
               smallest = t.Result;
            }
            Console.WriteLine(smallest);
         }

         
         //Console.Write(string.Join(";", mylist));
      }
   }
}
