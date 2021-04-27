using System;
using System.Collections.Generic;
using System.Text;

namespace MyClasses
{
    public class LowerString : MyString
    {
        public LowerString(in string strIn)
        {
            int length = strIn.Length;
            this.str = new char[length];
            for (int i = 0; i < length; i++)
            {
                this.str[i] = strIn[i];
                if (!System.Char.IsLower(this.str[i]))
                    this.str[i] = System.Char.ToLower(this.str[i]);
            }
        }
        public override void MoveLetters()
        {
            int length = (this.str).Length;
            int amount = 1;
            char[] temp = new char[amount];
            for (int i = 0; i < amount; i++)
            {
                temp[i] = this.str[length - 1 - i];
            }
            for (int i = length - 1; i >= amount; i--)
            {
                this.str[i] = this.str[i - amount];
            }
            for (int i = 0; i < amount; i++)
            {
                this.str[amount - 1 - i] = temp[i];
            }
        }
        public override int GetLength()
        {
            return (this.str).Length;
        }
    }
}