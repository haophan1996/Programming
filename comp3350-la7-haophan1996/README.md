# README

## Introduction to Lab Assignment 7

This assignment is designed to give you practice in working with basic knowledge bases in Prolog.

- Due: End of Day
- Deliverables: Commit and push to Github. Submit to Gradescope.

## Part A

In this assignment, we will have a knowledge base of various animal facts. You task is to complete a few additional rules (see TODO). There are no unit tests for this assignment; just visual inspection.

Run the following command:

    swipl parta.prolog

This will present a prompt to you:

    Welcome to SWI-Prolog.

    1 ?-

The last line is SWI-prolog's prompt. Type the following command:

    mammal(X).

Prolog will tell you that dog is a mammal:

    X = dog .

At this point, if you hit the space key, it will present you with more answers:

    X = dog ;
    X = cat ;
    X = rat.

To exit the prompt, type `halt.`

For this assignment, you task is to complete the following rules:

### inwater/1

All fish live in the water. If this is properly completed, this is what you should see:

    ?- inwater(X).
    X = shark.


### warblooded/1

A warm blooded animal is either a mammal or a bird. If this is completed, this is what you should see:

    X = dog ;
    X = cat ;
    X = rat ;
    X = pigeon ;
    X = owl.

### eats/2

Owl eats any small mammal. You should get this:

    X = rat.

## Part B

In this assignment, we will have a knowledge base of students and professors and their classes. The supplied knowledge base will have facts about
students, courses, and professors. Your task is to implement some predicates to get information.

Define the following predicates by writing a rule or rules for them. The examples and results use the facts given above the said rules.

To run the unit tests, run this command:

    swipl -t "[test_partb],  run_tests"

### Part B.1 professor/2

The professor predicate should take the arguments of `(Professor, Student)` and returns all students each professor teaches.

    ?- professor(alex, W).
    W = alice ;
    W = bob ;
    W = diana

### Part B.2 pupil/2

The pupil predicate should take the arguments of `(Student, Professor)` and returns all professors a student takes.

    ?- pupil(charlie, W).
    W = betty

### Part B.2 meets/2

The meets predicate returns two people if one person is a pupil/professor of the other, or two students take the same course.

## Part C

In this assignment, we will have a knowledge for students in classes. The supplied knowledge base will have facts about
students, courses, classrooms, and class times. Your task is to implement some predicates to get information.

Define the following predicates by writing a rule or rules for them. The examples and results use the facts given above the said rules.

To run the unit tests, run this command:

    swipl -t "[test_partc],  run_tests"

### Part C.1 occupied/2

The usage predicate should take the arguments of `(Classroom, Time)` and give all the times that a classroom is in use.

    ?- occupied(wilsn, T).
    T = t11 ;
    T = t13


### Part C.2 student_when/2

This predicate shows when a student has classes. For example, 

    ?- student_when(alice, T).
    T = t10 ;
    T = t11

The schedule predicate should take the arguments of `(student, classroom, time)`.

### Part C.3 student_when_where/3

This predicate shows when a student has classes, and where.

### Part C.4 student_same_course

This predicate checks if a student has signed up for two courses that occur at the same time.

### Part C.5 student_course_conflict/1

To complete this predicate, you should first complete `student_course_conflict/3`.

The `student_course_conflict/3` predicate should take the arguments of `(studentname, course1, course2)`. A conflict exists if student enrolls in two different courses, but the courses are scheduled for the same time.

The `student_course_conflict/1` predicate should display which student has a conflict, and should use the `student_course_conflict/3` predicate.

