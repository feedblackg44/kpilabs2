from BinaryTree import BinaryTree, Node

class BinarySearchTree:
    def __init__(self, BinTree, file):
        self.tempPath = []
        self.pathList = [[]]
        self.root = BinTree.root
        self.iterator = 0
        self.file = file
        BinTree.CreateArrForSort(BinTree.root)
        temp = self.NumbersFrom(BinTree.arrForSort)
        temp.sort()
        self.sorted = temp
        self.SearchTreeCreate(self.root)

    def InorderTreeWalk(self, x):
        if x != None:
            self.InorderTreeWalk(x.left)
            print(x.key, end=" ")
            self.InorderTreeWalk(x.right)

    def SearchTreeCreate(self, x):
        if x != None:
            self.SearchTreeCreate(x.left)
            if x.key != None and x.key != 0:
                x.key = self.sorted[self.iterator]
                self.iterator += 1
            self.SearchTreeCreate(x.right)

    def NumbersFrom(self, arr):
        arrOut = []
        for i in range(len(arr)):
            if arr[i] != None and arr[i] != 0:
                arrOut.append(arr[i])
        return arrOut

    def FindPathsBySum(self, root, path, S):
        if (not root):
            return

        path.append(root.key)

        self.FindPathsBySum(root.left, path, S)
        self.FindPathsBySum(root.right, path, S)

        f = 0
        for j in range(len(path) - 1, -1, -1):
            f += path[j]

            if (f == S):
                self.PrintVector(path, j)

        path.pop(-1)

    def PrintPathsBySum(self, root, S):
        path = []
        self.FindPathsBySum(root, path, S)

    def PrintVector(self, v, i):
        for j in range(i, len(v)):
            self.file.write(str(v[j]) + " ")
        self.file.write("\n")