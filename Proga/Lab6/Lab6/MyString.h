#pragma once

#include <iostream>

#define EMPTY_STRING nullptr

class MyString
{
protected:
    char* str;

public:
    virtual size_t GetLength() = 0;
    virtual void MoveLetters() = 0;

    friend std::ostream& operator<< (std::ostream&, const MyString&);
    friend std::ostream& operator<< (std::ostream&, const MyString*);

    ~MyString();
};
