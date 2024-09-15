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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOperators)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOperands)).BeginInit();
            this.SuspendLayout();
            // 
            // srcBtn
            // 
            this.srcBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.srcBtn.Location = new System.Drawing.Point(238, 26);
            this.srcBtn.Name = "srcBtn";
            this.srcBtn.Size = new System.Drawing.Size(330, 37);
            this.srcBtn.TabIndex = 11;
            this.srcBtn.Text = "Выбрать файл";
            this.srcBtn.UseVisualStyleBackColor = true;
            this.srcBtn.Click += new System.EventHandler(this.srcBtn_Click);
            // 
            // startBtn
            // 
            this.startBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startBtn.Location = new System.Drawing.Point(238, 98);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(330, 37);
            this.startBtn.TabIndex = 12;
            this.startBtn.Text = "Анализировать";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // tBoxResult
            // 
            this.tBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBoxResult.Location = new System.Drawing.Point(238, 163);
            this.tBoxResult.Name = "tBoxResult";
            this.tBoxResult.ReadOnly = true;
            this.tBoxResult.Size = new System.Drawing.Size(330, 180);
            this.tBoxResult.TabIndex = 14;
            this.tBoxResult.Text = "";
            // 
            // dataGridViewOperators
            // 
            this.dataGridViewOperators.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOperators.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOperators.Location = new System.Drawing.Point(12, 378);
            this.dataGridViewOperators.Name = "dataGridViewOperators";
            this.dataGridViewOperators.ReadOnly = true;
            this.dataGridViewOperators.Size = new System.Drawing.Size(345, 260);
            this.dataGridViewOperators.TabIndex = 15;
            // 
            // dataGridViewOperands
            // 
            this.dataGridViewOperands.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOperands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOperands.Location = new System.Drawing.Point(443, 378);
            this.dataGridViewOperands.Name = "dataGridViewOperands";
            this.dataGridViewOperands.ReadOnly = true;
            this.dataGridViewOperands.Size = new System.Drawing.Size(349, 260);
            this.dataGridViewOperands.TabIndex = 16;
            this.dataGridViewOperands.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOperands_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 661);
            this.Controls.Add(this.dataGridViewOperands);
            this.Controls.Add(this.dataGridViewOperators);
            this.Controls.Add(this.tBoxResult);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.srcBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
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
    }
}

