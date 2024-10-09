# Motor Driver Specifications

Shrew-Lite uses DRV8231A motor drivers. Shrew-Pro uses DRV8244 motor drivers. Both of these are integrated H-bridge chips. The datasheets can be [found here (click here)](datasheets-manuals)

## Protection Features

The motor drivers that Shrew uses all feature over-current protection and over-temperature protection. This means, at least according to the manufacturer, they should never allow themselves to be overloaded to a degree that cause them to fail.

Importantly, these drivers also recover from the protected states automatically, and quite quickly.

These protection features are implemented as a shutdown. When the current limit is hit, the chip completely shutsdown, it does not attempt to lower the output to limit the current to a ceiling. Importantly, these drivers also recover from this state automatically, and quite quickly.

The DRV8231A features a very consistent current cutoff, specified at 3.7A. I've tested this with just Gecko motors, which have a stall current only just a little bit over the limit, and it basically refuses to even twitch. This means it's not waiting for much of a "warm up" before kicking in the protection.

The DRV8244's limit is more variable, between 21A and 40A, it is likely temperature dependant. This isn't a bad thing, it allows for more potential performance yet still having a protection when absolutely neccessary. If you analyze the MOSFET resistance of the DRV8244, the variability of the limit might be because it generates such little heat.

If you are building a robot with motors that need the DRV8244s, you will literally melt your motors way before surpassing 21A.

## MOSFET Resistance

All motor drivers have MOSFETs, and while we want to think of MOSFETs as switches, MOSFETs do still have some small resistance. This is actually why MOSFETs heat up when passing current. In fact, this resistance called on-resistance, is probably the most enticing specification that people shop for.

Think about it, the current limit of a MOSFET is actually just a number that will let a MOSFET stay cool enough to survive. The on-resistance is the only thing that causes a MOSFET to heat up. The on-resistance and the ability for the MOSFET to transfer heat away are the two things that dictate what the current limit is. They are all related.

This resistance will also drop the voltage slightly as the current passes through. Your motor will get less voltage after this resistance, which means the motor is weaker. You want the least amount of MOSFET on-resistance to get the best performance out of your motor.

### Example Calculation

Pretend we are using a 12V power source, a motor that draws 3A of current at 12V, and the DRV8231A.

DRV8231A has a on-resistance of 600mΩ

The motor specs suggest its windings have a resistance of 4Ω

The total is 4.6Ω, and when you apply 12V of power and turn the motor driver on, the total current is `12 / 4.6 = 2.6`, 2.6A

Through the MOSFET, that 600mΩ is resulting in, `2.6 * 0.6 = 1.57`, 1.57V loss of voltage going to the motor. Also, it is wasting, `1.57 * 2.6 = 4.08`, 4.08W of heat.

Now, upgrade to a DRV8244, which features a 47mΩ on-resistance (Excuse me? It's that low? YES! This chip represents a technological leap in MOSFET manufacturing technology)

The total current is `12 / 4.047 = 2.965`, 2.965A

The loss through the MOSFET is `2.965 * 0.047 = 0.14`, 0.14V. And the wasted heat is `0.14 * 2.965 = 0.41`, 0.41W.

This means the DRV8244 can give you 13% more torque and speed than the DRV8231A when using the same motors and same input voltage.

This also means you can drive a motor roughly 10x more powerful with the DRV8244 and still get the same heat output as a DRV8231A. The DRV8244 is bigger physically as well so it can handle more heat because of that too.

For fun, consider the L298N motor driver, which was popular when I was a kid, and is still being sold today. It uses classic BJT transistors internally instead of MOSFETs. It's specified to handle 45V inputs and a current of 4A, which is quite respectable on the surface. But if you read the datasheet closely, you'll see that the on-resistance is about 2Ω, which is insanely high. Motors will run much slower with it and the driver is gigantic physically to dissipate the wasted heat.

Despite me raving about the DRV8244's advantages, the DRV8231A is not bad, it's quite good for its size and its price. It's lovely compared to the junk you might encounter that don't tell you what motor driver you are actually getting.
