:- begin_tests(parta).
:- consult(parta).

% valid_box([1,2,1,2], [3,4,3,4]) returns true
test(valid_1212) :-
    assertion( valid_box([1,2,1,2], [3,4,3,4]) ).

% valid_box([3,4,3,4], [1,2,1,2]) returns true
test(valid_3412) :-
    assertion( valid_box([3,4,3,4], [1,2,1,2]) ).

% valid_box([3,1,1,4], [2,4,2,3]) returns true
test(valid_3412) :-
    assertion( valid_box([3,1,1,4], [2,4,2,3]) ).

% valid_box([1,2,3,4], [1,2,1,2]) returns true
test(valid_1234) :-
    assertion( \+ valid_box([1,2,3,4], [1,2,1,2]) ).

:- end_tests(parta).
