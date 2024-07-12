#include <Arduino.h>

#define HBRIDGE_PIN_A1 10
#define HBRIDGE_PIN_A2 9
#define HBRIDGE_PIN_B1 19
#define HBRIDGE_PIN_B2 22
#define HBRIDGE_PWM_FREQ 24000U

void setup()
{
    pinMode(HBRIDGE_PIN_A1, OUTPUT);
    pinMode(HBRIDGE_PIN_A2, OUTPUT);
    pinMode(HBRIDGE_PIN_B1, OUTPUT);
    pinMode(HBRIDGE_PIN_B2, OUTPUT);
    analogWriteResolution(8);
    analogWriteFrequency(HBRIDGE_PWM_FREQ);
    analogWrite(HBRIDGE_PIN_A1, 0);
    analogWrite(HBRIDGE_PIN_A2, 0);
    analogWrite(HBRIDGE_PIN_B1, 0);
    analogWrite(HBRIDGE_PIN_B2, 0);
}

void loop()
{
    static uint32_t x = 0;
    uint32_t y;
    y = (x + (16 * 1)) % 256;
    analogWrite(HBRIDGE_PIN_A1, y);
    y = (x + (16 * 2)) % 256;
    analogWrite(HBRIDGE_PIN_A2, y);
    y = (x + (16 * 3)) % 256;
    analogWrite(HBRIDGE_PIN_B1, y);
    y = (x + (16 * 4)) % 256;
    analogWrite(HBRIDGE_PIN_B2, y);
    x = (x + 1) % 256;
    delay(1);
}
