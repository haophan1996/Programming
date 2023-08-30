# README

## Introduction to Assignment 1

This assignment has you write more complicated recursive functions that work with lists, tuples, and pattern matching.

- Due: One week
- Deliverables: Commit and push to Github. Submit to Gradescope

## TEST TIMEOUT WARNING

It is very easy to get into an infinite loop in this assignment. Make sure you get a green checkmark (✅).

The most surefire way to check is to use the terminal (notice the `-s .runsettings`!):

    > dotnet test -s .runsettings


## Part A: List Processing 1

### Part A.1: removeFirstX

Complete the function `removeFirstX`, that returns a new list that is identical to the original list but with the first
`x` removed. For example,

    > removeFirstX [4; 5; 4] 4;;
    let it : int list = [5; 4]

The type of the function is `int list -> int -> int list`.

### Part A.2: removeAllX

Complete the function `removeAllX`, that returns a new list that is identical to the original list but with all
instances of `x` removed. For example,

    > removeX [4; 5; 4] 4;;
    let it : int list = [5]

The type of the function is `int list -> int -> int list`

## Part B: List Processing 2

### Part B.1: vecAdd

Complete the function `vecAdd`, that does vector addition of two lists. Vector addition means you add the first two
elements, second two elements, third two elements, etc. Assume that both lists have the same number of elements.

For example,

    > vecAdd [11; 12; 13] [10; 10; 10];;
    let it : int list = [21; 22; 23]

First element of the return value is `11 + 10`, second is `12 + 10`, third is `13 + 10`.

Hint: Try using a match expression with a pair of lists, for example

    let rec vecAdd v1 v2 =
        match v1, v2 with
        | [], [] -> []
        | h1::t1, h2::t2 -> // TODO

The type of the function is `int list -> int list -> int list`.

### Part B.2: equivalent

Complete the function `equivalent` that returns `true` if both lists have the same numbers, in the same order.

    > equivalent [11; 12] [11; 12];;
    let it : bool = true
    > equivalent [11] [11; 12];;
    let it : bool = false

The type of the function is `'a list * 'a list -> bool`.

## Part C: intToList

Complete the function `intToList`, that takes a positive integer, returns a new list with the number split into each
position. For example,

    > intToList 219;;
    let it : int list = [2; 1; 9]

The type of the function is `int -> int list`.

## Part D: Triangle Times

This assignment is adapted from the Canadian Computing Competition: 2014 Stage 1, Junior #1 [[1]](#ref1).

You have trouble remembering which type of triangle is which. You write a function to help. Your function takes in three angles (in degrees):

1. If all three angles are 60 , return `"Equilateral"`.
2. If the three angles do *not* add up to 180 , return `"Error"`.
3. If the three angles add up to 180 **and** exactly two of the angles are the same, return `"Isosceles"`.
4. If the three angles add up to 180 and **no two angles** are the same, return `"Scalene"`.

For example, given `(60, 70, 50)`, you return `"Scalene"` because they add up to 180 and no two angles are the same. On
the other hand, given `(60, 75, 55)`, you return `"Error"` because they add up to 190.

The type of the function is `int * int * int -> string`.

## Part E: Fergusonball Ratings

This assignment is adapted from the Canadian Computing Competition: 2022 Stage 1, Junior #2 [[2]](#ref2).

Fergusonball players are given a star rating based on the number of points that they score and the number of fouls that
they commit. Specifically, they are **awarded** 5 stars for each point scored, and 3 stars are **taken away** for each
foul committed.

Assume that the number of points scored and the number of fouls will never be negative, and for every player, the number
of points that they score is greater than the number of fouls that they commit.

Your job is to determine how many players on a team have a star rating **greater than 40**.

For example, let's say there are two players on a team:

1. 12 goals and 4 fouls
2. 8 goals and 0 fouls

The first player has a star rating of 48 (`12 * 5 - 4 * 3`). The second player has a star rating of 40 (`8 * 5`).
Therefore, this team has 1 player that has a star rating greater than 40.

Your task is to complete the function `fergusonBall`, that takes a list of pairs (each element is a pair). This function
computes the star rating of every player, and returns the number of players that have a star rating of at least 41. For
example, the above example would give you the following result:

    > fergusonBall [(12, 4); (8; 0)];;
    let it = int 1;

The type of the function is `(int * int) list -> int`.

## References

- <a id="ref1">[1]</a> https://dmoj.ca/problem/ccc14j1
- <a id="ref2">[2]</a> https://dmoj.ca/problem/ccc22j2
