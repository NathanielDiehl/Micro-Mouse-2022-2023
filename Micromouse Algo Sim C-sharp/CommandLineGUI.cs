namespace Micromouse_Algo_Sim_C_sharp
{
    /// <summary>
    /// Handles the GUI for the micromouse simulator
    /// </summary>
    [Author("Taylor Howell", 1.0)]
    public static class CommandLineGUI
    {
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
    }
}