using System;
using System.Collections.Generic;
using System.IO;
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

                HashSet<string> uniqueOperators = new HashSet<string>();
                HashSet<string> uniqueOperands = new HashSet<string>();
                int totalOperatorCount = 0;
                int totalOperandCount = 0;

                foreach (string line in lines)
                {

                MatchCollection operatorMatches = Regex.Matches(line,
         @"(\+|\-|\*|\/|\%|\=\=|\!\=|\>|\<|\>=|\<=|\&&|\|\||!|::|\<\-|\>\>|\<\<|\+=|\-=|\*=|/=|\&|\||\^|\~|\=\>|\:\:|\#|\-\>)");
                foreach (Match match in operatorMatches)
                    {
                        uniqueOperators.Add(match.Value); 
                    }
                    totalOperatorCount += operatorMatches.Count;

                MatchCollection operandMatches = Regex.Matches(line, @"([a-zA-Z_\$][a-zA-Z0-9_\$]*)");
                foreach (Match match in operandMatches)
                    {
                        uniqueOperands.Add(match.Value); 
                    }
                    totalOperandCount += operandMatches.Count;
                }

                int uniqueOperatorCount = uniqueOperators.Count;
                int uniqueOperandCount = uniqueOperands.Count;

                tBoxResult.Text = $"Unique Operators: {uniqueOperatorCount}\n" +
                                  $"Unique Operands: {uniqueOperandCount}\n" +
                                  $"Total Operators: {totalOperatorCount}\n" +
                                  $"Total Operands: {totalOperandCount}\n" +
                                  $"Program Length: {totalOperatorCount + totalOperandCount}\n" +
                                  $"Program Vocabulary: {uniqueOperatorCount + uniqueOperandCount}\n" +
                                  $"Program Volume: {(totalOperatorCount + totalOperandCount) * (Math.Log(uniqueOperatorCount + uniqueOperandCount) / Math.Log(2))}\n";

        }

        public void startBtn_Click(object sender, EventArgs e)
        {
            var fileName = filePath;
            AnalyzeFile(fileName);
        }
    }
}
