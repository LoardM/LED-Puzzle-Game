
using System;
using Unosquare.RaspberryIO;
using Unosquare.WiringPi;
using Unosquare.RaspberryIO.Abstractions;
using System.Threading;
using NLog;
using Swan.Formatters;
using Swan;
using System.Diagnostics;

namespace Game
{
    class Program
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        

        static void Main(string[] args)
        {
            Pi.Init<BootstrapWiringPi>();

            #region attaching
            bool attached = false;
            try
            {
                if ("--debug" == args[0])
                {
                    Console.WriteLine("Wait for Attaching");
                    while (attached != true)
                    {
                        attached = System.Diagnostics.Debugger.IsAttached;
                    }

                }
                else
                {
                    Console.WriteLine("Don't wait for Attaching");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Don't wait for Attaching");
            }
            #endregion

            Random random = new System.Random();
            int R1; int R2; int R3; int R4; int R5 = 5;

            Stopwatch sw = new Stopwatch();

            while (true)
            {
                R1 = random.Next(0, 5); R2 = random.Next(0, 5); R3 = random.Next(0, 5); R4 = random.Next(0, 5);

                if ((R1 == 1 || R2 == 1 || R3== 1 || R4 == 1) && (R1 == 2 || R2 == 2 || R3 == 2 || R4 == 2) && (R1 == 3 || R2 == 3 || R3 == 3 || R4 == 3) && (R1 == 4 || R2 == 4 || R3 == 4 || R4 == 4))
                {
                    break;
                }
            }

     


            //sw.Stop();
            //long ms = sw.ElapsedMilliseconds;



            Raspberry raspi = new Raspberry();
            LED_Alg Push = new LED_Alg(R5, raspi);
            LED_Alg Down = new LED_Alg(R2, raspi);
            LED_Alg Left = new LED_Alg(R3, raspi);
            LED_Alg Right = new LED_Alg(R4, raspi);
            LED_Alg Up = new LED_Alg(R1, raspi);

            Push.SetLed();

            Console.WriteLine("Are you ready to start?");
            Console.ReadKey();
            sw.Start();


            while (true)
            {

                if (!raspi[JoystickE.Push].Read) { Push.SetLed(); Thread.Sleep(500); }
                if (!raspi[JoystickE.Down].Read) { Down.SetLed(); Thread.Sleep(500); }
                if (!raspi[JoystickE.Left].Read) { Left.SetLed(); Thread.Sleep(500); }
                if (!raspi[JoystickE.Right].Read) { Right.SetLed(); Thread.Sleep(500); }
                if (!raspi[JoystickE.Up].Read) { Up.SetLed(); Thread.Sleep(500); }
                if (raspi[LEDColor.Green].Enable == true && raspi[LEDColor.Blue].Enable == true && raspi[LEDColor.Yellow].Enable == true && raspi[LEDColor.Red].Enable == true) { sw.Stop();  break; }
               

            }

            Console.WriteLine("You Won");
            float record = sw.ElapsedMilliseconds / 1000;
            Console.WriteLine("You had " + record + " seconds");
            Console.ReadKey();








        }
    }
}
