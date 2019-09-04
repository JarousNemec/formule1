using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace formule1
{
    public class Animation
    {
        public static int sizeY = 40;
        public static int sizeX = 20;
        string[,] dest = new string[sizeY, sizeX];
        public int poziceAuta = sizeX / 2;
        public bool FallingStones = true;
        private int origWidth = 200;
        private int origHeight = 400;
        List<Stone> stones = new List<Stone>();
        public int lifes;
        
        Thread thread1;

        public Animation()
        {
            stones.Add(new Stone());
            stones.Add(new Stone());
            stones.Add(new Stone());
            stones.Add(new Stone());
            thread1 = new Thread(new ThreadStart(CteniKlavesnice));
            lifes = Health.health;
            
            
            int counter = 0;
            
            thread1.Start();
            int pocitadlo = 0;

            while (FallingStones && (lifes != 0)) 
            {
                
                StringBuilder sb = new StringBuilder();
                
                StringBuilder sbb = new StringBuilder();
                counter++;
                if (counter > 5)
                {
                    stones.Add(new Stone());
                    counter = 0;
                }

                for (int i = 0; i < sizeY; i++)
                for (int j = 0; j < sizeX; j++)
                    dest[i, j] = ".";


                foreach (Stone stone in stones)
                {
                    bool vykreslil = stone.VykresliSe(dest);
                    if (!vykreslil)
                    {
                        stone.SetToRemove();
                    }
                }


                int path = 0;

                for (int i = 0; i < sizeY; i++)
                {
                    if (RoadType.TypeRoad == 1)
                    {
                        switch (path)
                        {
                            case 1:
                                sb.Append(" ");
                                break;
                            case 2:
                                sb.Append("   ");
                                break;
                            case 3:
                                sb.Append("    ");
                                break;
                            case 4:
                            case 5:
                            case 6:
                                sb.Append("     ");
                                break;
                            case 7:
                                sb.Append("    ");
                                break;
                            case 8:
                                sb.Append("   ");
                                break;
                            case 9:
                                sb.Append("  ");
                                break;
                            case 10:
                                sb.Append(" ");
                                break;
                            default:
                            {
                                if (path > 11)
                                    path = -1;
                                break;
                            }
                        }

                        path++;
                    }


                    sb.Append("|");
                    for (int j = 0; j < sizeX; j++)
                        sb.Append(dest[i, j]);

                    sb.Append("|");
                    sb.Append("\n");
                }


                foreach (Stone stone in stones)
                    stone.Fall(dest);

                bool hit = CheckKolision();


                pocitadlo = pocitadlo + ClearOldStones();


                Console.Write(sb.ToString());

                Car.PaintCar(hit, poziceAuta);
                Thread.Sleep(1);
                sbb.Append("SCORE: " + pocitadlo);
                sbb.Append("\n");
                sbb.Append("Health: " + lifes);
                Console.WriteLine(sbb.ToString());
                Thread.Sleep(Speed.Fast);
                Console.Clear();
            }

            KillThreadAndPrintInfo();
        }

        private void KillThreadAndPrintInfo()
        {
            thread1.Abort();
            Console.Clear();
            if (lifes == 0)
            {
                Console.WriteLine("GameOver");
                Console.ReadKey();
                Console.Clear();
            }
            new Menu();
        }

        private bool CheckKolision()
        {
            bool hit = false;

            foreach (var stone in stones)
            {
                if (stone.GetPositionX() == poziceAuta - 1 && stone.GetPositionY() == sizeY)
                {
                    lifes--;
                }

                if (stone.GetPositionX() == poziceAuta && stone.GetPositionY() == sizeY)
                {
                    lifes--;
                }

                if (stone.GetPositionX() == poziceAuta + 1 && stone.GetPositionY() == sizeY)
                {
                    lifes--;
                }
            }

            return hit;
        }

        public void CteniKlavesnice()
        {
            while (true)
            {
                ConsoleKeyInfo name = Console.ReadKey();
                ConsoleKey code = name.Key;
                if (code == ConsoleKey.LeftArrow)
                {
                    MoveLeft();
                }

                if (code == ConsoleKey.RightArrow)
                {
                    MoveRight();
                }

                if (code == ConsoleKey.F10)
                {
                    FallingStones = false;
                }
            }
        }

        private void MoveLeft()
        {
            if (poziceAuta > 2)
                poziceAuta--;
        }

        private void MoveRight()
        {
            if (poziceAuta < sizeX - 3)
                poziceAuta++;
        }


        private int ClearOldStones()
        {
            List<Stone> toDeleteList = new List<Stone>();
            foreach (Stone stone in stones)
            {
                bool ToRemove = stone.IsStoneToDelete();
                if (ToRemove)
                {
                    toDeleteList.Add(stone);
                }
            }

            foreach (var stone in toDeleteList)
            {
                stones.Remove(stone);
            }

            return toDeleteList.Count;
        }
    }
}