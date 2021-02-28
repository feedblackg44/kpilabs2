import random

def generate_data(n, gen_type="random"):
    if gen_type=="best":
        a = [i+1 for i in range(n)]
        return a
    elif gen_type=="worst":
        a = [i+1 for i in reversed(range(n))]
        return a
    else:
        a = [i+1 for i in range(n)]
        random.shuffle(a)
        return a

def bubble_sort(data):
    counter = 0
    for i in range(0, len(data) - 1, 1):                        # Проходим по всем элементам массива в колчиестве раз равным количеству элементов
        for j in range(0, len(data) - 1, 1):                    # Проходим по всем элементам массива
            counter += 1
            if (data[j] > data[j + 1]):                         # Проверка, если текщуий элемент больше следующего
                data[j + 1], data[j] = data[j], data[j + 1]     # Переставляем элементы в таком случае
    return counter

def bubble_impr_sort(data):
    counter = 0
    for i in range(0, len(data) - 1, 1):                        # Проходим по всем элементам массива в колчиестве раз равным количеству элементов
        swap = False                                            # Флаг для проверки, не перемещались ли элементы
        for j in range(0, len(data) - i - 1, 1):                # Проходим по всем оставшимся элементам массива
            counter += 1
            if (data[j] > data[j + 1]):                         # Проверка, если текщуий элемент больше следующего
                data[j + 1], data[j] = data[j], data[j + 1]     # Переставляем элементы в таком случае
                swap = True
        if (swap == False):                                     # Если элементы не перемещались - выходим из цикла, т.к. массив сортирован
            break
    return counter


def insertion_sort(data):
    counter = 0
    for j in range(1, len(data)):                               # Проходим все элементы массива, кроме нулевого
        shift = False                                           # Переменная для проверки сдвига
        key = data[j]                                           # Ключ - текущий элемент
        i = j - 1                                               # Индекс предыдущего элемента
        while i >= 0 and data[i] > key:                         # Перебираем элементы от ключа в начало, пока ключ меньше текущего элемента
            data[i + 1] = data[i]                               # Присваиваем следующему элементу значение текущего
            i -= 1
            counter += 1
            shift = True
        if i >= 0:                                              # Если не прошли весь массив увеличиваем каунтер на одно сравнение
            counter += 1
        if shift:                                               # Если были сдвиги
            data[i + 1] = key                                   # Переставляем ключ на нужную позицию
    return counter
