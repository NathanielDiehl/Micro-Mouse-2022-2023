using System.Text;

namespace Micromouse_Algo_Sim_C_sharp {
    
    /// <summary>
    /// Represents the maze the robot must traverse
    /// </summary>
    [Author("John Woods", 1.0)]
    public class Maze {

        public const int MAZE_SIZE = 16;

        public enum Direction {
            NORTH = 0x01,
            EAST = 0x02,
            SOUTH = 0x04,
            WEST = 0x08
        };

        private byte[,] _maze;

        /// <summary>
        /// Constructs a maze from a given file, or a random file if none is specified.
        /// </summary>
        /// <param name="file">Optional name of the maze file</param>
        public Maze(string file = "") {
            if(file == "") {
                string[] allFiles = Directory.GetFiles(@"mazefiles/", "*.maz");
                Random random = new Random();
                file = allFiles[random.Next() % allFiles.Length];
                Console.WriteLine("No maze file specified, loading " + file);
            }

            byte[] rawMaze = File.ReadAllBytes(file);

            _maze = new byte[MAZE_SIZE, MAZE_SIZE];
            for(int i = 0; i < rawMaze.Length; i++)
            {
                _maze[MAZE_SIZE - 1 - i % MAZE_SIZE, i / MAZE_SIZE] = rawMaze[i];
            }
        }

        /// <summary>
        /// Gets the wall data from the given position in the maze.
        /// </summary>
        public byte this[int x, int y] {
            get => _maze[x, y];
        }

        /// <summary>
        /// Gets a string of the 2D representation of the maze.
        /// </summary>
        /// <returns>A string with the hex value for the wall data of each cell in the maze.</returns>
        // TODO: Print out a graphical representation of each hex value
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < MAZE_SIZE; i++) {
                for(int j = 0; j < MAZE_SIZE; j++) {
                    sb.Append(Convert.ToHexString(new byte[]{_maze[i, j]}));
                    sb.Append(' ');
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

    }

}