using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharlieDobson_GameShowQuiz_Programming1
{
    internal class Program
    {
        static string playerName = "";
        static int curQuestion;
        static int totalQuestion;
        static int totalCorrectAnswers;

        static bool isPlaying;
        static bool isPlayingAgain;

        static string[] questions = { };
        static string[,] answers = { { } };

        //╔╗═╚╝║
        static void Main(string[] args)
        {
            Intro();
            Console.Clear();
            isPlaying = true;
            while (isPlaying == true)
            {
                totalCorrectAnswers = 0;

                Questions();

                while (isPlayingAgain == false)
                {
                    Console.WriteLine("PLAY AGAIN? Y/N");
                    string input = Console.ReadLine();

                    if (input == "Y" || input == "y")
                    {
                        isPlayingAgain = true;
                        isPlaying = true;
                    }
                    if (input == "N" || input == "n")
                    {
                        isPlayingAgain = true;
                        isPlaying = false;
                    }
                }

            }
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
            for(int i = 0; i < 10; i++)
            {

            }
        }
    }
}
