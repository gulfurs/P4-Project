unsigned long last_time = 0;
const int buttonPin = 2;  // The pin the button is connected to

void setup()
{
    Serial.begin(9600);
    pinMode(buttonPin, INPUT);  // Set the button pin as input
}

void loop()
{
    // Print a heartbeat
    if (millis() > last_time + 2000)
    {
        Serial.println("Simon er fra Havnen!");
        last_time = millis();
    }

      int buttonState = digitalRead(buttonPin);  // Read the state of the button

    // Print the state of the button to the Serial Monitor
    Serial.print("Button state: ");
    Serial.println(buttonState);

    //delay(100);  // Delay to debounce the button (optional)
    // Send some message when I receive an 'A' or a 'Z'.
    switch (Serial.read())
    {
        case 'A':
            Serial.println("That's the first letter of the abecedarium.");
            break;
        case 'Z':
            Serial.println("That's the last letter of the abecedarium.");
            break;
    }
}