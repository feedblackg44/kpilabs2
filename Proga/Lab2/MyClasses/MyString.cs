using System;

namespace MyClasses
{
    public class MyString
    {
        public char[] str { get; private set; }
        public int length { get; private set; }

        public MyString()
        {
            this.str = new char[1];
            this.str[0] = '\0';
            this.length = 0;
        }

        public MyString(in char[] strIn)
        {
            if (strIn != null)
            {
                this.length = strlen(strIn);
                this.str = new char[this.length + 1];
                for (int i = 0; i < this.length; i++)
                {
                    this.str[i] = strIn[i];
                }
                this.str[this.length] = '\0';
            }
            else
            {
                this.str = new char[1];
                this.str[0] = '\0';
                this.length = 0;
            }
        }

        public MyString(in string strIn)
        {
            if (strIn != null)
            {
                this.length = strIn.Length;
                this.str = new char[this.length + 1];
                for (int i = 0; i < this.length; i++)
                {
                    this.str[i] = strIn[i];
                }
                this.str[this.length] = '\0';
            }
            else
            {
                this.str = new char[1];
                this.str[0] = '\0';
                this.length = 0;
            }
        }

        public MyString(char[] strIn)
        {
            if (strIn != null)
            {
                this.length = strlen(strIn);
                this.str = new char[this.length + 1];
                for (int i = 0; i < this.length; i++)
                {
                    this.str[i] = strIn[i];
                }
                this.str[this.length] = '\0';
            }
            else
            {
                this.str = new char[1];
                this.str[0] = '\0';
                this.length = 0;
            }
        }

        public MyString(in MyString strIn)
        {
            if (strIn.str != null)
            {
                this.length = strIn.length;
                this.str = new char[this.length + 1];
                for (int i = 0; i < this.length; i++)
                {
                    this.str[i] = strIn.str[i];
                }
                this.str[this.length] = '\0';
            }
            else
            {
                this.str = new char[1];
                this.str[0] = '\0';
                this.length = 0;
            }
        }

        public bool IsEmpty()
        {
            return !(Convert.ToBoolean(this.length));
        }

        public void DeepCopy(MyString strIn)
        {
            this.length = strIn.length;
            this.str = new char[this.length + 1];
            for (int i = 0; i < this.length; i++)
            {
                this.str[i] = strIn.str[i];
            }
            this.str[this.length] = '\0';
        }

        public void getline()
        {
            string temp = Console.ReadLine();
            MyString tempStr = new MyString(temp);
            this.DeepCopy(tempStr);
        }

        public MyString UpperCase()
        {
            MyString strTemp = new MyString(),
                     curWord = new MyString(),
                     strOut = new MyString();

            strTemp.DeepCopy(this);

            int spacesBefore = removeFirstSpaces(strTemp);
            for (int i = 0; i < spacesBefore; i++)
            {
                strOut += ' ';
            }

            while (!strTemp.IsEmpty())
            {
                int spaces = curWord.ExtractFisrtWordOfString(strTemp);

                if(!System.Char.IsUpper(curWord[0]))
                    curWord[0] = System.Char.ToUpper(curWord[0]);

                strOut += curWord;
                for (int i = 0; i < spaces; i++)
                {
                    strOut += ' ';
                }
            }
            strOut.str[strOut.length] = '\0';

            return strOut;
        }

        public MyString KeyWord()
        {
            MyString strTemp = new MyString(),
                     curWord = new MyString(),
                     strOut = new MyString();

            strTemp.DeepCopy(this);
            while (!strTemp.IsEmpty())
            {
                curWord.ExtractFisrtWordOfString(strTemp);
                strOut += curWord.str[0];
            }

            return strOut;
        }

        public void WriteLine()
        {
            Console.WriteLine(this.str);
        }

        public char this[int key]
        {
            get => str[key];
            private set => str[key] = value;
        }

        public static MyString operator + (MyString strIn, char symbol) 
        {
            int lngth = strIn.length;
            char[] temp = new char[lngth];
            for (int i = 0; i < lngth; i++)
            {
                temp[i] = strIn.str[i];
            }
            strIn.str = new char[lngth + 2];
            for (int i = 0; i < lngth + 1; i++)
            {
                if (i != lngth)
                    strIn.str[i] = temp[i];
                else
                    strIn.str[i] = symbol;
            }
            strIn.str[lngth + 1] = '\0';
            strIn.length++;

            return strIn;
        }

        public static MyString operator + (MyString strIn1, MyString strIn2)
        {
            int length2 = strIn2.length;
            for (int i = 0; i < length2; i++)
            {
                strIn1 += strIn2[i];
            }

            return strIn1;
        }

        private int ExtractFisrtWordOfString(MyString strIn)
        {
            MyString strTemp = new MyString(),
                     outWord = new MyString();

            bool found = false;
            bool countSpaces = true;
            int counter = 0;
            for (int i = 0; i < strIn.length; i++)
            {
                if (found)
                {
                    strTemp += strIn[i];
                    if (strIn[i] == ' ' && countSpaces)
                    {
                        counter++;
                    }
                    else
                    {
                        countSpaces = false;
                    }
                }
                else if ((strIn[i]) != ' ')
                {
                    outWord += strIn[i];
                }
                else if (i > 0 && strIn[i - 1] != ' ')
                {
                    counter++;
                    found = true;
                }
            }
            strIn.DeepCopy(strTemp);
            this.DeepCopy(outWord);

            return counter;
        }

        private int removeFirstSpaces(MyString strIn)
        {
            MyString strOut = new MyString();

            int counter = 0;
            bool found = false;
            for (int i = 0; i < strIn.length; i++)
            {
                if (found)
                {
                    strOut += strIn[i];
                }
                else if ((strIn[i]) == ' ')
                {
                    counter++;
                    if (i < strIn.length - 1 && strIn[i + 1] != ' ')
                    {
                        found = true;
                    }
                }
            }
            strIn.DeepCopy(strOut);

            return counter;
        }

        private int strlen(in char[] strIn)
        {
            int counter = 0;
            while (strIn[counter] != '\0')
            {
                counter++;
            }
            return counter;
        }
    }
}
