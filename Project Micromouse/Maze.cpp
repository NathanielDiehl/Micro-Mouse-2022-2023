#include <string>
#include <fstream>
#include <vector>
#include <filesystem>

#define MAZE_SIZE 16

using namespace std;

namespace ProjectMicroMouse
{

    /**
     * @brief Represents the maze the robot is traversing
     * @author John Woods
     */
    class Maze
    {
    private:
        unsigned char maze[MAZE_SIZE][MAZE_SIZE];

    public:
        /**
         * @brief Construct the maze from the specified file
         */
        Maze(string file)
        {
            ifstream inFile(file, ios_base::binary);
            inFile.seekg(0, ios_base::end);
            size_t length = inFile.tellg();
            inFile.seekg(0, ios_base::beg);

            vector<unsigned char> buffer;
            buffer.reserve(length);
            copy(istreambuf_iterator<char>(inFile), istreambuf_iterator<char>(), back_inserter(buffer));

            for (int i = 0; i < buffer.size(); i++)
            {
                maze[MAZE_SIZE - 1 - i % MAZE_SIZE][i / MAZE_SIZE] = buffer[i];
            }
        }

        /**
         * @brief Construct the maze from a random file
         */
        Maze()
        {
            vector<string> files;
            for (const auto &entry : filesystem::directory_iterator("/mazefiles/"))
            {
                files.push_back(entry.path().string());
            }
            //Maze(files[rand() % files.size()]); //TODO: fix the rand() error?
        }

        unsigned char get(int x, int y)
        {
            return maze[x][y];
        }
    };
}
