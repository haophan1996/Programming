# README

## Introduction to Assignment 3

This assignment has you practice working with sorting, binary search trees, and interpretation

- Due: One week
- Deliverables: Commit and push to Github. Submit to Gradescope

## Part A: Sorted Linked List

### Background

A linked list is a data structure that organizes items using nodes that are chained together. Each node contains a
reference to the next node in the list. 

    type LinkedList<'a> =
        | EmptyList
        | LLNode of 'a * LinkedList<'a>

The organization of a linked list makes it like a unary tree, and thus this part of the assignment is intended as
practice for the next part.

To add a new node to a list, you can use the `llAppend` function. This function takes a pointer to a node and a new item
to add. The item is always added to the very end of the list.

If the node is empty, this means that the list doesn't contain anything, so you should return a new node with the said
item

If the node is not empty, you need to move further down the list (because this is an append function, where new item is
added to the end).

For example, if we had a list that contains 2 and 3, this would be written as `LLNode (2, LLNode (3, EmptyList))` and
can be drawn as

    2 -> 3 -> X

After adding 8, the list is `LLNode (2, LLNode (3, LLNode (8, EmptyList)))` and drawn as

    2 -> 3 -> 8 -> X

Using this as reference, complete the two functions `llToList` and `llInsertSorted`.

### Part A.1 ToList

The `llToList` function reads a linked list and returns it as an F# list. For example,

    2 -> 3 -> 8 -> X

should be returned as `[2; 3; 8]`.

### Part A.2 InsertSorted

The `llInsertSorted` function takes a sorted linked list and a new item, and inserts the new item in the appropriate
position. For example, adding 5 to the following list:

    2 -> 3 -> 8 -> X

will return this list:

    2 -> 3 -> 5 -> 8 -> X

## Part B: Binary Search Trees

### Background

Binary search trees are binary trees that keep their nodes in a sorted order. It does this by checking the values of each node when inserting nodes.

When the item to be inserted is smaller than the node value, the item is inserted in the *left* subtree. If it's larger, it's inserted in the *right* subtree.

In other words, the tree has a restriction that *all* data values in the left subtree have values that are smaller that the node itself has, and all data values in the right subtree have values larger than the node itself. This restriction is called an **invariant**

For duplicates, you may insert them in any order.

### Part B.1: Insertion

This recursive function accepts a tree (or a potential subtree) and an item. It then inserts the item into the tree while maintaining the BST invariant. If the item is larger, insert into the right subtree. If smaller, insert into the left subtree. If the item is identical to the node, ignore and return the tree unmodified.

There is also a `listToBST` function that is completed for you (you do not need to complete this yourself). This function shows the power of the `fold` function. The `fold` function is given a function, the `insertBST` function, and an initial state, the `Empty` tree. It is also given a list, which is repeatedly applied to the empty tree to build up a full BST.

### Part B.2: ToList

This recursive function collects the contents of a binary tree using pre-order traversal. This method of traversal adds everything in the left subtree first, then the node itself, then everything in the right subtree last. 

Note that if you provide a binary search tree, the list will be fully sorted. If you provide a binary tree that's not a BST, then the list should be left unsorted.

Some examples:

    > Empty |> toList
    []
    > [3] |> listToBST |> toList
    [3]
    > [3; 1; 5] |> listToBST |> toList
    [1; 3; 5]
    
### Part B.3: min/max

These functions return the minimum and maximum of a binary search tree. The return type is `option`, and if the tree is empty, return `None`.

Note that because the tree is sorted, you are *not* to exhaustively search the tree. Instead, you should take advantage of the tree's properties and choose which subtree to take. Remember, every element of the left subtree is smaller than the node itself, and every element of the right subtree is larger than both.

Some examples:

    > Empty |> minBST
    None
    > [3] |> listToBST |> minBST
    Some 3
    > [3; 1; 5] |> listToBST |> minBST
    Some 1
    > [3; 1; 5] |> listToBST |> maxBST
    Some 5

