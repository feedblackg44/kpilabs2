import os
import random
import algorithms as alg

# uncomment to create a random input.txt
#import randomgen

if (os.path.exists("input.txt") == False):
    print("Error accessing the file!")
    exit(1)

fileIn = open("input.txt", 'r')
massLen = 0
mass = []
for i, line in enumerate(fileIn):
    temp = line.split(" ")
    map_temp = map(int, temp)
    temp = list(map_temp)
    if i == 0:
        massLen = temp[0]
    else:
        mass.append(temp[0])

fileIn.close()

if massLen != len(mass):
    print("Wrong array length!")
    exit(1)

mass1 = mass.copy()
counter1 = alg.QuickSort(mass1, 0, len(mass1) - 1)
print(mass1, counter1)

mass2 = mass.copy()
counter2 = alg.MedQuickSort(mass2, 0, len(mass2) - 1)
print(mass2, counter2)

fileOut = open("output.txt", 'w')
fileOut.write(str(counter1) + " " + str(counter2))
fileOut.close()