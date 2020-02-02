/*Quiz game v 2 - it's a game that read the questions from a text file. The application'll try to open the text file in application folder. 
 * If opening the text file fails, you will be asked for the file path.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;

namespace Quiz_app
{
    class Quiz_game
    {
        private static int points_Sum = 0;                                                           //Declarate a global integer of sum points.

        private static string file_Patch = "Quiz.txt";                                                            //Declarate a global string of question file patch.

        class Quiz
        {
            private int number;                                                                      //Declarate a integer of question number.

            private string content;                                                                  //Declarate a string of content.

            private string answer_A, answer_B, answer_C, answer_D;                                   //Declarate a string of answer from a to d.

            private string user_Answer, correct_Answer;                                              //Declarate a string of user and correct answer.

            public Quiz (int num)                                                                   //Constructor.
            {
                number = num;                                                                       //Assign a question number.

                Load();                                                                             //Calls a method Load().
            }

            private void Load()                                                                     //Method Load().
            {
                string [] lines = File.ReadAllLines (file_Patch);                                   //Assign file lines to string array.

                int first_Line = (number - 1) * 6;                                                  //Compute the first number of question.

                content = lines [first_Line];                                                       //Assign line 1 to variable.

                answer_A = lines [first_Line + 1];                                                  //Assign line 2 to variable.

                answer_B = lines [first_Line + 2];                                                  //Assign line 3 to variable.

                answer_C = lines [first_Line + 3];                                                  //Assign line 4 to variable.

                answer_D = lines [first_Line + 4];                                                  //Assign line 5 to variable.

                correct_Answer = lines [first_Line + 5];                                            //Assign line 6 to variable.

                Show();                                                                             //Calls a method Show().
            }

            private void Show()
            {
                Console.WriteLine(number + ". " + content);                                         //Show the question content.

                Console.WriteLine("a) " + answer_A);                                                //Show the answer a.

                Console.WriteLine("b) " + answer_B);                                                //Show the answer b.

                Console.WriteLine("c) " + answer_C);                                                //Show the answer c.

                Console.WriteLine("d) " + answer_D);                                                //Show the answer d.

                Console.Write("\nWrite answer a, b, c or d: ");                                     //Wait for user answer.

                CheckAnswer();
            }

            private void CheckAnswer()
            {
                user_Answer = Console.ReadLine();                                                   //Read user answer and assign it to variable.

                user_Answer = user_Answer.ToLower();                                                //Convert user answer to small letters.

                if (user_Answer == correct_Answer)
                {
                    Thread.Sleep(250);                                                              //Stop the console for 0.25 second.

                    Console.WriteLine("\nGood! You get a point!");

                    points_Sum += 1;                                                                //If user answer is true then add 1 point.

                    Thread.Sleep(2000);                                                             //Stop the console for 2 seconds.
                }

                else
                {
                    Thread.Sleep(250);                                                              //Stop the console for 0.25 second.

                    Console.WriteLine("\nThis is not the correct answer! You don't get a point!");

                    Console.WriteLine("The correct answer is {0}!", correct_Answer);                //If user answer is false then show the correct answer.

                    Thread.Sleep(6000);                                                             //Stop the console for 4 seconds.
                }
            }
        }

        static bool File_Exists(ref string patch)                                                   //Test if the quesion file exists.
        {
            if (! File.Exists (patch))                                                              //Negation.
            {
                Console.Write("\nThe question file doesn't exists!\nPlease enter the quesion file patch or write END to exit application: ");

                patch = Console.ReadLine();

                if (patch == "END")
                {
                    Environment.Exit(0);
                }

                return false;                                                                       //If the quesion file not exists return false.
            }

            else
            {
                return true;                                                                        //If the quesion file exists return true.
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("*************** C# Quiz ***************");

            Console.Write("Press ENTER to start the Quiz. Good Luck!");
            
            Console.ReadLine();

            while (! File_Exists (ref file_Patch));                                                 //Condition to stop the loop

            int how_Many_Questions = File.ReadLines(file_Patch).Count() / 6;                        //Compute number of questions in file.

            Quiz [] Question = new Quiz [how_Many_Questions];                                       //Declarate array of class Question.

            for (int question_Number = 0; question_Number < how_Many_Questions; question_Number++)  //For loop controls the question number.
            {
                Console.Clear();                                                                    //The method clear console.

                Question [question_Number] = new Quiz (question_Number + 1);                        //Creates new object of class Question.
            }

            Console.Clear();                                                                        //The method clear console.

            if (points_Sum == how_Many_Questions)
            {
                Console.WriteLine("Excellent! You got all {0} points!", points_Sum);
            }

            else if (points_Sum >= (how_Many_Questions * 0.67))
            {
                Console.WriteLine("Very Good! You got {0} points!", points_Sum);
            }

            else
            {
                Console.WriteLine("You got {0} points!", points_Sum);
            }

            Console.WriteLine("\n*************** End Quiz ***************");

            Console.ReadLine();
        }
    }
}
