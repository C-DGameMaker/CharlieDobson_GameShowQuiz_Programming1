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
        //Player stuff
        static string playerName = "Cookie";
        static float totalQuestionAnswered = 1;
        static float totalCorrectAnswers;

        //You'll never guess. Its the title
        static string title = " .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------. \r\n| .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |\r\n| |  _________   | || |  _______     | || |     _____    | || | ____   ____  | || |     _____    | || |      __      | |\r\n| | |  _   _  |  | || | |_   __ \\    | || |    |_   _|   | || ||_  _| |_  _| | || |    |_   _|   | || |     /  \\     | |\r\n| | |_/ | | \\_|  | || |   | |__) |   | || |      | |     | || |  \\ \\   / /   | || |      | |     | || |    / /\\ \\    | |\r\n| |     | |      | || |   |  __ /    | || |      | |     | || |   \\ \\ / /    | || |      | |     | || |   / ____ \\   | |\r\n| |    _| |_     | || |  _| |  \\ \\_  | || |     _| |_    | || |    \\ ' /     | || |     _| |_    | || | _/ /    \\ \\_ | |\r\n| |   |_____|    | || | |____| |___| | || |    |_____|   | || |     \\_/      | || |    |_____|   | || ||____|  |____|| |\r\n| |              | || |              | || |              | || |              | || |              | || |              | |\r\n| '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |\r\n '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------' \r\n                     .----------------.  .----------------.  .----------------.  .----------------.                     \r\n                    | .--------------. || .--------------. || .--------------. || .--------------. |                    \r\n                    | |    ______    | || |      __      | || | ____    ____ | || |  _________   | |                    \r\n                    | |  .' ___  |   | || |     /  \\     | || ||_   \\  /   _|| || | |_   ___  |  | |                    \r\n                    | | / .'   \\_|   | || |    / /\\ \\    | || |  |   \\/   |  | || |   | |_  \\_|  | |                    \r\n                    | | | |    ____  | || |   / ____ \\   | || |  | |\\  /| |  | || |   |  _|  _   | |                    \r\n                    | | \\ `.___]  _| | || | _/ /    \\ \\_ | || | _| |_\\/_| |_ | || |  _| |___/ |  | |                    \r\n                    | |  `._____.'   | || ||____|  |____|| || ||_____||_____|| || | |_________|  | |                    \r\n                    | |              | || |              | || |              | || |              | |                    \r\n                    | '--------------' || '--------------' || '--------------' || '--------------' |                    \r\n                     '----------------'  '----------------'  '----------------'  '----------------'                     ";

        //My perfect little bools of children
        static bool isPlaying;
        static bool isPlayingAgain;
        static bool questionAnswer = false;

        //For question answering
        static char input = ' ';

        //My question colors! A reference to How a lot of Nintendo (and probably other) format their 1st - 4th player cards. (blue is player 1, red is player 2, green is player 3, and yellow is player 4.)
        static ConsoleColor[] answerColor = {ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow};

        //My questions! I formatted them like this as I felt it worked better. 
        static string[] questions = 
        {
            "What varible type is used to store whole numbers?", 
            "What Varible stores either true or false", 
            "What kind of programming language is this program made in? (hint: its the same one we've been using)", 
            "Can a MatchBox?", //This is in reference to the impossible quiz, spefically off of wordplay
            "How do you set the text color?", 
            "How do you set background color?",
            "How to read from a text file?",
            "In unity and using code, how can you make an object move back and forth?",
            "Who is NOT a survivor of Super Danganronpa 2: Goodbye Despair?", //More about this in the answer
            "How to make multiple methods with the same name?"
        };

        //The written answers! Its a 2d array as it prints them in order. 
        static string[,] answers =
       {
            {"[1] Int", "[2] Double", "[3] Float", "[4] Char"},
            {"[1] Float", "[2] Char", "[3] String", "[4] Bool"},
            {"[1] Java", "[2] C#", "[3] BASIC", "[4] Pascal"},
            {"[1] Yes", "[2] No", "[3] No but a Tin Can", "[4] Yes, One beat Mike Tyson"}, //Which is why the answer is 3, because a Tin can box. Get it? When it was mentioned for two joke questions I wanted to do this
            {"[1] Console.SetTextColor", "[2] Console.ForegroundColor", "[3] Console.SetColor", "[4] You cannot change the text color."}, 
            {"[1] Console.BackgroundColor", "[2] Console.SetBackColor", "[3] Console.BackgrundColor", "[4] You cannot change the background color"},
            {"[1] You can't", "[2] Console.File(Path)", "[3] File.ReadAllLine(Path)", "[4] Console.ReadFile(path)"},
            {"[1] SmoothDamp", "[2] Lerp", "[3] Transform.Translate", "[4] All of the above"},
            {"[1] Hajime", "[2] Fuyuhiko", "[3] Sonia", "[4] Peko"}, //While this techincal answer is false, as its reveal the entire game was a sim and shit, Peko still died in game so im counting her here
            {"[1] You don't need to change anything", "[2] Change the requirements for the method", "[3] All of the answers", "[4] You Can't"},
        };

        //A char array of the 4 acceptable answers. NGL I was inspired to do this because of the slowshooter because it made sense like this to me
        static char[] acceptableAnswer = {'1', '2', '3', '4' };
       
        //Another array of chars, but these are the actual answers. 
        static char[] actualAnswers = {'1', '4', '2', '3', '2', '1', '3', '4', '4', '2'};
        
        static void Main(string[] args)
        {
            RunIntro();
            Console.Clear();
            isPlaying = true;
            while (isPlaying == true)
            {
                totalCorrectAnswers = 0;
                totalQuestionAnswered = 0;

                Questions();
                Console.Clear();
                HUD();
                //My other part of my shameless rhythm heaven ripoff- I mean reference
                Console.Write($"Out of {questions.Length} questions,");
                Thread.Sleep(500);
                Console.WriteLine($" you got {totalCorrectAnswers} right!");
                Thread.Sleep(2000);
                Rank();
                Console.ReadKey(true);

                Console.WriteLine("        ");
                EasterEgg();
                Console.ReadKey(true);
                Console.Clear();

                
                //This will check if you're playing again. if not, everything is clear and you can exit. If so.. everyting is also clear but you can go again
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

        //This just runs the intro.
        static void RunIntro()
        {
            //Making it look pretty!
            Console.Write("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════\n");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;

            //Title goes here. 
            Console.Write(title);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition(45,23);
            Console.Write("INSERT YOUR NAME BELOW!\n");
            Console.ResetColor();

            Console.Write("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════\n");
            //This reads your player name that gets display for the HUD
            Console.Write("Your name: ");
            playerName = Console.ReadLine();

        }

        //This runs through all questions
        static void Questions()
        {
            //This is so the numvber of questions can change
            for(int i = 0; i < questions.Length; i++)
            {
                //Resets if the question is answered
                questionAnswer = false;
                while(questionAnswer == false)
                {//Write the hud first, then  goes through the question to answer it. 
                    HUD();
                    Console.Write("═════════════════════════════════════════\n");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($"  Question {i + 1}/{questions.Length}: {questions[i]}  \n");
                    Console.ResetColor();
                    Console.WriteLine("═════════════════════════════════════════");
                    for(int j = 0; j < answers.GetLength(1); j++)
                    {
                        Console.ForegroundColor = answerColor[j];
                        Console.Write("           ");
                        Console.Write(answers[i, j]);
                        Console.Write("\n");
                        Console.ResetColor();
                    }
                    Console.Write("═════════════════════════════════════════\n");
                    Console.WriteLine("What is the answer?");
                    Console.Write("Your answer: ");

                    //Takes your input, waits, then checks if it's acceptable before if its right
                    input = Console.ReadKey().KeyChar;
                    Thread.Sleep(250);
                    if (!acceptableAnswer.Contains((char)(input)))
                    {
                        Console.Write("PLEASE PUT ACCEPTABLE ANSWER!");
                        Thread.Sleep(1000);
                        Console.Clear();

                    }

                    //If you get it correct, it turns green, if not red. And it adds to your total correct answers
                    if(input == actualAnswers[i])
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("CORRECT!");
                        Console.ResetColor();
                        totalCorrectAnswers++;
                        
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("INCORRECT!");
                        Console.ResetColor();
                        
                        
                    }

                    //Displays the hud at the end, then clears and goes back to the top. If the question.length is done, then goes to result
                    if(i > 0)
                    {
                        totalQuestionAnswered++;
                    }
                    HUD();

                    Console.ReadKey(true);
                    Console.Clear();
                    questionAnswer = true;
                }
                
            }
        }

        static void HUD()
        {
            //My HUD!. Nothing too special its just a hud
            Console.Write("═════════════════════════════════════════\n");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Player Name:{playerName}  Current Score: {totalCorrectAnswers/totalQuestionAnswered * 100 }%" +
                $"");
            Console.ResetColor();
            Console.Write("═════════════════════════════════════════\n");
        }

        static void Rank()
        {
            //My shameless Rhythm Heaven reference. 
            if ((totalCorrectAnswers / totalQuestionAnswered * 100) < 60)
            {
                //Checks if its less than 60, then displays this. 
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Study more...");
                Console.ResetColor();
            }
            else if ((totalCorrectAnswers / totalQuestionAnswered * 100) < 80)
            {
                //If above 60 but less than 80, its this. 
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("But it was just okay");
                Console.ResetColor();
            }
            else if ((totalCorrectAnswers / totalQuestionAnswered * 100) < 100)
            {
                //If above 80, but less then 100, this. 
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Supberb!");
                Console.ResetColor();
            }
            else if ((totalCorrectAnswers / totalQuestionAnswered * 100) == 100)
            {
                //And finally, the perfect score for 100%
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("PERFECT!");
                Console.ResetColor();
            }
        }

        static void EasterEgg()
        {
            //MY EASTER EGGS. Both things are stuff I drew myself. As well as both names being a reference to my ocs! And a link to my tumblr
            if (playerName == "Atlas")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("==========================================================================================\r\n==========================================================================================\r\n==========================================================================================\r\n==========================================================================================\r\n==========================================================================================\r\n=============================+#############%%#+====#*=====================================\r\n==========================*######################=####%===================================\r\n=========================*#%%%%%%#######################*=================================\r\n=========================#%%%%%%%%%%%%@##################+================================\r\n========================%%%%%%%%%%%%%%%%#################*================================\r\n=======================*%%%%%%%%%%%%%%@##%*+*%############================================\r\n=======================%%%%%%%%%%%%%%%%........*###@%%@#%*==++============================\r\n======================+%%%%%%%%%%%%%%=......-...+#%%%%%%%%%%%%*===========================\r\n=====================%%%%%%%%%%%%%@%*.....:%#+..-%%%%%@@@@@%%%+===========================\r\n======================*%%%%%%@@@##%%*:....-@@=..=%%%%%%%%@%%%%============================\r\n=======================*###*%%%+==+++==*==+*%...%#%%%@%%%%@%%#============================\r\n========================+#%##=======*++==+====+%%@%%%%%%%@%%%%============================\r\n==========================%%+============++===+#%@@@@@@@%@**+=============================\r\n=========================%%%+===============+++####%@%%@%%##*=============================\r\n========================#%##%++==========*++++#####%@%##@%#*#+============================\r\n=======================*####%%@*+++++++++++++###@%@@%%#**%================================\r\n======================%#####%%%--------=**=--%#@@%#####%@=================================\r\n=====================######%%%..............+#@@%%#######*#+==============================\r\n===================*#######%%#..............+#@%%########***++============================\r\n=================+########%%%%#%%#*+=====+#%%%#%%%####%***-....=#+========================\r\n================##########%%%**********###%####%%%###***-.....-**%========================\r\n==============###########%%%-........:-=######=####**+:......+**#*========================\r\n============*###########%%%=.......:-+#####%=:.=###+.......=***%###=======================\r\n===========############%%%#**+++++*######%*++==*#----....+***#%#####%=====================\r\n==========+###########%%#+****#%######%##*******#%----=*****%#########%*==================\r\n==========+#########%%#....-+########=-::---=====+**####*#%##############%================\r\n===========######%%%#+...+%######%=-..............-%##%%%%%#################%*============\r\n==============%%%%#%##%%######%*=-................:-----=%%%%%%#################%%@+======\r\n=============+%%%%%%#######%%##*****##*************#########%%%%%%%%%%#######%%%%#========\r\n==========*%#%%%#%#######--....::::::---------=+++*%%@@@%%%%%##+###%%%%%%%%%%%#===========\r\n=========*%#%%%%#@%%%%%%##**++====--:..............%#%%%%%%%%%@*==========================\r\n=========%##%%%##%%%%%@%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%@@@@@@@@@@@*=========================\r\n========*##%##%%%%%%%%@@@@@@@@@@@@@@@@@@@%%%%%%%%%@@@@@@@@@@@@@@@%========================\r\n========##%*+%##%%%%%@@%%%%%%%%%%%%%%%%@@@@@@@@@@@@@@@@@@@@@@@@@@@@%*=====================\r\n========%#%%%%##%%%%%@@%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%@@@@@@@@@@@@@@@@%===================\r\n========%#%%%%##%%%%%@%%%%%%%%%%%@@%%%%%%%%%%%%%%%%@@@@@@@@@@@@@@@@@@@@%==================\r\n========%#%%%##%%%%%@@%%%%%%%%%%%@@%%%%%%%%%%%%%%%@@@@@@@@@@@@@@@@%%%%@===================\r\n========%%%%%##%%%%%@%%%%%%%%%%%@@%%%%%%%%%%%%%%%@@@@@@@@@@@@@%%%%%%%%%===================\r\n===========#%##%%##%@@@%%%%%%%%@@@@@@@@@@@@@@@@@@@@@@@@@%%%%%%%*-%#=--+===================\r\n=====================+=*#%%%%%%*-:-----==+*###%%%%%%%%%%%%%%%%=-=+=-======================\r\n================+*==++++-:....................:--%%%%%%%%%%#---=+-=+======================\r\n===========*===========++++++--:............:---*%%%%%%#++-----=*+========================\r\n===============++==========++++++++++******+++***++++++++==+#+============================\r\n==============+++++++++++=========++++++*++++++++++============+++==+==+==================\r\n=============++++++++++++++++++*++++++++%++++*+===================+++*+===================\r\n===========+++++++++++++++++++++++++++*==+++++++#+++++++++++++++++==+=+===================\r\n===============*#++++++++++++++++++*=====+++++++++++++++++++++++++===++==+================\r\n=======================+**######*==========#+++++++++++++++++++++===*=====================\r\n=============================================+*+++++++++++++++++==*+======================\r\n==========================================================================================\r\n==========================================================================================\r\n==========================================================================================\r\n==========================================================================================\r\n==========================================================================================\r\n==========================================================================================\r\n==========================================================================================\r\n==========================================================================================\r\n==========================================================================================");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("https://www.tumblr.com/agent-atlas");
                Console.ResetColor();
            }
            else if (playerName == "Cookie")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%###*****##%%%%%%%%\r\n%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%##*+=--:::-+*##%##%%\r\n%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#*+--:.....::-*##%%%%\r\n%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#*+-:-:..:-:::-=*#%%%%\r\n%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#**=:....:==-:-=+##%%%%\r\n%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%###**=-::..::::-=+*#%%%%%\r\n%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#######**+=-::----=+*#%%%%%%\r\n%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%############***++++****##%%%%%%%\r\n%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%##################****###%%%%%%%%%%\r\n%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#######################%%%%%%%%%%%%%%\r\n%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#######################%%%%%%%%%%%%%%%\r\n%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%########################%%%%%%%%%%%%%%%%\r\n%%%%%%%%%%%%%%%%%%@@@@@@@@%%%%%%%%%%%%%%%%%%%%%#####*#####################%#%%%%%%%%%%%%%%\r\n%%%%%%%%%%%%%%%%@@@@@@@@@@@%%%%%%%%%%%%%%%%%%%##**#######################%%%%%%%%%%%%%%%%%\r\n%%%%%%%%%%%%%%%%@@@@@@@@@@@%%%%%%%%%%%%%%#**############################%##*##%%%%%%%%%%%%\r\n%%%%%%%%%%%%%%%%@@@@@@@@@@@%%%%%%%%%%%%############*+########*=====++*******#%%%%%%%%%#%%%\r\n%%%%%%%%%%%%%%%%@@@@@@%%#**-#%%%%%%##%######***********####*###########%%%%%*#%%%%%%%%%%%%\r\n%%%%%%%%%%%%%%%%********###%%%%%#########**************#########*###***#%%*##%%%%%%%%%%%%%\r\n%%%%%%%%%%%%%@@@@@@@@@@@@@%%%#%%########*##*******##############*##*+++*##%##%%%%%%%%%%%%%\r\n%%%%%%%%%%%%%%%@@@@@@%%%%%%*++%%############***###################*++++*#%%#%%%%%%%%%%%%%%\r\n%%%%%%%%%%%%%%%%%%%%%%%%%%%#*%%%%%###########################%###%#####%%%%#%%%%%%%%%%%%%%\r\n%%%%%%%%%%%%%%%%*##%%%%%**+*%%%%%%####################%%%%%%%%*###########%@@%%%%%%%%%%%%%\r\n%%%%%%%%%%%%%%%#*********#***#%%%%%%%#######%%%%%%%%%#%%%%%%%%%%%#####%%@%@@%%%%%%%%%%%%%%\r\n%%%%%%%%%%%%%%%#*********%****%%%%%%%#*%#%%%%%%%%%%%%#%%%%%%%%%%%%@@@@%@%@%%%###%%%%%%%%%%\r\n%%%%%%%%%%%%%%##*********#****%+**####%%%%%%%%%%%%%%%##%%%%%%%%%##%%%@%%%%%#++++++++++++**\r\n##***+++++++*#*#***************%#==*#%%%%%%%%%%%%%%%%###*+==+%%######%#%%#%=========+++++*\r\n++++++++++++#%%#**************%%#==%%%%%%%%%%%%%%%%%%%##*==*%@%#######%%#%*--------===++++\r\n****+++++++#%%%#*********###%%@%%*%%%%%%%%%%%%%%%%%%%%%##+=%#%#####%%%#####=::::::---===++\r\n****+++++#%%%%%************#%@%%%%%%%%%%%%%%%%%%%%%%%%%##%%%%###############:::::::---====\r\n***++++===++**#****#%#******#**#%%%%%%%%%%%%%%%%%%%%%%%%%#%%%#############%%--:::::---====\r\n**+++=====+++####*#%%#*######*=++%%%%%%%%%%%%%%%%%%%%%%%%%#*#%@%%%%%%%%@%%%+=----------===\r\n++++===-==++++++++*#*++++======++*%%%%%%%%%%%%%%%%%%%%%%%*+++*%###########%==----------===\r\n+++==---==++++++++++++===-----=++++++*****************++++++++++**%######++==----------===\r\n++===--==++++++++++===---------=+++++++++++++++++++++++++===++++++**#%%#*++=----------====\r\n========+++++++++==-------------=+++++++++++++++++++++++====+++++++++++++++=----------==++\r\n=====+++++++++++==--------------==+++++++++++++++++++++==--=++++++++++++++==---------==+++\r\n====++++++++++++==---------------==++++++++++++++++++==----=++++++++++++++==---------==+++\r\n===++++++++++++==-----------------==++++++++++++++++==-----=++++++++++++++==--------==+++*\r\n===++++++++++==--------------------==++++++++++++++==------==+++++++++++++==-------==+++**\r\n===+++++++++==----------------------==++++++++++++=--------==+++++++++++++==-----===+++***\r\n=====++++++==------------------------==++++++++++=---------==++++++++++++++=----===+++****");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("https://www.tumblr.com/agent-atlas");
                Console.ResetColor();
            }
        }

        
    }
}
