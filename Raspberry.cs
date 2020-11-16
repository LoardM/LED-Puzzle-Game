using System;
using Unosquare.RaspberryIO;
using Unosquare.WiringPi;
using Unosquare.RaspberryIO.Abstractions;

namespace Game
{
    public class Raspberry
    {


        private LED ledGreen;
        private LED ledYellow;
        private LED ledBlue;
        private LED ledRed;
        private LED ledError;

        public static Joystick JSP;
        public static Joystick JSD;
        public static Joystick JSL;
        public static Joystick JSR;
        public static Joystick JSU;
        public static Joystick JSError;




        public Raspberry()                          //Teilt den LED objekten die Farbe und die LED-Pins zu.
        {
            Pi.Init<BootstrapWiringPi>();

            ledGreen = new LED(LEDColor.Green, P1.Pin36);
            ledYellow = new LED(LEDColor.Yellow, P1.Pin38);
            ledBlue = new LED(LEDColor.Blue, P1.Pin32);
            ledRed = new LED(LEDColor.Red, P1.Pin40);

            JSP = new Joystick(JoystickE.Push, P1.Pin37);
            JSD = new Joystick(JoystickE.Down, P1.Pin33);
            JSL = new Joystick(JoystickE.Left, P1.Pin31);
            JSR = new Joystick(JoystickE.Right, P1.Pin29);
            JSU = new Joystick(JoystickE.Up, P1.Pin35);

        }

    

        public LED this[LEDColor color]                     //Lässt sich wie ein Array aufrufen und man kann mithilfe eine LEDfarbe das entsprechende LED-Objekt abfragen.
        {
            get
            {
                switch (color)
                {
                    case LEDColor.Green: return ledGreen;
                    case LEDColor.Yellow: return ledYellow;
                    case LEDColor.Blue: return ledBlue;
                    case LEDColor.Red: return ledRed;
                    default: Console.WriteLine("Unbekannte LED" + color); return ledError;
                }
            }
        }

        public Joystick this[JoystickE direc]           // Mithilfe einer Richtung lässt sich das entsprechende Joystick-Objekt abfragen.
        {
            get
            {
                switch (direc)
                {
                    case JoystickE.Push: return JSP;
                    case JoystickE.Down: return JSD;
                    case JoystickE.Left: return JSL;
                    case JoystickE.Right: return JSR;
                    case JoystickE.Up: return JSU;

                    default: Console.WriteLine("Unbekannte Richtung" + direc); return JSError;
                }
            }
        }



    }
}
