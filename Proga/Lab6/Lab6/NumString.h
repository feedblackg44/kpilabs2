#pragma once
#include <iostream>
#include "MyString.h"

class NumString :
    public MyString
{
public:
    NumString(const char*);
    NumString(char*);

    size_t GetLength() override;
    void MoveLetters() override;

private:
    size_t strNumLen(char*);
    size_t strNumLen(const char*);
};

