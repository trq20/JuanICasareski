from math import sin, cos, radians
from time import sleep
from machine import Pin, SPI, ADC
import st7789

tft = st7789.ST7789(
    SPI(2, baudrate=30000000, polarity=1, phase=1, sck=Pin(18), mosi=Pin(19)),
    240,
    240,
    reset=Pin(23, Pin.OUT),
    dc=Pin(22, Pin.OUT)
)

tft.init()

WHITE = st7789.WHITE
BLACK =  st7789.BLACK
circulox = 120
circuloy = 120
radio = 90

adc = ADC(Pin(36))

def indicar(ang):
    for a in range(360):
        x = int(cos(radians(a))*radio)
        y = int(sin(radians(a))*radio)
        tft.pixel(circulox+x, circuloy+y, WHITE)

    xLinea = int(cos(radians(ang))*radio)
    yLinea = int(sin(radians(ang))*radio)
    tft.line(circulox, circuloy, circulox-xLinea, circuloy+yLinea, WHITE)

    sleep(1)
    tft.fill(BLACK)

while(1):
    entrada = adc.read()
    angulo = entrada*180/4095
    indicar(angulo)
