# README

## Introduction to Lab Assignment 5

This assignment has you practice working with binary search trees

- Due: One day
- Deliverables: Commit and push to Github. Submit to Gradescope

## Part A: Count

This recursive function counts the number of items in binary tree. 

Some examples:

    > count Empty
    0

    // tree316 is a tree with 3 as root, and 1, 6 on either side
    // i.e.   3
    //       1 6

    > count tree316
    3

## Part B: ToListPreOrder

This recursive function collects the contents of a binary tree using pre-order traversal. This method of traversal adds
the node itself first, then everything in the left subtree, then finally everything in the right subtree. 

Some examples:

    // tree316 is a tree with 3 as root, and 1, 6 on either side
    // i.e.   3
    //       1 6

    > count tree316
    [3; 1; 6]

## Part C: maxTree

This function returns the maximum of a binary tree. The return type is `option`, and if the tree is empty, return `None`.

Some examples:

    > maxTree Empty
    None

    // tree316 is a tree with 3 as root, and 1, 6 on either side
    // i.e.   3
    //       1 6

    > maxTree tree316
    Some 6

Note: It may be helpful to first complete the helper function `threeMax`, which takes in two options and one item and
returns the maximum value of either of them.

## Part D: pathsum

This assignment is adapted from LeetCode [[1]](#ref1).

A path of a binary tree is a sequence of values from the root to a leaf node, and the pathsum is the sum of all elements. If the tree is empty, the pathsum is 0.

This function computes pathsums of a binary tree, and returns `true` if *at least one path* returns the sum identical to target sum.

Some examples:

    > pathsum Empty 0
    true

    // tree316 is a tree with 3 as root, and 1, 6 on either side
    // i.e.   3
    //       1 6

    > pathsum tree316 4 // The path 3 > 1
    true
    > pathsum tree316 9 // The path 3 > 6
    true
    > pathsum tree316 3
    false
    
## References

- <a id="ref1">[1]</a>https://leetcode.com/problems/path-sum/
