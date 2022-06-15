using System.Linq;
using System.Text;

namespace LexicalAnalyzer
{
    public class Result
    {
        const int SPACING_25 = 25;
        const int SPACING_20 = 20;
        const int SPACING_10 = 10;

        public Result(Token token, string lexical, int line, int finalColumn)
        {
            TokenType = token;
            Token = lexical;
            Line = line + 1;
            StartColumn = finalColumn + 1 - lexical.Length;
            FinalColumn = finalColumn + 1;
        }

        public Token TokenType { get; }
        public string Token { get; }
        public int Line { get; }
        public int StartColumn { get; }
        public int FinalColumn { get; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append($"{TokenType}{DefineSpacing(SPACING_25 - TokenType.ToString().Length)}");
            result.Append($"{Token}{DefineSpacing(SPACING_25 - Token.Length)}");
            result.Append($"{Line}{DefineSpacing(SPACING_10 - Line.ToString().Length)}");
            result.Append($"{StartColumn}{DefineSpacing(SPACING_20 - StartColumn.ToString().Length)}");
            result.Append($"{FinalColumn}{DefineSpacing(SPACING_20 - FinalColumn.ToString().Length)}");
            return result.ToString(); 
        }

        public static string GetResultHeader()
        {
            var resultHeader = new StringBuilder();

            var tokenTypeHeader = "Token Type: ";
            var tokenHeader = "Token: ";
            var lineHeader = "Line: ";
            var startColumnHeader = "Start Column: ";
            var finalColumnHeader = "Final Column: ";

            resultHeader.Append($"{tokenTypeHeader}{DefineSpacing(SPACING_25 - tokenTypeHeader.Length)}");
            resultHeader.Append($"{tokenHeader}{DefineSpacing(SPACING_25 - tokenHeader.Length)}");
            resultHeader.Append($"{lineHeader}{DefineSpacing(SPACING_10 - lineHeader.Length)}");
            resultHeader.Append($"{startColumnHeader}{DefineSpacing(SPACING_20 - startColumnHeader.Length)}");
            resultHeader.Append($"{finalColumnHeader}{DefineSpacing(SPACING_20 - finalColumnHeader.Length)}");

            return resultHeader.ToString();
        }

        private static string DefineSpacing(int fullSize) =>
            string.Join(string.Empty, Enumerable.Range(0, fullSize).Select(x => ' '));
    }
}
