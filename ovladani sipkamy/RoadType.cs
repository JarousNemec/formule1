using System;
using System.IO;
using System.Text;

namespace formule1
{
    public class RoadType
    {
        static int counter = 0;
        private string mezera = "                            ";
        public static int TypeRoad = 0;
        public RoadType()
        {
            string[] types = {"STRAIGHT", "CROOKED "};

            while (true)
            {
                StringBuilder sb = new StringBuilder();
                using (StreamReader sr = new StreamReader(@"RoadOption.txt"))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        sb.Append(s);
                        sb.Append("\n");
                    }
                }
                
                sb.Append("\n");
                
                for (int i = 0; i < types.Length; i++)
                {
                    if (i == counter)
                    {
                        sb.Append(mezera + types[i] + " [*]");
                        sb.Append("\n");
                    }
                    else
                    {
                        sb.Append(mezera + types[i] + " [ ]");
                        sb.Append("\n");
                    }
                }

                Console.Write(sb.ToString());
                ConsoleKeyInfo name = Console.ReadKey();
                ConsoleKey code = name.Key;


                if (code == ConsoleKey.DownArrow)
                {
                    if (counter < types.Length - 1)
                        counter++;
                }


                if (code == ConsoleKey.UpArrow)
                {
                   if (counter > 0)
                        counter--;
                }

                if (code == ConsoleKey.Enter)
                {
                    Enter();
                }


                Console.Clear();
            }
        }
        
        public void Enter()
        {
            if (counter == 1)
            {
                TypeRoad = 1;
            }

            else if (counter == 0)
            {
                TypeRoad = 0;
            }
            Console.Clear();
            new Option();
        }
    }
}