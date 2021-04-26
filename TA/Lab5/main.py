import random
import algorithms as alg

arr = [i for i in range(121, 141)]
random.shuffle(arr)
print("Stock:", arr)

out = alg.RadixSort(arr, 3)
print("Sorted:", out)