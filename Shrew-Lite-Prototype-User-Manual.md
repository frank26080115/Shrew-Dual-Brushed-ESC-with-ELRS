# Shrew-Lite Prototype User Manual

Shrew-Lite is a dual brushed motor ESC with an integrated ExpressLRS RC radio receiver.

 * Maximum voltage: 18V (4S lithium ion)
 * Recommended voltage: 6V-14V (2S-3S lithium ion)
 * Current rating per brushed motor channel: 3.7A each
 * Has over-current protection and over-temperature protection
 * 4 digital outputs, capable of PWM, PWM-stretched, DShot, CRSF, SBUS

**IMPORTANT:** This version of the user manual is specifically for the first batch of prototypes. Literally only one or maybe two people should be reading this. If you are not using these for sbockey, you should probably stop reading.

## Pin Map

![](docs/imgs/shrew-lite-proto-pinout.png)

Motor-A is assigned to channel 1. Motor-B is assigned to channel 2. These assignments cannot be changed.

The `CHAN` number is the PWM channel number under default configuration. The `GPIO` numbers are the ones that can be used in the JSON configuration or in the firmware source code. The `UART`, aka serial port, can be remapped. A second serial port can be configured by the user. Note that the UART pins can be used for additional PWM/DSHOT pins if you want 4 channels instead of 2 channels.

## Dimensions

![](docs/imgs/shrew-lite-proto-dimensions.png)

## LED Blink Meaning

| Behaviour | Meaning |
|-----------|---------|
| ![](docs/imgs/led-blinks/disconnected.webp) | not connected, waiting for connection <br> orange regular blink |
| ![](docs/imgs/led-blinks/nobind.webp) | not bound, please bind it to a transmitter <br> orange double blink |
| ![](docs/imgs/led-blinks/wifi.webp) | Wi-Fi mode <br> green yellow green animation |
| ![](docs/imgs/led-blinks/active.webp) | connected and active <br> solid colour, colour changes as the radio transmitter sticks/channels move |

(above table contains animations, appologies if they are not playing correctly)

## Transmitter Preperation

