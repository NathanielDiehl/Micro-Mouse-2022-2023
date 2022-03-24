

class Motor {
    public:
        //pins
        int PowerPinNum;
        int GroundPinNum;
        //...



        //Constructs a new Motor Object 
        Motor(int ppn, int gpn) {
            PowerPinNum = ppn;
            GroundPinNum = gpn;
        }

        //Drives the motor at speed 
        void drive(float speed) {
            //add code
        }

        //Drive the motor to a given angle
        void driveToAngle(float angle) {
            //add code
        }
};