#include "PID.h"
#include <cmath>

//using namespace PID;
    int millis(){return 0;}

    double P_Gain;
    double I_Gain;
    double D_Gain;
    double errorMargin;

    double currentError;
    double previousError;
    double accumulatedError;

    unsigned long previousTime;

    PID::PID(double p, double i, double d, double e){
        P_Gain = p;
        I_Gain = i;
        D_Gain = d;
        errorMargin = e;

        currentError = 0;
        previousError = 0;
        accumulatedError = 0;
        previousTime = 0;
    }
    double PID::run(double currentValue, double desiredValue){
        unsigned long currentTime = millis();

        double output = 0;
        double P = 0;
        double I = 0;
        double D = 0;

        PID::calcCurrentError(currentValue, desiredValue);

        if (PID::shouldRun()) {
            accumulatedError += currentError;

            P = P_Gain * currentError;
            I = I_Gain * accumulatedError;
            D = D_Gain * ((currentError - previousError) / (currentTime - previousTime));

            previousError = currentError;
            output = (P + I + D);
        }
        previousTime = currentTime;
        return output;

    }
    void PID::calcCurrentError(double currentValue, double desiredValue){
        currentError = currentValue - desiredValue;
    }
    void PID::reset(){
        accumulatedError = 0;
        currentError = 0;
        previousTime = millis();
    }
    bool PID::shouldRun(){return (abs(currentError) > errorMargin);}
    double PID::getCurrentError(){return currentError;}
    double PID::getAccumulatedError(){return accumulatedError;}
