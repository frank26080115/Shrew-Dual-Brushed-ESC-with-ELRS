# Revision Zero

The first batch of prototypes were made around June of 2024. This batch is special and different from subsequent batches.

All PCBs are made without castellated edge holes to save cost. This makes the PCB a bit bigger than intended. To join the receiver and motor driver PCBs together, the edge of the PCB can be sanded down first to create castellated edge holes that are soldered together.

The receiver PCB half is manufactured as a standard 4 layer PCB with 1 oz copper. The mini motor driver PCB is made with a 2 layer PCB with 1 oz copper. The mega motor driver is made with a 2 layer PCB with 2 oz copper. Any future revisions with the two halves integrated will need to use a 4 layer PCB.

I forgot to put some silkscreen text on the PCBs. Please refer to diagram to avoid any wiring mistakes.

The footprints being used for the 0402 components are a bit larger than what the PCB manufacture prefers, but this might help me when I am hand soldering or doing repair work. Future revisions will have a smaller footprint for the 0402 components.

## Mini Motor Driver

The components for revision-zero may differ from future cost optimized revisions.

The voltage regulator is a [DS8242-33A3L](https://jlcpcb.com/partdetail/Dstech-DS824233A3L/C5884130), which is rated for up to 23V input continuously, 28V absolute maximum. It claims to output 500mA continuously when not considering thermal derating. It does feature thermal limiting. Dropout voltage is 0.5V.

The input capacitors on this circuit are four [C440198](https://jlcpcb.com/partdetail/439567-GRM21BR61H106KE43L/C440198), 10uF 50V X5R +/-10% ceramic capacitors. Future revisions may aim to use capacitors that have higher capacitance.

## Mega Motor Driver

The revision-zero mega variant motor driver is completely hand soldered.

The voltage regulator on it is a [MIC5239-3.3YS](https://www.digikey.com/en/products/detail/microchip-technology/MIC5239-3-3YS-TR/1030750). It is rated for a 30V input, 32V absolute maximum input. It claims to output 500mA continuously when not considering thermal derating. It does feature thermal limiting. Dropout voltage is 0.35V.

The input capacitors on this circuit are 7x [C2012X5R1V226M125AC](https://www.digikey.com/en/products/detail/tdk-corporation/C2012X5R1V226M125AC/3951664), 22uF 35V X5R ceramic capacitors. These are somewhat expensive and may not be used in future cost optimized revisions.
