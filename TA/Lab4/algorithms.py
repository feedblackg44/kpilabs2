import math

def Partition(A, p, r):
    x = A[r]
    i = p - 1
    counter = 0
    for j in range(p, r):
        counter += 1
        if A[j] <= x:
            i += 1
            A[i], A[j] = A[j], A[i]
    A[i + 1], A[r] = A[r], A[i + 1]
    return i + 1, counter

def QuickSort(A, p, r):
    counter = 0
    if p < r:
        q, temp_counter = Partition(A, p, r)
        counter += temp_counter
        counter += QuickSort(A, p, q-1)
        counter += QuickSort(A, q+1, r)
    return counter

def GetMedian(a, b, c):
    if a > b:
        if a < c:
            return a
        elif b > c:
            return b
        else:
            return c
    else:
        if a > c:
            return a
        elif b < c:
            return b
        else:
            return c

def MedPartition(A, p, r):
    q = math.floor((p+r)/2)
    median = GetMedian(A[p], A[q], A[r])
    medIndex = p
    if median == A[q]:
        medIndex = q
    elif median == A[r]:
        medIndex = r
    A[r], A[medIndex] = A[medIndex], A[r]
    x = A[r]
    i = p - 1
    counter = 0
    for j in range(p, r):
        counter += 1
        if A[j] <= x:
            i += 1
            A[i], A[j] = A[j], A[i]
    A[i + 1], A[r] = A[r], A[i + 1]
    return i + 1, counter

def MedQuickSort(A, p, r):
    counter = 0
    if p < r:
        if r - p > 2:
            q, temp_counter = MedPartition(A, p, r)
            counter += temp_counter
            counter += MedQuickSort(A, p, q - 1)
            counter += MedQuickSort(A, q + 1, r)
        else:
            q, temp_counter = Partition(A, p, r)
            counter += temp_counter
            counter += MedQuickSort(A, p, q - 1)
            counter += MedQuickSort(A, q + 1, r)
    return counter