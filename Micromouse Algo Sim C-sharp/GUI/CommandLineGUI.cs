
using System.Numerics;
using Micromouse_Algo_Sim_C_sharp.GUI;

namespace Micromouse_Algo_Sim_C_sharp
{
    /// <summary>
    /// Handles the GUI for the micromouse simulator
    /// </summary>
    [Author("Taylor Howell", 1.2)]
    public static class CommandLineGUI
    {

        /// <summary>
        /// The main menu 
        /// </summary>
        /// <remarks>this stuff should be moved into CommandlineGUI.cs</remarks>
        public static void Menu()
        {
            int result = 0;

            while (result != -1)
            {
                ShowTitle("--- Main Menu ---");
                List<Command> actions = new List<Command>()
            {
                new Command("test", "this is a test", GUITestCases.TestMessages),
                new Command("Example map", "this shows an example map for all to see", GUITestCases.CreateExampleMaze),
                new Command("Run Test Case", "Run a test case with a lot of data", () => GUITestCases.DoNumbers(20))
            };

                result = ShowCommands(actions);
            }

        }


        /// <summary>
        /// Show the command list in a consistent format, and manage general movement between menus
        /// </summary>
        /// <param name="commands">the string array of commands</param>
        public static int ShowCommands(List<Command> commands)
        {
            while (true)
            {

                Console.WriteLine("---------------------------------");

                ShowSubTitle("Enter A Command");

                Console.WriteLine("");

                int i = 0;

                foreach (var x in commands)
                {
                    Console.WriteLine(i + ") " + x.Title + "\n" + x.Description);
                    Console.WriteLine();

                    i++;
                }

                Console.WriteLine(i + ") Back \nExit the menu");

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;

                string input = Console.ReadLine();

                Console.ResetColor();

                if (input == null)
                {
                    ShowError("input is null");


                    return ShowCommands(commands);
                }

                input = input.Trim();


                if (Int32.TryParse(input, out var result))
                {
                    if (result < commands.Count)
                    {
                        if (commands[result].Action != null)
                        {
                            commands[result].Action();
                        }

                        return result;
                    }
                    else if (result == commands.Count)
                    {
                        //quit
                        Console.WriteLine();
                        Console.WriteLine("Going Back");
                        return -1;
                    }
                }
                else
                {
                    Console.WriteLine();
                    List<string> similarCommands = new List<string>();
                    for (int j = 0; j < commands.Count; j++)
                    {
                        if (input.ToLower() == commands[j].Title.ToLower())
                        {
                            if (commands[j].Action != null)
                            {
                                commands[j].Action();
                            }

                            return j;
                        }
                        else if (LineAnalyzer.GetTokenRatio(input, commands[j].Title) > 40)
                        {
                            similarCommands.Add(commands[j].Title);
                        }
                    }

                    if (similarCommands.Count > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Similar Commands: \t" + string.Join(", ", similarCommands));
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    if (input.ToLower() == "Back".ToLower())
                    {
                        //quit

                        Console.WriteLine();
                        Console.WriteLine("Going Back");
                        return -1;
                    }

                }
            }
        }

        /// <summary>
        /// Show a title (black text with a white background)
        /// </summary>
        /// <param name="title">the title</param>
        public static void ShowTitle(string title)
        {
            title = CreateNewLinesForLongMessages(title);

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine($"{title}");
            Console.ResetColor();
            Console.WriteLine("");
        }

        /// <summary>
        /// Show a subtitle (green text)
        /// </summary>
        /// <param name="title">the title</param>
        public static void ShowSubTitle(string title)
        {
            title = CreateNewLinesForLongMessages(title);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{title}");
            Console.ResetColor();
        }

        /// <summary>
        /// Show text to the console (a text analyzer is applied that shortens the text to make it fit easier in the console)
        /// </summary>
        /// <param name="text">the text</param>
        public static void ShowText(string text)
        {
            text = CreateNewLinesForLongMessages(text);
            Console.WriteLine(text);
        }

        /// <summary>
        /// Show an error message
        /// </summary>
        /// <param name="message">the message</param>
        public static void ShowError(string message)
        {
            message = CreateNewLinesForLongMessages(message);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error! - {message}");
            Console.ResetColor();
        }


        /// <summary>
        /// Show an warning message
        /// </summary>
        /// <param name="message">the message</param>
        public static void ShowWarning(string message)
        {
            message = CreateNewLinesForLongMessages(message);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Warning! - {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Show an message
        /// </summary>
        /// <param name="message">the message</param>
        public static void ShowMessage(string message)
        {
            message = CreateNewLinesForLongMessages(message);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Note: {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Creates a new line for the message if it is greater than 20 characters
        /// </summary>
        /// <param name="message">the message</param>
        /// <returns>the message with new line characters</returns>
        public static string CreateNewLinesForLongMessages(string message)
        {

            //Console.WriteLine($"{message}");

            bool usedTab = message[0] == '\t';

            if (message.Length > 20)
            {
                for (int i = 0; i < message.Length; i += 40)
                {
                    for (int j = i; j >= 0; j--)
                    {
                        if (message[j] == ' ')
                        {

                            if (usedTab)
                            {
                                message = message.Remove(j, 1);
                                message = message.Insert(j, "\n\t");
                            }
                            else
                            {
                                message = message.Insert(i, "\n");
                            }
                            break;
                        }
                    }
                }
            }

            return message;
        }

        /// <summary>
        /// Show a list of data
        /// </summary>
        /// <param name="data">the data</param>
        /// <typeparam name="T">the collection</typeparam>
        public static void ShowData<T>(IEnumerable<T> data)
        {
            Console.WriteLine("\tData: ");

            int i = 0;
            foreach (var x in data)
            {
                if (i % 2 == 0) Console.ForegroundColor = ConsoleColor.DarkYellow;
                else Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.WriteLine(i + ") " + x);
                i++;
            }

            Console.ResetColor();
            Console.WriteLine("----End Of Data----");
            Console.WriteLine();
        }

        /// <summary>
        /// Prints "----Done----"
        /// </summary>
        public static void PrintDone()
        {
            ShowText("\n----Done----\n");
        }

        /// <summary>
        /// Show the maze in the command line
        /// </summary>
        /// <param name="maze">the maze</param>
        /// <param name="botLocation">the location of the bot</param>
        public static void PaintMaze(Maze maze)
        {
            ShowSubTitle($"----Maze '{maze.Name}'----\n\n");
            Console.WriteLine(maze.ToString());
        }

        /// <summary>
        /// Show the maze in the command line
        /// </summary>
        /// <param name="maze">the maze</param>
        /// <param name="botPosition">the location of the bot</param>
        public static void PaintMaze(Maze maze, Position BotPosition)
        {
            ShowSubTitle($"----Maze '{maze.Name}'----\n\n");
            Console.WriteLine(maze.PrintMazeWithRobot(BotPosition));
        }

        /// <summary>
        /// Show the maze in the command line along with the step number <paramRef name="stepNumber"/> (to show the iterations).
        /// </summary>
        /// <param name="maze">the maze</param>
        /// <param name="stepNumber">the step number</param>
        public static void PaintMaze(Maze maze, int stepNumber)
        {
            ShowSubTitle(maze.Name + " " + stepNumber + ")\n");
            Console.WriteLine(maze.ToString());
        }


         /// <summary>
        /// Show the maze in the command line along with the step number <paramRef name="stepNumber"/> (to show the iterations).
        /// </summary>
        /// <param name="maze">the maze</param>
        /// <param name="stepNumber">the step number</param>
        /// <param name="botPosition">the location of the bot</param>
        public static void PaintMaze(Maze maze, int stepNumber, Position BotPosition)
        {
            ShowSubTitle(maze.Name + " " + stepNumber + ")\n");
            Console.WriteLine(maze.PrintMazeWithRobot(BotPosition));
        }
    }
}