namespace WinFormsApp1
{
    partial class FrmQuiz
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
            panColor = new Panel();
            card = new Panel();
            lblNumQuestion = new Label();
            comboTrueFalse = new ComboBox();
            lblQuestion = new Label();
            txtAnswer = new TextBox();
            listBoxChoices = new ListBox();
            checkedListBox = new CheckedListBox();
            btnValidate = new Button();
            btnNext = new Button();
            btnPrevious = new Button();
            lblScore = new Label();
            btnUtiliserIndice = new Button();
            lblIndice = new Label();
            panColor.SuspendLayout();
            card.SuspendLayout();
            SuspendLayout();
            // 
            // panColor
            // 
            panColor.BackColor = Color.Gray;
            panColor.Controls.Add(card);
            panColor.Location = new Point(12, 12);
            panColor.Name = "panColor";
            panColor.Padding = new Padding(20);
            panColor.Size = new Size(742, 417);
            panColor.TabIndex = 3;
            // 
            // card
            // 
            card.BackColor = Color.LightBlue;
            card.Controls.Add(lblIndice);
            card.Controls.Add(btnUtiliserIndice);
            card.Controls.Add(lblNumQuestion);
            card.Controls.Add(comboTrueFalse);
            card.Controls.Add(lblQuestion);
            card.Controls.Add(txtAnswer);
            card.Controls.Add(listBoxChoices);
            card.Controls.Add(checkedListBox);
            card.Controls.Add(btnValidate);
            card.Controls.Add(btnNext);
            card.Controls.Add(btnPrevious);
            card.Controls.Add(lblScore);
            card.Location = new Point(22, 19);
            card.Name = "card";
            card.Padding = new Padding(20);
            card.Size = new Size(697, 380);
            card.TabIndex = 2;
            // 
            // lblNumQuestion
            // 
            lblNumQuestion.Font = new Font("Segoe UI Semibold", 16F);
            lblNumQuestion.ForeColor = Color.FromArgb(30, 30, 30);
            lblNumQuestion.Location = new Point(20, 20);
            lblNumQuestion.Name = "lblNumQuestion";
            lblNumQuestion.Size = new Size(73, 70);
            lblNumQuestion.TabIndex = 10;
            // 
            // comboTrueFalse
            // 
            comboTrueFalse.BackColor = Color.White;
            comboTrueFalse.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTrueFalse.FlatStyle = FlatStyle.Flat;
            comboTrueFalse.Font = new Font("Segoe UI", 11F);
            comboTrueFalse.ForeColor = Color.FromArgb(30, 30, 30);
            comboTrueFalse.Items.AddRange(new object[] { "True", "False" });
            comboTrueFalse.Location = new Point(20, 100);
            comboTrueFalse.Name = "comboTrueFalse";
            comboTrueFalse.Size = new Size(150, 28);
            comboTrueFalse.TabIndex = 0;
            comboTrueFalse.Visible = false;
            // 
            // lblQuestion
            // 
            lblQuestion.Font = new Font("Segoe UI Semibold", 16F);
            lblQuestion.ForeColor = Color.FromArgb(30, 30, 30);
            lblQuestion.Location = new Point(99, 20);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(568, 70);
            lblQuestion.TabIndex = 0;
            // 
            // txtAnswer
            // 
            txtAnswer.BackColor = Color.FromArgb(245, 245, 245);
            txtAnswer.BorderStyle = BorderStyle.None;
            txtAnswer.Font = new Font("Segoe UI", 11F);
            txtAnswer.Location = new Point(20, 100);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.Size = new Size(300, 20);
            txtAnswer.TabIndex = 1;
            // 
            // listBoxChoices
            // 
            listBoxChoices.BackColor = Color.FromArgb(250, 250, 250);
            listBoxChoices.BorderStyle = BorderStyle.None;
            listBoxChoices.Font = new Font("Segoe UI", 11F);
            listBoxChoices.ItemHeight = 20;
            listBoxChoices.Location = new Point(20, 100);
            listBoxChoices.Name = "listBoxChoices";
            listBoxChoices.Size = new Size(300, 100);
            listBoxChoices.TabIndex = 4;
            // 
            // checkedListBox
            // 
            checkedListBox.BackColor = Color.FromArgb(250, 250, 250);
            checkedListBox.BorderStyle = BorderStyle.None;
            checkedListBox.CheckOnClick = true;
            checkedListBox.Font = new Font("Segoe UI", 11F);
            checkedListBox.Location = new Point(20, 100);
            checkedListBox.Name = "checkedListBox";
            checkedListBox.Size = new Size(300, 110);
            checkedListBox.TabIndex = 5;
            // 
            // btnValidate
            // 
            btnValidate.BackColor = Color.FromArgb(0, 120, 215);
            btnValidate.FlatAppearance.BorderSize = 0;
            btnValidate.FlatStyle = FlatStyle.Flat;
            btnValidate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnValidate.ForeColor = Color.White;
            btnValidate.Location = new Point(20, 250);
            btnValidate.Name = "btnValidate";
            btnValidate.Size = new Size(120, 35);
            btnValidate.TabIndex = 6;
            btnValidate.Text = "Valider";
            btnValidate.UseVisualStyleBackColor = false;
            btnValidate.Click += btnValidate_Click;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.FromArgb(50, 50, 50);
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.ForeColor = Color.White;
            btnNext.Location = new Point(285, 250);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(120, 35);
            btnNext.TabIndex = 7;
            btnNext.Text = "Suivant";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.BackColor = Color.FromArgb(120, 120, 120);
            btnPrevious.FlatAppearance.BorderSize = 0;
            btnPrevious.FlatStyle = FlatStyle.Flat;
            btnPrevious.ForeColor = Color.White;
            btnPrevious.Location = new Point(157, 250);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(120, 35);
            btnPrevious.TabIndex = 8;
            btnPrevious.Text = "Précédent";
            btnPrevious.UseVisualStyleBackColor = false;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // lblScore
            // 
            lblScore.Font = new Font("Segoe UI", 10F);
            lblScore.ForeColor = Color.Gray;
            lblScore.Location = new Point(20, 300);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(300, 30);
            lblScore.TabIndex = 9;
            // 
            // btnUtiliserIndice
            // 
            btnUtiliserIndice.BackColor = Color.FromArgb(255, 192, 128);
            btnUtiliserIndice.FlatAppearance.BorderSize = 0;
            btnUtiliserIndice.FlatStyle = FlatStyle.Flat;
            btnUtiliserIndice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUtiliserIndice.ForeColor = Color.Black;
            btnUtiliserIndice.Location = new Point(343, 100);
            btnUtiliserIndice.Name = "btnUtiliserIndice";
            btnUtiliserIndice.Size = new Size(120, 35);
            btnUtiliserIndice.TabIndex = 11;
            btnUtiliserIndice.Text = "Utiliser indice";
            btnUtiliserIndice.UseVisualStyleBackColor = false;
            btnUtiliserIndice.Click += btnUtiliserIndice_Click;
            // 
            // lblIndice
            // 
            lblIndice.Font = new Font("Segoe UI Semibold", 16F);
            lblIndice.ForeColor = Color.FromArgb(30, 30, 30);
            lblIndice.Location = new Point(343, 155);
            lblIndice.Name = "lblIndice";
            lblIndice.Size = new Size(340, 55);
            lblIndice.TabIndex = 12;
            // 
            // FrmQuiz
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(766, 438);
            Controls.Add(panColor);
            Name = "FrmQuiz";
            Text = "FrmQuiz";
            panColor.ResumeLayout(false);
            card.ResumeLayout(false);
            card.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panColor;
        private Panel card;
        private ComboBox comboTrueFalse;
        private Label lblQuestion;
        private TextBox txtAnswer;
        private ListBox listBoxChoices;
        private CheckedListBox checkedListBox;
        private Button btnValidate;
        private Button btnNext;
        private Button btnPrevious;
        private Label lblScore;
        private Label lblNumQuestion;
        private Label lblIndice;
        private Button btnUtiliserIndice;
    }
}