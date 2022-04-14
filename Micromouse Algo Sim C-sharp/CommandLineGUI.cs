namespace Micromouse_Algo_Sim_C_sharp
{
    /// <summary>
    /// Handles the GUI for the micromouse simulator
    /// </summary>
    [Author("Taylor Howell", 1.0)]
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
                List<(string, string, Action)> actions = new List<(string, string, Action)>()
            {
                ("test", "this is a test", Test),
                ("Example map", "this shows an example map for all to see", Tick)
            };

                result = ShowCommands(actions, null);
            }

        }

        public static void Tick()
        {
            Console.WriteLine("Example Maze:\n");
            Console.WriteLine(CreateExampleOutput());
        }

        public static void Test()
        {
            ShowError("Something went wrong!");
            ShowMessage("Make sure to brush your teeth");
            ShowWarning("the robot failed");
        }

        private static string CreateExampleOutput()
        {
            string str =
            "   0 1 2 3 4 5 6 7 8 9 A B C D E F \n" +
            "0  _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ \n" +
            "1 |_|_ _ _ _|_ _ _ _ _ _ _  |_ _ _|\n" +
            "2 |_ _ _ _|_ _     _ _ _ _ _ _ _ _|\n" +
            "3 |_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ \n" +
            "4 |_|_ _ _ _|_ _ _ _ _ _ _  |_ _ _|\n" +
            "5 |_ _ _ _|_ _     _ _ _ _ _ _ _ _|\n" +
            "6 |_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _| \n" +
            "7 |_|_ _ _ _|_ _ _ _ _ _ _  |_ _ _|\n" +
            "8 |_ _ _ _|_ _     _ _ _ _ _ _ _ _|\n" +
            "9 |_|_ _ _ _|_ _ _ _ _ _ _  |_ _ _|\n" +
            "A |_ _ _ _|_ _     _ _ _ _ _ _ _ _|\n" +
            "B |_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _|\n" +
            "C |_|_ _ _ _|_ _ _ _ _ _ _  |_ _ _|\n" +
            "D |_ _ _ _|_ _     _ _ _ _ _ _ _ _|\n" +
            "E |_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _|\n" +
            "F |_|_ _ _ _|_ _ _ _ _ _ _  |_ _ _|\n";

            return str;
        }

        /// <summary>
        /// Show the command list in a consistent format, and manage general movement between menus
        /// </summary>
        /// <param name="commands">the string array of commands</param>
        public static int ShowCommands(List<(string command, string description, Action nextMethod)> commands, Action? back)
        {
            while (true)
            {

                Console.WriteLine("---------------------------------");

                ShowSubTitle("Enter A Command");

                Console.WriteLine("");

                int i = 0;

                foreach (var x in commands)
                {
                    Console.WriteLine(i + ") " + x.command + "\n\t" + x.description);
                    Console.WriteLine();

                    i++;
                }

                Console.WriteLine(i + ") Quit \n\tExit the program");

                if (back != null)
                {
                    Console.WriteLine((i + 1) + ") Back \n\tGo Back");
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;

                string? input = Console.ReadLine();

                Console.ResetColor();

                if (input == null)
                {
                    ShowError("input is null");

                    if (back != null)
                        return ShowCommands(commands, back);

                    return ShowCommands(commands, null);
                }

                input = input.Trim();

                
                if (Int32.TryParse(input, out var result))
                {
                    if (result < commands.Count)
                    {
                        if (commands[result].nextMethod != null)
                        {
                            commands[result].nextMethod();
                        }

                        return result;
                    }
                    else if (result == commands.Count)
                    {
                        //quit
                        Console.WriteLine();
                        Console.WriteLine("Ending Session");
                        return -1;
                    }
                    else if (result == commands.Count + 1)
                    {
                        if (back != null)
                        {
                            back();
                            return -2;
                        }
                    }
                }
                else
                {
                    Console.WriteLine();
                    List<string> similarCommands = new List<string>();
                    for (int j = 0; j < commands.Count; j++)
                    {
                        if (input.ToLower() == commands[j].command.ToLower())
                        {
                            if (commands[j].nextMethod != null)
                            {
                                commands[j].nextMethod();
                            }

                            return j;
                        }
                        else if (LineAnalyzer.GetTokenRatio(input, commands[j].command) > 40)
                        {
                            similarCommands.Add(commands[j].command);
                        }
                    }

                    if (similarCommands.Count > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Similar Commands: \t" + string.Join(", ", similarCommands));
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    if (input.ToLower() == "Quit".ToLower())
                    {
                        //quit

                        Console.WriteLine();
                        Console.WriteLine("Ending Session");
                        return -1;
                    }

                    if (input.ToLower() == "Back".ToLower())
                    {
                        if (back != null)
                            back();
                        return -2;
                    }
                }
            }
        }

        public static void ShowTitle(string title)
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine($"{title}");
            Console.ResetColor();
            Console.WriteLine("");
        }

        public static void ShowSubTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{title}");
            Console.ResetColor();
        }

        /// <summary>
        /// Show an error message
        /// </summary>
        /// <param name="message">the message</param>
        public static void ShowError(string message)
        {
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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Note: {message}");
            Console.ResetColor();
        }
    }
}