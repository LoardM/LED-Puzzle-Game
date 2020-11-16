
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;


namespace Game
{
    public class Joystick
    {
        private IGpioPin JS;
        public Joystick(JoystickE direction, P1 pin)        //Setzt die Charakterdaten, den Namen und welche Pin dazugehört.
        {
            Direction = direction;
            JS = Pi.Gpio[pin];
            JS.PinMode = GpioPinDriveMode.Input;
        }

        public JoystickE Direction { get; }


        public bool Read
        {
            get { return JS.Read(); }  //liest den Joystick aus und gibt das dann zurück.



        }


    }
}
