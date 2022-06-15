using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LexicalAnalyzer
{
    public enum Token
    {
		[Display(Name = "Lexical Error")]
		[Description("Lexical Error")]
		LEXICALERROR = -1,

		[Display(Name = "EOF")]
		[Description("EOF")]
		EOF,

		[Display(Name = "Reserved Word")]
		[Description("Reserved Word")]
		RESERVEDWORD,

		[Display(Name = "Identifier")]
		[Description("Identifier")]
		IDENTIFIER,

		[Display(Name = "Integer Constant")]
		[Description("Integer Constant")]
		INTEGERCONSTANT,

		[Display(Name = "Floating Point Constant")]
		[Description("Floating Point Constant")]
		FLOATINGPOINTCONSTANT,

		[Display(Name = "+")]
		[Description("Plus")]
		PLUS,

		[Display(Name = "-")]
		[Description("Minus")]
		MINUS,

		[Display(Name = "*")]
		[Description("Product")]
		PRODUCT,

		[Display(Name = "/")]
		[Description("Division")]
		DIVISION,

		[Display(Name = "ˆ")]
		[Description("Power")]
		POWER,

		[Display(Name = "++")]
		[Description("Increment")]
		INCREMENT,

		[Display(Name = "--")]
		[Description("Decrement")]
		DECREMENT,

		[Display(Name = "%")]
		[Description("Module")]
		MODULE,

		[Display(Name = "==")]
		[Description("Equals")]
		EQUALS,

		[Display(Name = "!=")]
		[Description("Not Equals")]
		NOTEQUALS,

		[Display(Name = "<")]
		[Description("Less")]
		LESS,

		[Display(Name = ">")]
		[Description("Greater")]
		GREATER,

		[Display(Name = "<=")]
		[Description("Less Or Equal")]
		LESSOREQUAL,

		[Display(Name = ">=")]
		[Description("Greater Or Equal")]
		GREATEROREQUAL,

		[Display(Name = "&&")]
		[Description("LogicalAnd")]
		LOGICALAND,

		[Display(Name = "||")]
		[Description("Logical Or")]
		LOGICALOR,

		[Display(Name = "!")]
		[Description("Logical Not")]
		LOGICALNOT,

		[Display(Name = "<<")]
		[Description("Shift Left")]
		SHIFTLEFT,

		[Display(Name = ">>")]
		[Description("Shift Right")]
		SHIFTRIGHT,

		[Display(Name = "&")]
		[Description("And")]
		AND,

		[Display(Name = "|")]
		[Description("Or")]
		OR,

		[Display(Name = "=")]
		[Description("Assign")]
		ASSIGN,

		[Display(Name = "+=")]
		[Description("Plus Assign")]
		PLUSASSIGN,

		[Display(Name = "-=")]
		[Description("Minus Assign")]
		MINUSASSIGN,

		[Display(Name = "*=")]
		[Description("Product Assign")]
		PRODUCTASSIGN,

		[Display(Name = "/=")]
		[Description("Division Assign")]
		DIVISIONASSIGN,

		[Display(Name = "%=")]
		[Description("Module Assign")]
		MODULEASSIGN,

		[Display(Name = "for")]
		[Description("for")]
		FOR,

		[Display(Name = "do {} while")]
		[Description("do {} while")]
		DOWHILE,

		[Display(Name = "while")]
		[Description("while")]
		WHILE,

		[Display(Name = "if")]
		[Description("if")]
		IF,

		[Display(Name = "else if")]
		[Description("else if")]
		ELSEIF,

		[Display(Name = "else")]
		[Description("else")]
		ELSE,

		[Display(Name = "continue")]
		[Description("continue")]
		CONTINUE,

		[Display(Name = "break")]
		[Description("break")]
		BREAK,

		[Display(Name = "return")]
		[Description("return")]
		RETURN,

		[Display(Name = "switch")]
		[Description("switch")]
		SWITCH,

		[Display(Name = "case")]
		[Description("case")]
		CASE,

		[Display(Name = "default")]
		[Description("default")]
		DEFAULT,

		[Display(Name = "int")]
		[Description("int")]
		INT,

		[Display(Name = "char")]
		[Description("char")]
		CHAR,

		[Display(Name = "double")]
		[Description("double")]
		DOUBLE,

		[Display(Name = "float")]
		[Description("float")]
		FLOAT,

		[Display(Name = "struct")]
		[Description("struct")]
		STRUCT,

		[Display(Name = "void")]
		[Description("void")]
		VOID,

		[Display(Name = "->")]
		[Description("Struct Accessor")]
		STRUCTACCESSOR,

		[Display(Name = "_")]
		[Description("Underscore")]
		UNDERSCORE,

		[Display(Name = ".")]
		[Description("Dot")]
		DOT,

		[Display(Name = ",")]
		[Description("Comma")]
		COMMA,

		[Display(Name = ";")]
		[Description("Semi Collon")]
		SEMICOLLON,

		[Display(Name = ":")]
		[Description("Collon")]
		COLLON,

		[Display(Name = "(")]
		[Description("Parenthesis Open")]
		PARENTHESISOPEN,

		[Display(Name = ")")]
		[Description("Parenthesis Close")]
		PARENTHESISCLOSE,

		[Display(Name = "[")]
		[Description("Bracket Open")]
		BRACKETOPEN,

		[Display(Name = "]")]
		[Description("Bracket Close")]
		BRACKETCLOSE,

		[Display(Name = "{")]
		[Description("Brace Open")]
		BRACEOPEN,

		[Display(Name = "}")]
		[Description("Brace Close")]
		BRACECLOSE,

    }
}
