grammar C3pp;

// --- 規則 ---
prog: statement+ ;

statement
    : expression ';'                # ExprStmt
    | assignment ';'                # AssignStmt
    ;

assignment
    : IDENTIFIER '=' expression ;

expression
    : expression op=('*'|'/') expression    # MulDiv
    | expression op=('+'|'-') expression    # AddSub
    | '(' expression ')'                    # Paren
    | NUMBER                                # NumberLiteral
    | IDENTIFIER                            # Variable
    ;

// --- 詞法 ---
NUMBER : [0-9]+ ('.' [0-9]+)? ;
IDENTIFIER : [a-zA-Z_] [a-zA-Z0-9_]* ;
WS : [ \t\r\n]+ -> skip ;