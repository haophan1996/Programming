# README

## Introduction to Lab Assignment 3

This assignment is about these topics.

- Due: End of day
- Deliverables: Commit and push to Github. Submit to Gradescope

## Notes

- The only allowed external function is `string`, which you can use to convert an int to string (`string 42` will return
  `"42"`). You are **not** allowed to use any other external functions. This includes functions from the `List` module,
  such as `List.sort`

## Part A: Generate pairs

### Part A.1 dist

`dist` takes in a list `l` and an item `x`. This function distributes one element across every element in the list. For example,

    > dist 1000 ["CHEM"; "MATH"];;
    val it : (int * string) list = 
    [(1000, "CHEM"); (1000, "MATH")]

## Part A.2: pairs

This is the actual function that generates all possible combinations. For example,

    > pairs [1000;1050] ["CHEM";"MATH"];;
    val it : (int * string) list =
    [(1000, "CHEM"); (1000, "MATH"); (1050, "CHEM); (1050, "MATH")]

## Part B: Insertion Sort

### Part B.1 Insert

Insert takes an int value and sorted int list and returns an sorted int list with the element inserted in the proper place. As usual, start with a set of base cases, and build your inductive steps from there.

    > insert [2; 9] 7;;
    val it : int list = [2; 7; 9]

### Part B.2: InsertionSort

Insertion sort takes an unsorted int list and returns a sorted int list. Use the `insert` function to do so.

## Part C: FizzBuzz

This part implements the well-known problem FizzBuzz. The FizzBuzz problem generates a list of strings. The list should contain a list of sequential numbers as strings.

    > fizzbuzz 1;;
    ["1"]
    > fizzbuzz 5;;
    ["1"; "2"; "fizz"; "4"; "buzz"]

### Part C.1: FizzBuzzStr

This helper function takes in an integer and returns a string that is either:

1. `"fizz"`: if the number is a multiple of 3
2. `"buzz"`: if the number is a multiple of 5
3. `"fizzbuzz"`: if the number is a multiple of both 3 and 5
4. The integer as a string

### Part C.2: FizzBuzz

This function takes in an integer. It returns a list that contains either the string version of the integer or one of `"fizz"`, `"buzz"`, or `"fizzbuzz"` according to the logic in Part C.1. 
