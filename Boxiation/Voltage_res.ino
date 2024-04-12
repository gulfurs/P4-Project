const int analogPin = A2; // Analog pin where the resistor is connected
int Vin = 5;

float Rmain = 1000.0;
float convert = 1023.0;

void setup() {
  Serial.begin(9600); // Start serial communication
}

void loop() {
  int sensorValue = analogRead(analogPin); // Read the analog pin
  float recalc = sensorValue * (Vin / convert);
  float R = (Rmain * recalc)/(Vin-recalc);

  Serial.print("Sens: ");
  Serial.println(sensorValue);
  Serial.print("Recalc: ");
  Serial.println(recalc);
  Serial.print("R: ");
  Serial.println(R);

  delay(1000); // Wait for a moment before reading again
}
