#include <vector>

class World {
    private: 
        enum WallStatus { UNCHECKED, WALL, OPEN };
        static WallStatus MazeWalls[16][16];

    public:
        static std::vector <float> RobotPosition (2);
        static float RobotRotation;

        //Initializes all the variables
        static void Init() {
            RobotPosition[0] = 0;
            RobotPosition[1] = 0;
            RobotRotation = 0;

            ClearWalls();
        }
        
        //Sets all the walls to unchecked
        static void ClearWalls(){
            for (int i = 0; i < 16; i++) {
                for (int j = 0; j < 16; j++) {
                    MazeWalls[i][j] = WallStatus.UNCHECKED;
                }
            }
        }

        //Returns if a wall it at the index
        static bool IsWallAt(int row, int col) {
            if(row >= 0 && col >= 0 && row < 16 && col < 16)
                return MazeWalls[row][col] == WallStatus.WALL;
        }

        //Returns if the path is open at the index
        static bool IsPathOpen(int row, int col) {
            if(row >= 0 && col >= 0 && row < 16 && col < 16)
                return MazeWalls[row][col] == WallStatus.OPEN;
        }

        //Returns if the wall at the index has been checked
        static bool IsWallChecked(int row, int col) {
            if(row >= 0 && col >= 0 && row < 16 && col < 16)
                return !(MazeWalls[row][col] == WallStatus.UNCHECKED);
        }

        //Tells the code a wall was found at the index
        static void FoundWall(int row, int col) {
            if(row >= 0 && col >= 0 && row < 16 && col < 16)
                MazeWalls[row][col] = WallStatus.WALL;
        }

        //Tells the code a wall was not found at the index
        static void FoundNoWall(int row, int col) {
            if(row >= 0 && col >= 0 && row < 16 && col < 16)
                MazeWalls[row][col] = WallStatus.OPEN;
        }



};