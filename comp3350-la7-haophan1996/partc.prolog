% This file describes course assignments

% Time assignments (course#, start_time)
classtime(cs1, t10).
classtime(cs2, t11).
classtime(data, t13).
classtime(proglang, t11).
classtime(parallel, t13).

% Room assignments (course#, room#)
where(cs1, dobbs).
where(cs2, wilsn).
where(data, dobbs).
where(proglang, dobbs).
where(parallel, wilsn).

% Student enrollments (person, course#)
enroll(alice, cs1).
enroll(alice, cs2).
enroll(bob, data).
enroll(charles, data).
enroll(charles, parallel).
enroll(diane, proglang).
enroll(diane, parallel).

%! occupied(?Classroom, ?Time)
% TODO: Which time a classroom is occupied
occupied(Classroom, Time) :- where(X, Classroom), classtime(X, Time).

%! student_when(?Student, ?Time)
% TODO: When a student is supposed to take classes 
student_when(Student, Time) :- enroll(Student, X), classtime(X,Time).

%! student_when_where(?Student, ?Classroom, ?Time).
% TODO: When a student has classes, in which room 
student_when_where(Student, Classroom, Time) :-
    enroll(Student, X), where(X, Classroom), classtime(X, Time).

%! students_same_course(?Student1, ?Student2)
% TODO: Checks if a student has signed up for two courses that
% occur at the same time. 
students_same_course(Student1, Student2) :-
    enroll(Student1, X), enroll(Student2, X),Student1 \= Student2.

%! student_course_conflict(?Student)
% TODO: Checks if a student has signed up for any two courses that
% occur at the same time.
% student_course_conflict(charles).
% data, parallel
student_course_conflict(Student) :-  
    enroll(Student, Course1), enroll(Student, Course2), 
    Course1 \= Course2,
    classtime(Course1, Time1),
    classtime(Course2, Time2),
    Time1 == Time2.

%! student_course_conflict(?Student, ?Course1, ?Course2)
% TODO: Checks if a student has signed up for two courses that
% occur at the same time.
student_course_conflict(Student, Course1, Course2) :-
    enroll(Student, Course1), enroll(Student, Course2),
    Course1 \== Course2,  
    classtime(Course1, Time1),
    classtime(Course2, Time2),
    Time1 == Time2. 
