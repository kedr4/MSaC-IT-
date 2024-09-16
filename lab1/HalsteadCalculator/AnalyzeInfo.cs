using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace HalsteadCalculator
{
    public class AnalyzeInfo
    {
        public Dictionary<string, int> OperatorCount { get; private set; }
        public Dictionary<string, int> OperandCount { get; private set; }
        public double ProgramLength { get; private set; }
        public double ProgramVocabulary { get; private set; }
        public double ProgramVolume { get; private set; }

        // Зарезервированные слова и типы для фильтрации
        private static readonly HashSet<string> ReservedWords = new HashSet<string>
        {
            "abstract", "case", "catch", "class", "def", "do", "else", "extends",
            "false", "final", "finally", "for", "forSome", "if", "implicit",
            "import", "lazy", "match", "new", "null", "object", "override",
            "package", "private", "protected", "return", "sealed", "super",
            "this", "throw", "trait", "try", "true", "type", "val", "var",
            "while", "with", "yield",

            "Any", "AnyRef", "AnyVal", "Boolean", "Byte", "Char", "Double",
            "Float", "Int", "Long", "Short", "String", "Unit", "Nothing",
            "Null", "Option", "Some", "None", "Either", "Left", "Right",
            "Seq", "List", "Array", "Map", "Set", "Tuple"
        };

        public void AnalyzeFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            OperatorCount = new Dictionary<string, int>();
            OperandCount = new Dictionary<string, int>();

            var functionCalls = new HashSet<string>();
            var methodsCalled = new HashSet<string>();

            foreach (string line in lines)
            {
                // Регулярное выражение для вызовов функций
                MatchCollection functionMatches = Regex.Matches(line,
                    @"\b[a-zA-Z_\$][a-zA-Z0-9_\$]*\s*\(");

                foreach (Match match in functionMatches)
                {
                    string functionCall = match.Value.TrimEnd('(');
                    functionCalls.Add(functionCall);
                    if (OperatorCount.ContainsKey(functionCall))
                    {
                        OperatorCount[functionCall]++;
                    }
                    else
                    {
                        OperatorCount[functionCall] = 1;
                    }
                }

                // Регулярное выражение для операторов
                MatchCollection operatorMatches = Regex.Matches(line,
                  @"(\+=|\-=|\*=|/=|==|\!=|\>=|\<=|\->|\=>|\|\||&&|::|<<|>>|\+|\-|\*|\/|\%|\=|\!|\>|\<|\&|\||\^|\~|\#)");

                foreach (Match match in operatorMatches)
                {
                    string op = match.Value;
                    if (OperatorCount.ContainsKey(op))
                    {
                        OperatorCount[op]++;
                    }
                    else
                    {
                        OperatorCount[op] = 1;
                    }
                }

                // Регулярное выражение для методов, вызванных через точку (например, .toInt)
                MatchCollection methodCallMatches = Regex.Matches(line, @"\.[a-zA-Z_\$][a-zA-Z0-9_\$]*\b");

                foreach (Match match in methodCallMatches)
                {
                    string methodCall = match.Value.TrimStart('.');
                    methodsCalled.Add(methodCall);  // Добавляем метод в список вызванных методов

                    if (OperatorCount.ContainsKey(methodCall))
                    {
                        OperatorCount[methodCall]++;
                    }
                    else
                    {
                        OperatorCount[methodCall] = 1;
                    }
                }

                // Регулярное выражение для операндов
                MatchCollection operandMatches = Regex.Matches(line, @"\b[a-zA-Z_\$][a-zA-Z0-9_\$]*\b");

                foreach (Match match in operandMatches)
                {
                    string operand = match.Value;
                    // Проверяем, что это не функция, не зарезервированное слово и не метод, вызванный через точку
                    if (!functionCalls.Contains(operand) &&
                        !ReservedWords.Contains(operand) &&
                        !methodsCalled.Contains(operand) && // Не добавляем методы, вызванные через точку, как операнды
                        !IsOutputLine(line)) // Проверяем, что это не строка вывода
                    {
                        if (OperandCount.ContainsKey(operand))
                        {
                            OperandCount[operand]++;
                        }
                        else
                        {
                            OperandCount[operand] = 1;
                        }
                    }
                }
            }

            // Вычисление метрик программы
            int uniqueOperatorCount = OperatorCount.Count;
            int uniqueOperandCount = OperandCount.Count;
            int totalOperatorCount = OperatorCount.Values.Sum();
            int totalOperandCount = OperandCount.Values.Sum();
            ProgramLength = totalOperatorCount + totalOperandCount;
            ProgramVocabulary = uniqueOperatorCount + uniqueOperandCount;
            ProgramVolume = ProgramLength * (Math.Log(ProgramVocabulary) / Math.Log(2));
        }


        // Метод для определения строк вывода
        private bool IsOutputLine(string line)
        {
            return line.Contains("println") || line.Contains("print");
        }
    }
}
