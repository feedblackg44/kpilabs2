class Heap:
    arr = []
    heap_size = 0

    def __init__(self, arr):
        self.arr = arr
        self.heap_size = len(arr)

    def MaxHeapify(self, i):
        p = Heap.Left(i)
        q = Heap.Right(i)
        largest = i
        if p < self.heap_size and self[p] > self[largest]:
            largest = p
        if q < self.heap_size and self[q] > self[largest]:
            largest = q
        if largest != i:
            self.arr[i], self.arr[largest] = self.arr[largest], self.arr[i]
            self.MaxHeapify(largest)

    def MinHeapify(self, i):
        p = Heap.Left(i)
        q = Heap.Right(i)
        lowest = i
        if p < self.heap_size and self[p] < self[lowest]:
            lowest = p
        if q < self.heap_size and self[q] < self[lowest]:
            lowest = q
        if lowest != i:
            self.arr[i], self.arr[lowest] = self.arr[lowest], self.arr[i]
            self.MinHeapify(lowest)

    def HeapMaximum(self):
        return self.arr[0]

    def HeapExtractMax(self):
        if self.heap_size < 1:
            raise Exception("Heap is empty!")
        self.heap_size -= 1
        return self.arr.pop(0)

    @staticmethod
    def Left(i):
        return i << 1

    @staticmethod
    def Right(i):
        return (i << 1) + 1

    @staticmethod
    def Parent(i):
        return i >> 1

    def __getitem__(self, key):
        return self.arr[key]

    def __len__(self):
        return len(self.arr)

    def __str__(self):
        return str(self.arr)

    def ins(self, key, obj):
        self.arr.insert(key, obj)
        self.heap_size += 1

    def add(self, obj):
        self.arr.append(obj)
        self.heap_size += 1