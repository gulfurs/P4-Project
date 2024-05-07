#include <Servo.h>

Servo servo;  // Create a servo object
int sensorPin = 2; // Assuming the sensor is connected to digital pin 2
int sensorState = 0; // Variable to store the sensor state

int strainPin = A1;
int strainThreshold = 600;
int pos = 0;

void setup() {
  servo.attach(9); // Attach the servo to pin 9
  pinMode(sensorPin, INPUT); // Set the sensor pin as input
  Serial.begin(9600);
}

void loop() {
  // Read the sensor state
  sensorState = digitalRead(sensorPin);
  int strainValue = analogRead(strainPin);
  Serial.println(strainValue); 

  // If sensor is activated (assuming HIGH state means activated)
  if (sensorState == HIGH) {
    // Rotate the servo
    for (pos = 0; pos <= 180; pos += 1) {
      servo.write(pos); // Rotate the servo to 'pos' degrees
      delay(15);
    } 
    // Reverse rotation
    for (pos = 180; pos >= 0; pos -= 1) {
      servo.write(pos); // Rotate the servo to 'pos' degrees
      delay(15);
    }
  }
}
