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
        private AnalyzeInfo analyzeInfo;

        public Form1()
        {
            InitializeComponent();
            analyzeInfo = new AnalyzeInfo();
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
                DisplayFileContent(filePath);
            }
        }

        private void DisplayFileContent(string filePath)
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

        private void DisplayResults()
        {
            // Выводим статистику в текстовом поле
            tBoxResult.Text = $"Unique Operators: {analyzeInfo.OperatorCount.Count}\n" +
                              $"Unique Operands: {analyzeInfo.OperandCount.Count}\n" +
                              $"Total Operators: {analyzeInfo.OperatorCount.Values.Sum()}\n" +
                              $"Total Operands: {analyzeInfo.OperandCount.Values.Sum()}\n" +
                              $"Program Length: {analyzeInfo.ProgramLength}\n" +
                              $"Program Vocabulary: {analyzeInfo.ProgramVocabulary}\n" +
                              $"Program Volume: {analyzeInfo.ProgramVolume}\n";

            // Очистка DataGridView перед заполнением
            dataGridViewOperators.Rows.Clear();
            dataGridViewOperands.Rows.Clear();

            // Добавляем столбцы для dataGridViewOperators
            dataGridViewOperators.ColumnCount = 2;
            dataGridViewOperators.Columns[0].Name = "Operator";
            dataGridViewOperators.Columns[1].Name = "Count";

            // Заполняем DataGridView для операторов
            foreach (var entry in analyzeInfo.OperatorCount)
            {
                dataGridViewOperators.Rows.Add(entry.Key, entry.Value);
            }

            // Добавляем столбцы для dataGridViewOperands
            dataGridViewOperands.ColumnCount = 2;
            dataGridViewOperands.Columns[0].Name = "Operand";
            dataGridViewOperands.Columns[1].Name = "Count";

            // Заполняем DataGridView для операндов
            foreach (var entry in analyzeInfo.OperandCount)
            {
                dataGridViewOperands.Rows.Add(entry.Key, entry.Value);
            }
        }

    }
}

