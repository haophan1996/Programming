:- use_module(library(lists)).
% Template for logic puzzle solver: (c) David Matuszek (UPenn)
% Puzzle: (c) Brainzilla
%
% Puzzle adapted from https://www.brainzilla.com/logic/logic-grid/superheroes/
% There are three children: Bryan, Sean, and Tony.
% The children are all different ages, 6, 8, and 10, and they all have different
% favorite superheros.
%
% Using the following hints, identify how old each child is, and likes which superhero.
% 
% 1. Bryan likes superman
% 2. Tony doesn't like superman
% 3. The youngest kid likes superman
% 4. The kid who likes superman is 8.

child(bryan).
child(sean).
child(tony).

superhero(batman).
superhero(spiderman).
superhero(superman).

age(six).
age(eight).
age(ten).

solve :-
    % Setup variables for children's ages
    age(BryanAge), age(SeanAge), age(TonyAge),

    % Every child's age is unique (and thus makes a set)
    is_set([BryanAge, SeanAge, TonyAge]),

    % Setup variables for children's preferences
    superhero(BryanSuperhero), superhero(SeanSuperhero), superhero(TonySuperhero),
    
    % Every child's preference is different
    is_set([BryanSuperhero, SeanSuperhero, TonySuperhero]),

    % Construct valid assignments
    Triples = [ [bryan, BryanAge, BryanSuperhero],
                [sean, SeanAge, SeanSuperhero],
                [tony, TonyAge, TonySuperhero] ],

    % Setup rules

    % 1. Bryan likes spiderman
    member([bryan, _, spiderman], Triples),

    % 2. Tony doesn't like superman, meaning tony likes either spiderman or batman
    (
        member([tony, _, spiderman], Triples);
        member([tony, _, batman], Triples)
    ),

    % 3. The youngest kid likes Spiderman
    member([_, six, spiderman], Triples),
    
    % 4. The kid who likes Superman is 8
    member([_, eight, superman], Triples),
    
    % Output results
    tell(bryan, BryanAge, BryanSuperhero),
    tell(sean, SeanAge, SeanSuperhero),
    tell(tony, TonyAge, TonySuperhero).


% Helper function to print the results
tell(C, A, S) :-
    write(C), write(' ('), write(A),
    write(' years old) likes '), write(S), write('.'), nl.

