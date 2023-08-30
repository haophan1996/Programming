:- begin_tests(partb).
:- consult(partb).

% Professor alex should be with alice bob, diana
test(professor_alex) :-
    setof(T, professor(alex, T), Ts),
    assertion(permutation(Ts, [alice, bob, diana])).

% Professor betty should be with bob, charlie, diana
test(professor_betty) :-
    setof(T, professor(betty, T), Ts),
    assertion(permutation(Ts, [bob, charlie, diana])).

% charlie should be pupil of diana
test(pupil_charlie) :-
    once(pupil(charlie, Prof)),
    assertion(Prof = betty).

% betty meets all her students
test(meets_betty) :-
    setof(T, meets(betty, T), Ts),
    assertion(permutation(Ts, [bob, charlie, diana])).

% charlie meets his professor and several other students
test(meets_charlie) :-
    setof(T, meets(charlie, T), Ts),
    assertion(permutation(Ts, [bob, diana, betty])).

:- end_tests(partb).
