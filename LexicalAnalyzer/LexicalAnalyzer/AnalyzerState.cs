using System.IO;

namespace LexicalAnalyzer
{
    public class AnalyzerState
    {
        public bool EOF { get; private set; }
        public bool HasPoint { get; private set; }
        public char CurrentChar { get; private set; }
        public string CurrentLine { get; private set; }
        public int LineIndex { get; private set; }
        public int ColumnIndex { get; private set; }
        public string CurrentToken { get; private set; }
        public TokenType CurrentTokenType { get; private set; }
        public StreamReader AnalyzeStream { get; private set; }
        public StreamWriter ResultStream { get; private set; }

        public AnalyzerState(StreamReader inputStream, StreamWriter outputStream)
        {
            EOF = false;
            HasPoint = false;
            CurrentChar = default;
            CurrentLine = string.Empty;
            LineIndex = -1;
            ColumnIndex = -1;
            CurrentToken = string.Empty;
            CurrentTokenType = TokenType.InitialSymbol;
            AnalyzeStream = inputStream;
            ResultStream = outputStream;
        }

        public void ReadNextLine()
        {
            CurrentLine = AnalyzeStream.ReadLine();
            EOF = (CurrentLine is null);
            CurrentLine += '\n';
            ColumnIndex = -1;
            LineIndex++;
        }

        public void ReadNextChar()
        {
            ColumnIndex++;
            CurrentChar = CurrentLine[ColumnIndex];
            CurrentToken += CurrentChar;
        }

        public void UnreadLastChar()
        {
            ColumnIndex--;
            CurrentChar = CurrentLine[ColumnIndex];
            CurrentToken = CurrentToken[0..^1];
        }

        public void ResetCurrentToken()
        {
            CurrentToken = string.Empty;
            CurrentChar = default;
        }

        public void WriteTokenResult(Result result, bool closeFiles = false)
        {
            ResultStream.WriteLine(result);
            if (closeFiles)
            {
                AnalyzeStream.Close();
                ResultStream.Close();
            }
        }

        public void WriteHeader()
        {
            ResultStream.WriteLine(Result.GetResultHeader());
        }


        public void DefineTokenType(TokenType tokenType)
        {
            CurrentTokenType = tokenType;
        }

        public void TokenNumberWithPoint(bool hasPoint)
        {
            HasPoint = hasPoint;
        }
    }
}