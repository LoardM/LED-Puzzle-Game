using System;
using Unosquare.RaspberryIO;
using Unosquare.WiringPi;
using Unosquare.RaspberryIO.Abstractions;
using System.Threading;
using System.Runtime.CompilerServices;


namespace Game
{
    public class LED_Alg 
    {
       private static Random rand = new System.Random(); // new random object



        private LED ledGreen;
        private LED ledYellow;
        private LED ledBlue;
        private LED ledRed;
        private LED N1;
        private LED N2;
        private LED N3;

        private int Number = 0;

        public LED_Alg(int RN, Raspberry raspi)
        {
            

            ledGreen = raspi[LEDColor.Green];
            ledYellow = raspi[LEDColor.Yellow];
            ledBlue = raspi[LEDColor.Blue];
            ledRed = raspi[LEDColor.Red];

            switch (RN)
            {
                case 1: N1 = ledGreen; N2 = ledBlue; break;
                case 2: N1 = ledGreen; N2 = ledYellow; break;
                case 3: N1 = ledGreen; N2 = ledRed; break;
                case 4: N1 = ledRed; N2 = ledYellow; N3 = ledBlue; Number = RN; break;
                case 5: Number = RN; break;
              
            }


           
        }

        public void SetLed()
        {

            if (Number == 5)
            {
                ledGreen.Enable = false;
                ledYellow.Enable = false;
                ledBlue.Enable = false;
                ledRed.Enable = false;
                return;
            }
            N1.Toggle();
            N2.Toggle();
            if (Number == 4)
            {
                N3.Toggle();
            }

           
        }



        // public static void ran()
        // {
        //     Console.WriteLine(rand.Next(100, 201)); // numbers : 100 -200
        // }

        






    }
}
