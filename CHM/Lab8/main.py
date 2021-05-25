from functions import RungeKutta, Adams, beautifulPrint, calcualteE
from math import sin
from matplotlib.pyplot import plot, show, xlabel, ylabel

func = lambda x, y: 1+1.4*y*sin(x)-y**2
a = 0
b = 6
y0 = 0
h = 0.1

rungeX1, rungeY1 = RungeKutta(func, y0, a, b, h)
rungeX2, rungeY2 = RungeKutta(func, y0, a, b, h/2)
rungeE = calcualteE(rungeX1, rungeX2, rungeY1, rungeY2)
adamsX1, adamsY1 = Adams(func, y0, a, b, h)
adamsX2, adamsY2 = Adams(func, y0, a, b, h/2)
adamsE = calcualteE(adamsX1, adamsX2, adamsY1, adamsY2)
strOut = ""
strOut += "Перший метод (Рунге-Кутта):\n"
strOut += beautifulPrint(rungeY1, 5)
strOut += "Другий метод (Адамса):\n"
strOut += beautifulPrint(adamsY1, 5)
strOut += "Похибки першого методу (Рунге-Кутта):\n"
strOut += beautifulPrint(rungeE, 5)
strOut += "Похибки другого методу (Адамса):\n"
strOut += beautifulPrint(adamsE, 5)
file = open("output.txt", "w")
file.write(strOut)
file.close()
plot(rungeX1, rungeY1)
plot(adamsX1, adamsY1)
ylabel("y(x)")
xlabel("x")
show()
plot(rungeX1, rungeE)
plot(adamsX1, adamsE)
ylabel("e(x)")
xlabel("x")
show()
