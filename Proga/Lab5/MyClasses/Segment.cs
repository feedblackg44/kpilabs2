using System;
using System.Collections.Generic;
using System.Text;

namespace MyClasses
{
    public class Segment : Line
    {
        public Segment(double coord1, double coord2, double coord3, double coord4)
            : base(coord1, coord2, coord3, coord4)
        {
            _coords[1][0] -= _coords[0][0];
            _coords[1][1] -= _coords[0][1];
            _coords[0][0] -= _coords[0][0];
            _coords[0][1] -= _coords[0][1];
        }
        public void RestrictByFive()
        {
            double curLength = this.Length;
            double diff = curLength / (curLength - 5);
            _coords[1][0] /= diff;
            _coords[1][1] /= diff;
        }
        public double[][] Coords
        {
            get => this._coords;
        }
    }
}
