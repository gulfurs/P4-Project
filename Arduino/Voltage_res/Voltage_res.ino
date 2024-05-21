const int Pin0 = A0;
const int Pin1 = A1;
const int Pin2 = A2; // Analog pin where the resistor is connected
int Vin = 5;

float Rmain = 1000.0;
float convert = 1023.0;

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
  //int sensorValue = analogRead(Pin);
  int sensorValue = ((analogRead(Pin) / 5) * 5); // Read the analog pin
  //float recalc = sensorValue * (Vin / convert);
  //float R = (Rmain * recalc)/(Vin-recalc);

  //Serial.print("Sens: ");
  //Serial.println(sensorValue);
  //Serial.print("Recalc: ");
  //Serial.println(recalc);
  Serial.print("R" + String(Pin-13) + " :");
  //Serial.print("R: ");
  Serial.println(sensorValue);
  Serial.println("");
}