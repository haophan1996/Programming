# README

## Introduction to Lab Assignment 4

This assignment has you work with types and options.

- Due: End of lab
- Deliverables: Commit and push to Github. Submit to Gradescope

## Part A: Practice with types

### Part A.1 isShape

`isCircle` and `isRectangle` functions each take a shape, and returns `true`/`false` if the shape is the given type.

`isSquare` returns true if the shape is a rectangle, *and* the sides are equal.

### Part A.2 countShapes

The `countCircle` function takes a list of shapes, and counts how many circles there are.

## Part B: Practice with options

Note: For these functions, implement them **without** using the `List` module!

### Part B.1 tryMin

`tryMin` takes a list of integers, and returns the smallest number. If the list is empty, return `None`

    > tryMin [11]
    Some 11
    > tryMin []
    None

### Part B.2 tryNth

`tryNth` takes in an index `n` and a list `l`. This function returns the item at the specified index, if available. However, if the list is shorter than n, you need to return `None`

    > tryNth 0 [11]
    Some 11
    > tryNth 2 [11; 12]
    None
    > tryNth 0 []
    None

## Part B.3: tryFindIdx

This function takes in a predicate and a list. It searches through the list, and finds the **index** (wrapped inside an `option`) of the first element that satisfies the predicate (returns `true`). If there is no such element, return `None`.

    > tryFindIdx (fun x -> x > 0) [-3; 0; 7]
    Some 2
    > tryFindIdx (fun x -> x > 0) [-3; 0; -7]
    None

