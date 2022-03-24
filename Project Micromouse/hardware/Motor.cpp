

class Motor {
    public:
        //pins
        int PowerPinNum;
        int GroundPinNum;
        //...




        Motor(int ppn, int gpn) {
            PowerPinNum = ppn;
            GroundPinNum = gpn;
        }

        void drive(float speed) {
            //add code
        }

        void driveToAngle(float angle) {
            //add code
        }
};