#include "NumString.h"
#include <ctype.h>

// Public //

NumString::NumString(const char* strIn)
{
    size_t length = strNumLen(strIn);
    this->str = new char[length + 1];
    size_t j = 0;
    for (size_t i = 0; i < strlen(strIn); i++)
    {
        if (isdigit(strIn[i]))
            this->str[j++] = strIn[i];
    }
    this->str[length] = '\0';
}

NumString::NumString(char* strIn)
{
    size_t length = strNumLen(strIn);
    this->str = new char[length + 1];
    size_t j = 0;
    for (size_t i = 0; i < strlen(strIn); i++)
    {
        if (isdigit(strIn[i]))
            this->str[j++] = strIn[i];
    }
    this->str[length] = '\0';
}

void NumString::MoveLetters()
{
    size_t length = strlen(this->str);
    size_t amount = 1;
    char* temp = new char[amount];
    for (size_t i = 0; i < amount; i++)
    {
        temp[i] = this->str[i];
    }
    for (size_t i = 0; i < length - amount; i++)
    {
        this->str[i] = this->str[i + amount];
    }
    for (size_t i = 0; i < amount; i++)
    {
        this->str[length - 1 - i] = temp[amount - 1 - i];
    }
    delete[] temp;
}

size_t NumString::GetLength()
{
    return strNumLen(this->str);
}

// Private //

size_t NumString::strNumLen(char* strIn)
{
    size_t len = strlen(strIn);
    size_t counter = 0;
    for (size_t i = 0; i < len; i++)
    {
        if (isdigit(strIn[i]))
            counter++;
    }
    return counter;
}

size_t NumString::strNumLen(const char* strIn)
{
    size_t len = strlen(strIn);
    size_t counter = 0;
    for (size_t i = 0; i < len; i++)
    {
        if (isdigit(strIn[i]))
            counter++;
    }
    return counter;
}