#pragma once

class Expression 
{
private:
    double _a;
    double _b;
    double _c;
    double _d;

public:
    Expression(double a, double b, double c, double d);
    double Calculate();
};