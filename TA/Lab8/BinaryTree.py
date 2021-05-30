from Node import Node

class BinaryTree:
    def __init__(self, arr):
        self.root = None
        self.count = 0
        self.arrForSort = []
        self.GenerateTree(arr)
        self.Kill0Elems(self.root)

    def InorderTreeWalk(self, x):
        if x != None:
            self.InorderTreeWalk(x.left)
            print(x.key, end=" ")
            self.InorderTreeWalk(x.right)

    def CreateArrForSort(self, x):
        if x != None:
            self.CreateArrForSort(x.left)
            self.arrForSort.append(x.key)
            self.CreateArrForSort(x.right)

    def Kill0Elems(self, x):
        if x != None:
            self.Kill0Elems(x.left)
            if x.key == 0:
                if x.parent.left == x:
                    x.parent.left = None
                elif x.parent.right == x:
                    x.parent.right = None
            self.Kill0Elems(x.right)

    def GenerateTree(self, arr):
        parent = None
        for i in range(len(arr)):
            node = Node(0)
            node.key = arr[i];
            node.parent = parent;
            if node.key == 0:
                parent = node.parent
            else:
                parent = node

            if node.parent != None:
                flag = True;
                while flag:
                    if node.parent.left == None:
                        node.parent.left = node
                        flag = False
                    elif node.parent.right == None:
                        node.parent.right = node
                        flag = False
                    else:
                        node.parent = node.parent.parent
            if i == 0:
                self.root = node