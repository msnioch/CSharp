/*  Lotto random numbers lists v4. The program generates a number of suggestions lists.
 *  One suggestion list has 6 random numbers form 1 to 49. The numbers can't repeat.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto_random_numbers_lists
{
    class Lotto_app
    {
        class Lotto_generator
        {
            private List<int> list = new List<int>();                   //Create collection List<T>

            public void Print_list(int number, Random random)           //Print_list method of class Lotto_generator.
            {
                for (int number_counter = 0; number_counter < 6; number_counter++)
                {
                    int current_random = random.Next(1, 50);            //Create int random number from 1 to 49.

                    int test_counter = 0;                               //Declerate the counter and assign by 0.

                    while (test_counter < list.Count)                   //The random numbers can't repeat.
                    {
                        if (list[test_counter] == current_random)       //Test if the numbers in the list and current namber are the same.
                        {
                            current_random = random.Next(1, 50);        //If true generates new random number.

                            test_counter = 0;                           //If true assign the counter by 0.
                        }
                        else
                        {
                            test_counter++;                             //If the numbers aren't the same increment the counter by 1.
                        }
                    }

                    list.Add(current_random);                           //Add number to the list.
                }

                list.Sort();                                            //Sort the numbers in the list.

                Console.WriteLine("\nLotto numbers suggestion " + (number + 1));

                for (int k = 0; k < list.Count; k++)                    //Write the numbers list.
                {
                    Console.Write(list[k] + " ");
                }

                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("How many lotto suggestions should I generate? I can generate at most 25 suggestions.\n");

            Console.Write("Please enter a integer between 1 and 25: ");

            try
            {
                int how = Convert.ToInt32(Console.ReadLine());              //Convert user input to int.

                if (how <= 0 || how > 25)                                   //If the number <= 0 or number > 25.
                {
                    Console.WriteLine("\nThe number isn't correct. You should enter a integer between 1 and 25!");
                    
                    Console.ReadKey();                                      //Hold console after error.

                    System.Environment.Exit(0);                             //Exit programm after error.
                }

                Lotto_generator[] suggestion = new Lotto_generator[how];    //Numbers sugesstion array of class Lotto_generator.

                Random random = new Random();                               //Create random numbers of class Random.

                for (int number = 0; number < how; number++)
                {
                    suggestion[number] = new Lotto_generator();         //Create new suggestion object of class Lotto_generator.
                    suggestion[number].Print_list(number, random);  //Call Print_list method of object suggestion.
                }

                Console.WriteLine("\nGood Luck!");

            }

            catch (Exception e)
            {
                Console.WriteLine("\n" + e.Message);                        //If the number isn't an integer.
            }

            Console.ReadKey();                                              //Hold console after programm.
        }
    }
}