from algorithms import foundNumsForSum, makeHashTable, hashDiv, hashMult

arrLen = 0
sumsLen = 0
arr = []
sums = []

for i, line in enumerate(open('input.txt')):
    if i == 0:
        tempArr = line.split(" ")
        arrLen = int(tempArr[0])
        sumsLen = int(tempArr[1])
    elif i <= arrLen:
        arr.append(int(line))
    elif i <= arrLen + sumsLen:
        sums.append(int(line))

fOut = open("output.txt", "w")
for i in range (len(sums)+1):
    if i == 0:
        T1, counter1 = makeHashTable(A=arr, hashFunc=hashDiv)
        T2, counter2 = makeHashTable(A=arr, hashFunc=hashMult)
        fOut.write(str(counter1) + " " + str(counter2) + "\n")
    else:
        temp = foundNumsForSum(A=arr, S=sums[i-1], hashFunc=hashMult)
        fOut.write(str(temp[0]) + " " + str(temp[1]) + "\n")
fOut.close()