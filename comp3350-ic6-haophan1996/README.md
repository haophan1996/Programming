# README

## Introduction to In-class Activity 6

This assignment is designed to give you a taste of how logic puzzles may be solved in Prolog.

- Due: End of Day
- Deliverables: Commit and push to Github.

## Part A

This assignment is adapted from brainzilla.com [[1]](#ref1).

In this assignment, we will be using Prolog to solve simple logic puzzles. At the top of the prolog file, there are a
set of facts. Using the facts as hints, you can derive additional facts. For example, if there are two colors: red and
blue, and lisa doesn't like blue, this means lisa likes red.

Although you can solve this logic puzzle by hand, we will be solving it using the power of prolog. Review the example
problem, and complete the prolog file by following the logic. You can run the solver by running the `solve.` predicate.

Here what it should look like using the example puzzle:

    ?- solve.

    bryan (six years old) likes spiderman.
    sean (eight years old) likes superman.
    tony (ten years old) likes batman
    true

And this what you should get for Part A:

    ?- solve.

    lisa favorite color is blue and has a fish.
    angela favorite color is green and has a dog.
    susan favorite color is red and has a cat.
    true

## Part B

This assignment is adapted from mathisfun.com [[2]](#ref2).

About 2000 years BC there lived Ahmes, a royal secretary and mathematician of the Pharaoh Amenemhat III. One of his
papyruses was found in 1853 by an Englishman called Rhind near the temple of Ramses II in Thebes. It has many
mathematical puzzles and here is one:

- 600 loaves of bread must be divided among five workers.
- Each worker in line must get more than the previous: the same amount more in each case (an arithmetical progression).
- And the first two workers shall get seven times less than the three others.

How many loaves does each worker get?

The answer you should get would be:

    ?- solve(A, B, C, D, E).
    A = 10,
    B = 65,
    C = 120,
    D = 175,
    E = 230 ;


- <a id="ref1">[1]</a> [https://www.brainzilla.com/logic/logic-grid/basic-2/]
- <a id="ref2">[2]</a> [https://www.mathsisfun.com/puzzles/rhind-papyrus-100-loaves-5-men-solution.html]

