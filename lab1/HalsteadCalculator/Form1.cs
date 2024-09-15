using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HalsteadCalculator
{
    public partial class Form1 : Form
    {
        public string filePath;
        public Form1()
        {
            InitializeComponent();
        }

        public void srcBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Scala Files|*.scala";
            openFileDialog.Title = "Выберите файл";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                startBtn.Enabled = true;
                filePath = openFileDialog.FileName;
            }
        }

        public void AnalyzeFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            Dictionary<string, int> operatorCount = new Dictionary<string, int>();
            Dictionary<string, int> operandCount = new Dictionary<string, int>();

            foreach (string line in lines)
            {
                // Регулярное выражение для всех операторов Scala
                MatchCollection operatorMatches = Regex.Matches(line,
                    @"(\+|\-|\*|\/|\%|\=\=|\!\=|\>|\<|\>=|\<=|\&&|\|\||!|::|\<\-|\>\>|\<\<|\+=|\-=|\*=|/=|\&|\||\^|\~|\=\>|\:\:|\#|\-\>)");

                foreach (Match match in operatorMatches)
                {
                    string op = match.Value;
                    if (operatorCount.ContainsKey(op))
                    {
                        operatorCount[op]++;
                    }
                    else
                    {
                        operatorCount[op] = 1;
                    }
                }

                // Регулярное выражение для операндов Scala (переменные)
                MatchCollection operandMatches = Regex.Matches(line, @"([a-zA-Z_\$][a-zA-Z0-9_\$]*)");

                foreach (Match match in operandMatches)
                {
                    string operand = match.Value;
                    if (operandCount.ContainsKey(operand))
                    {
                        operandCount[operand]++;
                    }
                    else
                    {
                        operandCount[operand] = 1;
                    }
                }
            }

            // Формируем статистику
            int uniqueOperatorCount = operatorCount.Count;
            int uniqueOperandCount = operandCount.Count;
            int totalOperatorCount = operatorCount.Values.Sum();
            int totalOperandCount = operandCount.Values.Sum();
            double programLength = totalOperatorCount + totalOperandCount;
            double programVocabulary = uniqueOperatorCount + uniqueOperandCount;
            double programVolume = programLength * (Math.Log(programVocabulary) / Math.Log(2));

            // Выводим статистику в текстовом поле
            tBoxResult.Text = $"Unique Operators: {uniqueOperatorCount}\n" +
                              $"Unique Operands: {uniqueOperandCount}\n" +
                              $"Total Operators: {totalOperatorCount}\n" +
                              $"Total Operands: {totalOperandCount}\n" +
                              $"Program Length: {programLength}\n" +
                              $"Program Vocabulary: {programVocabulary}\n" +
                              $"Program Volume: {programVolume}\n";

            // Очистка DataGridView перед заполнением
            dataGridViewOperators.Rows.Clear();
            dataGridViewOperands.Rows.Clear();

            // Заполняем DataGridView для операторов
            dataGridViewOperators.ColumnCount = 2;
            dataGridViewOperators.Columns[0].Name = "Operator";
            dataGridViewOperators.Columns[1].Name = "Count";
            foreach (var entry in operatorCount)
            {
                dataGridViewOperators.Rows.Add(entry.Key, entry.Value);
            }

            // Заполняем DataGridView для операндов
            dataGridViewOperands.ColumnCount = 2;
            dataGridViewOperands.Columns[0].Name = "Operand";
            dataGridViewOperands.Columns[1].Name = "Count";
            foreach (var entry in operandCount)
            {
                dataGridViewOperands.Rows.Add(entry.Key, entry.Value);
            }
        }



        public void startBtn_Click(object sender, EventArgs e)
        {
            var fileName = filePath;
            AnalyzeFile(fileName);
        }

        private void dataGridViewOperands_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
