from sympy import *
import functions as fc

x = Symbol('x')

f = 2*x**3-4*x**2-x+2
e = 10**-6

print("Висхідна функція:\nf =", f)

func = lambdify(x, f)

temp1 = [0]
temp2 = [0]

bisec_res = [fc.Bisection(-1, 0, func, e, temp1), fc.Bisection(0, 1, func, e, temp2), 2]
bisek_counter = [temp1[0], temp2[0], 0]

hord_res = [fc.Hord(-1, 0, f, e, temp1), fc.Hord(0, 1, f, e, temp2), 2]
hord_counter = [temp1[0], temp2[0], 0]

newton_res = [fc.Newton(-1, 0, f, e, temp1), fc.Newton(0, 1, f, e, temp2), 2]
newton_counter = [temp1[0], temp2[0], 0]

print("\nКорені методу бісекцій:")
for i in range(len(bisec_res)):
    print(bisec_res[i], "\t\tКількість ітерацій: ", bisek_counter[i], sep="")
print("\nКорені методу хорд:")
for i in range(len(hord_res)):
    print(hord_res[i], "\t\tКількість ітерацій: ", hord_counter[i], sep="")
print("\nКорені методу Ньютона:")
for i in range(len(newton_res)):
    print(newton_res[i], "\t\tКількість ітерацій: ", newton_counter[i], sep="")