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

            public void Print_list(int i, Random random)                //Print_list method of class Lotto_generator.
            {
                for (int j = 0; j < 6; j++)
                {
                    int number = random.Next(1, 50);                    //Create int random number from 1 to 49.

                    int a = 0;                                          //Declerate the counter a and assign by 0.

                    while (a < list.Count)                              //The random numbers can't repeat.
                    {
                        if (list[a] == number)                          //Test if the numbers in the list and current namber are the same.
                        {
                            number = random.Next(1, 50);                //If true generates new random number.

                            a = 0;                                      //If true assign the counter a by 0.
                        }
                        else
                        {
                            a++;                                        //If the numbers aren't the same increment the counter a by 1.
                        }
                    }

                    list.Add(number);                                   //Add number to the list.
                }

                list.Sort();                                            //Sort the numbers in the list.

                Console.WriteLine("\nLotto numbers suggestions " + (i + 1));

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

                for (int i = 0; i < how; i++)
                {
                    suggestion[i] = new Lotto_generator();                  //Create new suggestion object of class Lotto_generator.
                    suggestion[i].Print_list(i, random);                    //Call Print_list method of object suggestion.
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