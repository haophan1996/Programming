# README

## Introduction to Lab Assignment 8

This assignment is designed to give you practice in working with lists in Prolog.

- Due: End of Lab
- Deliverables: Commit and push to Github. Submit to Gradescope.

## Installation

For this assignment going forward, you will be using SWI Prolog, a popular prolog implementation. If you're in Windows
or MacOS, head over to [SWI Prolog Stable Download Page](https://www.swi-prolog.org/download/stable) and install it.

You can also use your distribution's package manager (i.e. Linux, Windows scoop, or MacOS homebrew).

## Part A: allSame

This function will return `true` if all elements of a list are identical.

For example:

    allSame([11, 11]).

To run the unit tests, run this command:

    swipl '--on-error=halt' -t "[test_parta],  run_tests"

For testing individual queries, you may load the file into prolog:

    swipl '--on-error=halt' parta.prolog

And then run the querires manually:

    ?- allSame([11, 11]).
    true.

## Part B: insertionSort

### Part B.1: insert

Given a sorted list and an item, return a list with the item inserted in the correct position.

### Part B.2: insertionSort

Given an unsorted list, return the list sorted

## Part C: reverse

### Part C.1: appendList

The slides discuss `appendList`, which will prove handy for this assignment. You are given two lists, and are to
return a new list with the two added back to back.

### Part C.2: reverse

Using the `appendList` predicate, return a new list with the contents reversed (i.e. `[11, 12, 13]` reversed will be
`[13, 12, 11]`.

## Part D: getIdx

Given a list and an index, return the item at the specified index (0 means first item).

Make sure you don't return anything if the index is out of bounds. Remember, to make something not return anything,
don't handle the case (i.e. include `getIdx :- I #>= 0`  but skip `getIdx :- I #< 0`).
