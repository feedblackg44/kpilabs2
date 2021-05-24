from functions import RungeKutta
from matplotlib.pyplot import plot

func = lambda y, x: 1+1.4*y*sin(x)-y**2
a = 0
b = 6
y0 = 0
h = 0.01

arrX, arrY, arrE = RungeKutta(func, y0, a, b, h)
plot(arrX, arrY)