#include "LowerString.h"

// Public //

LowerString::LowerString(const char* strIn) 
{
    size_t length = strlen(strIn);
    this->str = new char[length + 1];
    for (size_t i = 0; i < length; i++)
    {
        this->str[i] = strIn[i];
        if (int(this->str[i]) >= 65 && int(this->str[i]) <= 90)
            this->str[i] = char(int(this->str[i]) + 32);
    }
    this->str[length] = '\0';
}

LowerString::LowerString(char* strIn)
{
    size_t length = strlen(strIn);
    this->str = new char[length + 1];
    for (size_t i = 0; i < length; i++)
    {
        this->str[i] = strIn[i];
        if (int(this->str[i]) >= 65 && int(this->str[i]) <= 90)
            this->str[i] = char(int(this->str[i]) + 32);
    }
    this->str[length] = '\0';
}

size_t LowerString::GetLength()
{
    return strlen(this->str);
}

void LowerString::MoveLetters()
{
    size_t length = strlen(this->str);
    size_t amount = 1;
    char* temp = new char[amount];
    for (size_t i = 0; i < amount; i++)
    {
        temp[i] = this->str[length - 1 - i];
    }
    for (size_t i = length - 1; i >= amount; i--)
    {
        this->str[i] = this->str[i - amount];
    }
    for (size_t i = 0; i < amount; i++)
    {
        this->str[amount - 1 - i] = temp[i];
    }
    delete[] temp;
}

// Private //