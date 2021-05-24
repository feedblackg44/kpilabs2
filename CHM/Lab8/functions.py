def RungeKutta(func, y0, a, b, h):
    x0 = a
    x = x0
    y = y0
    arrX = []
    arrY = []
    arrE = []
    while x <= b:
        k1 = func(x0, y0)
        k2 = func(x0+h/2, y0+h*k1/2)
        k3 = func(x0+h/2, y0+h*k2/2)
        k4 = func(x0+h, y0+h*k3)
        y = y0 + h/6*(k1+2*k2+2*k3+k4)
        t = abs((k2-k3)/(k1-k2))
        print(t)
        e = 1 / 6 * (k1 * y0 + 2 * k2 * y0 + 2 * k3 * y0 + k4 * y0) - (y - y0) / h
        arrX.append(x)
        arrY.append(y)
        arrE.append(e)
        x += h
        y0 = y
        x0 = x
    return arrX, arrY, arrE