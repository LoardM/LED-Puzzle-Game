using System;
using Unosquare.RaspberryIO;
using Unosquare.WiringPi;
using Unosquare.RaspberryIO.Abstractions;
using System.Threading;

namespace Game
{
    public class Joystick
    {
        private IGpioPin JS;
        public Joystick(JoystickE direction, P1 pin)
        {
            Direction = direction;
            JS = Pi.Gpio[pin];
            JS.PinMode = GpioPinDriveMode.Input;
        }

        public JoystickE Direction { get; }


        public bool Read
        {
            get { return JS.Read(); }



        }

        
        



        //private IGpioPin JSP;
        //private IGpioPin JSU;
        //private IGpioPin JSD;
        //private IGpioPin JSL;
        //private IGpioPin JSR;

        //public Joystick()
        //{
        //    JSP = Pi.Gpio[P1.Pin37];
        //    JSU = Pi.Gpio[P1.Pin35];
        //    JSD = Pi.Gpio[P1.Pin33];
        //    JSL = Pi.Gpio[P1.Pin31];
        //    JSR = Pi.Gpio[P1.Pin29];

        //    JSP.PinMode = GpioPinDriveMode.Input;
        //    JSU.PinMode = GpioPinDriveMode.Input;
        //    JSD.PinMode = GpioPinDriveMode.Input;
        //    JSL.PinMode = GpioPinDriveMode.Input;
        //    JSR.PinMode = GpioPinDriveMode.Input;



    


    }
}
