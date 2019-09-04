using System;
using System.IO;
using System.Text;
using System.Threading;

namespace formule1
{
    public class Menu
    {
        static int ArraySize = 4;
        static string[] moznosti = new string[ArraySize];
        static int counter = 0;
        private string mezera = "                  ";

        public Menu()
        {

                                                                                   
            string[] options = {"START        ", "OPTION       ", "ABOUT PROGRAM", "EXIT         "};

            while (true)
            {
                StringBuilder sb = new StringBuilder();
                using (StreamReader sr = new StreamReader(@"main menu.txt"))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        sb.Append(s);
                        sb.Append("\n");
                    }
                }

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == counter)
                    {
                        sb.Append(mezera + options[i] + " [*]");
                        sb.Append("\n");
                    }
                    else
                    {
                        sb.Append(mezera + options[i] + " [ ]");
                        sb.Append("\n");
                    }
                }
                
                Console.Write(sb.ToString());
                ConsoleKeyInfo name = Console.ReadKey();
                ConsoleKey code = name.Key;


                switch (code)
                {
                    case ConsoleKey.DownArrow:
                    {
                        if (counter < options.Length - 1)
                            counter++;
                        break;
                    }
                    case ConsoleKey.UpArrow:
                    {
                        if (counter > 0)
                            counter--;
                        break;
                    }
                    case ConsoleKey.Enter:
                        Enter();
                        break;
                }


                Console.Clear();
            }
        }

        public void Enter()
        {
            switch (counter)
            {
                case 3:
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    using (StreamReader sr = new StreamReader(@"FATAL ERROR.txt"))
                    {
                        string s;
                        while ((s = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(s);
                        }
                    }

                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"exit formule.wav");
                    player.Play();
                    Thread.Sleep(2800);
                    Environment.Exit(0);
                    break;
                }
                case 2:
                    Console.Clear();
                    new AboutProgram();
                    break;
                case 1:
                    Console.Clear();
                    new Option();
                    break;
                case 0:
                    Console.Clear();
                    new Animation();
                    break;
            }
        }
    }
}