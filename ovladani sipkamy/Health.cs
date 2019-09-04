using System;
using System.IO;
using System.Text;

namespace formule1
{
    public class Health
    {
        public static int health = 3;
        static int counter = 0;
        private string mezera = "                        ";

        public Health()
        {
            string[] types =
            {
                " 1 health", " 2 health", " 3 health", " 4 health", " 5 health", " 6 health", " 7 health", " 8 health"," 9 health", "10 health"
            };

            while (true)
            {
                StringBuilder sb = new StringBuilder();
                using (StreamReader sr = new StreamReader(@"HealthOption.txt"))
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
            switch (counter)
            {
                case 0:
                    health = 1;
                    break;
                case 1:
                    health = 2;
                    break;
                case 2:
                    health = 3;
                    break;
                case 3:
                    health = 4;
                    break;
                case 4:
                    health = 5;
                    break;
                case 5:
                    health = 6;
                    break;
                case 6:
                    health = 7;
                    break;
                case 7:
                    health = 8;
                    break;
                case 8:
                    health = 9;
                    break;
                case 9:
                    health = 10;
                    break;
            }
            Console.Clear();
            new Option();
        }
    }
}