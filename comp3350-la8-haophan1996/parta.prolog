:- use_module(library(clpfd)).

% allSame(List)
% TODO: Complete and comment 
allSame([]).
allSame([X]).
allSame([H,H|T]) :-
    allSame([H|T]).
    

% insert(Lin, X, Lout)
% TODO: Complete and comment 
% insert(Lin, X, Lout). 
insert([],X,[X]).
insert([H|T], X,L) :- 
    X #< H,
    L = [X,H|T].
insert([H|T],X,[H|L]) :-
    X #> H,
    insert(T,X,L).  
     

% insertionSort(L)
% TODO: Complete and comment 
% insertionSort(Lin, Lout).
% insertionSort([11, 9], L).
insertionSort([],[]).
insertionSort([X],[X]).
insertionSort([HA, HB|T], [HA,HB|L]):-
    HA #< HB,
    insertionSort(T, L).
insertionSort([HA, HB|T], [HB,HA|L]):-
    HA #> HB,
    insertionSort(T, L).


% reverse(Lin, Lout).
% TODO: Complete and comment 
% reverse([11, 12], L).
appendList(T, H, L) :- 
    append(T, [H], L).

reverse([], []).
reverse([X], [X]).
reverse([H|T], L):-
    reverse(T, R),     % Reverse the tail of the list and store it in R
    appendList(R, H, L).
    
     

% getIdx(L, I, X).
% TODO: Complete and comment 
getIdx([H | _], 0, H).

getIdx([_ | Tail], I, X) :-
    I #>= 0,
    NextI #= I - 1,
    getIdx(Tail, NextI, X).