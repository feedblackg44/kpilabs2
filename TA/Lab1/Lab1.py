import math

arr = [30, 19, 9, 15, 55, 24, 3, 78, 46, 41]
print("Входной массив:", arr, sep = '\n', end = '\n\n')

arr1 = arr.copy()
for i in range(0, len(arr1) - 1, 1):
    for j in range(0, len(arr1) - i - 1, 1):
        if (arr1[j] > arr1[j+1]):
            arr1[j+1], arr1[j] = arr1[j], arr1[j+1]
print("Сортированный массив пузырьком:", arr1, sep = '\n', end = '\n\n')

arr3 = arr.copy()
for i in range(0, len(arr3), 1):
    for j in range(0, len(arr3) - i, 1):
        if(j > 0):
            if (arr3[j] % 2 == 0 and arr3[j] < arr3[j-1]):
                arr3[j-1], arr3[j] = arr3[j], arr3[j-1]
        if (j < len(arr3) - 1):
            if(arr3[j] % 2 == 1 and arr3[j] < arr3[j+1]):
                arr3[j+1], arr3[j] = arr3[j], arr3[j+1]
print("Сортированный массив адаптированным пузырьком для задания 2:", arr3, sep = '\n', end = '\n\n')

arr2 = arr.copy()
for i in range(0, len(arr2) - 1, 1):
    swap = False
    for j in range(0, len(arr2) - i - 1, 1):
        if (arr2[j] > arr2[j+1]):
            arr2[j+1], arr2[j] = arr2[j], arr2[j+1]
            swap = True
    if (swap == False):
        break
print("Сортированный массив улучшенным пузырьком:", arr2, sep = '\n', end = '\n\n')

arr4 = arr.copy()
for i in range(0, len(arr4), 1):
    swap = False
    for j in range(0, len(arr4) - i, 1):
        if (j > 0):
            if (arr4[j] % 2 == 0 and arr4[j] < arr4[j-1]):
                arr4[j-1], arr4[j] = arr4[j], arr4[j-1]
                swap = True
        if (j < len(arr4) - 1):
            if (arr4[j] % 2 == 1 and arr4[j] < arr4[j+1]):
                arr4[j+1], arr4[j] = arr4[j], arr4[j+1]
                swap = True
    if(swap == False):
        break
print("Сортированный массив улучшенным адаптированным пузырьком для задания 3:", arr4, sep = '\n', end = '\n\n')