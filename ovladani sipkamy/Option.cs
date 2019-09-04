using System;
using System.IO;
using System.Text;

namespace formule1
{
    public class Option
    {
        static int counter = 0;
        private string mezera = "                  ";
        
        public Option()
        {
            string[] Options = {"ROAD TYPE", "FAST     ","HEALTH   ", "EXIT     "};

            while (true)
            {
                StringBuilder sb = new StringBuilder();
                using (StreamReader sr = new StreamReader(@"option.txt"))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        sb.Append(s);
                        sb.Append("\n");
                    }
                }

                for (int i = 0; i < Options.Length; i++)
                {
                    if (i == counter)
                    {
                        sb.Append(mezera + Options[i] + " [*]");
                        sb.Append("\n");
                    }
                    else
                    {
                        sb.Append(mezera + Options[i] + " [ ]");
                        sb.Append("\n");
                    }
                }

                Console.Write(sb.ToString());
                ConsoleKeyInfo name = Console.ReadKey();
                ConsoleKey code = name.Key;


                if (code == ConsoleKey.DownArrow)
                {
                    if (counter < Options.Length - 1)
                        counter++;
                }


                else if (code == ConsoleKey.UpArrow)
                {
                    if (counter > 0)
                        counter--;
                }

                else if (code == ConsoleKey.Enter)
                {
                    Enter();
                }


                Console.Clear();
            }
        }
        
        public void Enter()
        {
            switch (counter)
            {
                case 0:
                    Console.Clear();
                    new RoadType();
                    break;
                case 1:
                    Console.Clear();
                    new Speed();
                    break;
                case 2:
                    Console.Clear();
                    new Health();
                    break;
                case 3:
                    Console.Clear();
                    new Menu();
                    break;
            }
        }
    }
}