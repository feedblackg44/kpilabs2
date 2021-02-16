#include "functions.h"

bool moreThan(int num1, int num2)
{
    bool output = false;            // output bool variable which depends on compare of numbers
    bool highestBit = true;         // decide if it's a highest bit or not

    for (int i = sizeof(int)*8 - 1; i >= 0; i--)
    {
        if (num1 >> i ^ num2 >> i)
        {
            if (highestBit)
                output = num2 & (1 << i);
            else
                output = num1 & (1 << i);
            break;
        }
        else
            highestBit = false;
    }

    return output;
}

void dekrement(int& num)
{
    for (int i = 0; i < sizeof(int) * 8; i++)
    {
        num = num ^ (1 << i);
        if (num & (1 << i))
            continue;
        break;
    }
}