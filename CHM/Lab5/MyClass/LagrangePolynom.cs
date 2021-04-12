using System;

namespace MyClass
{
    public class LagrangePolynom
    {
        private double[] _arrX;
        private Func<double, double> _FuncY;
        private string _result;

        public LagrangePolynom(double[] arr, Func<double, double> func)
        {
            _arrX = arr;
            _FuncY = func;
            _result = "Not calculated yet.";
        }
        public void CalculateLagrange()
        {
            string strOut = "";
            for (int k = 0; k < _arrX.Length; k++)
            {
                double curY = _FuncY(_arrX[k]);
                strOut += "\t";
                if (CountMinuses(_arrX[k], _arrX) % 2 == 1)
                    curY = -curY;
                if(curY >= 0)
                    strOut += " ";
                strOut += Math.Round(curY, 6).ToString();
                strOut += " * (";
                bool flag = false;
                for (int i = 0; i < _arrX.Length; i++)
                {
                    if (i != k)
                    {
                        if(flag)
                            strOut += " * ";
                        strOut += "(x";
                        if (_arrX[i] < 0)
                            strOut += " + " + (-_arrX[i]).ToString();
                        else
                            strOut += " - " + _arrX[i].ToString();
                        strOut += ")/" + (Math.Abs(_arrX[k] - _arrX[i])).ToString();
                        flag = true;
                    }
                }
                strOut += ")";
                if (k != _arrX.Length - 1)
                    strOut += " +\n";
            }
            _result = strOut;
        }
        public override string ToString()
        {
            return this._result;
        }
        private static int CountMinuses(double num, double[] arr)
        {
            int counter = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if(num - arr[i] < 0)
                    counter++;
            }
            return counter;
        }
    }
}
