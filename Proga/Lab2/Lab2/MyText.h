#pragma once
#define DELIMITERS_TEXT "\n\r"

#include "MyString.h"

class MyText
{
public:
    MyText();

    MyText(std::nullptr_t);

    MyText(const MyText&);

    void AddString(MyString&, size_t strNum = -1);

    void RemoveString(size_t strNum = -1);

    size_t GetWordsNum();

    void Clear();

    int GetNumberOfStrings(size_t);

    MyText& TextUpperCase();

    void DeepCopy(MyText&);

    friend std::ostream& operator<< (std::ostream&, const MyText&);

    MyString operator [] (const int);

    ~MyText();

private:
    MyString* text;
    size_t strings_num;

    void AddEmptySpace();

    void RemoveEmptySpace();
};