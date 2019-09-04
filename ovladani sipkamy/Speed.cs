using System;
using System.IO;
using System.Text;

namespace formule1
{
    public class Speed
    {
        static int counter = 0;
        private string mezera = "                            ";
        public static int Fast = 100;
        public Speed()
        {
            string[] types = {"NOOB:)     ", "Easy       ", "Normal     ", "Possible   ", "Master     ", "SuperMaster", "Impossible "};

            while (true)
            {
                StringBuilder sb = new StringBuilder();
                using (StreamReader sr = new StreamReader(@"FastOption.txt"))
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


                switch (code)
                {
                    case ConsoleKey.DownArrow:
                    {
                        if (counter < types.Length - 1)
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
                case 0:
                    Fast = 200;
                    break;
                case 1:
                    Fast = 150;
                    break;
                case 2:
                    Fast = 100;
                    break;
                case 3:
                    Fast = 75;
                    break;
                case 4:
                    Fast = 50;
                    break;
                case 5:
                    Fast = 25;
                    break;
                case 6:
                    Fast = 5;
                    break;
            }
            Console.Clear();
            new Option();
        }
    }
}