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
            "object", "def", "val", "Unit", "String", "Int", "Array" // Добавьте сюда другие зарезервированные слова и типы
        };

        public void AnalyzeFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            OperatorCount = new Dictionary<string, int>();
            OperandCount = new Dictionary<string, int>();

            var functionCalls = new HashSet<string>();

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

                // Регулярное выражение для операндов
                MatchCollection operandMatches = Regex.Matches(line, @"\b[a-zA-Z_\$][a-zA-Z0-9_\$]*\b");

                foreach (Match match in operandMatches)
                {
                    string operand = match.Value;
                    // Проверяем, что это не функция или зарезервированное слово
                    if (!functionCalls.Contains(operand) &&
                        !ReservedWords.Contains(operand) &&
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
