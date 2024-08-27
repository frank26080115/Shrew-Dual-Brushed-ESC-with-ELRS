# No-Pulse Failsafe Mode

ExpressLRS features a failsafe mode called "no-pulse", which means that if the radio transmitter is disconnected somehow, the ExpressLRS receiver sends absolutely no signals to connected ESCs at all.

This is different from other RC radio receivers, where you set a specific pulse width that is to be sent when the radio transmitter is disconnected. This is called "set position" inside ExpressLRS, as ExpressLRS allows you to pick between three different failsafe modes.

The "set position" failsafe mode is not very safe when it is used in a hobby robotics context.

First, understand that ESCs typically require an **arming** signal before it will spin a motor. The arming signal is a signal that tells the ESC to stop spinning. This is supposed to ensure that the motor never starts spinning as soon as the user turns on the power switch. If the user left the throttle on the radio transmitter in a high position, and then powered-on the robot, it does not immediately start spinning the motor.

The problem is if the failsafe signal is also the stop signal, then that means the failsafe signal is also the arming signal. Disconnecting a radio transmitter will also arm the ESC, maybe without the user even realizing. If the user powers-on the robot but leaves the radio transmitter off, then the receiver will arm the ESC, and then if the user powers-on the radio transmitter next with a high throttle, then the motor will unexpectedly start spinning.

In contrast, when a no-pulse failsafe mode is used, then the **ESC will never arm unless both the radio transmitter is already powered-on and also the throttle is actually low**. And if the signal is lost, the **ESC will go back into an disarmed state**, waiting for another arming signal.

Also, with bidirectional ESCs using PWM, it is possible for high temperatures to cause the failsafe position to actually be misinterpreted, and then the motor will unexpectedly start spinning with no way of shutting it down. The no-pulse failsafe mode will prevent such incidents from happening.

While it is possible to configure most radio transmitters to warn the user if the transmitter has a high throttle when booting up, it is simply not reliable to expect the user to... actually do anything, even getting a user to read a manual is pretty hard (thanks for reading, by the way). These are also often kids. Thus, the Shrew is configured to use no-pulse by default.
