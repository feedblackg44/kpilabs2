#include "functions.h"

bool moreThan(int num1, int num2)
{   
    int iter = 1 << (sizeof(int) * 8 - 1);       // iterator to cross over all bits
    if (num1 & iter ^ num2 & iter)
        return num2 & iter;

    iter = 1 << (sizeof(int) * 8 - 2);
    while (iter)
    {
        if (num1 & iter ^ num2 & iter)
        {
            return num1 & iter;
        }
        iter >>= 1;
    }

    return false;
}

void dekrement(int& num)
{
    int iter = 1;           // iterator to cross over all bits
    while (iter)
    {
        num ^= iter;
        if (num & iter)
            iter <<= 1;
        else
            iter = 0;
    }
}