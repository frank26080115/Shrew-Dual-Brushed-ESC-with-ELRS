# Shrew Firmware Development Hints

## Summary of Project Structure

The ExpressLRS firmware is written as a PlatformIO project. The programming language is C++ mostly. It supports multiple microcontroller architectures but all of the code is built on top of the Arduino framework. Shrew is built with a ESP32 microcontroller.

Every firmware build comprises of two parts: the firmware binary itself, and a block of default configuration data. The block of configuration data is what contains the pin mappings. The configuration can be changed later through the Wi-Fi web interface.

The flash memory comprises of 3 parts: the firmware, the EEPROM (it's an emulated EEPROM), and the file-system. There are some rules about firmware updating that determines if the EEPROM and file-system is erased during the update. Sometimes they are erased, sometimes they are not. If you need to, PlatformIO provides a specific button to erase all of the flash memory. During development and testing, I recommend you always erase flash memory completely.

The firmware is multitasking, but it is not using RTOS threads. FreeRTOS is available in the project for Shrew as it is using ESP32, but multithreading is not heavily used.

The firmware has some core functionality, which handles how the transmitter and receiver communicates. The other functions are implemented as "Devices", which are individual state machines.

The build process is taken care of by PlatformIO but there are some Python scripts that are used to pack all the HTML files and JSON files into the firmware.

NOTE: web pages being served by the Wi-Fi mode are not stored in file-system, they are actually compiled into the code with the help of some python scripting

## Cardinal Rules

Do not use the multithreading features of FreeRTOS.

Do not let your code run in a long loop that blocks other code from running. Do not use delays. Do not write code that can cause the radio to miss a packet!

Do not halt the timers that the core code depends on.

Do not disable any interrupts.

All of the above pretty much means: please use state machines

Do not use pins that are forbidden to be used on the ESP32 (there are some internal memory pins that cannot be used).

## How to Change Pin Assignments

The majority of pin assignments are defined in a set of JSON files under the `ExpressLRS/src/hardware/RX` directory.

For Shrew, the two files are `ShrewESC.json` and `Shrew-Zero.json` depending on which variation of Shrew you want to use.

For all other ExpressLRS hardware, you need to read through `targets.json` under the directory `ExpressLRS/src/hardware` to figure out which file should be edited.

For Shrew-Lite and Shrew-Pro (which uses the term `ShrewESC` in the code), the pin assignments for the H-bridge inputs are hard-coded in the source code, not in the JSON files.

## How to Set Default User Options

Look inside the `ExpressLRS/src` directory for a file named `user_defines.txt`. Edit this file as you wish before compiling.

This can be useful for testing as it allows you to preset the binding phrase and lower the time before enabling Wi-Fi.

## How to Set Compiler Flags

Look inside the `ExpressLRS/src/targets` directory for a file named `shrew.ini`. It would also be helpful if you read `unified.ini` as well. You will see how the build flags are defined and how they are inherited.

If you do edit `shrew.ini` or `unified.ini`, PlatformIO will not detect the change immediately. But look inside the directory `ExpressLRS/src` for `platformio.ini`. Make a small change, like add a spacebar, revert the change, and then save it. Changes to `platformio.ini` will force PlatformIO to refresh all build options.

## Adding Code

If you are new at adding code to ExpressLRS, then I suggest you add it to an existing file. Look inside the directory `ExpressLRS/src/lib`, which will have a list of subdirectories with small code modules. Find the one that is related to what you want to add.

As an example, Shrew's ability to control H-bridge drivers is similar to outputting PWM pulses for servos. So I added the code into the `ServoOutput` module.

The neat thing about the `ServoOutput` module is that it contains code that is constantly running.

## Adding Web Pages

Web pages and other files that needs to be served are stored in the `ExpressLRS/src/html` directory. They are not automatically included. You need to also:

 * edit `ExpressLRS/src/lib/WIFI/devWIFI.cpp`, look for a variable called `files[]`, and add your file to the list
 * edit `ExpressLRS/src/python/build_html.py`, look for a function named `build_common`, and add your file to the list

The files can have pre-processor actions. I suggest you read the existing files to see how those are used. The pre-processor directives use the `@@` symbol.

NOTE: whitespace is stripped from HTML files to save space, which might break JavaScript placed in HTML files

NOTE: the files are minified and gzip compressed automatically, so don't worry too much about saving memory

If you need additional backend handling of HTTP requests, you will need to add handlers to the actual source code. The file you are interested in is `ExpressLRS/src/lib/WIFI/devWIFI.cpp`. The firmware uses the `ESPAsyncWebServer` library extensively. If you know how to use this library then you will have the skills to add backend functionality, it's documentation is here: https://github.com/me-no-dev/ESPAsyncWebServer

If you do not want to add code to `devWIFI.cpp` itself, then write functions that can take the `server` object as a parameter and add the handlers to that object.
