using System;

namespace MyClass
{
    public class Expression
    {
        private double _a;
        private double _b;
        private double _c;
        private double _d;
        public Expression(double a, double b, double c, double d)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
        }
        public double Calculate()
        {
            double x = 24 + _d - _c;
            if (_b == 0)
                throw new Exception("Can't divide by 0!");
            if (x < 0)
                throw new Exception("Expression under the square root must be more or equal to 0!");
            double z = Math.Sqrt(x) + _a / _b;
            if (z < 0)
                throw new Exception("Can't divide by 0!");

            double result = (1 + _a - _b / 2) / z;
            return result;
        }
    }
}
