#include "MyString.h"

MyString::~MyString()
{
    if (this->str != NULL)
        delete[] this->str;
}

// Operators //

std::ostream& operator<< (std::ostream& os, const MyString& strIn)
{
    os << strIn.str;
    return os;
}

std::ostream& operator<< (std::ostream& os, const MyString* strIn)
{
    os << (*strIn).str;
    return os;
}

// Private //