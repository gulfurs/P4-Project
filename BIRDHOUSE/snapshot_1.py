import sensor
import time
import machine
import pyb
import image



p = pyb.Pin("P0", pyb.Pin.IN)
pin_value = p.value() # Returns 0 or 1.
print(pin_value)


sensor.reset()  # Reset and initialize the sensor.
sensor.set_pixformat(sensor.RGB565)  # Set pixel format to RGB565 (or GRAYSCALE)
sensor.set_framesize(sensor.QVGA)  # Set frame size to QVGA (320x240)
sensor.skip_frames(time=2000)  # Wait for settings take effect.

"""
while (True):

    pin_value = p.value() # Returns 0 or 1.

    print(pin_value)
"""


while True:
    pin_value = p.value()
    print(pin_value)

    if pin_value == 1:
        print("Ada")
        timestamp = time.localtime()
        sensor.reset()  # Reset and initialize the sensor.
        sensor.set_pixformat(sensor.RGB565)  # Set pixel format to RGB565 (or GRAYSCALE)
        sensor.set_framesize(sensor.QVGA)  # Set frame size to QVGA (320x240)
        sensor.skip_frames(time=2000)  # Wait for settings take effect

        led = machine.LED("LED_BLUE")
        start = time.ticks_ms()
        while time.ticks_diff(time.ticks_ms(), start) < 3000:
            sensor.snapshot()
            led.toggle()

        led.off()
        filename = "Bird_{}{}{}{}{}{}.jpg".format(timestamp[0], timestamp[1], timestamp[2], timestamp[3], timestamp[4], timestamp[5])
        img = sensor.snapshot()
        img.save(filename)  # or "example.bmp" (or others)
        pin_value = p.value()

        # raise (Exception("Please reset the camera to see the new file."))

    elif pin_value == 0:
        print("No Power")
        pin_value = p.value()












