
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

            CommandLineGUI.ShowData(data2);

            CommandLineGUI.ShowCommands(new List<Command>() {
                new Command("Run again", "run the test again", () => DoNumbers(20)),
            });
        }

        /// <summary>
        /// Create an example maze
        /// </summary>
        public static void CreateExampleMaze()
        {
            Maze maze = new Maze();
            Console.WriteLine("Example Maze:\n");
            CommandLineGUI.PaintMaze(maze);
        }

        /// <summary>
        /// test different types of messages
        /// </summary>
        public static void TestMessages()
        {
            CommandLineGUI.ShowError("Something went wrong!");
            CommandLineGUI.ShowMessage("Make sure to brush your teeth");
            CommandLineGUI.ShowWarning("the robot failed");
        }
    }
}