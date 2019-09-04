using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace formule1
{
    public class AboutProgram
    {
        public int pointer = 0;
        public int sequence = 0;
        public bool run = true;
        StringBuilder sbMenu = new StringBuilder();
        StringBuilder sbTitle = new StringBuilder();
        List<string> pages = new List<string>();

        public AboutProgram()
        {
            ReadDocumentation();
            ControlPresentation();
        }

        private void ControlPresentation()
        {
            while (run == true)
            {
                Console.Write(sbTitle.ToString());
                PrintPage(pointer);
                Console.WriteLine("|                                                                                                     Page " + (pointer+1) +" of "+pages.Count+" |");
                Console.Write(sbMenu.ToString());
                ConsoleKeyInfo name = Console.ReadKey();
                ConsoleKey code = name.Key;

                if (code == ConsoleKey.RightArrow)
                {
                    if (pointer < pages.Count - 1)
                        pointer = pointer + 1;
                }
                else if (code == ConsoleKey.LeftArrow)
                {
                    if (pointer > 0)
                        pointer = pointer - 1;
                }
                else if (code == ConsoleKey.F)
                {
                    pointer = 0;
                }
                else if (code == ConsoleKey.F10)
                {
                    run = false;
                }

                Console.Clear();
            }
        }

        private void ReadDocumentation()
        {
            using (StreamReader sr = new StreamReader(@"About.txt"))
            {
                string s;
                StringBuilder sb = new StringBuilder();
                while ((s = sr.ReadLine()) != null)
                {
                    if (s == "@@@@@")
                    {
                        pages.Add(sb.ToString());
                        sb.Clear();
                    }
                    else
                    {
                        sb.Append(s);
                        sb.Append("\n");
                    }
                }

                if (sb.Length > 0)
                {
                    pages.Add(sb.ToString());
                    sb.Clear();
                }
            }
            using (StreamReader sr = new StreamReader(@"AboutMenuAscii.txt"))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    sbMenu.Append(s);
                    sbMenu.Append("\n");
                }
            }
            using (StreamReader sr = new StreamReader(@"aboutProgramTitle.txt"))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    sbTitle.Append(s);
                    sbTitle.Append("\n");
                }
            }
        }


        private void PrintPage(int index)
        {
            Console.Write(pages[index]);
        }
    }
}