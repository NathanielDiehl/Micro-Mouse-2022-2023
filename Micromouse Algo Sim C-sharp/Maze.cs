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
        
        public string Name { get; set; }

        /// <summary>
        /// Constructs a maze from a given file, or a random file if none is specified.
        /// </summary>
        /// <param name="file">Optional name of the maze file</param>
        public Maze(string name = "", string file = "") {
            if(file == "") {
                string[] allFiles = Directory.GetFiles(@"mazefiles/", "*.maz");
                Random random = new Random();
                file = allFiles[random.Next() % allFiles.Length];
            }

            byte[] rawMaze = File.ReadAllBytes(file);

            _maze = new byte[MAZE_SIZE, MAZE_SIZE];
            for(int i = 0; i < rawMaze.Length; i++)
            {
                _maze[MAZE_SIZE - 1 - i % MAZE_SIZE, i / MAZE_SIZE] = rawMaze[i];
            }

            if(name == "") {
                Name = file;
            } else {
                Name = name;
            }
        }

        /// <summary>
        /// Gets the wall data from the given position in the maze.
        /// </summary>
        public byte this[int x, int y] {
            get => _maze[x, y];
        }
        
        /// <summary>
        /// Checks if a wall exists in the specified direction at the specified direction.
        /// </summary>
        /// <param name="x">The x-coordinate</param>
        /// <param name="y">The y-coordinate</param>
        /// <param name="dir">The direction to check</param>
        /// <returns></returns>
        public bool WallExists(int x, int y, Direction dir) {
            return (_maze[x, y] & (byte)dir) > 0;
        }

        /// <summary>
        /// Gets a string of the 2D representation of the maze.
        /// </summary>
        /// <returns>A string with a 2D graphical representation of the maze</returns>
        public override string ToString()
        {
            return PrintMazeWithRobot(new Position());
        }

        /// <summary>
        /// Gets a string of the 2D representation of the maze.
        /// </summary>
        /// <returns>A string with the hex value for the wall data of each cell in the maze.</returns>
        public string ToHexString()
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p">The robot's position</param>
        /// <returns>A string with a 2D graphical representation of the maze and the robot</returns>
        public string PrintMazeWithRobot(Position p) {
            char[,] output = new char[2 * MAZE_SIZE + 1, 4 * MAZE_SIZE + 1];

            for(int i = 0; i < MAZE_SIZE; i++) {
                for(int j = 0; j < MAZE_SIZE; j++) {
                    output[2 * i, 4 * j] = '+';
                    output[2 * i, 4 * j + 4] = '+';
                    output[2 * i + 2, 4 * j] = '+';
                    output[2 * i + 2, 4 * j + 4] = '+';
                    if(WallExists(i, j, Direction.NORTH)) {
                        output[2 * i, 4 * j + 1] = '-';
                        output[2 * i, 4 * j + 2] = '-';
                        output[2 * i, 4 * j + 3] = '-';
                    }
                    if(WallExists(i, j, Direction.WEST)) {
                        output[2 * i + 1, 4 * j] = '|';
                    }
                    if(WallExists(i, j, Direction.EAST)) {
                        output[2 * i + 1, 4 * j + 4] = '|';
                    }
                    if(WallExists(i, j, Direction.SOUTH)) {
                        output[2 * i + 2, 4 * j + 1] = '-';
                        output[2 * i + 2, 4 * j + 2] = '-';
                        output[2 * i + 2, 4 * j + 3] = '-';
                    }
                    if(i == p.X && j == p.Y) {
                        output[2 * i + 1, 4 * j + 2] = 'X';
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < 2 * MAZE_SIZE + 1; i++) {
                for(int j = 0; j < 4 * MAZE_SIZE + 1; j++) {
                    if(output[i, j] == '\0') {
                        sb.Append(' ');
                    }
                    else 
                    {
                        sb.Append(output[i, j]);
                    }
                }
                sb.Append('\n');
            }

            return sb.ToString();
        }

    }

}