// Distance sensor constants
// Simons variabler
#include <Servo.h>
Servo servo; 
const int analogInputPin = A0; // Analog input pin
const int ledPin = 13;
const int flexSensorPin = A5;
const int motorPin = 9;   
const int motorPin3 = 3;  
// Slut Simons Variabler 

// Malthe Variabler

int calibrationTime = 10; 
long unsigned int lowIn;         
long unsigned int pause = 5000;  
boolean lockLow = true;
boolean takeLowTime; 
int pirPin = 4;    //the digital pin connected to the PIR sensor's output
int CameraPin = 12;


//Slut Malthe Variabler

void setup() {
  // Initialize serial communication
  // Simons Del
  Serial.begin(9600);
  servo.attach(9);  
  servo.attach(motorPin3);  
  pinMode(ledPin, OUTPUT);
  pinMode(motorPin, OUTPUT);
  pinMode(flexSensorPin, OUTPUT)
  pinMode(motorPin3, OUTPUT);
  // Malthes Del
  pinMode(pirPin, INPUT);
  pinMode(ledPin, OUTPUT);
  digitalWrite(pirPin, LOW);
  Serial.print("calibrating sensor ");
    for(int i = 0; i < calibrationTime; i++){
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

  // Print raw sensor value to serial monitor
  //Serial.print("Raw Sensor Value: ");
  //Serial.println(sensorValue);

  Serial.print("Flex Sensor Voltage: ");
  Serial.print(flexvoltage);
  Serial.println(" V");
  digitalWrite(motorPin3, 180);

   if (flexValue > 350) {
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
  // Slut Simons Del
  //Start Malthes Del

  
     if(digitalRead(pirPin) == HIGH){       
       digitalWrite(CameraPin, HIGH);
       
         //the led visualizes the sensors output pin state
       if(lockLow){  
         //makes sure we wait for a transition to LOW before any further output is made:
         lockLow = false;            
         Serial.println("---");
         Serial.print("It's High");
         Serial.print("motion detected at ");
         Serial.print(millis()/1000);
         Serial.println(" sec"); 
         delay(50);
         }         
         takeLowTime = true;
       }

     if(digitalRead(pirPin) == LOW){       
       digitalWrite(CameraPin, LOW);
       

       if(takeLowTime){
        lowIn = millis();          //save the time of the transition from high to LOW
        takeLowTime = false;       //make sure this is only done at the start of a LOW phase
        }
       //if the sensor is low for more than the given pause, 
       //we assume that no more motion is going to happen
       if(!lockLow && millis() - lowIn > pause){  
           //makes sure this block of code is only executed again after 
           //a new motion sequence has been detected
           lockLow = true;                        
           Serial.print("motion ended at ");      //output
           Serial.print((millis() - pause)/1000);
           Serial.println(" sec");
           Serial.print("It's Low");
           delay(50);
           }
       }
  // Slut Malthes Del

}
