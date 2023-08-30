# README

## Introduction to Lab Assignment 2

This assignment is designed get you used to working with tuples, lists, and recursion.

- Due: End-of-class
- Deliverables: Commit and push to Github. Submit to Gradescope

## Part A: Syntax Practice

### Part A.1: addPair

Complete the function `addPair`, that accepts a pair (2-tuple) of numbers and adds them together.

The type of the function is `int * int -> int`.

### Part A.2: middleOne

Complete the function `middleOne`, that returns the middle item of a triplet (3-tuple). Middle item means the one
positionwise in the middle, not by value.

The type of the function is `int * int * int -> int`.

### Part A.3: squareAndCubed

Complete the function `squareAndCubed`, that takes a number and returns a pair (2-tuple) that contains both the square and cube of the number.

### Part A.4: multArrays

Complete the function `multArrays`, that takes a number `x` and returns a list. The list contains `x`, 2 times `x`, 3 times `x`, and 4 times `x`.

## Part B: Recursion

### Part B.1: euclids_gcd

The Euclidean Algorithm is a method for computing the greatest common divisor of two positive integers [[1]](#ref1). It does so by dividing the two numbers and getting the remainder. This process is repeated by dividing the remainder and the smaller of the previous number. The final non-zero answer is the greatest common divisor.

For example, to get the GCD of 36 and 15

1. 36 % 15 = 6
2. 15 % 6 = 3
3. 6 % 3 = 0

Therefore, the answer is 3.

Complete the function `euclids_gcd`, which computes the greatest common divisor of two integers `a` and `b`. Write a recursive function that implements the following:

- Base case: If `a` is 0, return `b`
- Base case: If `b` is 0, return `a`
- Inductive step: First compare the two numbers. Let's say the larger is `x`, smaller is `y`. Divide x from y, and recursively call `euclids_gcd` with `y` `x%y`.

You may assume `a` and `b` will never be negative.

### Part B.2: pascalsTriangle

Pascal's Triangle is a sequence of numbers organized in a trianglular layout. Each number is the sum of two numbers directly above it. The first and last element of each row is 1.

For example, the following is an example of a 4-row triangle

       1
      1 1
     1 2 1
    1 3 3 1

If you look at the bottom row, the 3s are computed by adding the 1 and 2 above it.

In this part, you are to complete the recursive function `pascalsTriangle` which will compute the values of cells within the Pascals' Triangle. The function takes two arguments, row and index. 

- Base case: Row 0 returns 1
- Base case: 0th and last index of each row returns 1
- Inductive step: The pascalsTriangle value of the two numbers immediately above it

* *note: Once all tests for pascals triangle has passed, you can view the result by running the following command in the terminal*

    dotnet run --project ./src/App/App.fsproj 10

*To view a 10-row triangle.

## References

- <a id="ref1">[1]</a> https://en.wikipedia.org/wiki/Euclidean_algorithm
- <a id="ref2">[2]</a> https://en.wikipedia.org/wiki/Pascal%27s_triangle
