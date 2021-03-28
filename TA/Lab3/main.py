import os

import algorithms as alg

fileName = "input.txt"

if (os.path.exists(fileName) == False):
    print("Error accessing the file!")
    exit(1)

fileIn = open(fileName, 'r')
userNum = 0
filmsNum = 0
matrixOfMarks = []
userList = []

for i, line in enumerate(fileIn):
    temp = line.split(" ")
    map_temp = map(int, temp)
    temp = list(map_temp)
    if i == 0:
        userNum = temp[0]
        filmsNum = temp[1]
    else:
        userList.append(temp[0])
        temp.pop(0)
        matrixOfMarks.append(temp)

fileIn.close()

print("Type a usernumber:")
userToCompare = int(input())
if ((userToCompare in userList) == False):
    print("There is no user with choosed number!")
    exit(1)

curUserMarks = matrixOfMarks[userToCompare - 1]
matrixOfMarks.pop(userToCompare - 1)
userList.pop(userToCompare - 1)

matrixOut = []
for i in range(len(matrixOfMarks)):
    temp = alg.sortToCount(curUserMarks, matrixOfMarks[i])
    countInv = alg.InvCount(temp, 1, len(temp))
    matrixOut.append([userList[i], countInv])

alg.MergeSortBySecond(matrixOut, 1, len(matrixOut))
matrixOut.insert(0, [userToCompare])
matrixOut.append([userToCompare])

fileOut = open("output.txt", 'w')
for i in range(len(matrixOut)):
    strOut = ""
    for j in range(len(matrixOut[i])):
        strOut += str(matrixOut[i][j])
        if j != len(matrixOut[i]) - 1:
            strOut += ' '
    if i != len(matrixOut) - 1:
        strOut += '\n'
    fileOut.write(strOut)

fileOut.close()
