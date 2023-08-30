grammar parta;

// Scanner rules
WS: [ \n\t\r]+ -> skip;
INT_NUMBER : [1-9][0-9]* ;
ADD_OP: [-+];
// EOF: built-in token that represents the end of input. Similar to regex's `$`

// Parser rules
expr: addExpr EOF;
addExpr: INT_NUMBER | addExpr ADD_OP INT_NUMBER;
