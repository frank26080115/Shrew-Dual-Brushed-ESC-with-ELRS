# Microcontroller

The ESP32-PICO-D4 chosen, because ExpressLRS supports it. The AnyLeaf designs uses it https://github.com/AnyLeaf/elrs-hardware/

It has internal flash memory and no PSRAM.

The circuit design has taken into consideration all of the pin bootstrapping.

The SPI bus used to connect the SX1280 uses arbitary GPIO pins selected for convenience during PCB layout. Research indicated that the ESP32 can map any pin to any SPI bus function as long as only one SPI bus is being used. (if both VSPI and HSPI are being used, then you must use the specific pins assigned to both VSPI and HSPI)

The RF antenna is attached directly to the ESP32 LNA pin without any filtering or matching circuit. This is because the Wi-Fi functionality of the ESP32 is only used during reconfiguration and it will always be in close proximity to the user's smartphone.

# Radio

`SX1280IMLTRT` is used, because it is pretty much the only thing used for ExpressLRS in the 2.4GHz band.

It is configured to use DC-DC power mode, not the LDO mode. I have not found any example designs using LDO mode and I also don't see any advantage to using LDO mode.

`2450FM07D0034` is an all-in-one ceramic filter connected to the SX1280 before the antenna.

The SX1280 requires a 52MHz oscillator, ideally a temperature compensated one. The Seiko Epson `X1G0054410320` has been selected due to it's low cost and small size.

RF performance is not super critical. Most ExpressLRS receivers are meant for long range aircraft flight. For combat robotics, the range required is only a few feet at most.

# Motor Driver: DRV8231

`DRV8231ADSGR` is a tiny motor driver capable of up to 3.7A of current and can handle 33V of input voltage.

It features overcurrent protection. When the current limit is hit, it will disable itself for 3 milliseconds. It also features undervoltage-lockout and thermal shutdown.

Either the DRV8231 or the DRV8231A can be used in the design as current regulation is not being used at all.

https://www.ti.com/product/DRV8231A

https://www.digikey.com/en/products/detail/texas-instruments/DRV8231ADSGR/15854016

# Motor Driver: DRV8244

`DRV8244HQRYJRQ1` is capable of driving 21A of current and handle up to 35V of input voltage. The internal resistance of this driver is incredibly low at about 47 milli-ohms. In theory, this driver will run cooler than the DRV8231 for my use case.

The QFN footprint is selected. And the HW variant is chosen so that a SPI bus is not required for configuration.

This driver features over-current protection and over-temperature protection. It is configured to automatically retry when a fault is detected. The retry time is under 1 millisecond.

https://www.ti.com/product/DRV8244-Q1


# Voltage Regulator - Mini

`AP7375-33Y-13` https://www.digikey.com/en/products/detail/diodes-incorporated/AP7375-33Y-13/20371309

Rated for 45V and 300mA. Features thermal protection.

I don't expect any users to exceed 18V.

# Voltage Regulator - Mega

`LT1129CST-3.3#PBF` https://www.digikey.com/en/products/detail/analog-devices-inc/LT1129CST-3-3-PBF/889181

`MIC5239-3.3YS-TR` https://www.digikey.com/en/products/detail/microchip-technology/MIC5239-3-3YS-TR/1030750

These LDO voltage regulators have a decent rating and also require low valued ceramic capacitors.
