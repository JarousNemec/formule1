using System;
using System.Text;

namespace formule1
{
    public class Car
    {
        
        public static void PaintCar(bool hit, int poziceAuta)
        {
            
            
            string[,] paintCar = new string[3,Animation.sizeX];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < Animation.sizeX; j++)
                {
                    paintCar[i, j] = ".";
                }
            }

            paintCar[0, poziceAuta] = "T";
            paintCar[0, poziceAuta-1] = "=";
            paintCar[0, poziceAuta+1] = "=";
            paintCar[0, poziceAuta-2] = "0";
            paintCar[0, poziceAuta+2] = "0";
            
            paintCar[1, poziceAuta] = "|";
            
            paintCar[2, poziceAuta] = "T";
            paintCar[2, poziceAuta-1] = "=";
            paintCar[2, poziceAuta+1] = "=";
            paintCar[2, poziceAuta-2] = "0";
            paintCar[2, poziceAuta+2] = "0";
            
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < 3; i++)
            {
                sb.Append("|");
                for (int j = 0; j < Animation.sizeX; j++)
                {
                    sb.Append(paintCar[i, j]);
                }
                sb.Append("|");
                sb.Append("\n");
            }
            Console.Write(sb.ToString());
            
        }
    }
}