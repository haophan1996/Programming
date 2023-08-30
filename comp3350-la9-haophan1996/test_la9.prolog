:- begin_tests(la9).
:- consult(la9).

test(solveAge) :-
    solveAge(D, P),
    assertion(D == 80),
    assertion(P == 44).

test(solveCoins) :-
    solveCoins(Q, N),
    assertion(N == 15),
    assertion(Q == 9).

test(pytha345) :-
    pythaTriple(3, 4, Z), assertion(Z == 5).

test(pytha81517) :-
    pythaTriple(8, 15, Z), assertion(Z == 17).

test(pytha8YZ) :-
    pythaTriple(8, Y, Z), assertion([Y,Z] == [15, 17]).

test(pytha8YZ) :-
    pythaTriple(8, Y, Z), assertion([Y,Z] == [15, 17]).

test(pytha7YZ) :-
    pythaTriple(7, Y, Z), assertion([Y,Z] == [24, 25]).

test(pytha20YZ) :-
    pythaTriple(20, Y, Z), assertion([Y,Z] == [21, 29]).

% Part B.1 Diagonal
test(diag1) :-
    R1 = [11, 12, 13],
    R2 = [21, 22, 23],
    R3 = [31, 32, 33],
    setof(D2, diagonal(R1, R2, R3, _, D2), D2s),
    setof(D1, diagonal(R1, R2, R3, D1, _), D1s),
    assertion(D1s == [[11, 22, 33]]),
    assertion(D2s == [[13, 22, 31]]).

% Part B.2 Magic Square
test(magic1) :-
    once(magicSquare([[8, 1, 6], [3, 5, 7], [4, 9, C33]])),
    assertion(C33 == 2).

test(magic2) :-
    once(magicSquare([[2, 7, 6], [9, C22, 1], [4, 3, C33]])),
    assertion(C22 == 5),
    assertion(C33 == 8).

:- end_tests(la9).
