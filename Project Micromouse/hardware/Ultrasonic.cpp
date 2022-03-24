

class Ultrasonic {
public:
    //pins
    int PowerPinNum;
    int GroundPinNum;
    int TrigPinNum;
    int EchoPinNum;




    Ultrasonic(int ppn, int gpn, int tpn, int epn) {
        PowerPinNum = ppn;
        GroundPinNum = gpn;
        TrigPinNum = tpn;
        EchoPinNum = epn;
    }

    float getDistance() {
        //add code
    }

};