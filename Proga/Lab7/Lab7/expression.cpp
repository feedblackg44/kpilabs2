#include <iostream>
#include "expression.h"

Expression::Expression(double a, double b, double c, double d)
{
    _a = a;
    _b = b;
    _c = c;
    _d = d;
}

double Expression::Calculate()
{
    double x = 24 + _d - _c;
    if (_b == 0)
        throw std::exception("Can't divide by 0!");
    if (x < 0)
        throw std::exception("Expression under the square root must be more or equal to 0!");
    double z = sqrt(x) + _a / _b;
    if (z < 0)
        throw std::exception("Can't divide by 0!");
    
    double result = ( 1 + _a - _b/2 ) / z;
    return result;
}