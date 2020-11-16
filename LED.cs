
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;

namespace Game
{
    public class LED
    {

        private IGpioPin ledPin;
        public LED(LEDColor color, P1 pin)  //Setzt die Charakterdaten der Klasse. Die Farbe und den dazugehörigen Pin.
        {
            Color = color;
            ledPin = Pi.Gpio[pin];
            ledPin.PinMode = GpioPinDriveMode.Output;
        }

        public LEDColor Color { get; }    //Speichert die Farbe des LED's.

        public bool Enable                //get gibt den aktuellen wert des Pins aus und set setzt den mitgegebenen boolschen wert.
        {
            get { return ledPin.Read(); }
            set { ledPin.Write(value); }
        }
        public void Toggle()            //lässt die LED toggeln.
        {
            Enable = !Enable;
        }




    }
}
