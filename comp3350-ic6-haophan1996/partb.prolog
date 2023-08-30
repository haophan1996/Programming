:- use_module(library(clpfd)).

% Using the CLP(FD) library, solve the loaves of bread puzzle.
% A, B, C, D, E are the number of loaves of bread in increasing order.
% First specify the range of possible values,
% Then specify the rules
% Last, use labeling to convert rules to concrete answers.
solve(A, B, C, D, E) :-
    A in 1..600,
    B in 1..600,
    C in 1..600,
    D in 1..600,
    E in 1..600, 
    A #> 9 ,
    A #< 11, 
    A + B + C + D + E #= 600, 
    X #> 0,  
    B #= A + X,
    C #= B + X,
    D #= C + X,
    E #= D + X, 
    A + B #> 9, 
    labeling([], [A, B, C, D, E]).