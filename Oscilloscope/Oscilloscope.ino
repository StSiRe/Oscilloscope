//volatile uint8_t A01;  
//volatile uint8_t A02;  
int pin1 = A0,pin2 = A1;
void setup()    
{   
  Serial.begin(115200);
  /* ADCSRA=(1<<ADEN)|(1<<ADIE)|(1<<ADSC)|(1<<ADATE)|(1<<ADPS1)|(1<<ADPS0);  
   ADMUX=(1<<ADLAR)|(1<<REFS1)|(1<<REFS0);  */
  pinMode(pin1,INPUT);
  pinMode(pin2,INPUT);
  
  analogWrite(6,16);//fOR EXAMPLE

   
}  

void loop()    
{ 
  //SendToHooliGraph();
  //SendToArduino();
  SendToSerialPlotter();
} 
void SendToHooliGraph()//Start sending data to Hooli.Graph
{
  for(;;)
  {
    Serial.print("$");
    Serial.print(analogRead(A0));
    Serial.print(" ");
    Serial.print(analogRead(A1));
    Serial.println(";");
  }
}
void SendToArduino()
{
  for(;;)
  {
    Serial.print(analogRead(A0));
    Serial.print(" ");
    Serial.println(analogRead(A1));
  }
}
void SendToSerialPlotter()
{
  for(;;)
  {
    Serial.println("$");
    Serial.println(analogRead(A0));
    Serial.println(" ");
    Serial.println(analogRead(A1));
    Serial.println(";");
  }
}
/*
ISR(ADC_vect)  
{  
   A01 = ADCH; 
   A02 =    
} 
*/
