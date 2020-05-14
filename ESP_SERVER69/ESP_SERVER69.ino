#include <WiFiUdp.h>
#include "ESP8266WiFi.h"
#include <Ethernet2.h>

WiFiUDP Udp;

const char *essid = "Imp";
const char *key = "Braindead6233";

const char *remIp = "192.168.1.66";
int remPort = 25066;

const int INNER_LED = 2;
const int timeCheck = 5000; // ms

char  replyPacket[] = "Hi there! Got the message :-)";

void setup() {
  Serial.begin(115200);

  pinMode(INNER_LED,OUTPUT);
  digitalWrite(INNER_LED, HIGH);
  
  WiFi.hostname("esp_server69");
  WiFi.begin(essid,key);
  
  Serial.println("\n");
  Serial.print("Connecting");  
  
  while (WiFi.status() != WL_CONNECTED)
  {
    delay(500);
    Serial.print(".");
  }
  Serial.println();

  Serial.println("Connected. Local network settings:");
  
  Serial.print("IP address: ");           
  Serial.println(WiFi.localIP());
  
  Serial.print("Subnet Mask: ");           
  Serial.println(WiFi.subnetMask());
  
  Serial.print("Gateway IP: ");           
  Serial.println(WiFi.gatewayIP());

  Serial.print("MAC: ");
  Serial.println(WiFi.macAddress());

  Serial.println("---------");

  
}

void loop() {
  if (WiFi.status() == WL_CONNECTED)
  {      
    Serial.println("Connection +present");    
    digitalWrite(INNER_LED, LOW);
  }
  else
  {    
    Serial.println("Connection -lost");  
    WiFi.begin(essid,key);
    digitalWrite(INNER_LED, HIGH);
  }

  Udp.beginPacket(remIp, remPort);
  Udp.write(replyPacket);
   Udp.endPacket();

  delay(timeCheck);  
}
