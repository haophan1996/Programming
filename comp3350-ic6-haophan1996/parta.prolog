:- use_module(library(lists)).

% Template for logic puzzle solver: (c) David Matuszek (UPenn)
% Puzzle: (c) Brainzilla
%
% Puzzle adapted from https://www.brainzilla.com/logic/logic-grid/basic-2/
%
% There are three children: Angela, Lisa, and Susan.
% The children have different pets: a cat, a dog, and a fish, and they all have different
% favorite colors: red, green, blue.
%
% Using the following hints, identify the pet and favorite colors.
% 
% 1. Lisa has a fish
% 2. Susan's favorite color is red
% 3. The kid who likes green also has a dog
% 4. Lisa's favorite color is not green

% TODO: List facts
child(lisa).
child(susan).
child(angela).

pet(cat).
pet(dog).
pet(fish).

color(red).
color(green).
color(blue).
% TODO: Specify rules
solve :-
    %The children have different pets:
    pet(LisaPet), pet(SusanPet), pet(AngelaPet),

    % Every child's pet is different
    is_set([LisaPet, SusanPet, AngelaPet]),

    % The children have different favorite colors:
    color(LisaColor), color(SusanColor), color(AngelaColor),

    % Set color
    is_set([LisaColor, SusanColor, AngelaColor]),

    % Construct valid assignments
    Triples = [ [lisa, LisaColor, LisaPet], 
        [angela, AngelaColor, AngelaPet],
        [susan, SusanColor, SusanPet] ],

    % Setup rules

    % 1. Lisa has a fish
    member([lisa, _, fish], Triples),

    % 2. Susan's favorite color is red
    member([susan, red, _], Triples),

    % 3. The kid who likes green also has a dog
    member([_, green, dog], Triples),

    % 4. Lisa's favorite color is not green
    (
        member([lisa, red, _], Triples);
        member([lisa, blue, _], Triples)    
    ),

    %output results
    tell(lisa, LisaColor, LisaPet),
    tell(angela, AngelaColor, AngelaPet),
    tell(susan, SusanColor, SusanPet).

% Helper function to print the results
tell(N, C, P) :-
    write(N), write(' favorite color is '), write(C),
    write(' and has a '), write(P), write('.'), nl.

