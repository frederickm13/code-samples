import models


def print_tree(node):
    queue = []
    queue.append(node)

    while (len(queue) > 0):
        n = queue.pop(0)
        print(n.val, end=" ")

        if (n.left is not None):
            queue.append(n.left)
        
        if (n.right is not None):
            queue.append(n.right)
    
    print("\n")

def shallow_copy_node(node):
    copy = None

    if (node is not None):
        copy = models.TreeNode(node.val, None, None)

    return copy

def copy_tree(node):
    stack = []
    pointer = [node, shallow_copy_node(node)]
    parent_copy_node = None

    while pointer[0] is not None or len(stack) > 0:
        if (pointer[0] is not None):
            # Check if node value is set.
            if (pointer[0].val != pointer[1].val):
                pointer[1].val = pointer[0].val

            # Check if parent copy is already tracked.
            if (parent_copy_node is None):
                parent_copy_node = pointer[1]

            # Copy left and right nodes.
            pointer[1].left = shallow_copy_node(pointer[0].left)
            pointer[1].right = shallow_copy_node(pointer[0].right)

            # Add right node to stack for 
            # both the original and copy trees.
            stack.append([pointer[0].right, pointer[1].right])
            
            # Move pointer to left on both
            # the original and copy trees.
            pointer = [pointer[0].left, pointer[1].left]

        else:
            pointer = stack.pop()
    
    return parent_copy_node