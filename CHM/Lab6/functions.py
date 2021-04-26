from sympy import *
import math

def Bisection(a, b, func, e, counter):
    counter[0] = 0
    x = (a + b) / 2
    while abs(b - a) >= e and abs(func(x)) >= e:
        counter[0] += 1
        x = (a + b) / 2
        if func(x) == 0:
            pass
        elif func(a)*func(x) > 0:
            a = x
        else:
            b = x
    return x

def Hord(a, b, func, e, counter):
    x = Symbol('x')
    counter[0] = 0

    f1 = func.diff(x)
    f2 = f1.diff(x)
    f0 = lambdify(x, func)
    f1 = lambdify(x, f1)
    f2 = lambdify(x, f2)

    x0 = (a + b) / 2
    x1 = math.inf
    x2 = math.inf

    if f1(x0) * f2(x0) < 0:
        x0 = a
        x2 = b
    elif f1(x0) * f2(x0) > 0:
        x0 = b
        x2 = a
    while abs(x2 - x1) >= e and abs(f0(x2)) >= e:
        counter[0] += 1
        x1 = x2
        x2 = x1 - f0(x1)/(f0(x1) - f0(x0)) * (x1 - x0)
    return x2

def Newton(a, b, func, e, counter):
    x = Symbol('x')
    counter[0] = 0

    f1 = func.diff(x)
    f2 = f1.diff(x)
    f0 = lambdify(x, func)
    f1 = lambdify(x, f1)
    f2 = lambdify(x, f2)

    x1 = (a + b) / 2
    x2 = math.inf

    if f1(x1) * f2(x1) < 0:
        x2 = a
    elif f1(x1) * f2(x1) > 0:
        x2 = b
    while abs(x2 - x1) >= e and abs(f0(x2)) >= e:
        counter[0] += 1
        x1 = x2
        x2 = x1 - f0(x1)/f1(x1)
    return x2