from BinarySearchTree import BinarySearchTree, Node, BinaryTree

temp = open("input.txt", "r").read().split(" ")
arr = [int(temp[i]) for i in range(len(temp))]

Tree = BinaryTree(arr)
print("Inorder walk on generated binary tree:")
Tree.InorderTreeWalk(Tree.root)
print()

f = open("output.txt", "w")
SearchTree = BinarySearchTree(Tree, f)
print("Inorder walk on generated binary search tree:")
SearchTree.InorderTreeWalk(SearchTree.root)
print()

print("Write needed sum:")
S = int(input())
print("All paths by sum", S, "is in file 'output.txt'.")
SearchTree.PrintPathsBySum(SearchTree.root, S)

f.close()
