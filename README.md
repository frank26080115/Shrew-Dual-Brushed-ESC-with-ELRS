# Shrew: Dual Brushed ESC with ELRS

Shrew is a ESC that can drive two brushed motors, with ELRS integrated. It is designed to be as small as possible yet still pack plenty of power. It is meant for insect class combat robots.

There are two variations of Shrew, and so Shrew is actually designed as two circuit boards. The first circuit board is called the Shrew-RX and it contains all of the ExpressLRS circuitry. The second circuit board contains two motor driver ICs and a 3.3V voltage regulator that converts the high battery voltage to the low voltage that the Shrew-RX needs.

The user is expected to solder the two circuit boards together to form one final board.

![](docs/imgs/shrew-family-rev0.jpg)

![](docs/imgs/shrew-rev0-malenki-compare.jpg)

There are two variations of the motor driver circuit board: the Mini, and the Mega.

The Mini is rated for 4S batteries and can drive up to 3.7A per motor. It is small, the final size is 24mm x 14mm. This is designed for a few friends who are building small 150g fairyweight class robots.

The Mega version is rated for 6S batteries and can drive up to 21A per motor. It is a bit bigger, 28mm x 18mm. This is designed for my own 3lbs beetleweight class robot that are trying to run JCR Viper motors (they stall at 12A).

The Shrew-RX also has two more additional outputs to allow the user to attach devices such as servos and other ESCs. The UART pins are also available to output CRSF data. It can also read battery voltage and report it back through radio telemetry.

The Shrew-RX runs a special build of ExpressLRS firmware so that it can drive all of the motor drivers using only two CRSF channels. This firmware is technically optional, but it makes it so much easier to use.

## Revision Zero

Current revision has serious flaws and the design files on this repository should not be used.

I have documented the flaws and test results: [Revision Zero](docs/Revision-Zero.md)

## Open Source Notes

All of the circuitry is designed using CadSoft EAGLE v7. This is NOT Autodesk EAGLE, but Autodesk EAGLE can open the files.

All the manufacturing data is tailored for JLCPCB's PCBA service.

The firmware in this repo are in binary form only, but the source code for them are on a branch of a fork of ExpressLRS: https://github.com/frank26080115/ExpressLRS/tree/shrew
