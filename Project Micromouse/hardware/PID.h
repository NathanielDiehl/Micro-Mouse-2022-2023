class PID
{
    private:
        double P_Gain;
        double I_Gain;
        double D_Gain;
        double Error_Margin;

        double Current_Error;
        double previousError;
        double Accumulated_Error;

        unsigned long previousTime;

    public:
        PID(double p, double i, double d, double e);
        double run(double currentValue, double desiredValue);
        void calcCurrentError(double currentValue, double desiredValue);
        void reset();
        bool shouldRun();
        double getCurrentError();
        double getAccumulatedError();


};