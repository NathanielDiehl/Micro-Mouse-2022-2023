
// Author Taylor Howell

#include <vector>
#include <string>

using namespace std;

//This class handles translating the information from the 'brain' to the real or virtual world
static class Simulator
{

public:

    // Call this to import the world
    void ImportWorld()
    {

    }

    // Call this to run the program
    //nameOfSelectedAlgorithm: the name of the selected algorithm
    //runVirtual: should this be executed virtually?
    void Run(string nameOfSelectedAlgorithm, bool runVirtual)
    {
        if (runVirtual)
        {
            RunVirtual();
        }
        else
        {
            RunHardware();
        }
    }

private:
    // Run the virtual simulation here
    void RunVirtual()
    {
        
    }

    // Run the hardware simulation here
    void RunHardware()
    {
    
    }
};
