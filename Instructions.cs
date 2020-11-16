using System;
using System.IO;
using Unosquare.RaspberryIO;
using Unosquare.WiringPi;
using System.Diagnostics;
using System.Threading;

namespace Game
{
    public class Instructions
    {
        public string[] rangking { get; set; }
        public string gametype { get; set; }
        public string username { get; set; }
        bool counter = false;

        public void Start()
        {
            FileStream RangkingPuzzle = new FileStream("RankingPuzzle", FileMode.OpenOrCreate);

            Console.WriteLine("\nGib deinen Benutzernamen ein !\n");
            username = Console.ReadLine();                              //Speichert Benutzername für den Eintrag in der Rangliste
            Console.Clear();


            Console.WriteLine($"\nHallo {username} :)");
            Thread.Sleep(2000);
            Console.Clear();

            bool Exit = false;

            while (Exit != true)
            {
                Console.WriteLine("\nWähle das gewünschte Spiel aus (mögliche Spiele:Puzzle).\n");
                gametype = Console.ReadLine();                                 //Gewünschter Gametyp wird abgespeichert
                Console.Clear();
                Console.WriteLine("\nWähle mittels Eingabe aus, wie du weiterfahren möchtest. \nErklärung, Rangliste, Spielen oder Exit.\n");

                switch (Console.ReadLine())
                {
                    case "Erklärung": Explenation(gametype, username); break;       //Gibt die Erklärung des gewünschten Spiels auf der Console aus
                    case "Rangliste": PrintRangking(gametype, username); break;     //Gibt die Rangliste des gewünschten Spiels auf der Console aus
                    case "Spielen": Play(gametype, username); break;                //Startet das gewünschte Spiel
                    case "Exit": Exit = true; break;

                    default: Console.WriteLine("\nUngueltige Anweisung ausgewält. Versuche es erneut!"); break;  //Falls eine falsche Anweisung gemacht wird, wir einfach nach erneut nach einer gültigen Anweisung gefragt
                }
            }
        }



        public void Play(string gametype, string username)                      //Startet das gewünschte Spiel, falls es existiert
        {
            switch (gametype)
            {
                case "Puzzle":
                    FileStream RangkingPuzzle = new FileStream("RankingPuzzle", FileMode.Open);
                    StreamReader reader = new StreamReader(RangkingPuzzle);
                    StreamWriter writer = new StreamWriter(RangkingPuzzle);


                    if (counter == false)
                    {
                        string line = reader.ReadLine();                        //Kopiert alles aus der alten Liste in die neue.
                        while ((line != null))
                        {
                            writer.WriteLine(line);

                            line = reader.ReadLine();

                        }
                        counter = true;
                        writer.Close();
                    }

                  

                    Puzzle(username); break;

                default: Console.WriteLine("\nDieses Spiel gibt es nicht!"); break;
            }
        }



        public void Explenation(string gametype, string username)           //Gibt die Erklährung auf der Console aus
        {
            switch (gametype)
            {
                case "Puzzle":
                Console.WriteLine("\nWillkommen beim LED-Puzzle.\nZiel des Spiels ist es alle LED's gleichzeitig zum Leuchten zu bringen.\nAllen Richtungen des Joysticks wurden LED's zugeteilt. Beim drücken in eine bestimmte Richtung, gehen entsprechende LED's an.\n" +
                "Aber Achtung, brennt eine LED schon und du drückst in eine Richtung in der sie wieder 'Angehen' würde, so löscht die LED wieder ab.\nMit hineindrücken des Joysticks kannst du alle LED's wieder ausschalten.\n\nDie LED-gruppen werden jedesmal neu auf die Richtungen des Joysticks verteilt." +
                "\n\nViel Glück!"); break;
                default: Console.WriteLine("\nGametyp gibt es nicht!"); break;
            }
        }



