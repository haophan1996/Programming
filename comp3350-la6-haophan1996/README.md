# README

## Introduction to Lab Assignment 6

This assignment is designed to give you a better understanding of the inner workings of the scanner.

- Due: End-of-lab
- Deliverables: Commit and push to Github.

## Part A: Reading Regular Expressions

In this part, there are a number of regular expressions. Study the regular expression and come up with three (3) strings that will match successfully. The unit tests will check if you have three unique strings that match the regular expression (`IsMatch` returns `true`).

You do not need to add any documentation for this part.

## Part B: Writing Regular Expressions

In this part, there are a number of string lists. Study the strings and come up with a regular expression that will match the description. Your regular expressions should successfully match the "yes" strings, but not match the "no" strings.

You do not need to add any documentation for this part.

## Part C: Scanner

### Part C.0: Understanding Token Types

The role of the scanner is to ingest a stream of characters and output a list of tokens. The Token type defined near
the top contains a preliminary version of this type. In particular, it contains the following types:

1. Keyword: This token represents F# keywords, and the value of the keyword is included as a `string`. The supported keywords are `let`, `if`, `then`, `else`
2. Assignment: This token indicates an assignment (i.e. `=`). You may leave this alone.
3. Operator: This token indicates arithmetic operators (`+`, `-`) and boolean operators (`>`, and `<`). The type of
   argument is included as a string.
4. Id: Identifier, or variable names. Variable names start with a letter (a-z) upper or lowercase. The rest can be
   either letters or numbers. The name is included in the argument as a string.
   arugment.
5. IntNum: This token indicates an integer value, such as `42`. Integers should not start with 0 except for 0 itself
   (i.e. `007` is not allowed). The value of this token is included as an `int`.
6. FloatNum: This token indicates an floating point value, such as `1.1`. Decimal points are required.
   The value of this token is included as an `float`.
7. Error: This ''token'' indicates that there was an error in processing the input. It should be returned if the input
   matches none of the provided regular expressions.

### Part C.1: Implementing Regular Expressions

For this part, you are to complete the list of regular expressions. Pay attention to the use of special characters (such
as `+`, which may be both replication operators or the plus sign.

Sometimes tokens may be mixed up. Pay attention to the order of matching and the use of anchors (`^` and `$`)!

Because the tokens are pre-sliced, you should do full matching by using anchors, not partial matching.

1. Keywords: Keywords are either `let`, `if`, `then`, `else`.
2. Ident: Identifiers may only start with an alphabet character (a-z), but may have any number of alphabet characters,
3. IntNum: Integer numbers are a sequence of digits, with an *optional* `-`.
   definition to match these as well.
4. FloatNum: Real numbers start with an *optional* `-`, some digits, a decimal point, and some more digits.

Note that because identifiers and keywords can overlap, make sure you check for identifiers first.

### Part C.2: Tokenize Function

Once you have the regular expressions done, the tokenize function will then match the input string `s` against each
of the regular expressions. Once a match has been found, create a Token with the argument filled in.

#### TokenizeAll Function

The input program will be pre-sliced at whitespace boundaries, so that the `tokenize` function works on simple strings.
This means you can use regular expressions that can be matched against the entire argument. For example, the input
string:

    let x = 3

Will be first converted to 

    ["let"; "x"; "="; "3"]

This will allow the regular expressions to be simpler to write. For example, to check for a `Keyword` token you just
need `Regex @"^let$".`

**NOTE**: In a real scanner, the scanner will work on a stream of characters (i.e. an array of chars). A consequence of this
is that our scanner will not be able to process string like `let x=3`
