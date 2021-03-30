using System;

namespace MyClass
{
    public class Romb
    {
        private double[][] coords;
        private double side;
        public double Side
        {
            get => this.side;
        }
        public double Perimeter
        {
            get => this.side * 4;
        }
        public double Square
        {
            get
            {
                double d1 = GetVectorDistance(this.coords[0], this.coords[2]);
                double d2 = GetVectorDistance(this.coords[1], this.coords[3]);

                return d1 * d2 * 0.5;
            }
        }
        public Romb()
        {
            this.coords = new double[4][];
            for (int i = 0; i < 4; i++)
            {
                this.coords[i] = new double[2];
            }
            this.coords[0][0] = 0.0; this.coords[0][1] = 1.0;
            this.coords[1][0] = -1.0; this.coords[1][1] = 0.0;
            this.coords[2][0] = 0.0; this.coords[2][1] = -1.0;
            this.coords[3][0] = 1.0; this.coords[3][1] = 0.0;
            this.side = GetVectorDistance(this.coords[0], this.coords[1]);
        }
        public Romb(in Romb copyFrom)
        {
            this.coords = new double[4][];
            for (int i = 0; i < 4; i++)
            {
                this.coords[i] = new double[2];
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    this.coords[i][j] = copyFrom.coords[i][j];
                }
            }
            this.side = copyFrom.side;
        }
        public Romb(double[][] arr)
        {
            if (IsCoordsCorrect(arr))
            {
                this.coords = new double[4][];
                for (int i = 0; i < 4; i++)
                {
                    this.coords[i] = new double[2];
                }
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        this.coords[i][j] = arr[i][j];
                    }
                }
                this.side = GetVectorDistance(this.coords[0], this.coords[1]);
            }
        }
        public double[] GetAngles()
        {
            double d1 = GetVectorDistance(this.coords[0], this.coords[2]);
            double d2 = GetVectorDistance(this.coords[1], this.coords[3]);

            double[] angles = new double[2];
            angles[0] = 2 * Math.Atan(d1 / d2) / Math.Acos(-1) * 180;
            angles[1] = 180 - angles[0];

            return angles;
        }
        public void WriteToConsole()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(" {0,-5}", this.coords[i][j]);
                }
                if (i != 3)
                    Console.WriteLine();
            }
        }
        public static Romb operator *(in Romb rombik, double multip)
        {
            Romb rombikOut = new Romb();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    rombikOut.coords[i][j] = multip * rombik.coords[i][j];
                }
            }
            rombikOut.side = rombikOut.GetVectorDistance(rombikOut.coords[0], rombikOut.coords[1]);
            return rombikOut;
        }
        public static Romb operator -(in Romb rombik1, in Romb rombik2)
        {
            Romb rombikOut = new Romb();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    rombikOut.coords[i][j] = rombik1.coords[i][j] - rombik2.coords[i][j];
                }
            }
            rombikOut.side = rombikOut.GetVectorDistance(rombikOut.coords[0], rombikOut.coords[1]);
            return rombikOut;
        }
        private bool IsCoordsCorrect(in double[][] coords)
        {
            bool outB = false;
            if (GetVectorDistance(coords[0], coords[1]) - GetVectorDistance(coords[1], coords[2]) < 0.000001 &&
                GetVectorDistance(coords[1], coords[2]) - GetVectorDistance(coords[2], coords[3]) < 0.000001 &&
                GetVectorDistance(coords[2], coords[3]) - GetVectorDistance(coords[3], coords[0]) < 0.000001 &&
                GetVectorDistance(coords[3], coords[0]) - GetVectorDistance(coords[0], coords[1]) < 0.000001)
                outB = true;
            else
            {
                Console.WriteLine("Error parsing coordinates!");
                Console.ReadKey();
                System.Environment.Exit(1);
            }
            return outB;
        }
        public double GetVectorDistance(double[] pos1, double[] pos2)
        {
            double[] vec = { pos2[0] - pos1[0], pos2[1] - pos1[1] };
            return Convert.ToDouble(Math.Sqrt(vec[0] * vec[0] + vec[1] * vec[1]));
        }
    }
}
