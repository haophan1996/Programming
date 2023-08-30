:- begin_tests(partc).
:- consult(partc).

% Dobbs should be used at times t10, t13, t11 (in any order)
test(occupied_dobbs) :-
    setof(T, occupied(dobbs, T), Ts),
    % Returns true if Ts contains t10, t11, t13 in any order
    assertion(permutation(Ts, [t10, t11, t13])).

% Alice should have classes at t10 and t11
test(when_classes_alice) :-
    setof(T, student_when(alice, T), Ts),
    assertion(permutation(Ts, [t10, t11])).

% Charles should have two classes at t13
test(when_classes_charles) :-
    bagof(T, student_when(charles, T), Ts),
    assertion(permutation(Ts, [t13, t13])).

% Alice should have classes in dobbs (t10) and wilson (t11)
test(when_where_alice) :-
    setof(T, student_when_where(alice, dobbs, T), Td),
    assertion(Td = [t10]),
    setof(T, student_when_where(alice, wilsn, T), Tw),
    assertion(Tw = [t11]).

% Only charles has a course conflict
test(charles_conflict) :-
    setof(S, student_course_conflict(S), Ss),
    assertion(Ss = [charles]).

% Only charles has a course conflict
test(charles_conflict_list) :-
    once(student_course_conflict(charles, C1, C2)),
    list_to_set([C1, C2], Cs),
    assertion(permutation(Cs, [data, parallel])).

% Bob and Charles should have same courses
test(bob_charles_same_course1) :-
    once(students_same_course(bob, S2)),
    assertion(S2 = charles).

% Bob and Charles should have same courses (in reverse)
test(bob_charles_same_course2) :-
    once(students_same_course(charles, S2)),
    assertion(S2 = bob).

:- end_tests(partc).
