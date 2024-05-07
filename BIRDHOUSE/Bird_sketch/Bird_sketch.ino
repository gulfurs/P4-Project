#include <Servo.h>

Servo servo;  // Create a servo object

int pos = 0;

void setup() {
  servo.attach(9); // Attach the servo to pin 9
}

void loop() {
  for (pos = 0; pos <= 180; pos += 1) {
    servo.write(pos); // Rotate the servo to 'pos' degrees
    delay(15);
  } 
  for (pos = 180; pos >= 0; pos -= 1) {
    servo.write(pos); // Rotate the servo to 'pos' degrees
    delay(15);
  }
}