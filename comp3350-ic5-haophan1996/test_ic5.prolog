:- begin_tests(ic5).
:- consult(ic5).

% List Length tests
test(len_11) :-
    setof(L, listLen([11], L), Ls),
    assertion(Ls == [1]).

test(len_11_12_13) :-
    setof(L, listLen([11, 12, 13], L), Ls),
    assertion(Ls == [3]).

test(len_e) :-
    setof(L, listLen([], L), Ls),
    assertion(Ls == [0]).

% Last Tests
test(last_11) :-
    setof(L, last([11], L), Ls),
    assertion(Ls == [11]).

test(last_11_12_13) :-
    setof(L, last([11, 12, 13], L), Ls),
    assertion(Ls == [13]).

% Sum positive numbers test
test(sum_pos_11) :-
    setof(S, sumPos([11], S), Ss),
    assertion(Ss == [11]).

test(sum_pos_n9) :-
    setof(S, sumPos([-9], S), Ss),
    assertion(Ss == [0]).

test(sum_pos_11_13_15) :-
    setof(S, sumPos([11, 13, 15], S), Ss),
    assertion(Ss == [39]).

test(sum_pos_11_13_n9) :-
    setof(S, sumPos([11, 13, -9], S), Ss),
    assertion(Ss == [24]).

test(sum_pos_11_n9_13) :-
    setof(S, sumPos([11, -9, 13], S), Ss),
    assertion(Ss == [24]).

% Duplicate tests
test(dup_11) :-
    setof(L, duplicate([11], L), Ls),
    assertion(Ls == [[11, 11]]).

test(dup_e) :-
    setof(L, duplicate([], L), Ls),
    assertion(Ls == [[]]).

test(dup_11_12_13) :-
    setof(L, duplicate([11, 12, 13], L), Ls),
    assertion(Ls == [[11, 11, 12, 12, 13, 13]]).

:- end_tests(ic5).
