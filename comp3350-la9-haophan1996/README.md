# README

## Introduction to Lab Assignment 9

This assignment is designed to give you more experience in puzzle solving in Prolog.

- Due: Tonight Midnightm
- Deliverables: Commit and push to Github. Submit to Gradescope.

## Running Tests

Like before, to run the tests:

    swipl -t "[test_la9],  run_tests"

## Part A: Linear Equations

### Part A.1

This assignment is adapted from Boffins Portal [[1]](#ref1).

Dominic is 36 years older than Peter and was twice Peter's age 8 years ago. Assuming none are older than 100 years, how old are their ages now?

### Part A.2

This assignment is adapted from Boffins Portal [[1]](#ref1).

James has 24 coins in nickels and quarters. In total, he has $3.00 (or 300 cents). How many nickels and quarters does he have?

### Part A.3

A Pythagorean Triple is a set of 3 positive integers [[2]](#ref2) X, Y, and Z where `X * X + Y * Y = Z * Z`. Write a prolog
predicate that will generate some pythagorean triplets. Y should be larger than X.

To make sure that the program won't take too long to complete, you should make sure that all numbers are positive integers smaller than 30.

A fully correct answer should be able to generate the Pythagorean Triples, although the unit tests are unable to
properly test for this. If you pass the unit tests that should be good enough your grade.

    ?- pythaTriple(X, Y, Z).
    X = 3,
    Y = 4,
    Z = 5 ;
    X = 5,
    Y = 12,
    Z = 13 ;

    ...and so on

## Part B: Magic Square

The magic square is a square of integers, where the sum of numbers in each row, column and the two diagonals are all the same.

### Part B.0: sumList/allSame

These predicates were seen previously, and you may copy from previous assignments (will not be part of your grade).

### Part B.1: diagonal

Create a predicate that takes in three lists of three each, and creates two lists of the diagonals. For example, given the following square:

| C0 | C1 | C2 |
| -- | -- | -- |
| 1  | 2  |  3 |
| 4  | 5  |  6 |
| 7  | 8  |  9 |

The main diagonals are [3, 5, 7] and [1, 5, 9]. Some examples of using the predicate are:

    ?- diagonal([1,2,3], [4,5,6], [7,8,9], D1, D2).
    D1 = [1,5,9],
    D2 = [3,5,7].

    D1 = [3,5,7],
    D2 = [1,5,9].

You may assume each row has always has 3 elements, so the two diagonals will always have 3 elements as well.

### Part B.2: Magic Square

As noted earlier, the magic square is a square of integers, where the sum of numbers in each row, column and the two diagonals are all the same. We will be looking at the normal version, so all numbers are between 1 through N x N (inclusive).

Using the `sudoku22` predicate as reference, create a predicate that will return whether the provided square is a magic square.

You should only use the following built-in predicates:

- length: To check the length of a list
- transpose: To convert rows into columns
- all_distinct: To check if each element in a list is different

Although you may create and use more helper predicates.

There are two magic puzzles to test against:

| C0 | C1 | C2 |
| -- | -- | -- |
| 8  | 1  |  6 |
| 3  | 5  |  7 |
| 4  | 9  |  2 |

and

| C0 | C1 | C2 |
| -- | -- | -- |
| 2  | 7  |  6 |
| 9  | 5  |  1 |
| 4  | 3  |  8 |

Your output should match the following:

    ?- magicSquare([[8, 1, 6], [3, 5, 7], [4, 9, 2]]).
    true
    ?- magicSquare([[2, 7, 6], [9, 5, 1], [4, 3, 8]]).
    true

    ?- magicSquare([[8, 1, 6], [3, 5, 7], [4, 9, C33]]).
    C33 = 2.

    ?- magicSquare([[2, 7, 6], [9, C22, 1], [4, 3, C33]]).
    C22 = 5,
    C33 = 8.

## References

- <a id="ref1">[1]</a> (https://boffinsportal.com/10-examples-of-linear-equations-in-real-life/)
- <a id="ref2">[2]</a> (https://en.wikipedia.org/wiki/Pythagorean_triple)
- <a id="ref3">[3]</a> (https://en.wikipedia.org/wiki/Magic_square)
