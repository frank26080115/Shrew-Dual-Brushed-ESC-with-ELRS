Build from development branch ca68a5529578e69162ccdd16afd8aebe9cb593b7

This version fixes AM32 not responding to DSHOT.

A new DSHOT mode has been added called "Dshot-3D", and it must be used if the ESC is configured for bidirectional rotation (such as for robot drive motors)

Added some minor features to the AM32 configurator:
 * make "complementary PWM" enabled if "bidirectional" is enabled
 * asking if the user wants to switch to/from Dshot-3D if bidirectional is enabled/disabled

Added a mixer for arcade tank drive mixing.
