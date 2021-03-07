#include <iostream>
#include <limits>
#include "MyString.h"

// Public //

MyString::MyString()
{
    this->str = new char[1];
    this->str[0] = '\0';
    this->length = 0;
}

MyString::MyString(std::nullptr_t)
{
    this->str = new char[1];
    this->str[0] = '\0';
    this->length = 0;
}

MyString::MyString(const char* strIn)
{
    this->length = strlen(strIn);
    this->str = new char[this->length + 1];
    for (size_t i = 0; i < this->length; i++)
    {
        this->str[i] = strIn[i];
    }
    this->str[this->length] = '\0';
}

MyString::MyString(char* strIn)
{
    this->length = strlen(strIn);
    this->str = new char[this->length + 1];
    for (size_t i = 0; i < this->length; i++)
    {
        this->str[i] = strIn[i];
    }
    this->str[this->length] = '\0';
}

MyString::MyString(const MyString& strIn)
{
    this->length = strIn.length;
    this->str = new char[this->length + 1];
    for (size_t i = 0; i < this->length; i++)
    {
        this->str[i] = strIn.str[i];
    }
    this->str[this->length] = '\0';
}

size_t MyString::GetLength()
{
    return this->length;
}

bool MyString::IsEmpty()
{
    return !((bool)this->length);
}

void MyString::DeepCopy(MyString& strIn)
{
    this->length = strIn.length;
    this->str = new char[this->length + 1];
    for (size_t i = 0; i < this->length; i++)
    {
        this->str[i] = strIn.str[i];
    }
    this->str[this->length] = '\0';
}

void getline(std::istream& is, MyString& strOut)
{
    char* temp = new char[8192];
    is.getline(temp, 8192, '\n');
    MyString tempStr = temp;
    strOut.DeepCopy(tempStr);
}

MyString& MyString::UpperCase()
{
    MyString strTemp,
             curWord,
             *strOut = new MyString;

    strTemp.DeepCopy(*this);

    while (!strTemp.IsEmpty())
    {
        int spaces = curWord.ExtractFisrtWordOfString(strTemp);

        if (int(curWord[0]) >= 97 && int(curWord[0]) <= 122)
            curWord.str[0] = char(int(curWord.str[0]) - 32);
        if (int(curWord[0]) >= 224 && int(curWord[0]) <= 255)
            curWord.str[0] = char(int(curWord.str[0]) - 32);

        (*strOut) += curWord;
        for (int i = 0; i < spaces; i++)
        {
            (*strOut) += ' ';
        }
    }
    (*strOut).str[(*strOut).length] = '\0';

    return (*strOut);
}

MyString& MyString::KeyWord()
{
    MyString strTemp,
             curWord,
             *strOut = new MyString;

    strTemp.DeepCopy(*this);
    while (!strTemp.IsEmpty())
    {
        curWord.ExtractFisrtWordOfString(strTemp);
        (*strOut) += curWord.str[0];
    }

    return (*strOut);
}

// Operators //

std::ostream& operator<< (std::ostream& os, const MyString& strIn)
{
    os << strIn.str;
    return os;
}

char MyString::operator[] (const int index)
{
    return this->str[index];
}

MyString& MyString::operator+= (char symbol)
{
    size_t lngth = this->length;
    char* temp = new char[lngth];
    for (size_t i = 0; i < lngth; i++)
    {
        temp[i] = this->str[i];
    }
    this->str = new char[lngth + 2];
    for (size_t i = 0; i < lngth + 1; i++)
    {
        if (i != lngth)
            this->str[i] = temp[i];
        else
            this->str[i] = symbol;
    }
    this->str[lngth + 1] = '\0';
    delete[] temp;
    this->length++;

    return *this;
}

MyString& MyString::operator+= (MyString& strIn)
{
    size_t length1 = this->length;
    char* temp = new char[length1];
    for (size_t i = 0; i < length1; i++)
    {
        temp[i] = this->str[i];
    }
    this->str = new char[length1 + strIn.length + 1];
    for (size_t i = 0; i < length1; i++)
    {
        this->str[i] = temp[i];
    }
    for (size_t i = 0; i < strIn.length; i++)
    {
        this->str[length1 + i] = strIn.str[i];
    }
    this->str[this->length + strIn.length] = '\0';
    delete[] temp;
    this->length += strIn.length;

    return *this;
}

MyString& MyString::operator= (MyString& strIn)
{
    (*this).DeepCopy(strIn);

    return (*this);
}

MyString& MyString::operator= (const char* strIn)
{
    MyString strTemp = strIn;
    (*this).DeepCopy(strTemp);

    return (*this);
}

MyString::~MyString()
{
    if(this->str != NULL)
        delete[] this->str;
}   

// Private //

int MyString::ExtractFisrtWordOfString(MyString& strIn)
{
    MyString strTemp,
             outWord;

    bool found = false;
    bool countSpaces = true;
    int counter = 0;
    for (size_t i = 0; i < strIn.length; i++)
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
    (*this).DeepCopy(outWord);

    return counter;
}