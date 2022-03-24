
// Author Taylor Howell

#include <vector>
#include <string>

//This class handles translating the information from the 'brain' to the real or virtual world
static class Simulator
{

    // Is the code running the virtual 'gui' (or the hardware)?
    static const bool Virtual = true;

public:
    // Call this to import the world
    void ImportWorld()
    {

    }

    // Call this to run the program
    void Run()
    {
        if (Virtual)
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
