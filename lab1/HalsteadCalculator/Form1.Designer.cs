using System.Drawing;
using System.IO;

namespace HalsteadCalculator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.srcBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.tBoxResult = new System.Windows.Forms.RichTextBox();
            this.dataGridViewOperators = new System.Windows.Forms.DataGridView();
            this.dataGridViewOperands = new System.Windows.Forms.DataGridView();
            this.CodeRichTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOperators)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOperands)).BeginInit();
            this.SuspendLayout();
            // 
            // srcBtn
            // 
            this.srcBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.srcBtn.Location = new System.Drawing.Point(591, 29);
            this.srcBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.srcBtn.Name = "srcBtn";
            this.srcBtn.Size = new System.Drawing.Size(466, 46);
            this.srcBtn.TabIndex = 11;
            this.srcBtn.Text = "Выбрать файл";
            this.srcBtn.UseVisualStyleBackColor = true;
            this.srcBtn.Click += new System.EventHandler(this.srcBtn_Click);
            // 
            // startBtn
            // 
            this.startBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startBtn.Location = new System.Drawing.Point(591, 118);
            this.startBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(466, 46);
            this.startBtn.TabIndex = 12;
            this.startBtn.Text = "Анализировать";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // tBoxResult
            // 
            this.tBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBoxResult.Location = new System.Drawing.Point(591, 198);
            this.tBoxResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tBoxResult.Name = "tBoxResult";
            this.tBoxResult.ReadOnly = true;
            this.tBoxResult.Size = new System.Drawing.Size(465, 221);
            this.tBoxResult.TabIndex = 14;
            this.tBoxResult.Text = "";
            // 
            // dataGridViewOperators
            // 
            this.dataGridViewOperators.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOperators.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOperators.Location = new System.Drawing.Point(16, 465);
            this.dataGridViewOperators.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewOperators.Name = "dataGridViewOperators";
            this.dataGridViewOperators.ReadOnly = true;
            this.dataGridViewOperators.RowHeadersWidth = 53;
            this.dataGridViewOperators.Size = new System.Drawing.Size(460, 320);
            this.dataGridViewOperators.TabIndex = 15;
            // 
            // dataGridViewOperands
            // 
            this.dataGridViewOperands.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOperands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOperands.Location = new System.Drawing.Point(591, 465);
            this.dataGridViewOperands.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewOperands.Name = "dataGridViewOperands";
            this.dataGridViewOperands.ReadOnly = true;
            this.dataGridViewOperands.RowHeadersWidth = 53;
            this.dataGridViewOperands.Size = new System.Drawing.Size(465, 320);
            this.dataGridViewOperands.TabIndex = 16;
            // 
            // CodeRichTextBox
            // 
            this.CodeRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CodeRichTextBox.Location = new System.Drawing.Point(16, 29);
            this.CodeRichTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CodeRichTextBox.Name = "CodeRichTextBox";
            this.CodeRichTextBox.ReadOnly = true;
            this.CodeRichTextBox.Size = new System.Drawing.Size(465, 390);
            this.CodeRichTextBox.TabIndex = 17;
            this.CodeRichTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 814);
            this.Controls.Add(this.CodeRichTextBox);
            this.Controls.Add(this.dataGridViewOperands);
            this.Controls.Add(this.dataGridViewOperators);
            this.Controls.Add(this.tBoxResult);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.srcBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOperators)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOperands)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button srcBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.RichTextBox tBoxResult;
        private System.Windows.Forms.DataGridView dataGridViewOperators;
        private System.Windows.Forms.DataGridView dataGridViewOperands;
        private System.Windows.Forms.RichTextBox CodeRichTextBox;
    }
}

