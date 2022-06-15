using System;
using System.IO;

namespace LexicalAnalyzer
{
    public class Program
    {
        static void Main(string[] args)
        {
            using var input = new StreamReader(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"sourcecodetest.txt"));

            using var resultFile = File.CreateText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{DateTime.Now:yyyyMMddhhmmss}.lexi"));

            var lexicalAnalyser = new LexicalAnalyzer();

            lexicalAnalyser.Analyze(new AnalyzerState(input, resultFile));
        }
    }
}