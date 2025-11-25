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
        static void Main(string[] args)
        {
            Intro();
        }

        static void Intro()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;

            Console.WriteLine("WELCOME TO MY PROGRAMMING QUIZ SHOW! PLACE YOUR NAME BELOW!");
            Console.ResetColor();

            Console.Write("Your name: ");

            playerName = Console.ReadLine();
        }
    }
}
