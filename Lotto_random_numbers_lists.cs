using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Lotto_random_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> li = new List<int>();         //Collection List<T>

            Random random = new Random();

            for (int i = 0; i < 6; i++)
            {
                int number = random.Next(1, 50);    //Random number from 1 to 49.

                int a = 0;

                while (a < li.Count)                 //The random numbers can't repeat.
                {
                    if (li[a] == number)             //If the numbers repeat.
                    {
                        number = random.Next(1, 50);

                        a = 0;
                    }
                    else
                    {
                        a++;
                    }
                }

                li.Add(number);                     //Add number to the list.
            }

            li.Sort();                              //Sort the numbers in the list.

            for (int j = 0; j < li.Count; j++)      //Show the list.
            {
                Console.Write(li[j] + " ");
            }

            Console.ReadKey();                      //To hold the programm.
        }
    }
}