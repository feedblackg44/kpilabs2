using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9csh
{
    class Test
    {
        private string[] _arr;

        public Test(string[] arr)
        {
            _arr = arr;
        }
        public string ExMainDiag()
        {
            string strOut = "";
            for (int i = 0; i < _arr.Length; i++)
            {
                for (int j = 0; j < _arr[i].Length; j++)
                {
                    if (i == j)
                        strOut += _arr[i][j];
                }
            }
            return strOut;
        }
        public static string StaticMainDiag(string[] arr)
        {
            string strOut = "";
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (i == j)
                        strOut += arr[i][j];
                }
            }
            return strOut;
        }
    }
}
