from sympy import *
from math import ceil
import numpy.polynomial.legendre as leg

x = Symbol('x')

def trapIntegral(f, a, b, e):
    print("Trapeszoid method begins.")
    maxSecond = maxVal(f.diff(x).diff(x), a, b)
    n = ceil(sqrt((maxSecond*((b-a)**3))/(abs(e)*12)))
    print("There is", n, "intrevals.")
    f0 = lambdify(x, f, modules="sympy")
    integral = (b - a) / (2 * n)
    summ = f0(a)
    step = (b - a) / n
    print("Step of iteration process will be:", step)
    i = a + step
    print("Calculating the result.")
    while i < b:
        summ += 2*f0(i)
        i += step
    summ += f0(b)
    integral *= summ
    return integral

def maxVal(f, a, b):
    e = 0.000001
    f0 = lambdify(x, f)
    solutions = []
    i = a
    while i <= b:
        solutions.append(abs(f0(i)))
        i += e
    solutions.append(abs(f0(b)))
    return max(solutions)

def gaussIntegral(f, a, b, e):
    print("Gauss method begins.")
    n = 0
    e1 = 1
    print("Finding out correct number of intervals.")
    while e1 >= e:
        n += 1
        f0 = f
        for i in range(0, 2 * n):
            f0 = f0.diff(x)
        e1 = ((factorial(n)**4 * (b-a)**(2*n+1) * maxVal(f0, a, b))/((2*n+1)*(factorial(2*n))**3))
    print(e1, "<", e)
    print("So we found n =", n)
    t = Symbol('t')
    f1 = f.subs(x, (b + a) / 2 + t * (b - a) / 2)
    f1 = lambdify(t, f1, modules="sympy")
    print("Substituting new variable.")
    multip = (b - a) / 2
    print("Finding Legendre roots and coefficients.")
    x_arr, A_arr = leg.leggauss(n)
    f_arr = [f1(x_arr[i]) for i in range(len(x_arr))]
    summ = 0
    print("Calculating the result.")
    for i in range(len(f_arr)):
        summ += A_arr[i]*f_arr[i]
    return summ * multip
