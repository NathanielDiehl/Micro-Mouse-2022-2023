#include <vector>

class World {
    public:
        static std::vector <float> RobotPosition (2);
        static float RobotRotation;

        static float MazeWalls[16][16];




        static void init() {
            RobotPosition.at(0) = 0;
            RobotPosition.at(1) = 0;
            RobotRotation = 0;

            for (int i = 0; i < 16; i++) {
                for (int j = 0; j < 16; j++) {
                    MazeWalls[i][j] = 0;
                }
            }
        }

        static void FoundWall(int row, int col) {
            MazeWalls[row][col] = 1;
        }

};