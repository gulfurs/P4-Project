#include <Servo.h>

const int led = 8;
const int pir = 2;
int motion;
Servo servo;
int pos = 0;



void setup() {
  // put your setup code here, to run once:
 Serial.begin(9600);
 pinMode(led, OUTPUT);
 pinMode(pir, INPUT);
 servo.attach(11);
}

void loop() {
  motion = digitalRead(pir);
  if(motion){
    digitalWrite(led,HIGH);
    for (pos = 0; pos <= 180; pos += 1){
    servo.write(pos);
    delay(10);
    }
  }
  else{
    digitalWrite(led,LOW);
    if(pos != 0)
    {
      pos -= 1;
      servo.write(pos);
    }
  }

  
  delay(10);
}
