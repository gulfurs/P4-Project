// Distance sensor constants
#include <Servo.h>
Servo servo; 
const int analogInputPin = A0; // Analog input pin
const int ledPin = 13;
const int flexSensorPin = A5;
const int motorPin = 9;   

void setup() {
  // Initialize serial communication
  Serial.begin(9600);
  servo.attach(9);  
  pinMode(ledPin, OUTPUT);
  pinMode(motorPin, OUTPUT);
}

void loop() {
  // Read analog input from sensor
  int sensorValue = analogRead(analogInputPin);
  int flexValue = analogRead(flexSensorPin); 
  float flexvoltage = flexValue * (5.0 / 1023.0);

  // Print raw sensor value to serial monitor
  //Serial.print("Raw Sensor Value: ");
  //Serial.println(sensorValue);

  Serial.print("Flex Sensor Voltage: ");
  Serial.print(flexvoltage);
  Serial.println(" V");

   if (flexvoltage > 3.0) {
    servo.write(150);
    digitalWrite(motorPin, HIGH); // Activate motor
  } else {
    servo.write(0);
    digitalWrite(motorPin, LOW); // Deactivate motor
  }

  if (sensorValue < 90) {
   digitalWrite(ledPin, HIGH);
  } else {
    digitalWrite(ledPin, LOW);
  }
  delay(100);
}