        public void PrintRangking(string gametype, string username)         //Gibt die Rangliste auf der Console aus
        {

            FileStream RangkingPuzzle = new FileStream("RankingPuzzle", FileMode.Open);
            switch (gametype)
            {
                case "Puzzle":
                    StreamReader reader1 = new StreamReader(RangkingPuzzle);

                    string line = reader1.ReadLine();
                    if (line == null)
                    {
                        Console.WriteLine("\nEs gibt noch keinen Eintrag in der Rangliste. Spiele jetz und sei der erste ;)");
                    }
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = reader1.ReadLine();
                    }
                    reader1.Close();
                    break;

                default: Console.WriteLine("\nGametyp gibt es nicht!"); break;
            }

        }

        public void Rangking(string gametype, string username, float score)
        {
            FileStream RangkingPuzzle = new FileStream("RankingPuzzle", FileMode.Open);

            switch (gametype)
            {
                case "Puzzle":
                
                    StreamWriter writer = new StreamWriter(RangkingPuzzle);



                    writer.WriteLine($"Username:{username}    Score:{score}");  //Schreibt an die nächst freie Stelle
                    writer.Flush();

                    
                    writer.Close();
                    

                    break; ;



                default: Console.WriteLine("\nGametyp gibt es nicht!"); break;
            }

        }

        public void Puzzle(string username)
        {
            Pi.Init<BootstrapWiringPi>();

            Random random = new System.Random();
            int R1; int R2; int R3; int R4; int R5 = 5;

            Stopwatch sw = new Stopwatch();

            while (true)                                        //Durch das zuteilen von Random nummern, wird sichrgestellt, dass die Joystick richtungen und die zugeteilten LED's variieren.
            {
                R1 = random.Next(0, 5); R2 = random.Next(0, 5); R3 = random.Next(0, 5); R4 = random.Next(0, 5);

                if ((R1 == 1 || R2 == 1 || R3 == 1 || R4 == 1) && (R1 == 2 || R2 == 2 || R3 == 2 || R4 == 2) && (R1 == 3 || R2 == 3 || R3 == 3 || R4 == 3) && (R1 == 4 || R2 == 4 || R3 == 4 || R4 == 4))
                {
                    break;
                }
            }


            Raspberry raspi = new Raspberry();
            LED_Alg Push = new LED_Alg(R5, raspi);              //Erstellt die Klassen, für die Joysrickrichtungen und teilt die Random nummern zu.
            LED_Alg Down = new LED_Alg(R2, raspi);
            LED_Alg Left = new LED_Alg(R3, raspi);
            LED_Alg Right = new LED_Alg(R4, raspi);
            LED_Alg Up = new LED_Alg(R1, raspi);

            Push.SetLed();

            Console.Clear();
            Console.WriteLine("\nAre you ready to start?\nThen press 'y'.");
            Console.ReadKey();
            sw.Start();


            while (true)                                                                //Fragt den Joystick ab ob er und in welche richtung er gedrückt wird. Anschliessend werden die entsprechenden LED's getoggelt.
            {

                if (!raspi[JoystickE.Push].Read) { Push.SetLed(); Thread.Sleep(500); }
                if (!raspi[JoystickE.Down].Read) { Down.SetLed(); Thread.Sleep(500); }
                if (!raspi[JoystickE.Left].Read) { Left.SetLed(); Thread.Sleep(500); }
                if (!raspi[JoystickE.Right].Read) { Right.SetLed(); Thread.Sleep(500); }
                if (!raspi[JoystickE.Up].Read) { Up.SetLed(); Thread.Sleep(500); }
                if (raspi[LEDColor.Green].Enable == true && raspi[LEDColor.Blue].Enable == true && raspi[LEDColor.Yellow].Enable == true && raspi[LEDColor.Red].Enable == true) { sw.Stop(); break; }


            }
            Console.Clear();
            Console.WriteLine($"\n{username} You won!");
            float record = sw.ElapsedMilliseconds;
            Console.WriteLine("\nYou had " + record + " miliseconds.");
            Thread.Sleep(2000);

            Rangking("Puzzle", username, record);               //Gibt den Namen des Spielers und seine Zeit weiter.

        }

    
    }
}
