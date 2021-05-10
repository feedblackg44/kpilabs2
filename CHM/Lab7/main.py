from sympy import *
import functions as fc
import math
import numpy.polynomial.legendre as leg

x = Symbol('x')

f = cos(x) / (x + 1)
n = 4
e = 10**-n
a = 0.7
b = 1.4
MathCadIntegral = 0.174005157219204

print("Source formula: f(x) =", f, "\n")
if a < b:
    trap = fc.trapIntegral(f, a, b, e)
    print("Trapezoid Integral:", round(trap, n))
    print("Trapezoid Error:", abs(MathCadIntegral - trap), "\n")
    gauss = fc.gaussIntegral(f, a, b, e)
    print("Gauss Integral:", round(gauss, n))
    print("Gauss Error:", abs(MathCadIntegral - gauss))
elif a == b:
    print("Value of integral is 0.")
else:
    print("A mistake happend :D")