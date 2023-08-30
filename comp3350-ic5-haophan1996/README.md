# README
swipl -t "[test_ic5],  run_tests"
## Introduction to In-class Assignment 5

This assignment is designed to give you practice in working with basic lists in Prolog.

- Due: End of Class
- Deliverables: Commit and push to Github. 

## Running Tests

Like last week, to run the test open up a new terminal, and run:

    swipl.exe '--on-error=halt' -t "[test_ic5], run_tests"

## Part 1: List Length

This function counts how many elements exist in the list. The first argument is the list; the second is the number of elements. 

For example:

    listLen([11], 1).
    listLen([11, 12, 13], 3).

## Part 2: last

This function returns the last element of the list. This is similar to the `head` function, but returns the last, not the first element.

If the list is empty, don't do anything.

For example:

    last([11], 11).
    last([11, 12, 13], 13).

## Part 3: sumPos

This function adds all *postiive* numbers. The first argument is the list; the second is the total sum.

For example:

    sumPos([11], 11).
    sumPos([11, 13, -9], 24).

## Part 4: duplicate

This function duplicates each element of the list. The first argument is the list, the second argument is the duplicated list.

For example:

    duplicate([11], [11, 11]).
    duplicate([11, 12], [11, 11, 12, 12]).

