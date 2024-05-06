// Distance sensor constants
const int analogInputPin = A0; // Analog input pin
const int ledPin = 13;

void setup() {
  // Initialize serial communication
  Serial.begin(9600);
  pinMode(ledPin, OUTPUT);
}

void loop() {
  // Read analog input from sensor
  int sensorValue = analogRead(analogInputPin);

  // Print raw sensor value to serial monitor
  Serial.print("Raw Sensor Value: ");
  Serial.println(sensorValue);

  // Delay for a short interval

  if (sensorValue < 90) {
   digitalWrite(ledPin, HIGH);
  } else {
    digitalWrite(ledPin, LOW);
  }
  delay(100);
}
