% This file describes students and professors

% Courses taken
studies(alice, cs1).
studies(bob, cs1).
studies(bob, data).
studies(charlie, data).
studies(charlie, parallel).
studies(diana, data).
studies(diana, prog).

% Courses teaching
teaches(alex, cs1).
teaches(alex, prog).
teaches(betty, data).
teaches(betty, parallel).

%! professor(?Prof, ?Student)
% TODO: If the professor teaches a course the student is taking
professor(X, Y) :- teaches(X, Cate), studies(Y, Cate).

%! pupil(?Student, ?Prof)
% TODO: If the student is taking a course the professor is teaching
% pupil(charlie, W).
pupil(X, Y) :- 
        studies(X,Cate), teaches(Y, Cate).
        

%! meets(?X, ?Y)
% meets(betty, T).
% Two people meet if X is Y's professor or X and Y study the same course
meets(X, Y) :- professor(X, Y).
meets(X, Y) :- professor(Y, X).
meets(X, Y) :- studies(X, Cate), studies(Y, Cate), X \= Y.

