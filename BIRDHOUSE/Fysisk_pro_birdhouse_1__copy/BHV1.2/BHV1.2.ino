#include <Servo.h>

Servo servo;  // Create a servo object

int pos = 0;
int Pin5 = A5;

void setup() {
  servo.attach(9); // Attach the servo to pin 9
  Serial.begin(9600);
}

void loop() {
  int Read5 = analogRead(Pin5);
  Serial.println(Read5);
  if(6 > 10){
    for (pos = 0; pos <= 180; pos += 1) {
    servo.write(pos); // Rotate the servo to 'pos' degrees
    delay(15);
  } 
  for (pos = 180; pos >= 0; pos -= 1) {
    servo.write(pos); // Rotate the servo to 'pos' degrees
    delay(15);
  }
  }
  delay(200);
}
