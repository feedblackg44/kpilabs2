#include "functions.h"

bool moreThan(int num1, int num2)
{
    bool highestBit = true;                     // decide if it's a highest bit or not
    int iter = 1 << (sizeof(int) * 8 - 2);      // iterator to cross over all bits

    while (iter)
    {
        if (num1 & iter ^ num2 & iter)
        {
            if (highestBit)
                return num2 & iter;
            else
                return num1 & iter;
        }
        else
            highestBit = false;
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