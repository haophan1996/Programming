:- use_module(library(clpfd)).


% Solution to determining Dominic And Peters ages given specific contraints
% TODO: Complete and document
solveAge(Dominic, Peter) :-
    Dominic #= Peter + 36,  % Dominic is 36 years and older than Peter
    Dominic8YearsAgo #= Dominic - 8, % Dominic 8 years ago
    Peter8YearsAgo #= Peter - 8,    % Peter 8 years ago
    Dominic8YearsAgo #= 2 * Peter8YearsAgo,  % Dominic was twice Peter's age
    Dominic #=< 100, Peter #=< 100, Dominic #>= 0,Peter #>= 0.

% Determine amount of quarters and nickels James has based on constraints
% TODO: Complete and document
solveCoins(Quarters, Nickels) :-
    24 #= Quarters + Nickels,
    300 #= Quarters * 25 + Nickels * 5,
    Quarters #>= 0, Nickels #>= 0.

% Determine whether X, Y, and Z are pythagorean triples
% Make sure you define ranges of valid answers
% TODO: Complete and document
pythaTriple(X, Y, Z) :-
    Z * Z #= X * X + Y * Y,
    Y #>= X, 
    X #>= 0, X #>= 0, Z #>= 0, % XYZ MUST be Positive
    X #=< 30, Y #=< 30, Z #=< 30. % XYZ Must less than 30

% Part B.0 Ungraded helper predicate that adds up each element
% TODO: Complete and document
sumList([], 0).
sumList([H|T], Sum) :-
    sumList(T, Rest),
    Sum #= H + Rest.

% Part B.0 Ungraded helper predicate that returns true if all elements are the same
% TODO: Complete and document
allSame([]).
allSame([_]).
allSame([X,X|T]) :- allSame([X|T]).

% Part B.1: Convert rows to diagonals
% TODO: Complete and document
diagonal([A,_,C], [_,B,_], [D,_,F], [A,B,F], [C,B,D]).

% Part B.2 Check whether a square is a magic square
% (given by 3 rows of 3 numbers each)
magicSquare([[A, B, C], [D, E, F], [G, H, I]]) :- 
    EleminList = [A, B, C, D, E, F, G, H, I], 
    EleminList ins 1..9, 
    all_distinct(EleminList), 
    SumRow #= A + B + C, 
    sumList([A,B,C], Sumrow1), Sumrow1 #= SumRow,
    sumList([D,E,F], Sumrow2), Sumrow2 #= SumRow,
    sumList([G,H,I], Sumrow3), Sumrow3 #= SumRow, 
    sumList([A,D,G], SumCol1), SumCol1 #= SumRow,
    sumList([B,E,H], SumCol2), SumCol2 #= SumRow,
    sumList([C,F,I], SumCol3), SumCol3 #= SumRow, 
    sumList([A,E,I], Sumdia1), Sumdia1 #= SumRow,
    sumList([C,E,G], Sumdia2), Sumdia2 #= SumRow.