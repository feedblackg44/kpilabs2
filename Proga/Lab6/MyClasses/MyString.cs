using System;

namespace MyClasses
{
    public abstract class MyString
    {
        protected char[] str;
        public abstract int GetLength();
        public abstract void MoveLetters();

        public override string ToString()
        {
            string strOut = "";
            for (int i = 0; i < (this.str).Length; i++)
            {
                strOut += this.str[i];
            }
            return strOut;
        }
    }
}
