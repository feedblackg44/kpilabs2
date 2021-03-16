using System;

namespace MyClass
{
    public class MyText
    {
        private char[][] Array;
        private int numOfConsLetters;
        public int NumOfConsLetters
        {
            get 
            {
                return numOfConsLetters;
            }
            private set
            {
                numOfConsLetters = value;
            }
        }

        // Public methods //

        public MyText()
        {
            this.Array = null;
            NumOfConsLetters = 0;
        }

        public MyText(string strIn)
        {
            int amount = CountEndlines(strIn);
            this.Array = new char[amount][];
            this.Array[0] = new char[0];
            int curLine = 0;
            int curSymbol = 0;
            for (int i = 0; i < strIn.Length; i++)
            {
                if (strIn[i] == '\n')
                {
                    curLine++;
                    curSymbol = 0;
                    this.Array[curLine] = new char[0];
                }
                else
                {
                    this.AddEmptySymbol(curLine);
                    this.Array[curLine][curSymbol] = strIn[i];
                    curSymbol++;
                }
            }

            this.NumOfConsLetters = CountConsLetters(this.Array);
        }
        public void ConsoleWrite()
        {
            for (int i = 0; i < this.Array.Length; i++)
            {
                for (int j = 0; j < this.Array[i].Length; j++)
                {
                    Console.Write("{0}", this.Array[i][j]);
                }
                if (i != this.Array.Length - 1)
                    Console.WriteLine();
            }
        }
        public string this[int key]
        {
            get 
            {
                string strOut = "";
                for (int i = 0; i < this.Array[key].Length; i++)
                {
                    strOut += this.Array[key][i];
                }
                return strOut;
            }
        }

        // Private methods //

        private static int CountConsLetters(char[][] array)
        {
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (MatchPattern(array[i][j]))
                        counter++;
                }
            }
            return counter;
        }
        private static bool MatchPattern(char symbol)
        {
            string symbols = "bcdfghjklmnpqstvxzrw";
            for (int i = 0; i < symbols.Length; i++)
            {
                if (System.Char.ToLower(symbol) == symbols[i])
                {
                    return true;
                }
            }
            return false;
        }
        private void AddEmptySymbol (int curLine)
        {
            int length = this.Array[curLine].Length;
            char[] temp = new char[length + 1];
            for (int i = 0; i < length; i++)
            {
                temp[i] = this.Array[curLine][i];
            }
            this.Array[curLine] = new char[length + 1];
            for (int i = 0; i < length + 1; i++)
            {
                this.Array[curLine][i] = temp[i];
            }
        }
        private static int CountEndlines(string strIn)
        {
            int counter = 1;
            for (int i = 0; i < strIn.Length; i++)
            {
                if (strIn[i] == '\n')
                    counter++;
            }
            return counter;
        }

    }
}
