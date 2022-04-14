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
        public static void MainMenu()
        {
            Console.WriteLine("--- Main Menu ---");
            List<(string, string, Action, Action)> actions = new List<(string, string, Action, Action)>()
            {
                ("test", "this is a test", () =>{}, () =>{})
            };

            ShowCommands(actions);

        }

        public static void Tick()
        {
            Console.WriteLine("Example Maze:\n");
            Console.WriteLine(CreateExampleOutput());
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
        public static int ShowCommands(List<(string command, string description, Action nextMethod, Action BackAction)> commands)
        {
            while (true)
            {

                Console.WriteLine();
                Console.WriteLine("Commands: ");

                int i = 0;

                foreach (var x in commands)
                {
                    Console.WriteLine(i + ") " + x.command + "\n\t" + x.description);
                    Console.WriteLine();

                    i++;
                }

                Console.WriteLine((i + 1) + ") Quit \n\tExit the program");

                string? input = Console.ReadLine();

                if (input == null)
                {
                    ShowError("input is null");

                    return ShowCommands(commands);
                }

                input = input.Trim();

                int someCommand = 0;
                if (Int32.TryParse(input, out var result))
                {
                    if (someCommand < commands.Count)
                    {
                        return someCommand;
                    }
                    else if (someCommand == commands.Count)
                    {
                        //quit
                        return -1;
                    }
                }
                else
                {
                    for (int j = 0; j < commands.Count; j++)
                    {
                        if (input == commands[j].command)
                        {
                            return j;
                        }
                    }

                    if (input == "Quit")
                    {
                        //quit
                        return -1;
                    }
                }
            }

            //quit
            return -1;
        }

        /// <summary>
        /// Show an error message
        /// </summary>
        /// <param name="message"></param>
        public static void ShowError(string message)
        {
            Console.WriteLine($"Error!\n{message}");
        }
    }
}