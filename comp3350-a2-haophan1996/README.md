# README

## Introduction to Assignment 2

This assignment has you practice recursive functions and higher order functions.

- Due: One week
- Deliverables: Commit and push to Github. Submit to Gradescope

## Approved List Functions

You may use any function from the List module. Here is a list of a few that might come in handy. For details, consult the following [link](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html).

- List.map: Convert each item
- List.find: Find a single item that satisfies a given predicate
- List.findBack: Same as above, but start from the back
- List.filter: Find all items that satisfies a given predicate
- List.forall: Check if *all* items satisfy the given predicate
- List.exists: Check if *any* items satisfy the given predicate
- List.reduce: Combine each item in the list
- List.fold: Combine the accumulator and each item in the list
- List.foldBack: Same as before, but start from back
- List.length: Get the length of the list
- List.isEmpty: Check if list is empty
- List.sort: Sort list acording to each item's value
- List.sortBy: Sort list according to a projection (i.e. use part of the item as the sort key)

## Part A: More Recursion Practice

### compress

This function takes a list and scans if there are consecutive duplicates in the list. If so, it "compresses" them into a single item. However, if there are duplicates that are separate, they are kept separate (see second example below).

For example,

    > compress [1; 1]
    val it : int list = [1]
    > compress [1; 1; 2; 2; 1]
    val it : int list = [1; 2; 1]

### split1

This function takes in a list of chars and a delimiter character, and splits the list into two: the part before the list, and after the list (the delimiter is discarded). The two lists are returned as a pair (2-tuple).

- If the delimiter is not found, the second list is empty
- If the delimiter is found multiple times, split only at the first position.

For example,

    > split1 ['a'; 'b'; 'c'] ','
    val it : char list * char list = (['a'; 'b'; 'c'], [])
    > split1 ['a'; 'b'; ','; 'c'] ','
    val it : char list * char list = (['a'; 'b'], ['c'])

## Part B: Higher-order Functions

For these assignments, it is recommended that you use one of the List functions (see above).

### count

This function takes a list and a predicate, and counts how many items in the list satisfy the predicate.

For example,

    > count (fun x -> x > 0) [1; 2; 3]
    val it : int = 3
    > count (fun x -> x = 0) [3; 0; -1]
    val it : int = 1
    > count (fun x -> x > 3) [-3; 1; 2]
    val it : int = 0

### join

This function takes a string list and a string delimiter and combines each item in the list using the delimiter.

For example,

    > join ["www"; "wit"; "edu"] "."
    val it : string = "www.wit.edu"
    > join ", " ["Alice"; "Bob"]
    val it : string = "Alice, Bob"

### sortPairs

This function takes a list that contains a pair of names (strings). Your task is to sort the list so that a user can visually inspect the list for any mistakes.

You should convert each pair so that the first string contains the name that alphabetically comes first (hint: Use comparison operators (`<` or `>`) with the `ToUpper` function). Then sort each pair so that the pairs are sorted alphabetially as well.

For example,

    > sortPairs [("Bob", "Alice")]
    val it : (string * string) list = [("Alice", "Bob")]
    > sortPairs [("Bob", "Alice"); ("andrew", "alice")]
    val it : (string * string) list = [("alice"; "andrew"); ("Alice", "Bob")]

## Part C: Flipper

This assignment is adapted from the Canadian Computing Competition: 2019 Stage 1, Senior #1 [[2]](#ref2).

You are trying to pass the time while at the optometrist. You notice there is a grid of four numbers:

    1 2
    3 4

You see lots of mirrors and lenses at the optometrist, and wonder how flipping the grid horizontally or vertically would change the grid.

Specifically, a "horizontal" flip (across the horizontal centre line) would take the original grid of four numbers and result in:

    3 4
    1 2

A "vertical" flip (across the vertical centre line) would take the original grid of four numbers and result in:

    2 1
    4 3

Your task is to determine the final orientation of the numbers in the grid after a sequence of horizontal and vertical flips. The grid is provided as a 4-tuple starting from the upper left, moving right, then down. So the grid:

    1 2
    3 4

will be provided as `(1, 2, 3, 4)`.

The `flip` function takes in a list of commands, given as either `'h'` or `'v'`, for horizontal or vertical. There are three functions you are to complete: flipHr, flipVr, and flip.

flipHr and flipVr take a tuple of 4 integers and either flip it horizontally or vertially.

flip takes a list of commands and starting from `(1, 2, 3, 4)`, flip repeately flip the grid.

    > `flip ['h']` // Flip it horizontally once
    val it : int * int * int * int = (3, 4, 1, 2)

## Part D: Rotating Letters

This assignment is adapted from the Canadian Computing Competition: 2013 Stage 1, Junior #2 [[2]](#ref2).

An artist wants to construct a sign whose letters will rotate freely in the breeze. In order to do this, she must only use letters that are not changed by rotation of 180 degrees: I, O, S, H, Z, X, and N.

Your task is to write a function that reads a word and determines whether the word can be used on the sign. To complete this, you are given two functions to work on:

### either

The `either` function takes a single string and a list of strings, and returns `true` if the former can be found in the latter. In other words, return `true` if `i` can be found in `l`.

### rotatingLetters

This function takes a list of chars and returns `true` if all the characters are "valid", i.e. within the list of valid characters. You may use the variable `validChars` that is defined in Library.fs.

## References

- <a id="ref1">[1]</a>https://dmoj.ca/problem/ccc19s1
- <a id="ref2">[2]</a> https://dmoj.ca/problem/ccc13j2
