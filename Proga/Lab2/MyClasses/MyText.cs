using System;

namespace MyClasses
{
    public class MyText
    {
        public MyString[] text { get; private set; }
        public int strings_num { get; private set; }

        public MyText()
        {
            this.text = null;
            this.strings_num = 0;
        }

        public MyText(in MyText textIn)
        {
            if (textIn.text != null)
            {
                this.strings_num = textIn.strings_num;
                this.text = new MyString[this.strings_num];

                for (int i = 0; i < this.strings_num; i++)
                {
                    this.text[i] = new MyString();
                    this.text[i].DeepCopy(textIn.text[i]);
                }
            }
            else 
            {
                this.text = null;
                this.strings_num = 0;
            }
        }

        public void AddString(MyString strIn, int strNum)
        {
            AddEmptySpace();
            int sNum = this.strings_num;
            if (strNum > sNum)
                strNum = sNum;
            else if (strNum < 1)
                strNum = sNum;
            for (int i = sNum - 1; i >= strNum; i--)
            {
                this.text[i].DeepCopy(this.text[i - 1]);
            }
            this.text[strNum - 1] = strIn;
        }

        public void RemoveString(int strNum)
        {
            int sNum = this.strings_num;
            if (strNum > sNum)
                strNum = sNum;
            else if (strNum < 1)
                strNum = sNum;
            if (text != null && strings_num > 0)
            {
                for (int i = 0; i < sNum - 1; i++)
                {
                    if (i >= strNum - 1)
                        this.text[i].DeepCopy(this.text[i + 1]);
                }
            }
            RemoveEmptySpace();
        }

        public void Clear()
        {
            this.text = null;
            this.strings_num = 0;
        }

        public int GetNumberOfStrings(int length)
        {
            int counter = 0;
            for (int i = 0; i < this.strings_num; i++)
            {
                if (this.text[i].length == length)
                    counter++;
            }
            return counter;
        }

        public MyText TextUpperCase()
        {
            MyText textOut = new MyText();

            textOut.DeepCopy(this);

            for (int i = 0; i < textOut.strings_num; i++)
            {
                textOut.text[i] = this[i].UpperCase();
            }

            return textOut;
        }

        public void DeepCopy(MyText textIn)
        {
            this.strings_num = textIn.strings_num;
            this.text = new MyString[this.strings_num];

            for (int i = 0; i < strings_num; i++)
            {
                this.text[i] = new MyString();
                this.text[i].DeepCopy(textIn.text[i]);
            }
        }

        public void WriteLine()
        {
            for (int i = 0; i < this.strings_num; i++)
            {
                this.text[i].WriteLine();
            }
        }

        public MyString this[int key]
        {
            get => text[key];
            private set => text[key] = value;
        }

        private void AddEmptySpace()
        {
            int sNum = this.strings_num;

            MyString[] temp = new MyString[sNum];
            for (int i = 0; i < sNum; i++) 
            {
                temp[i] = new MyString();
                temp[i].DeepCopy(this.text[i]);
            }

            this.text = new MyString[sNum + 1];
            for (int i = 0; i < sNum; i++)
            {
                this.text[i] = new MyString();
                this.text[i].DeepCopy(temp[i]);
            }
            this.text[strings_num] = new MyString();
            this.strings_num++;
        }

        private void RemoveEmptySpace()
        {
            if (this.text != null && this.strings_num > 0)
            {
                int sNum = this.strings_num;

                MyString[] temp = new MyString[sNum];
                for (int i = 0; i < sNum; i++)
                {
                    temp[i] = new MyString();
                    temp[i].DeepCopy(this.text[i]);
                }

                this.text = new MyString[sNum - 1];
                for (int i = 0; i < sNum - 1; i++)
                {
                    this.text[i] = new MyString();
                    this.text[i].DeepCopy(temp[i]);
                }
                this.strings_num--;
            }
        }
    }
}
