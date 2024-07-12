#include <Arduino.h>

void setup()
{
    Serial.begin(9600);
}

void loop()
{
    Serial.printf("Hello World! %d\r\n", millis());
    delay(500);
}
