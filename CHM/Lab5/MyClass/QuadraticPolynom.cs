using System;
using System.Collections.Generic;
using System.Text;

namespace MyClass
{
    public class QuadraticPolynom
    {
        private double[] _arrX;
        private double[] _arrY;
        private double[] _arrA;
        private double[] _arrB;
        private double[] _arrC;
        private double[] _arrD;
        private double[] _arrH;
        private Func<double, double> _FuncY;
        private string[] _result;

        public QuadraticPolynom(double[] arr, Func<double, double> func)
        {
            _arrX = arr;
            _FuncY = func;
            int n = _arrX.Length - 1;
            _arrY = new double[_arrX.Length];
            _arrA = new double[_arrX.Length - 1];
            _arrB = new double[_arrX.Length - 1];
            _arrC = new double[_arrX.Length - 1];
            _arrD = new double[_arrX.Length - 1];
            _arrH = new double[_arrX.Length - 1];
            _result = new string[n];
            _result[0] = "Not calculated yet.";

            for (int i = 0; i < _arrY.Length; i++)
            {
                _arrY[i] = _FuncY(_arrX[i]);
                if (i != _arrY.Length - 1)
                {
                    _arrA[i] = _arrY[i];
                }
                if (i != 0)
                {
                    _arrH[i - 1] = _arrX[i] - _arrX[i - 1];
                }
            }
            _arrC[0] = 0;
            _arrC[_arrC.Length - 1] = 0;
            
            double[][] matrix = new double[2][];
            matrix[0] = new double[2];
            matrix[1] = new double[2];
            matrix[0][0] = 2 * (_arrH[1] + _arrH[2]); matrix[0][1] = _arrH[2];
            matrix[1][0] = _arrH[2]; matrix[1][1] = 2 * (_arrH[2] + _arrH[3]);

            double[] rightVec = { 3 * (((_arrY[2] - _arrY[1]) / _arrH[1]) - ((_arrY[1] - _arrY[0]) / _arrH[0])),
                                  3 * (((_arrY[3] - _arrY[2]) / _arrH[2]) - ((_arrY[2] - _arrY[1]) / _arrH[1])) };
            SystemOfEq Sys = new SystemOfEq(matrix, rightVec);
            _arrC[1] = Sys._X[0];
            _arrC[2] = Sys._X[1];

            for (int i = 0; i < n; i++)
            {
                if(i == n - 1)
                    _arrD[i] = (-_arrC[i]) / (3 * _arrH[i]);
                else
                    _arrD[i] = (_arrC[i + 1] - _arrC[i]) / (3 * _arrH[i]);
            }

            for (int i = 0; i < n; i++)
            {
                if (i == n - 1)
                    _arrB[i] = ((_arrY[i + 1] - _arrY[i]) / _arrH[i]) - (2 * _arrH[i] * _arrC[i] / 3);
                else
                    _arrB[i] = ((_arrY[i + 1] - _arrY[i]) / _arrH[i]) - (_arrH[i] / 3 * (_arrC[i + 1] + 2 * _arrC[i]));
            }

            for (int i = 0; i < n; i++)
            {
                _result[i] = Math.Round(_arrA[i], 6).ToString();
                if (_arrB[i] < 0)
                    _result[i] += " - ";
                else
                    _result[i] += " + ";
                _result[i] += Math.Abs(Math.Round(_arrB[i], 6)).ToString() + " * (x";
                if (_arrX[i] < 0)
                    _result[i] += " + ";
                else
                    _result[i] += " - ";
                _result[i] += Math.Abs(Math.Round(_arrX[i], 6)).ToString() + ")";
                if (_arrC[i] < 0)
                    _result[i] += " - ";
                else
                    _result[i] += " + ";
                _result[i] += Math.Abs(Math.Round(_arrC[i], 6)).ToString() + " * (x";
                if (_arrX[i] < 0)
                    _result[i] += " + ";
                else
                    _result[i] += " - ";
                _result[i] += Math.Abs(Math.Round(_arrX[i], 6)).ToString() + ")";
                _result[i] += " * (x";
                if (_arrX[i] < 0)
                    _result[i] += " + ";
                else
                    _result[i] += " - ";
                _result[i] += Math.Abs(Math.Round(_arrX[i], 6)).ToString() + ")";
                if (_arrD[i] < 0)
                    _result[i] += " - ";
                else
                    _result[i] += " + ";
                _result[i] += Math.Abs(Math.Round(_arrD[i], 6)).ToString() + " * (x";
                if (_arrX[i] < 0)
                    _result[i] += " + ";
                else
                    _result[i] += " - ";
                _result[i] += Math.Abs(Math.Round(_arrX[i], 6)).ToString() + ")";
                _result[i] += " * (x";
                if (_arrX[i] < 0)
                    _result[i] += " + ";
                else
                    _result[i] += " - ";
                _result[i] += Math.Abs(Math.Round(_arrX[i], 6)).ToString() + ")";
                _result[i] += " * (x";
                if (_arrX[i] < 0)
                    _result[i] += " + ";
                else
                    _result[i] += " - ";
                _result[i] += Math.Abs(Math.Round(_arrX[i], 6)).ToString() + ")";
            }
        }
        public string this[int index]
        {
            get => this._result[index];
        }
        public int Length { get => this._result.Length; }
    }
}
