
%! This file describes various facts about animals.

% These are the categories of various animals
mammal(dog).
mammal(cat).
mammal(rat).
reptile(lizard).
reptile(snake).
fish(shark).
bird(pigeon).
bird(owl).

% These are the sizes of animals
small(rat).
small(lizard).
small(snake).
small(pigeon).

medium(dog).
medium(cat).
medium(owl).

% All of atoms are animals
animal(X) :- mammal(X).
animal(X) :- reptile(X).
animal(X) :- fish(X).
animal(X) :- bird(X).

% TODO: all fish live in the water
inwater(X) :- fish(X).

% TODO: all mammals and birds are warm blooded
warmblooded(X) :- mammal(X).
warmblooded(X) :- bird(X).

% TODO: Owl eats any small mammal
eats(owl, X) :- mammal(X),small(X).
