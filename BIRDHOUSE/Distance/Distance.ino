// Distance sensor constants
// Simons variabler
#include <Servo.h>
Servo servo;
Servo servo2;
const int analogInputPin = A0;  // Analog input pin
const int ledPin = 7;
const int flexSensorPin = A4;
const int motorPin = 10;
const int motorPin11 = 9;
// Slut Simons Variabler

// Malthe Variabler

int calibrationTime = 10;
long unsigned int lowIn;
long unsigned int pause = 5000;
boolean lockLow = true;
boolean takeLowTime;
int pirPin = 4;  //the digital pin connected to the PIR sensor's output
int CameraPin = 6;


//Slut Malthe Variabler

void setup() {
  // Initialize serial communication
  // Simons Del
  Serial.begin(9600);

  servo.attach(motorPin);

  servo2.attach(motorPin11);

  pinMode(ledPin, OUTPUT);
  pinMode(motorPin, OUTPUT);
  pinMode(motorPin11, OUTPUT);
  pinMode(flexSensorPin, INPUT);
  // Malthes Del
  pinMode(pirPin, INPUT);
  digitalWrite(pirPin, LOW);
  Serial.print("calibrating sensor ");
  for (int i = 0; i < calibrationTime; i++) {
    Serial.print(".");
    delay(1000);
  }
  Serial.println(" done");
  Serial.println("SENSOR ACTIVE");
  delay(50);
  // Slut Malthes Del
}

void loop() {
  // Read analog input from sensor
  // Simons Del
  int sensorValue = analogRead(analogInputPin);
  int flexValue = analogRead(flexSensorPin);
  float flexvoltage = flexValue * (5.0 / 1023.0);
  digitalWrite(motorPin11, LOW);

  // Print raw sensor value to serial monitor
  // Serial.print("Raw Sensor Value: ");
  //Serial.println(sensorValue);

  Serial.print("Flex Sensor Voltage: ");
  Serial.print(flexValue);
  Serial.println(" V");
  // digitalWrite(motorPin3, 180);

if (flexValue <= 350) {
    Serial.print("po");
    servo.write(100);
    digitalWrite(motorPin, HIGH);  // Activate motor
    delay(100);
} else if (flexValue > 400 && flexValue < 420) {
    servo2.write(110);
    digitalWrite(motorPin11, HIGH);
    delay(100);
} else {
    servo.write(0);
    digitalWrite(motorPin, LOW);  // Deactivate motor 1
    servo2.write(90);
    // få servo2 til at stoppe
    digitalWrite(motorPin11, LOW); 
    delay(100);// Deactivate motor 2
}

  // Deactivate motor

  /*
   if (flexValue <= 400) {
    Serial.print("po2");
    servo2.write(150);
    digitalWrite(motorPin11, LOW); // Activate motor
  } else {
    servo2.write(0);
    digitalWrite(motorPin11, LOW); // Deactivate motor
  }*/


  if (sensorValue < 90) {
    digitalWrite(ledPin, HIGH);
  } else {
    digitalWrite(ledPin, LOW);
  }
  delay(100);
  // Slut Simons Del
  //Start Malthes Del


  if (digitalRead(pirPin) == HIGH) {
    digitalWrite(CameraPin, HIGH);

    //the led visualizes the sensors output pin state
    if (lockLow) {
      //makes sure we wait for a transition to LOW before any further output is made:
      lockLow = false;
      Serial.println("---");
      Serial.print("It's High");
      Serial.print("motion detected at ");
      Serial.print(millis() / 1000);
      Serial.println(" sec");
      delay(50);
    }
    takeLowTime = true;
  }

  if (digitalRead(pirPin) == LOW) {
    digitalWrite(CameraPin, LOW);


    if (takeLowTime) {
      lowIn = millis();     //save the time of the transition from high to LOW
      takeLowTime = false;  //make sure this is only done at the start of a LOW phase
    }
    //if the sensor is low for more than the given pause,
    //we assume that no more motion is going to happen
    if (!lockLow && millis() - lowIn > pause) {
      //makes sure this block of code is only executed again after
      //a new motion sequence has been detected
      lockLow = true;
      Serial.print("motion ended at ");  //output
      Serial.print((millis() - pause) / 1000);
      Serial.println(" sec");
      Serial.print("It's Low");
      delay(50);
    }
  }
  // Slut Malthes Del
}