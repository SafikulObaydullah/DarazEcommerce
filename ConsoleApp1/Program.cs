using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            int n, d;
            int[] a = new int[7];

            
            n = int.Parse(Console.ReadLine());
            d = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the value of n and d");


            //input array elements
            Console.WriteLine("Enter the  array elements ");
            for (int i = 0; i < n; i++)
            {
                a[i] = Console.Read();
            }

            //print the elements of array after rotation
            Console.WriteLine("array elements after rotation : ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(a[(i + d) % n]+" ");
            }

        }
    
    }
}
