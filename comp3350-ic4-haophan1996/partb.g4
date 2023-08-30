grammar partb;

// Scanner rules
WS: [ \n\t\r]+ -> skip;
INT_NUMBER : [1-9][0-9]* ;
ADD_OP: [-+];
MUL_OP: [*/];
// EOF: built-in token that represents the end of input. Similar to regex's `$`

// Parser rules
expr: addExpr EOF;
// TODO: Add mulExpr rule
addExpr: INT_NUMBER | addExpr ADD_OP INT_NUMBER | addExpr MUL_OP INT_NUMBER;
