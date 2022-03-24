

class Ultrasonic {
    public:
        //pins
        int PowerPinNum;
        int GroundPinNum;
        int TrigPinNum;
        int EchoPinNum;



        //Constructs a new Ultrasonic Object
        Ultrasonic(int ppn, int gpn, int tpn, int epn) {
            PowerPinNum = ppn;
            GroundPinNum = gpn;
            TrigPinNum = tpn;
            EchoPinNum = epn;
        }

        //Measures the distance 
        float GetDistance() {
            //add code
        }

};