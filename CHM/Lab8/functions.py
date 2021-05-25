from math import ceil

def RungeKutta(func, y0, a, b, h0):
    x0 = a
    x = x0
    y = y0
    arrX = []
    arrY = []
    h = h0
    while x <= b:
        k1 = func(x0, y0)
        k2 = func(x0+h/2, y0+h*k1/2)
        k3 = func(x0+h/2, y0+h*k2/2)
        k4 = func(x0+h, y0+h*k3)
        y = y0 + h/6*(k1+2*k2+2*k3+k4)
        arrX.append(round(x, 6))
        arrY.append(y)
        x += h
        y0 = y
        x0 = x
        t = abs((k2 - k3) / (k1 - k2))
        if t > 0.04:
            h /= 2
    return arrX, arrY

def Adams(func, y0, a, b, h0):
    h = h0
    arrX, arrY = RungeKutta(func, y0, a, a+h*3, h)
    i = 3
    while arrX[i] <= b:
        y_ex = arrY[i] + (h/24)*(55*func(arrX[i], arrY[i]) -
                                 59*func(arrX[i-1], arrY[i-1]) +
                                 37*func(arrX[i-2], arrY[i-2]) -
                                 9*func(arrX[i-3], arrY[i-3]))
        y_cor = arrY[i] + (h/24)*(9*func(arrX[i]+h, y_ex) +
                                  19*func(arrX[i], arrY[i]) -
                                  5*func(arrX[i-1], arrY[i-1]) +
                                  func(arrX[i-2], arrY[i-2]))
        arrX.append(round(arrX[i] + h, 6))
        arrY.append(y_cor)
        i += 1
        if (abs(y_cor - y_ex) > 0.04):
            h /= 2
    arrX.pop(len(arrX)-1)
    arrY.pop(len(arrY)-1)
    return arrX, arrY

def calcualteE(arrX1, arrX2, arrY1, arrY2):
    arrE = []
    for i in range(len(arrX1)):
        tempIndex = arrX2.index(arrX1[i])
        arrE.append(abs(arrY1[i] - arrY2[tempIndex])/(2**4 - 1))
    return arrE

def beautifulPrint(arr, num):
    strOut = ""
    newArr = [[None for i in range(num)] for i in range (ceil(len(arr) / num))]
    i = 0
    j = 0
    k = 0
    while i < len(arr):
        if j < len(newArr):
            if k < len(newArr[j]):
                newArr[j][k] = arr[i]
                i += 1
                k += 1
            else:
                k = 0
                j += 1
        else:
            break
    for g in range(len(newArr[len(newArr) - 1]) - 1, -1, -1):
        if newArr[len(newArr) - 1][g] == None:
            newArr[len(newArr) - 1].pop(g)
    for g in range(len(newArr)):
        for u in range(len(newArr[g])):
            strOut += str(newArr[g][u]) + " "
        strOut += "\n"
    return strOut