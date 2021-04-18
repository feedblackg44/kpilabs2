import os
import random

size = 10

# changing size of the array randomly to 10, 100 or 1000
choose = random.randint(1, 3)
for i in range(1, choose):
    size *= 10
size += 1

mass = [i for i in range(1, size)]
random.shuffle(mass)

fileIn = open("input.txt", 'w')

for i in range(-1, len(mass)):
    if i == -1:
        fileIn.write(str(len(mass)))
    else:
        fileIn.write(str(mass[i]))
    if i != len(mass) - 1:
        fileIn.write("\n")

fileIn.close()