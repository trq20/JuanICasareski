from math import sin, cos, pi, radians
from time import sleep
from machine import Pin, SPI
import st7789

tft = st7789.ST7789(
    SPI(2, baudrate=30000000, polarity=1, phase=1, sck=Pin(18), mosi=Pin(19)),
    240,
    240,
    reset=Pin(23, Pin.OUT),
    dc=Pin(22, Pin.OUT)
)

tft.init()  # Inicializacion del display

WHITE = st7789.WHITE
BLACK =  st7789.BLACK
circulox = 120
circuloy = 120
radio = 90

for hora in range(60):
    for a in range(60):
        x = int(cos(radians(a*6))*radio)
        y = int(sin(radians(a*6))*radio)
        tft.pixel(circulox+x, circuloy+y, WHITE)

        if a == hora:
            tft.line(circulox, circuloy, circulox+x, circuloy+y, WHITE)
        sleep(1)
    tft.fill(BLACK)





