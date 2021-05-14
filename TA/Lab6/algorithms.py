from Heap import Heap

def GetMedian(lowHeap, highHeap):
    if len(lowHeap) > len(highHeap):
        return [lowHeap.HeapMaximum()]
    elif len(lowHeap) < len(highHeap):
        return [highHeap.HeapMaximum()]
    else:
        return [lowHeap.HeapMaximum(), highHeap.HeapMaximum()]

def AddElement(lowHeap, highHeap, element):
    if len(lowHeap) == 0:
        lowHeap.add(element)
    elif len(highHeap) == 0:
        if element < lowHeap.HeapMaximum():
            highHeap.add(lowHeap.HeapExtractMax())
            lowHeap.add(element)
        else:
            highHeap.add(element)
    elif element < lowHeap.HeapMaximum():
        lowHeap.ins(0, element)
        lowHeap.MaxHeapify(0)
    else:
        highHeap.ins(0, element)
        highHeap.MinHeapify(0)

    if len(lowHeap) - len(highHeap) == 2:
        highHeap.ins(0, lowHeap.HeapExtractMax())
    elif len(highHeap) - len(lowHeap) == 2:
        lowHeap.ins(0, highHeap.HeapExtractMax())