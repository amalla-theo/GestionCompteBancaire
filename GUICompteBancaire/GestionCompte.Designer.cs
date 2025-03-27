namespace GUICompteBancaire
{
    partial class GestionCompte
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
            listeTransactions = new ListView();
            columnDate = new ColumnHeader();
            columnMontant = new ColumnHeader();
            columnNotes = new ColumnHeader();
            label1 = new Label();
            pickerDate = new DateTimePicker();
            textMontant = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // listeTransactions
            // 
            listeTransactions.Columns.AddRange(new ColumnHeader[] { columnDate, columnMontant, columnNotes });
            listeTransactions.FullRowSelect = true;
            listeTransactions.GridLines = true;
            listeTransactions.Location = new Point(12, 27);
            listeTransactions.Name = "listeTransactions";
            listeTransactions.Size = new Size(396, 411);
            listeTransactions.TabIndex = 0;
            listeTransactions.UseCompatibleStateImageBehavior = false;
            listeTransactions.View = View.Details;
            // 
            // columnDate
            // 
            columnDate.Text = "Date";
            columnDate.Width = 120;
            // 
            // columnMontant
            // 
            columnMontant.Text = "Montant";
            columnMontant.TextAlign = HorizontalAlignment.Right;
            columnMontant.Width = 160;
            // 
            // columnNotes
            // 
            columnNotes.Text = "Notes";
            columnNotes.Width = 250;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(442, 42);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 1;
            label1.Text = "Date";
            // 
            // pickerDate
            // 
            pickerDate.Location = new Point(442, 60);
            pickerDate.Name = "pickerDate";
            pickerDate.Size = new Size(201, 23);
            pickerDate.TabIndex = 2;
            // 
            // textMontant
            // 
            textMontant.AutoSize = true;
            textMontant.Location = new Point(442, 118);
            textMontant.Name = "textMontant";
            textMontant.Size = new Size(53, 15);
            textMontant.TabIndex = 3;
            textMontant.Text = "Montant";
            textMontant.TextAlign = ContentAlignment.MiddleRight;
            textMontant.Click += label2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(442, 136);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(201, 23);
            textBox1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(442, 205);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 5;
            label2.Text = "Notes";
            // 
            // GestionCompte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(textMontant);
            Controls.Add(pickerDate);
            Controls.Add(label1);
            Controls.Add(listeTransactions);
            Name = "GestionCompte";
            Text = "GestionCompte";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listeTransactions;
        private ColumnHeader columnDate;
        private ColumnHeader columnMontant;
        private ColumnHeader columnNotes;
        private Label label1;
        private DateTimePicker pickerDate;
        private Label textMontant;
        private TextBox textBox1;
        private Label label2;
    }
}