const int Pin0 = A0;
const int Pin1 = A1;
const int Pin2 = A2; // Analog pin where the resistor is connected

void setup() {
  Serial.begin(9600); // Start serial communication
}

void loop() {
  
  Res(Pin0);
  Res(Pin1);
  Res(Pin2);
  Serial.println("------");

  delay(500); // Wait for a moment before reading again
}

void Res(int Pin)
{
  int sensorValue = analogRead(Pin);
  Serial.print("R" + String(Pin-13) + " :");
  Serial.println(sensorValue);
  Serial.println("");
}
