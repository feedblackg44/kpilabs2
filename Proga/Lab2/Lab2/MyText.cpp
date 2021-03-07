#include <iostream>
#include "MyString.h"
#include "MyText.h"

// Public //

MyText::MyText()
{
    this->text = nullptr;
    this->strings_num = 0;
}

MyText::MyText(std::nullptr_t)
{
    this->text = nullptr;
    this->strings_num = 0;
}

MyText::MyText(const MyText& textIn)
{
    this->strings_num = textIn.strings_num;
    this->text = new MyString[this->strings_num];

    for (size_t i = 0; i < this->strings_num; i++)
    {
        this->text[i].DeepCopy(textIn.text[i]);
    }
}

void MyText::AddString(MyString& strIn, size_t strNum)
{   
    this->AddEmptySpace();
    size_t sNum = this->strings_num;
    if (strNum > sNum)
        strNum = sNum;
    else if (strNum < 1)
        strNum = sNum;
    for (size_t i = sNum - 1; i >= strNum; i--)
    {
        this->text[i] = this->text[i - 1];
    }
    this->text[strNum - 1] = strIn;
}

void MyText::RemoveString(size_t strNum)
{
    size_t sNum = this->strings_num;
    if (strNum > sNum)
        strNum = sNum;
    else if (strNum < 1)
        strNum = sNum;
    if (text != nullptr && strings_num > 0)
    {
        for (size_t i = 0; i < sNum - 1; i++)
        {
            if (i >= strNum - 1)
                this->text[i] = this->text[i + 1];
        }
    }
    this->RemoveEmptySpace();
}

size_t MyText::GetWordsNum()
{
    return this->strings_num;
}

void MyText::Clear()
{
    delete[] this->text;
    this->text = nullptr;
    this->strings_num = 0;
}

int MyText::GetNumberOfStrings(size_t length)
{
    int counter = 0;
    for (size_t i = 0; i < this->strings_num; i++)
    {
        if (this->text[i].GetLength() == length)
            counter++;
    }
    return counter;
}

MyText& MyText::TextUpperCase()
{
    MyText* textOut = new MyText;

    textOut->DeepCopy(*this);

    for (size_t i = 0; i < textOut->strings_num; i++)
    {
        textOut->text[i] = (*this)[i].UpperCase();
    }

    return *textOut;
}

void MyText::DeepCopy(MyText& textIn)
{
    this->strings_num = textIn.strings_num;
    this->text = new MyString[this->strings_num];

    for (size_t i = 0; i < strings_num; i++)
    {
        this->text[i].DeepCopy(textIn.text[i]);
    }
}

// Operators //

std::ostream& operator<< (std::ostream& os, const MyText& textIn)
{
    for (size_t i = 0; i < textIn.strings_num; i++)
    {
        os << textIn.text[i];
        if (i != textIn.strings_num - 1)
            os << "\n";
    }
    return os;
}

MyString MyText::operator [] (const int index)
{
    return this->text[index];
}

MyText::~MyText()
{
    if(this->text != nullptr)
        delete[] this->text;
}

// Private //

void MyText::AddEmptySpace()
{
    size_t sNum = this->strings_num;

    MyString* temp = new MyString[sNum];
    for (size_t i = 0; i < sNum; i++)
    {
        temp[i].DeepCopy(this->text[i]);
    }

    this->text = new MyString[sNum + 1];
    for (size_t i = 0; i < sNum; i++)
    {
        this->text[i].DeepCopy(temp[i]);
    }
    this->strings_num++;
}

void MyText::RemoveEmptySpace()
{
    if (this->text != nullptr && this->strings_num > 0)
    {
        size_t sNum = this->strings_num;

        MyString* temp = new MyString[sNum];
        for (size_t i = 0; i < sNum; i++)
        {
            temp[i].DeepCopy(this->text[i]);
        }

        this->text = new MyString[sNum - 1];
        for (size_t i = 0; i < sNum - 1; i++)
        {
            this->text[i].DeepCopy(temp[i]);
        }
        this->strings_num--;
    }
}