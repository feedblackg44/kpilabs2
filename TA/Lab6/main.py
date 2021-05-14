from algorithms import GetMedian, AddElement
from Heap import Heap

lowHeap = Heap([])
highHeap = Heap([])
strOut = ""
for i, line in enumerate(open("input.txt", "r")):
    if i > 0:
        AddElement(lowHeap, highHeap, int(line))
        med = GetMedian(lowHeap, highHeap)
        for i in range(len(med)):
            strOut += str(med[i])
            if i != len(med) - 1:
                strOut += " "
        strOut += "\n"

out = open("output.txt", "w")
out.write(strOut)
out.close()