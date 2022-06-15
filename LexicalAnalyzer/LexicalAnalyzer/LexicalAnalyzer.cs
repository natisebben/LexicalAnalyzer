using System;
using System.Collections.Generic;

namespace LexicalAnalyzer
{
    public class LexicalAnalyzer
    {
        public LexicalAnalyzer()
        {

        }

        public void Analyze(AnalyzerState state)
        {
            if (state.AnalyzeStream == null)
                return;

            state.WriteHeader();

            do
            {
                state.ReadNextLine();

                while (!state.EOF && state.ColumnIndex < state.CurrentLine.Length - 1)
                {
                    state.ReadNextChar();

                    var result = CheckToken(state);

                    if (result is null)
                    {
                        continue;
                    }
                    else
                    {
                        state.WriteTokenResult(result);
                        state.ResetCurrentToken();
                    }
                }

            } while (!state.EOF);

            state.WriteTokenResult(new Result(Token.EOF, string.Empty, state.LineIndex, state.ColumnIndex), true);
        }

        private Result CheckToken(AnalyzerState state)
        {
            switch (state.CurrentTokenType)
            {
                case TokenType.InitialSymbol:
                    return CheckInitialSymbolToken(state);

                case TokenType.Word:
                    return CheckWordToken(state);

                case TokenType.Number:
                    return CheckNumberToken(state);

                default:
                    return default;
            }
        }

        private Result CheckInitialSymbolToken(AnalyzerState state)
        {
            if (state.CurrentChar == ' ' || 
                state.CurrentChar == '\t' || 
                state.CurrentChar == '\n')
            {
                state.ResetCurrentToken();
                return default;
            }
            else if (char.IsLetter(state.CurrentChar) ||
                     state.CurrentChar == '_')
            {
                state.DefineTokenType(TokenType.Word);
                return default;
            }
            else if (char.IsDigit(state.CurrentChar))
            {
                state.DefineTokenType(TokenType.Number);
                return default;
            }
            else
            {
                return CheckSymbolToken(state);
            }
        }

        private Result CheckSymbolToken(AnalyzerState state)
        {
            switch (state.CurrentChar)
            {
                case '(':
                    return GetTokenResult(state, Token.PARENTHESISOPEN);
                case ')':
                    return GetTokenResult(state, Token.PARENTHESISCLOSE);
                case '[':
                    return GetTokenResult(state, Token.BRACKETOPEN);
                case ']':
                    return GetTokenResult(state, Token.BRACKETCLOSE);
                case '{':
                    return GetTokenResult(state, Token.BRACEOPEN);
                case '}':
                    return GetTokenResult(state, Token.BRACECLOSE);
                case ';':
                    return GetTokenResult(state, Token.SEMICOLLON);
                case ',':
                    return GetTokenResult(state, Token.COMMA);
                case '~':
                    return GetTokenResult(state, Token.NEGATE);
                case '^':
                    return GetTokenResult(state, Token.XOR);
                case ':':
                    return GetTokenResult(state, Token.COLLON);
                case '.':
                    return GetTokenResult(state, Token.DOT);
                case '=':
                    return GetInitialSymbolTokenResultCheckingPossibilities(
                        state,
                        Token.ASSIGN,
                        new List<Token> { Token.EQUALS });
                case '!':
                    return GetInitialSymbolTokenResultCheckingPossibilities(
                        state,
                        Token.LOGICALNOT,
                        new List<Token> { Token.NOTEQUALS });
                case '>':
                    return GetInitialSymbolTokenResultCheckingPossibilities(
                        state,
                        Token.GREATER,
                        new List<Token> { Token.GREATEROREQUAL, Token.SHIFTRIGHT });
                case '<':
                    return GetInitialSymbolTokenResultCheckingPossibilities(
                        state,
                        Token.LESS,
                        new List<Token> { Token.LESSOREQUAL, Token.SHIFTLEFT });
                case '+':
                    return GetInitialSymbolTokenResultCheckingPossibilities(
                        state,
                        Token.PLUS,
                        new List<Token> { Token.PLUSASSIGN, Token.INCREMENT });
                case '-':
                    return GetInitialSymbolTokenResultCheckingPossibilities(
                        state,
                        Token.MINUS,
                        new List<Token> { Token.MINUSASSIGN, Token.DECREMENT, Token.STRUCTACCESSOR });
                case '/':
                    return GetInitialSymbolTokenResultCheckingPossibilities(
                        state,
                        Token.DIVISION,
                        new List<Token> { Token.DIVISIONASSIGN });
                case '*':
                    return GetInitialSymbolTokenResultCheckingPossibilities(
                        state,
                        Token.PRODUCT,
                        new List<Token> { Token.PRODUCTASSIGN });
                case '%':
                    return GetInitialSymbolTokenResultCheckingPossibilities(
                        state,
                        Token.MODULE,
                        new List<Token> { Token.MODULEASSIGN });
                case '|':
                    return GetInitialSymbolTokenResultCheckingPossibilities(
                        state,
                        Token.OR,
                        new List<Token> { Token.LOGICALOR });
                case '&':
                    return GetInitialSymbolTokenResultCheckingPossibilities(
                        state,
                        Token.AND,
                        new List<Token> { Token.LOGICALAND });
                default:
                    return default;
            }
        }

        private Result CheckWordToken(AnalyzerState state)
        {
            if (char.IsLetter(state.CurrentChar) ||
                state.CurrentChar == '_' || 
                char.IsDigit(state.CurrentChar))
            {
                return default;
            }
            else
            {
                state.UnreadLastChar();
                state.DefineTokenType(TokenType.InitialSymbol);

                if (Enum.IsDefined(typeof(Token), state.CurrentToken.ToUpper()))
                {
                    return GetTokenResult(state, (Token)Enum.Parse(typeof(Token), state.CurrentToken.ToUpper()));
                }
                else
                {
                    return GetTokenResult(state, Token.IDENTIFIER);
                }
            }
        }

        private Result CheckNumberToken(AnalyzerState state)
        {
            if (char.IsDigit(state.CurrentChar))
            {
                return default;
            }
            else if (state.CurrentChar == '.')
            {
                if (!state.HasPoint)
                {
                    state.TokenNumberWithPoint(true);
                    return default;
                }
                else
                {
                    state.DefineTokenType(TokenType.InitialSymbol);

                    return GetTokenResult(state, Token.LEXICALERROR);
                }
            }
            else
            {
                state.UnreadLastChar();
                state.DefineTokenType(TokenType.InitialSymbol);
                state.TokenNumberWithPoint(false);

                var token =
                    int.TryParse(state.CurrentToken, out _) ? Token.INTEGERCONSTANT :
                    float.TryParse(state.CurrentToken, out _) ? Token.FLOATINGPOINTCONSTANT :
                    Token.LEXICALERROR;

                return GetTokenResult(state, token);
            }
        }

        private Result GetInitialSymbolTokenResultCheckingPossibilities(AnalyzerState state, Token originalToken, List<Token> possibleTokens)
        {
            foreach (var possibleToken in possibleTokens)
            {
                state.ReadNextChar();

                if (state.CurrentToken == possibleToken.GetEnumDisplayName())
                    return GetTokenResult(state, possibleToken);

                state.UnreadLastChar();
            }
            return GetTokenResult(state, originalToken);
        }

        private Result GetTokenResult(AnalyzerState state, Token token)
        {
            var result = new Result(token, state.CurrentToken, state.LineIndex, state.ColumnIndex);
            state.ResetCurrentToken();
            return result;
        }
    }
}
