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

        public void AnalyzeFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            OperatorCount = new Dictionary<string, int>();
            OperandCount = new Dictionary<string, int>();

            foreach (string line in lines)
            {
                // Регулярное выражение для операторов Scala
                MatchCollection operatorMatches = Regex.Matches(line,
                    @"(\+|\-|\*|\/|\%|\=\=|\!\=|\>|\<|\>=|\<=|\&&|\|\||!|::|\<\-|\>\>|\<\<|\+=|\-=|\*=|/=|\&|\||\^|\~|\=\>|\:\:|\#|\-\>)");

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

                // Регулярное выражение для операндов Scala
                MatchCollection operandMatches = Regex.Matches(line, @"([a-zA-Z_\$][a-zA-Z0-9_\$]*)");

                foreach (Match match in operandMatches)
                {
                    string operand = match.Value;
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

            // Вычисление метрик программы
            int uniqueOperatorCount = OperatorCount.Count;
            int uniqueOperandCount = OperandCount.Count;
            int totalOperatorCount = OperatorCount.Values.Sum();
            int totalOperandCount = OperandCount.Values.Sum();
            ProgramLength = totalOperatorCount + totalOperandCount;
            ProgramVocabulary = uniqueOperatorCount + uniqueOperandCount;
            ProgramVolume = ProgramLength * (Math.Log(ProgramVocabulary) / Math.Log(2));
        }
    }
}
