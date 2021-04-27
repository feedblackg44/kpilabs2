using System;
using System.Collections.Generic;
using System.Text;

namespace MyClasses
{
    public class NumString : MyString
    {
        public NumString(in string strIn)
        {
            int length = strNumLen(strIn);
            this.str = new char[length];
            int j = 0;
            for (int i = 0; i < strIn.Length; i++)
            {
                if (Char.IsDigit(strIn[i]))
                    this.str[j++] = strIn[i];
            }  
        }
        public override void MoveLetters()
        {
            int length = this.str.Length;
            int amount = 1;
            char[] temp = new char[amount];
            for (int i = 0; i < amount; i++)
            {
                temp[i] = this.str[i];
            }
            for (int i = 0; i < length - amount; i++)
            {
                this.str[i] = this.str[i + amount];
            }
            for (int i = 0; i < amount; i++)
            {
                this.str[length - 1 - i] = temp[amount - 1 - i];
            }
        }
        public override int GetLength()
        {
            return strNumLen(this.str);
        }
        private int strNumLen(in char[] strIn)
        {
            int len = strIn.Length;
            int counter = 0;
            for (int i = 0; i < len; i++)
            {
                if (Char.IsDigit(strIn[i]))
                    counter++;
            }
            return counter;
        }
        private int strNumLen(in string strIn)
        {
            int len = strIn.Length;
            int counter = 0;
            for (int i = 0; i < len; i++)
            {
                if (Char.IsDigit(strIn[i]))
                    counter++;
            }
            return counter;
        }
    }
}