Just in case you need it, here are some links to official ExpressLRS instructions on how to prepare your transmitter:

 * [Radio Preperation](https://www.expresslrs.org/quick-start/transmitters/tx-prep/)
 * [Lua Script Install](https://www.expresslrs.org/quick-start/transmitters/lua-howto/)

**Important Note:** Your transmitter can run official ExpressLRS firmware, as long as it is version `3.3.0` and later. **You can use ExpressLRS Configurator to update your transmitter**

**Important Note Continued:** The Shrew firmware is not official ExpressLRS firmware, and does not have to match to the transmitter firmware. **Do not use the ExpressLRS Configurator to update Shrew**.

I hope you have followed the instructions above and have access to the ExpressLRS Lua script on your transmitter. Run the `ExpressLRS` script, scroll down and select `WiFi Connectivity`, and then select `Enable WiFi`.

![](docs/imgs/transmitter-activate-wifi.png)

From your phone or computer, connect to the `ExpressLRS TX` Wi-Fi access point. The password is `expresslrs`.

![](docs/imgs/smartphone-wifilist-tx.png)

Use your web-browser to navigate to `http://10.0.0.1/`

![](docs/imgs/wifiui-browser.png)

Scroll down and edit the binding-phrase and then save it.

![](docs/imgs/wifiui-binding-phrase.png)

Once you have saved it, **turn off the radio**, or at least exit Wi-Fi mode.

## First Time Binding

For the set of prototypes of Shrew-Lite, you have been given a USB power adapter cable. This cable supplies your robot with 5V of power. Please use this to power up the Shrew-Lite whenever you are trying to use its Wi-Fi functionality. **The prototype firmware will refuse to go into Wi-Fi mode if the voltage is above 5.8V**

(the 5V power is low enough to avoid an overheating problem, battery voltages above 6V will cause the voltage regulator to overheat while in Wi-Fi mode)

![](docs/imgs/shrew-lite-proto-usb-adapter.jpg)

When Shrew is powered, the LED should start blinking orange. Wait for about 60 seconds. Then the LED will start to go crazy (it's like a green-yellow fading animation). This means the Shrew has activated its own Wi-Fi access point.

Using your phone or computer, connect to the `ExpressLRS RX` Wi-Fi access point. The password is `expresslrs`.

![](docs/imgs/smartphone-wifilist-rx.png)

Use your web-browser to navigate to `http://10.0.0.1/`

![](docs/imgs/wifiui-browser.png)

Scroll down and edit the binding-phrase and then save it.

![](docs/imgs/wifiui-binding-phrase.png)

Once you have done that, Shrew should be ready to use with default settings.

**IMPORTANT:** The Shrew firmware disables the activation of binding mode by power cycling it 3 times. This is done to prevent accidental activation of binding mode.

## Please Set Packet-Rate

ExpressLRS is originally intended for racing drones with high responsiveness, but that means your transmitter is likely set to a super high packet-rate. The high packet-rate setting does not send all of the channels. We need to change the packet-rate to something lower that sends all of the channels.

Use the `ExpressLRS` Lua script again, set the `Packet Rate` option to `100Hz Full`. Then set the `Switch Mode` to `16ch Rate/2`.

![](docs/imgs/transmitter-change-packet-rate.png)

For a full explanation, ExpressLRS officially has this documentation: https://www.expresslrs.org/software/switch-config/ . Only the 100Hz and 333Hz modes support full resolution channels, and only the rate/2 mode allows channel 5 to work normally.

If you want the best possible performance, read the section on `Packet Rate Lock` later on.

## First Test

Have your radio transmitter powered up and ready to use. Power-cycle Shrew, it should connect to your transmitter, the LED should stay a solid colour, and your transmitter should indicate that it is connected (you might see a RSSI symbol somewhere on your screen).

![](docs/imgs/rssi-symbol.png)

Moving any sticks/channels on the transmitter should make the LED on the Shrew change colour. (experimental feature, ExpressLRS receivers don't typically do this, but Shrew firmware does)

## Robot Drive Mixing

I have provided mixes for your transmitter. It involves copying a file to your transmitter's microSD card. Please see [this page for full details](tx-mixes/readme.md).

Otherwise, make your own mix however you want, just remember that Motor-A is always channel 1 and Motor-B is always channel 2.

## Activating Wi-Fi

To configure anything on Shrew, you need to connect to its web-ui via Wi-Fi.

For the set of prototypes of Shrew-Lite, you have been given a USB power adapter cable. This cable supplies your robot with 5V of power. Please use this to power up the Shrew-Lite whenever you are trying to use its Wi-Fi functionality. **The prototype firmware will refuse to go into Wi-Fi mode if the voltage is above 5.8V**

(the 5V power is low enough to avoid an overheating problem, battery voltages above 6V will cause the voltage regulator to overheat while in Wi-Fi mode)

![](docs/imgs/shrew-lite-proto-usb-adapter.jpg)

There are two ways of activating Wi-Fi on Shrew.

 * Powering it up without a transmitter, and then waiting for 60 seconds. (this time period is configurable)
 * Powering it up, connect it to the transmitter, and then using the transmitter's Lua script to activate Wi-Fi. This is similar to activating the transmitter's own Wi-Fi, but you use the `[Enable Rx WiFi]` option instead.

![](docs/imgs/transmitter-activate-wifi-rx.png)

From your phone or computer, connect to the `ExpressLRS TX` Wi-Fi access point. The password is `expresslrs`.

![](docs/imgs/smartphone-wifilist-rx.png)

Use your web-browser to navigate to `http://10.0.0.1/`

![](docs/imgs/wifiui-browser.png)

## Editing the Channels

Once you are on the Wi-Fi web-ui page, you should see a table like this:

![](docs/imgs/shrew-zero-channel-table.png)

If you are using a ESC that supports DShot protocol (specifically DSHOT300), it is recommended that you change the `Mode` drop-down to `DShot`. Otherwise, use `50Hz` mode for servos and ESCs that do not support DShot. Ignore the other modes for now.

![](docs/imgs/shrew-zero-channel-table-mode.png)

To rearrange the channel mapping, use the `Input` drop-down to select the radio channel that the output should be mapped to.

![](docs/imgs/shrew-zero-channel-table-channel.png)

The servo-stretching feature can be activated by checking the `Stretch?` checkbox. Servo stretching means that the sent PWM pulse width is from 476us to 2524us instead of 988us to 2012us. This is useful for wide range servos.

![](docs/imgs/shrew-zero-channel-table-stretch.png)

The failsafe mode should be left at `No Pulse`, this is the safest option. (other options are explained)

![](docs/imgs/shrew-zero-channel-table-failsafe.png)

## Other Notable Options

#### Packet Rate Lock

I recommend you activate this option:

![](docs/imgs/wifiui-packet-rate.png)

In the previous steps, I have asked you to set the packet-rate to 100Hz already. Locking it on Shrew will allow for it to reconnect a bit faster.

#### AM32 Configurator

While connected to the Wi-Fi web-ui, use the web browser to visit `http://10.0.0.1/am32.html`

![](docs/imgs/wifiui-am32-config-intro.png)

#### More Advanced Usage

ExpressLRS is open source, and the source code for Shrew is a fork of the ExpressLRS source code. If you wish to add your own features to Shrew's source code, the starting point is at [https://github.com/frank26080115/ExpressLRS/tree/shrew](https://github.com/frank26080115/ExpressLRS/tree/shrew).

The GPIOs are capable of things like I2C, an extra serial port, or even CAN bus.

## Firmware Update

If there is a firmware update, it will be provided from me personally, as you have a special prototype. Once you have the file, it can be uploaded to the `Update` tab in the Wi-Fi web-ui.

![](docs/imgs/wifiui-fw-update-tab.png)

**IMPORTANT:** Updating the firmware in any way will reset all settings to the default as specified in the firmware. Please double check your settings after every firmware update.

If you need to update the firmware via a USB-to-serial converter, then follow the instructions on [firmware updating via USB](docs/Firmware-Updating-via-USB.md). (for example, if Wi-Fi is unavailable due to corrupted firmware, or, if you are building the circuit at home instead of purchasing one)

## Wiring Hints

The design allows you to run the wires in one direction and then wrap it all in heat shrink tubing.

![](docs/imgs/shrew-lite-wire-hint.jpg)

![](docs/imgs/shrew-lite-wire-hint-heatshrink.jpg)

The connectors I put on for the motors are GNB A30 connectors.

![](docs/imgs/gnba30.jpg)

Notice that I do not put the wires through the holes, the wires are soldered to the surface instead, there is enough solder to actually fill the holes though. This is all intentional and the way I recommend you solder wires to Shrew.

![](docs/imgs/shrew-lite-wire-surface.jpg)

## Appendix

 * [Reassigning Pins](docs/Reassigning-Pins.md)
 * [Digital Protocols for ESC Control](docs/Digital-Protocols-for-ESC-Control.md), and why they are better
 * [No-Pulse Failsafe Mode](docs/No-Pulse-Failsafe-Mode.md), and why it's safer
