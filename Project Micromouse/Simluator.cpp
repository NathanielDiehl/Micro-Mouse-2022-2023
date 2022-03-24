
//Author Taylor Howell
//Handles the translation from the brain to the virtual or real world depending on what we need.

#include <vector>
#include <string>

class Simulator
{
public:
    bool Virtual = true;

    //call this to import the world
    void ImportWorld()
    {
    }

    //call this to run the program
    void Run()
    {
        if (RunVirtual)
        {
            RunVirtual();
        }
        else
        {
            RunHardware();
        }
    }

private:

    //run the virtual simulation here
    void RunVirtual()
    {
        //run the virtual simulation here
    }

    
    //run the hardware simulation here
    void RunHardware()
    {
        //run the hardware here
    }
};
