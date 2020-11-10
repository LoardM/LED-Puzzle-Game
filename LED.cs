using System;
using Unosquare.RaspberryIO;
using Unosquare.WiringPi;
using Unosquare.RaspberryIO.Abstractions;
using System.Threading;
using System.Diagnostics;

namespace Game
{
    public class LED
    {
        //public static IGpioPin Green;
        //public static IGpioPin Yellow;
        //public static IGpioPin Blue;
        //public static IGpioPin Red;
        //public static IGpioPin Colour;

        //public LED()
        //{
        //    Green =  Pi.Gpio[P1.Pin36];
        //    Yellow = Pi.Gpio[P1.Pin38];
        //    Blue = Pi.Gpio[P1.Pin32];
        //    Red = Pi.Gpio[P1.Pin40];

        //    Green.PinMode = GpioPinDriveMode.Output;
        //    Yellow.PinMode = GpioPinDriveMode.Output;
        //    Blue.PinMode = GpioPinDriveMode.Output;
        //    Red.PinMode = GpioPinDriveMode.Output;

        //}


        private IGpioPin ledPin;
        public LED(LEDColor color, P1 pin)
        {
            Color = color;
            ledPin = Pi.Gpio[pin];
            ledPin.PinMode = GpioPinDriveMode.Output;
        }

        public LEDColor Color { get; }

        public bool Enable
        {
            get { return ledPin.Read(); }
            set { ledPin.Write(value); }
        }
        public void Toggle()
        {
            Enable = !Enable;
        }




    }
}
