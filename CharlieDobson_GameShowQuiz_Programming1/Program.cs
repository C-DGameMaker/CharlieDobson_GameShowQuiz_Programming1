using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CharlieDobson_GameShowQuiz_Programming1
{
    internal class Program
    {
        static string playerName = "";
        static float totalQuestionAnswered = 1;
        static float totalCorrectAnswers;

        static bool isPlaying;
        static bool isPlayingAgain;
        static bool questionAnswer = false;

        static char input = ' ';

        static string[] questions = {"What color is my shirt?", "What color is the sky?", "..."};
        static char[] acceptableAnswer = {'1', '2', '3', '4' };
        static string[,] answers = 
        { 
            {"[1] Green", "[2] Gray", "[3] Blue", "[4] Red"},
            {"[1] Green", "[2] Gray", "[3] Blue", "[4] Red"},
            {"[1] Green", "[2] Gray", "[3] Blue", "[4] Red"},
            {"[1] Green", "[2] Gray", "[3] Blue", "[4] Red"},
            {"[1] Green", "[2] Gray", "[3] Blue", "[4] Red"},
            {"[1] Green", "[2] Gray", "[3] Blue", "[4] Red"},
        };

        static char[] actualAnswers = {'1', '1', '1' };
        //╔╗═╚╝║
        static void Main(string[] args)
        {
            //Intro();
            Console.Clear();
            isPlaying = true;
            while (isPlaying == true)
            {
                totalCorrectAnswers = 0;

                Questions();
                Console.Clear();
                HUD();

                Console.WriteLine($"Out of {questions.Length} questions, you got {totalCorrectAnswers} right!");

                while (isPlayingAgain == false)
                {
                    Console.WriteLine("PLAY AGAIN? Y/N");
                    string input = Console.ReadLine();

                    if (input == "Y" || input == "y")
                    {
                        isPlayingAgain = true;
                        isPlaying = true;
                        Console.Clear();
                    }
                    if (input == "N" || input == "n")
                    {
                        isPlayingAgain = true;
                        isPlaying = false;
                    }
                }

            }

            Console.Clear();
            Console.ReadKey(true);
        }

        static void Intro()
        {
            Console.Write("╔═════════════════════════════════════╗\n");
            Console.Write("║");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;

            Console.Write("WELCOME TO MY PROGRAMMING QUIZ SHOW!");
            Console.ResetColor();
            Console.Write(" ║ \n");
            Console.Write("║");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;

            Console.Write("INSERT YOUR NAME BELOW!");
            Console.ResetColor();

            Console.Write("              ║ \n");
            
            Console.Write("╚═════════════════════════════════════╝\n");
            Console.Write("Your name: ");
            playerName = Console.ReadLine();

        }

        static void Questions()
        {
            for(int i = 0; i < questions.Length; i++)
            {
                questionAnswer = false;
                while(questionAnswer == false)
                {
                    HUD();
                    Console.Write("═════════════════════════════════════════\n");
                    Console.Write($"Question {i + 1}/{questions.Length}: {questions[i]} \n");
                    Console.ResetColor();
                    Console.WriteLine("═════════════════════════════════════════");
                    for(int j = 0; j < answers.GetLength(1); j++)
                    {
                        Console.Write("           ");
                        Console.Write(answers[i, j]);
                        Console.Write("\n");
                    }
                    Console.Write("═════════════════════════════════════════\n");
                    Console.WriteLine("What is the answer?");
                    Console.Write("Your answer: ");

                    input = Console.ReadKey().KeyChar;
                    if (!acceptableAnswer.Contains((char)(input)))
                    {
                        Console.Write("PLEASE PUT ACCEPTABLE ANSWER!");
                        Thread.Sleep(10000);
                        Console.Clear();

                    }

                    if(input == actualAnswers[i])
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("CORRECT!");
                        totalCorrectAnswers++;
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("INCORRECT!");
                        Console.ResetColor();
                    }


                    if(i > 0)
                    {
                        totalQuestionAnswered++;
                    }
                    
                    Console.ReadKey(true);
                    Console.Clear();
                    questionAnswer = true;
                }
                
            }
        }

        static void HUD()
        {
            Console.Write("═════════════════════════════════════════\n");
            Console.WriteLine($"Player Name: {playerName}     Questions right {totalCorrectAnswers/totalQuestionAnswered * 100 }%");
            Console.Write("═════════════════════════════════════════\n");
        }

        
    }
}
