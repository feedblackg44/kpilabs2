using System;

namespace MyClasses
{
    public class Line
    {
        protected double[][] _coords;

        public Line(double coord1, double coord2, double coord3, double coord4)
        {
            _coords = new double[2][];
            _coords[0] = new double[2];
            _coords[1] = new double[2];
            _coords[0][0] = coord1;
            _coords[0][1] = coord2;
            _coords[1][0] = coord3;
            _coords[1][1] = coord4;
        }
        public double Length
        {
            get => Math.Sqrt((_coords[1][0] - _coords[0][0]) * (_coords[1][0] - _coords[0][0]) + (_coords[1][1] - _coords[0][1]) * (_coords[1][1] - _coords[0][1]));
        }
    }
}
