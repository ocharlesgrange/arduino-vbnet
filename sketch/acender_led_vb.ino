/* INSCREVA-SE NO CANAL:
 * https://www.youtube.com/channel/UCJTl75qEN7eRvBlAfjRHKAw - TUDO ELETRÔNICA
 * LIVRE PARA USO!!!
 */

int leds[3] = {9, 10, 11};

void setup() {
  pinMode(leds[0], OUTPUT);
  pinMode(leds[1], OUTPUT);
  pinMode(leds[2], OUTPUT);
  Serial.begin(9600);
}

void loop() {
  int value;
  if(Serial.available())
  {
    delay(50);
    while(Serial.available() > 0)
    {
      value = Serial.read();
      if(value == '1'){
        digitalWrite(leds[0], !digitalRead(leds[0]));
      }
      if(value == '2'){
        digitalWrite(leds[1], !digitalRead(leds[1]));
      }
      if(value == '3'){
        digitalWrite(leds[2], !digitalRead(leds[2]));
      }
    }
  }
}
