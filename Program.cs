
using System;


namespace Game
{
    public class Program
    {
        private static readonly NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();


        static void Main(string[] args)
        {
            //Damit lässt sich während des Debuggens auf den Code zugreifen, wenn man "--debug" mitgiebt.
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

            Instructions bsp = new Instructions();

            bsp.Start();


        }
    }
}
