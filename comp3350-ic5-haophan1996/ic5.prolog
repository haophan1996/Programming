:- use_module(library(clpfd)).

% listLen(List, Length)
% TODO: Complete and comment 

listLen([],0).
listLen([_|T], L):- 
        listLen(T, Restl),
        L #= 1 + Restl.

% last(List, LastElement)
% TODO: Complete and comment 
last([],0).
last([X], X).
last([_|T],L) :- 
    last(T, TL),
    L #= TL.

% sumPos(List, Sum)
% TODO: Complete and comment 
sumPos([],0).

sumPos([H|T], S) :-
    H #> 0,
    sumPos(T, ST), 
    S #= H+ST.
sumPos([H|T], S) :-
    H #< 0,
    sumPos(T,S).

% duplicate(List, DuplicatedList)
% TODO: Complete and comment 
duplicate([], []).
duplicate([X|T],[X,X|Restl]) :-
    duplicate(T, Restl).
