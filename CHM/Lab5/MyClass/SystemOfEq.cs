using System;
using System.Collections.Generic;
using System.Text;

namespace MyClass
{
    public class SystemOfEq
    {
        private double[][] _Matrix;
        private double[] _rightVector;
        private int[] _numbersX;
        private int _size;
        public double[] _X { get; private set; }

        public SystemOfEq(double[][] matrix, double[] rightVector)
        {
            _Matrix = matrix;
            _rightVector = rightVector;
            _numbersX = new int[rightVector.Length];
            for (int i = 0; i < _numbersX.Length; i++) 
            {
                _numbersX[i] = i;
            }
            _X = new double[rightVector.Length];
            _size = rightVector.Length;
            gaussAlgorithmTriangle();
            gaussAlgorithmGetSolution();
        }
        private int[] getIndexOfMaxElement(int n)
        {
            int[] keys = new int[2];
            double Max = Math.Abs(_Matrix[n][n]);
            keys[0] = n;
            keys[1] = n;
            for (int i = n; i < _size; i++)
            {
                for (int j = n; j < _size; j++)
                {
                    if (Math.Abs(_Matrix[i][j]) > Max)
                    {
                        Max = Math.Abs(_Matrix[i][j]);
                        keys[0] = i;
                        keys[1] = j;
                    }
                }
            }
            return keys;
        }
        private double[] getMultipliersArray(int[] key, int n)
        {
            double[] arr = new double[_size];
            for (int i = 0; i < _size; i++)
            {
                if (i != key[0] && i >= n)
                {
                    arr[i] = _Matrix[i][key[1]] / _Matrix[key[0]][key[1]];
                }
                else
                {
                    arr[i] = 0;
                }
            }
            return arr;
        }
        private void swapRows(int numRow1, int numRow2)
        {
            for (int i = 0; i < _size; i++)
            {
                double tmp = _Matrix[numRow1][i];
                _Matrix[numRow1][i] = _Matrix[numRow2][i];
                _Matrix[numRow2][i] = tmp;
            }

            double temp = _rightVector[numRow1];
            _rightVector[numRow1] = _rightVector[numRow2];
            _rightVector[numRow2] = temp;
        }
        private void swapCols(int numCol1, int numCol2)
        {
            for (int i = 0; i < _size; i++)
            {
                double temp = _Matrix[i][numCol1];
                _Matrix[i][numCol1] = _Matrix[i][numCol2];
                _Matrix[i][numCol2] = temp;

                int tmp = _numbersX[numCol1];
                _numbersX[numCol1] = _numbersX[numCol2];
                _numbersX[numCol2] = tmp;
            }
        }
        private void gaussStep(int[] keys, double[] multipl, int n)
        {
            for (int i = n; i < _size; i++)
            {
                for (int j = n; j < _size; j++)
                {
                    _Matrix[i][j] -= multipl[i] * _Matrix[keys[0]][j];
                }
                _rightVector[i] -= multipl[i] * _rightVector[keys[0]];
            }
            swapRows(n, keys[0]);
            swapCols(n, keys[1]);
        }
        private void gaussAlgorithmTriangle()
        {
            for (int n = 0; n < _size; n++)
            {
                int[] maxKeys = getIndexOfMaxElement(n);
                double maxA = _Matrix[maxKeys[0]][maxKeys[1]];
                //Console.Write("\nCurrent max element: ");
                //print(maxA);

                if (maxA == 0)
                {
                    Console.WriteLine("This system has no solutions!");
                    break;
                }

                double[] m = getMultipliersArray(maxKeys, n);
                //Console.Write("\nCurrent vector of multipliers: ");
                //print(m, _size);

                gaussStep(maxKeys, m, n);
                //Console.WriteLine("\nCurrent Matrix:\n");
                //print(_Matrix, _size);
                //Console.Write("Current right vector: ");
                //print(_rightVector, _size);
                //Console.WriteLine("-----------------------------------------------------------------");
            }
        }

        private void gaussAlgorithmGetSolution()
        {
            for (int n = _size - 1; n >= 0; n--)
            {
                _X[n] = (_rightVector[n] - Solution(n)) / _Matrix[n][n];
            }
            for (int i = 0; i < _size; i++)
            {
                double temp = _X[i];
                _X[i] = _X[_numbersX[i]];
                _X[_numbersX[i]] = temp;
            }
        }

        private double Solution(int n)
        {
            double output = 0;
            for (int i = _size - 1; i > n; i--)
            {
                output += _Matrix[n][i] * _X[i];
            }
            return output;
        }
        public static void print(double[][] Matrix, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write("{0:11} ", Math.Round(Matrix[i][j], 6));
                }
                Console.WriteLine();
            }
        }
        public static void print(double[] Vector, int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write("{0} ", Math.Round(Vector[i], 6));
            }
            Console.WriteLine();
        }
        public static void print(double number)
        {
            Console.WriteLine(number);
        }
    }
}
