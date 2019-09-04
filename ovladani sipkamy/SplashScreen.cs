using System;
using System.IO;
using System.Threading;

namespace formule1
{
    public class SplashScreen
    {
        public SplashScreen()
        {
            
            using (StreamReader sr = new StreamReader(@"SplashScreen.txt"))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Thread.Sleep(1);
                    Console.WriteLine(s);
                    Thread.Sleep(1);
                }
            }
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"úvod do formule.wav");
            player.Play();
            Thread.Sleep(6500);
            Console.Clear();
        }
    }
}