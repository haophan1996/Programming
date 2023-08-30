:- use_module(library(clpfd)).

% Example code that solves a sudoku puzzle
sudoku22(Rows) :-
     % Basic sanity checks: Make sure we have 4 rows of 4 elements each
    length(Rows, 4),
    
    [R1, R2, R3, R4] = Rows,
    length(R1, 4),
    length(R2, 4),
    length(R3, 4),
    length(R4, 4),

    % All elements need to be within 1-4
    R1 ins 1..4,
    R2 ins 1..4,
    R3 ins 1..4,
    R4 ins 1..4,

    % All elements are distinct within the row
    all_distinct(R1),
    all_distinct(R2),
    all_distinct(R3),
    all_distinct(R4),

    % Generate list of columns from the rows
    transpose(Rows, Cols),

    % All elements are distinct within the column
    [C1, C2, C3, C4] = Cols,
    all_distinct(C1),
    all_distinct(C2),
    all_distinct(C3),
    all_distinct(C4),

    % All elements are distinct within a box
    valid_box(R1, R2), valid_box(R3, R4),
    
    % Convert each row to answers
    label(R1), label(R2), label(R3), label(R4),
    tell(Rows).

% TODO: Function that checks if two rows can create two valid boxes
valid_box([A1, A2, C2, C1], [B1, B2, D1, D2]) :-
    all_distinct([A1, A2, B1, B2]), all_distinct([C1, C2, D1, D2]).

tellRow(R) :-
    [C1, C2, C3, C4] = R,
    write(C1), write(' '), write(C2), write(' '), write(C3), write(' '), write(C4), nl.

% Helper function to print the results
tell(Rows) :-
    length(Rows, 4),
    [R1, R2, R3, R4] = Rows,
    tellRow(R1),
    tellRow(R2),
    tellRow(R3),
    tellRow(R4).


solve1 :-
    sudoku22(
        [[_, 1, _, 4],
         [_, _, _, _],
         [_, 3, _, 1],
         [_, 2, _, _]]).

% TODO: Search for another 2x2 sudoku puzzle online and try to solve it using Prolog:
solve2 :-
    sudoku22(
        [[4, _, _, 1],
         [3, _, _, 4],
         [1, _, _, 2],
         [2, _, _, 3]]).
