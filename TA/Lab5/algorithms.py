import math

def RadixSort(A, d):                                    # функция RadixSort принимает сортируемый массив и число разрядов
    for i in range(1, d + 1):                           # от первого до последнего разряда
        B = [0 for i in range(0, len(A))]               # создаём массив в который будет возвращаться сортированный массив на каждом
        k = MaxRankNum(A, i)                            # получаем длину будущего дополнительного массива
        CountingSort(A, B, k, i)                        # выполняем стойкую сортировку на основе CountingSort
        A = B.copy()                                    # копируем сортированный массив в массив А
    return A                                            # возвращаем сортированный массив

def CountingSort(A, B, k, d):                           # стойкая сортировка на основе CountingSort
    C = [0 for i in range(0, k + 1)]                    # создаём дополнительный массив для подсчёта количества одинаковых элементов
    for j in range(0, len(A)):                          # от 0 до длины массива A
        C[GetNumOfRank(A[j], d)] += 1                   # прибавляем 1 за каждый одинаковый элемент
    for i in range(1, k + 1):                           # от 1 длины временного массива
        C[i] += C[i - 1]                                # к каждому следующему прибавляем предыдущее число,
                                                        # поскольку каждому индексу соответствует элемент с тем же значением
    for j in range(len(A) - 1, -1, -1):                 # от последнего элемента до нулевого в сортируемом массиве A
        B[C[GetNumOfRank(A[j], d)] - 1] = A[j]          # ставим на нужное место элемент A[j]
        C[GetNumOfRank(A[j], d)] -= 1                   # отнимаем от текущего массива индексов 1
                                                        # что бы если встретится ещё один такой же элемент
                                                        # поставить его не на то же место, а на соседнее

def MaxRankNum(A, rank):
    Max = GetNumOfRank(A[0], rank)
    for i in range(1, len(A)):
        if GetNumOfRank(A[i], rank) > Max:
            Max = GetNumOfRank(A[i], rank)
    return Max

def GetNumOfRank(num, rank):
    rank -= 1
    num -= math.floor(num / math.pow(10, rank + 1)) * math.pow(10, rank + 1)
    num /= math.floor(math.pow(10, rank))
    return int(num)