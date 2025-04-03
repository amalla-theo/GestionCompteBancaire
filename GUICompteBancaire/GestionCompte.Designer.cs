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
            label3 = new Label();
            textMontant = new TextBox();
            label2 = new Label();
            textBoxNotes = new TextBox();
            statusStrip1 = new StatusStrip();
            labelSolde = new ToolStripStatusLabel();
            labelErreur = new ToolStripStatusLabel();
            panelZoom = new Panel();
            buttonSupprimer = new Button();
            buttonAjouter = new Button();
            buttonValider = new Button();
            statusStrip1.SuspendLayout();
            panelZoom.SuspendLayout();
            SuspendLayout();
            // 
            // listeTransactions
            // 
            listeTransactions.Columns.AddRange(new ColumnHeader[] { columnDate, columnMontant, columnNotes });
            listeTransactions.FullRowSelect = true;
            listeTransactions.GridLines = true;
            listeTransactions.Location = new Point(12, 27);
            listeTransactions.MultiSelect = false;
            listeTransactions.Name = "listeTransactions";
            listeTransactions.Size = new Size(396, 411);
            listeTransactions.TabIndex = 0;
            listeTransactions.UseCompatibleStateImageBehavior = false;
            listeTransactions.View = View.Details;
            listeTransactions.SelectedIndexChanged += listeTransactions_SelectedIndexChanged;
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
            label1.Location = new Point(3, 5);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 1;
            label1.Text = "Date";
            // 
            // pickerDate
            // 
            pickerDate.Location = new Point(3, 23);
            pickerDate.Name = "pickerDate";
            pickerDate.Size = new Size(201, 23);
            pickerDate.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 81);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 3;
            label3.Text = "Montant";
            label3.TextAlign = ContentAlignment.MiddleRight;
            label3.Click += label2_Click;
            // 
            // textMontant
            // 
            textMontant.Location = new Point(3, 99);
            textMontant.Name = "textMontant";
            textMontant.Size = new Size(201, 23);
            textMontant.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 168);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 5;
            label2.Text = "Notes";
            // 
            // textBoxNotes
            // 
            textBoxNotes.Location = new Point(3, 186);
            textBoxNotes.Multiline = true;
            textBoxNotes.Name = "textBoxNotes";
            textBoxNotes.ScrollBars = ScrollBars.Both;
            textBoxNotes.Size = new Size(201, 136);
            textBoxNotes.TabIndex = 6;
            textBoxNotes.TextChanged += textBox2_TextChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { labelSolde, labelErreur });
            statusStrip1.Location = new Point(0, 454);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(706, 22);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            // 
            // labelSolde
            // 
            labelSolde.Name = "labelSolde";
            labelSolde.Size = new Size(0, 17);
            // 
            // labelErreur
            // 
            labelErreur.ForeColor = Color.Red;
            labelErreur.Name = "labelErreur";
            labelErreur.Size = new Size(0, 17);
            // 
            // panelZoom
            // 
            panelZoom.Controls.Add(pickerDate);
            panelZoom.Controls.Add(label1);
            panelZoom.Controls.Add(textBoxNotes);
            panelZoom.Controls.Add(label3);
            panelZoom.Controls.Add(label2);
            panelZoom.Controls.Add(textMontant);
            panelZoom.Enabled = false;
            panelZoom.Location = new Point(461, 40);
            panelZoom.Name = "panelZoom";
            panelZoom.Size = new Size(216, 331);
            panelZoom.TabIndex = 8;
            // 
            // buttonSupprimer
            // 
            buttonSupprimer.Location = new Point(467, 377);
            buttonSupprimer.Name = "buttonSupprimer";
            buttonSupprimer.Size = new Size(73, 61);
            buttonSupprimer.TabIndex = 9;
            buttonSupprimer.Text = "Supprimer";
            buttonSupprimer.UseVisualStyleBackColor = true;
            buttonSupprimer.Click += button1_Click;
            // 
            // buttonAjouter
            // 
            buttonAjouter.Location = new Point(594, 377);
            buttonAjouter.Name = "buttonAjouter";
            buttonAjouter.Size = new Size(71, 61);
            buttonAjouter.TabIndex = 10;
            buttonAjouter.Text = "Ajouter";
            buttonAjouter.UseVisualStyleBackColor = true;
            buttonAjouter.Click += buttonAjouter_Click;
            // 
            // buttonValider
            // 
            buttonValider.Enabled = false;
            buttonValider.Location = new Point(594, 377);
            buttonValider.Name = "buttonValider";
            buttonValider.Size = new Size(71, 61);
            buttonValider.TabIndex = 11;
            buttonValider.Text = "Ajouter";
            buttonValider.UseVisualStyleBackColor = true;
            buttonValider.Visible = false;
            buttonValider.Click += buttonValider_Click;
            // 
            // GestionCompte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(706, 476);
            Controls.Add(buttonAjouter);
            Controls.Add(buttonSupprimer);
            Controls.Add(panelZoom);
            Controls.Add(statusStrip1);
            Controls.Add(listeTransactions);
            Controls.Add(buttonValider);
            Name = "GestionCompte";
            Text = "GestionCompte";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panelZoom.ResumeLayout(false);
            panelZoom.PerformLayout();
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
        private Label label3;
        private TextBox textMontant;
        private Label label2;
        private TextBox textBoxNotes;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel labelSolde;
        private Panel panelZoom;
        private Button buttonSupprimer;
        private Button buttonAjouter;
        private Button buttonValider;
        private ToolStripStatusLabel labelErreur;
    }
}