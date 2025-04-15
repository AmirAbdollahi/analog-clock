# Analog Clock

A simple analog clock application built using C# and Windows Forms.

## Features

- **Real-time Clock**: Displays the current time with hour, minute, and second hands.
- **Smooth Animation**: Hands move smoothly to reflect the passing time.
- **Minimalistic UI**: Clean and intuitive user interface.

## Technical Details

- **Language**: C#
- **Framework**: Windows Forms (.NET Framework)
- **Main Components**:
  - **AnalogClockForm**: The main form that hosts the clock.
  - **Timer**: A timer controls the clock's update interval.
  - **Graphics**: Used for rendering the clock face and hands.
- **Rendering**:
  - The clock face is drawn using the `Graphics` class.
  - The hour, minute, and second hands are drawn as lines originating from the center of the clock.
  - The hands are rotated based on the current time using trigonometric calculations.
- **Timer Interval**: The timer's interval is set to 1000 milliseconds (1 second) to update the clock every second.
- **Time Calculation**:
  - The current time is obtained using `DateTime.Now`.
  - The angles for the hands are calculated based on the current time.
  - The angles are then converted to radians for the `Math.Sin` and `Math.Cos` functions.
- **UI Updates**: The `Invalidate` method is called to trigger a repaint of the form, ensuring the clock is updated every second.

## Installation

1. Clone this repository:

   ```bash
   git clone https://github.com/AmirAbdollahi/analog-clock.git
   ```


2. Open the solution file (`Analog Clock.sln`) in Visual Studio.
3. Build and run the project.

## Usage

Upon running the application, an analog clock window will appear, displaying the current time.

## Contributing

Contributions are welcome! Please fork the repository, make your changes, and submit a pull request.

## License

This project is licensed under the MIT License.
