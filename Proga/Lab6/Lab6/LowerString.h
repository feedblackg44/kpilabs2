#pragma once
#include "MyString.h"
class LowerString :
    public MyString
{
public:
    LowerString(const char*);
    LowerString(char*);

    size_t GetLength() override;
    void MoveLetters() override;
};

