import functions
import models


def main():
    # Build tree.
    node1 = models.TreeNode(1, None, None)
    node2 = models.TreeNode(2, None, None)
    node3 = models.TreeNode(3, node1, node2)
    node4 = models.TreeNode(4, None, None)
    node5 = models.TreeNode(5, None, None)
    node6 = models.TreeNode(6, node4, node5)
    node7 = models.TreeNode(7, node3, node6)

    # Tree diagram.
    #    7
    #   3 6
    # 1 2 4 5

    # Print original tree.
    print("Original tree:")
    functions.print_tree(node7)

    # Copy tree.
    copy_tree_parent = functions.copy_tree(node7)

    # Print tree copy.
    print("Copy:")
    functions.print_tree(copy_tree_parent)

# Run main method.
main()