/* Quiz game v5 - it's a game that read the questions from a text file. The application'll try to open the text file in application folder. 
   If opening the text file fails, you will be asked for the file path.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;

namespace Quiz_app
{
    class Quiz_game
    {
        private static int points_Sum = 0;                                                          //Declarate global integer of sum points.

        private static string file_Patch = "Quiz.txt";                                              //Declarate global string of question file patch.

        class Quiz
        {
            private int number;                                                                     //Declarate integer of question number.

            private string content;                                                                 //Declarate string of content.

            private string answer_A, answer_B, answer_C, answer_D;                                  //Declarate string of answer from a to d.

            private string user_Answer, correct_Answer;                                             //Declarate string of user and correct answer.

            public Quiz (int num)                                                                   //Constructor.
            {
                number = num;                                                                       //Assign variable question number.

                Load();
            }

            private void Load()
            {
                string [] lines = File.ReadAllLines (file_Patch);                                   //Assign file lines to string array.

                int first_Line = (number - 1) * 6;                                                  //Compute the first line number for current question.

                content = lines [first_Line];                                                       //Assign temporary_Line 0, 6, 12 ... to variable content.

                answer_A = lines [first_Line + 1];                                                  //Assign temporary_Line 1, 7, 13 ... to variable answer_A.

                answer_B = lines [first_Line + 2];                                                  //Assign temporary_Line 2, 8, 14 ... to variable answer_B.

                answer_C = lines [first_Line + 3];                                                  //Assign temporary_Line 3, 9, 15 ... to variable answer_C.

                answer_D = lines [first_Line + 4];                                                  //Assign temporary_Line 4, 10, 16 ... to variable answer_D.

                correct_Answer = lines [first_Line + 5];                                            //Assign temporary_Line 5, 11, 17 ... to variable correct_Answer.

                Show();                                                                             //Calls a method Show().
            }

            private void Show()
            {
                Console.WriteLine(number + ". " + content);                                         //Show the question content.

                Console.WriteLine("a) " + answer_A);                                                //Show the answer a.

                Console.WriteLine("b) " + answer_B);                                                //Show the answer b.

                Console.WriteLine("c) " + answer_C);                                                //Show the answer c.

                Console.WriteLine("d) " + answer_D);                                                //Show the answer d.

                Console.Write("\nWrite correct answer a, b, c or d and press ENTER: ");             //Show the user answers.

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

                    points_Sum++;                                                                   //If user answer is true then add 1 point.

                    Thread.Sleep(2000);                                                             //Stop the console for 2 seconds.
                }

                else
                {
                    Thread.Sleep(250);                                                              //Stop the console for 0.25 second.

                    Console.WriteLine("\nThis is not the correct answer! You don't get a point!");

                    Console.WriteLine("The correct answer is {0}!", correct_Answer);                //If user answer is false then show the correct answer.

                    Thread.Sleep(6000);                                                             //Stop the console for 6 seconds.
                }
            }
        }

        static bool File_Exists (ref string patch)                                                  //Method test if the file exists with input of file patch (by reference).
        {
            if (! File.Exists (patch))                                                              //Negation if the patch is correct.
            {
                Console.Write("\nThe question file doesn't exists!\nPlease write the quesion file patch or write END then press ENTER to exit application: ");

                patch = Console.ReadLine();                                                         //Change file patch or exit application with command END.

                if (patch == "END")
                {
                    Environment.Exit(0);                                                            //Exit application.
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
            
            Console.ReadLine();                                                                     //Stop console.

            while (! File_Exists (ref file_Patch));                                                 //If the file not exsist, the condition is true. Send file_Patch by reference.

            int how_Many_Questions = File.ReadLines(file_Patch).Count() / 6;                        //Compute number of questions in file. One question has 6 lines. Count() function return number of lines in file.

            Quiz [] Question = new Quiz [how_Many_Questions];                                       //Declarate array of class Question.

            for (int question_Number = 0; question_Number < how_Many_Questions; question_Number++)  //Loop controls question number.
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

            Console.Write("Press ENTER to exit.");

            Console.ReadLine();                                                                 //Stop console.
        }
    }
}