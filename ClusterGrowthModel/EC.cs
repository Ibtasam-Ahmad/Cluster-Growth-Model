using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusterGrowthModel
{
    internal class EC
    {
        int size = 100;

        // Bool data type main true or false condition hoti ha
        bool[,] occupied;
        bool[,] perimeter; // decleration

        Random random = new Random();

        // Constructor for memory allocation
        public EC()
        {
            occupied = new bool[size, size];
            perimeter = new bool[size, size]; // memory allocation
        }

        // place seed values or infected seed somewhere mannually
        public void Seed()
        {
            occupied[size/2, size/2] = true;
        }

        public void Seed1()
        {
            for (int i = 0; i < size; i++)
            {
                occupied[i, size - 2] = true;
                // (size - 2) krna sa error nhi ati
                // kion k necha perimeter main hum
                // size - 1 likh rha hota hain
            }
        }

        public void PerimeterDecide()
        {
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - 1; j++)
                {
                    if (occupied[i, j] == true) 
                        // if occupied ho ga to further check
                        // kra ga k surroounding main kia ha
                    {
                        if( occupied[i - 1, j] == false)
                        {
                            perimeter[i - 1, j] = true;
                        }
                        if (occupied[i + 1, j] == false)
                        {
                            perimeter[i + 1, j] = true;
                        }
                        if (occupied[i, j - 1] == false)
                        {
                            perimeter[i, j - 1] = true;
                        }
                        if (occupied[i, j + 1] == false)
                        {
                            perimeter[i, j + 1] = true;
                        }
                    }
                }
            }
        }

        public void occupiedDecidedECGM(Form1 frm)
        {
            Graphics gg = frm.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.DarkRed);

            int x = random.Next(size);
            int y = random.Next(size);

            if (perimeter[x, y] == true)
                // agar perimeter ki value false nhi ho gi to
                // loop chlta rha ga
            {
                occupied[x, y] = true;
                // jab tk perimeter ki value 1 ho jae gi to
                // occupied pay bhi 1 place kr dain gain
                gg.FillEllipse(sb, 150 + x * 3, 450 - y * 3, 5, 5);

            }
        }
    }
}
