# README

## Introduction to In-class Activity 7

This assignment is designed to give you more examples of logic puzzles in Prolog.

- Due: End of Day
- Deliverables: Commit and push to Github.

## Magic Square

The magic square is a square of integers, where the sum of numbers in each row, column and the two diagonals are all the
same. For this assignment, we will first study a related puzzle before solving the magic square puzzle.

### Part 0: Sudoku

Sudoku is a number puzzle where each row, each column, and each NxN box of the puzzle contains exactly one number.
For example, the following is a simplified version of sudoku called a 2x2 sudoku, where each box is 2x2, and the
numbers can be between 1 and 4:

| C0 | C1 | C2    | C3    |
|----|----|-------|-------|
|    |    | **Y** | **3** |
|    |    | **2** | **4** |
|    | 2  |       | 1     |
| 1  |    |       | X     |

Sudoku numbers are (C) WorksheetWorks.com [[1]](#ref1).

If you look at column C3, there is 3, 4, 1. Therefore, the cell that represents X will be 2. Also, if you look at the
upper right column (where all the numbers are bold, there is 2, 3, and 4, but not 1. Therefore, you can see that Y
needs to be 1.

Solving the entire puzzle, we get:

| C0 | C1 | C2 | C3 |
|----|----|----|----|
| 2  | 4  | 1  | 3  |
| 3  | 1  | 2  | 4  |
| 4  | 2  | 3  | 1  |
| 1  | 3  | 4  | 2  |

`sudoku22` is a predicate that checks if the puzzle is a valid sudoku table, and additionally solves it for
you.

For example, let's say we have the following sudoku table:

    solve1 :-
        sudoku22(
            [[_, 1, _, 4],
             [_, _, _, _],
             [_, 3, _, 1],
             [_, 2, _, _]]).

If we try to solve it, this is what you should get:

    ?- solve1.
    2 1 3 4
    3 4 1 2
    4 3 2 1
    1 2 4 3

Study how the sudoku puzzle works and understand what's going on.

## Part A.1

Unfortunately the `valid_box` predicate is not complete, so you won't get a proper answer. This predicate is given two
rows, and returns true if the left 2x2 box and the right 2x2 box contain distinct numbers. For example the following two
rows (`[x, y, a, b], [z, w, c, d]`)

    x y a b
    z w c d

contain two boxes (w,y,z,w, the left box), and (a,b,c,d, the right box). The boxes need to contain unique numbers.

To run the unit tests, run the following command:

    swipl.exe '--on-error=halt' -t "[test_parta], run_tests"

## Part A.2

Search for "2x2 sudoku" online, and mimic `solve1` to solve the other sudoku puzzle.

## References

- <a id="ref1">[1]</a> https://worksheetworks.com/puzzles/sudoku/sudoku-2x2.html
