#include <vector>

class World {
    private: 
        static float MazeWalls[16][16];

    public:
        static std::vector <float> RobotPosition (2);
        static float RobotRotation;



        static void Init() {
            RobotPosition[0] = 0;
            RobotPosition[1] = 0;
            RobotRotation = 0;

            ClearWalls();
        }

        static void ClearWalls(){
            for (int i = 0; i < 16; i++) {
                for (int j = 0; j < 16; j++) {
                    MazeWalls[i][j] = 0;
                }
            }
        }

        static bool IsWallAt(int row, int col) {
            if(row >= 0 && col >= 0 && row < 16 && col < 16)
                return MazeWalls[row][col] == 1;
        }

        static void FoundWall(int row, int col) {
            if(row >= 0 && col >= 0 && row < 16 && col < 16)
                MazeWalls[row][col] = 1;
        }


};