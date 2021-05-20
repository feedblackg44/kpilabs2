import math

def makeHashTable(A, hashFunc):                        # Создание хеш-таблицы
    T = [None for i in range(len(A)*3)]                # Создаём пустую таблицу (все элементы = Null)
                                                       # длиной в три раза большем чем размер входного массива
    counter = 0                                        # Создаём счётчик коллизий
    for i in range(len(A)):                            # От 0 до длины входных данных
        temp = hashFunc(A[i], len(T))                  # Создаём временную переменную хранящую хеш текущего элемента
        if T[temp] == None:                            # Если по хешу текущего элемента пусто -
            T[temp] = [A[i]]                           # создаём пустой писок и кладём туда текущий элемент
        else:                                          # Иначе
            counter += 1                               # Произошла коллизия
            T[temp].append(A[i])                       # Добавляем текущий элемент в конец списка для утранения коллизий
    return T, counter                                  # Возвращаем созданную таблицу и количество коллизий

def foundNumsForSum(A, S, hashFunc):                   # Поиск пары чисел по переданной сумме
    T, counter = makeHashTable(A, hashFunc)            # Создание хеш-таблицы на основе переданных данных
    for i in range(len(A)):                            # От 0 до длины входных данных
        temp = hashFunc(S - A[i], len(T))              # Создаём временную переменную хранящую хеш искомого элемента
        if temp >= 0 and temp < len(T):                # Если хеш-ключ не выходит за границы таблицы
            if T[temp] != None:                        # Если по хешу искомого элемента не пусто
                if SearchInList(T[temp], S - A[i]):    # Если в списке по хешу искомого элемента есть искомый элемент
                    return [A[i], S - A[i]]            # Возвращаем искомый элемент
    return [0, 0]                                      # Иначе возвращаем два нуля

def hashDiv(k, m):                                     # Хеш-алгоритм деления
    return k % m

def hashMult(k, m):                                    # Хеш-алгоритм умножения
    A = (math.sqrt(5)-1)/2
    return math.ceil(m*((k*A) % 1))

def SearchInList(arr, value):
    for i in arr:
        if i == value:
            return True
    return False