:- begin_tests(parta).
:- consult(parta).

% Part A All Same
test(allSame_11) :-
    assertion( allSame([11]) ).

test(allSame_11_11_11) :-
    assertion(allSame([11, 11, 11])).

test(allSame_11_11_11_11_11) :-
    assertion(allSame([11, 11, 11, 11, 11])).

test(allSame_e) :-
    assertion(allSame([])).

test(allSame_11_12) :-
    % allSame should *not* return true
    assertion( \+ allSame([11, 12]) ).

test(allSame_11_11_12) :-
    % allSame should *not* return true
    assertion( \+ allSame([11, 11, 12]) ).

test(allSame_11_12_11) :-
    % allSame should *not* return true
    assertion( \+ allSame([11, 12, 11]) ).

test(allSame_11_11_11_12_11) :-
    % allSame should *not* return true
    assertion( \+ allSame([11, 11, 11, 12, 11]) ).

% Part B: Insertion Sort

test(insert_11_i9) :-
    setof(L, insert([11], 9, L), Ls),
    assertion(Ls == [[9, 11]]).

test(insert_11_i13) :-
    once(insert([11], 13, L)),
    assertion(L == [11, 13]).

test(insert_11_14_i13) :-
    once(insert([11, 14], 13, L)),
    assertion(L == [11, 13, 14]).

test(insertionSort_11_i9) :-
    setof(L, insertionSort([11], L),Ls),
    assertion(Ls == [[11]]).

test(insertionSort_11_9_i9) :-
    setof(L, insertionSort([11, 9], L),Ls),
    assertion(Ls == [[9, 11]]).

% Part C: Reverse

test(reverse_11) :-
    setof(L, reverse([11], L),Ls),
    assertion(Ls == [[11]]).

test(reverse_11_12) :-
    setof(L, reverse([11, 12], L),Ls),
    assertion(Ls == [[12, 11]]).

test(reverse_11_12_13_14) :-
    setof(L, reverse([11, 12, 13, 14], L),Ls),
    assertion(Ls == [[14, 13, 12, 11]]).

test(reverse_11_11_14_14) :-
    setof(L, reverse([11, 11, 14, 14], L),Ls),
    assertion(Ls == [[14, 14, 11, 11]]).


test(reverse_e) :-
    setof(L, reverse([], L),Ls),
    assertion(Ls == [[]]).

% Part D: getIdx

test(getIdx_11_0) :-
    setof(X, getIdx([11], 0, X), Xs),
    assertion(Xs == [11]).

test(getIdx_11_1) :-
    % Out of bounds should *never* return true
    assertion( \+ getIdx([11], 1, _) ).

test(getIdx_11_12_13_0) :-
    setof(X, getIdx([11, 12, 13], 0, X), Xs),
    assertion(Xs == [11]).

test(getIdx_11_12_13_1) :-
    setof(X, getIdx([11, 12, 13], 1, X), Xs),
    assertion(Xs == [12]).

test(getIdx_11_12_13_2) :-
    setof(X, getIdx([11, 12, 13], 2, X), Xs),
    assertion(Xs == [13]).

test(getIdx_11_12_13_3) :-
    % Out of bounds should *never* return true
    assertion( \+ getIdx([11, 12, 13], 3, _) ).

test(getIdx_11_1) :-
    % Out of bounds should *never* return true
    assertion( \+ getIdx([11], 1, _) ).

test(getIdx_11_n1) :-
    % Out of bounds should *never* return true
    assertion( \+ getIdx([11], -1, _) ).



:- end_tests(parta).
