
// Author Taylor Howell

#include <vector>
#include <string>

using namespace std;

//This class handles translating the information from the 'brain' to the real or virtual world
static class Simulator
{

    static string _nameOfSelectedAlg;
    static bool _runningVirtual;

public:

    // Call this to import the world
    void ImportWorld()
    {

    }

    // Call this to run the program
    //nameOfSelectedAlgorithm: the name of the selected algorithm
    //runVirtual: should this be executed virtually?
    void Init(bool runVirtual) //call an event with an ID??
    {
        _runningVirtual = runVirtual;

        if (_runningVirtual)
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
