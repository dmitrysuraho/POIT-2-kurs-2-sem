namespace Lab4
{
    partial class Form2
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
            this.SizeCollection = new System.Windows.Forms.TextBox();
            this.TextSizeCollection = new System.Windows.Forms.TextBox();
            this.SortUp = new System.Windows.Forms.Button();
            this.GenCollection = new System.Windows.Forms.Button();
            this.SortDown = new System.Windows.Forms.Button();
            this.Request2 = new System.Windows.Forms.Button();
            this.Request3 = new System.Windows.Forms.Button();
            this.Request1 = new System.Windows.Forms.Button();
            this.ResultCollection = new System.Windows.Forms.RichTextBox();
            this.Results = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // SizeCollection
            // 
            this.SizeCollection.Location = new System.Drawing.Point(309, 53);
            this.SizeCollection.Name = "SizeCollection";
            this.SizeCollection.Size = new System.Drawing.Size(110, 20);
            this.SizeCollection.TabIndex = 0;
            this.SizeCollection.TextChanged += new System.EventHandler(this.SizeCollection_TextChanged);
            // 
            // TextSizeCollection
            // 
            this.TextSizeCollection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextSizeCollection.Location = new System.Drawing.Point(309, 34);
            this.TextSizeCollection.Name = "TextSizeCollection";
            this.TextSizeCollection.ReadOnly = true;
            this.TextSizeCollection.Size = new System.Drawing.Size(110, 13);
            this.TextSizeCollection.TabIndex = 1;
            this.TextSizeCollection.Text = "Размер коллекции";
            this.TextSizeCollection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SortUp
            // 
            this.SortUp.Location = new System.Drawing.Point(48, 115);
            this.SortUp.Name = "SortUp";
            this.SortUp.Size = new System.Drawing.Size(145, 52);
            this.SortUp.TabIndex = 2;
            this.SortUp.Text = "Сортировать по возрастанию";
            this.SortUp.UseVisualStyleBackColor = true;
            this.SortUp.Click += new System.EventHandler(this.SortUp_Click);
            // 
            // GenCollection
            // 
            this.GenCollection.Location = new System.Drawing.Point(236, 106);
            this.GenCollection.Name = "GenCollection";
            this.GenCollection.Size = new System.Drawing.Size(258, 71);
            this.GenCollection.TabIndex = 3;
            this.GenCollection.Text = "Сгенерировать коллекцию";
            this.GenCollection.UseVisualStyleBackColor = true;
            this.GenCollection.Click += new System.EventHandler(this.GenCollection_Click);
            // 
            // SortDown
            // 
            this.SortDown.Location = new System.Drawing.Point(532, 115);
            this.SortDown.Name = "SortDown";
            this.SortDown.Size = new System.Drawing.Size(145, 52);
            this.SortDown.TabIndex = 4;
            this.SortDown.Text = "Сортировать по убыванию";
            this.SortDown.UseVisualStyleBackColor = true;
            this.SortDown.Click += new System.EventHandler(this.SortDown_Click);
            // 
            // Request2
            // 
            this.Request2.Location = new System.Drawing.Point(328, 222);
            this.Request2.Name = "Request2";
            this.Request2.Size = new System.Drawing.Size(75, 36);
            this.Request2.TabIndex = 6;
            this.Request2.Text = "Запрос №2";
            this.Request2.UseVisualStyleBackColor = true;
            this.Request2.Click += new System.EventHandler(this.Request2_Click);
            // 
            // Request3
            // 
            this.Request3.Location = new System.Drawing.Point(589, 222);
            this.Request3.Name = "Request3";
            this.Request3.Size = new System.Drawing.Size(75, 36);
            this.Request3.TabIndex = 7;
            this.Request3.Text = "Запрос №3";
            this.Request3.UseVisualStyleBackColor = true;
            this.Request3.Click += new System.EventHandler(this.Request3_Click);
            // 
            // Request1
            // 
            this.Request1.Location = new System.Drawing.Point(67, 222);
            this.Request1.Name = "Request1";
            this.Request1.Size = new System.Drawing.Size(86, 36);
            this.Request1.TabIndex = 8;
            this.Request1.Text = "Запрос №1";
            this.Request1.UseVisualStyleBackColor = true;
            this.Request1.Click += new System.EventHandler(this.Request1_Click);
            // 
            // ResultCollection
            // 
            this.ResultCollection.BackColor = System.Drawing.SystemColors.Window;
            this.ResultCollection.Location = new System.Drawing.Point(67, 290);
            this.ResultCollection.Name = "ResultCollection";
            this.ResultCollection.ReadOnly = true;
            this.ResultCollection.Size = new System.Drawing.Size(286, 148);
            this.ResultCollection.TabIndex = 9;
            this.ResultCollection.Text = "";
            // 
            // Results
            // 
            this.Results.BackColor = System.Drawing.SystemColors.Window;
            this.Results.Location = new System.Drawing.Point(388, 290);
            this.Results.Name = "Results";
            this.Results.ReadOnly = true;
            this.Results.Size = new System.Drawing.Size(286, 148);
            this.Results.TabIndex = 10;
            this.Results.Text = "";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 450);
            this.Controls.Add(this.Results);
            this.Controls.Add(this.ResultCollection);
            this.Controls.Add(this.Request1);
            this.Controls.Add(this.Request3);
            this.Controls.Add(this.Request2);
            this.Controls.Add(this.SortDown);
            this.Controls.Add(this.GenCollection);
            this.Controls.Add(this.SortUp);
            this.Controls.Add(this.TextSizeCollection);
            this.Controls.Add(this.SizeCollection);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form2_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SizeCollection;
        private System.Windows.Forms.TextBox TextSizeCollection;
        private System.Windows.Forms.Button SortUp;
        private System.Windows.Forms.Button GenCollection;
        private System.Windows.Forms.Button SortDown;
        private System.Windows.Forms.Button Request2;
        private System.Windows.Forms.Button Request3;
        private System.Windows.Forms.Button Request1;
        private System.Windows.Forms.RichTextBox ResultCollection;
        private System.Windows.Forms.RichTextBox Results;
    }
}