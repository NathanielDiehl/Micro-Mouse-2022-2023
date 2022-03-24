#include <vector>

class Hardware {
    public:
        Motor motors[2];
        Ultrasonic sensors[4];


        Hardware(Motor m0, Motor m1, Ultrasonic s0, Ultrasonic s1, Ultrasonic s2, Ultrasonic s3) {
            motors[0] = m0;
            motors[1] = m1;

            sensors[0] = m0;
            sensors[1] = m1;
            sensors[2] = m2;
            sensors[3] = m3;
        }

        void DriveDistance(float d){
            //add code
        }

        void TurnToAngle(float a){
            //add code
        }

        
        void DriveToPosition(float x, float y){
            //add code
        }

        void DriveToPosition(vector<float>& v){
            if(v.size() == 2)
                DriveToPosition(v[0], v[1]);
           }

        
};