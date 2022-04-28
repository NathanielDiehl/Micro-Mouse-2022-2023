
using Micromouse_Algo_Sim_C_sharp;
using System.Numerics;

namespace Micromouse_Algo_Sim_C_sharp.GUI
{
    /// <summary>
    /// Some smallish test cases for GUI
    /// </summary>
    [Author("Taylor Howell", 1.0)]
    public static class GUITestCases
    {

        /// <summary>
        /// create a list of numbers to show in the showList
        /// </summary>
        /// <param name="total">the total number of integers</param>
        public static void DoNumbers(int total)
        {
            HashSet<(double, double)> data = new HashSet<(double, double)>();

            for (double i = 0; i <= 20; i++)
            {
                for (double j = 0; j <= 20; j++)
                {
                    if ((i - j) != 0)
                    {
                        if ((i - j) % 3 == 0)
                        {
                            data.Add((i, j));
                        }
                        if ((j - i) % 3 == 0)
                        {
                            data.Add((j, i));
                        }
                    }
                }
            }

            PriorityQueue<(double, double), double> p = new PriorityQueue<(double, double), double>();

            foreach (var x in data)
            {
                p.Enqueue(x, x.Item1 + x.Item2);
            }

            List<(double, double)> data2 = new List<(double, double)>();

            for (int i = 0; i < p.Count; i++)
            {
                data2.Add(p.Dequeue());
            }

            LineGUI.ShowData(data2);

            LineGUI.ShowCommands(new List<Command>() {
                new Command("Run again", "run the test again", () => DoNumbers(20)),
            });
        }

        /// <summary>
        /// Create an example maze
        /// </summary>
        public static void CreateExampleMaze()
        {
            Console.WriteLine("Example Maze:\n");
            Console.WriteLine(CreateExampleOutput());
        }

        /// <summary>
        /// the maze
        /// </summary>
        /// <returns>returns the string as a maze</returns>
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
            "6 |_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _|\n" +
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
        /// test different types of messages
        /// </summary>
        public static void TestMessages()
        {
            LineGUI.ShowError("Something went wrong!");
            LineGUI.ShowMessage("Make sure to brush your teeth");
            LineGUI.ShowWarning("the robot failed");
        }
    }
}