using System.Windows.Forms;
using System.Xml.Linq;


namespace WinFormsApp1
{
    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panColor = new Panel();
            card = new Panel();
            cboNbQuestions = new ComboBox();
            lblTitre = new Label();
            lblNomQuiz = new Label();
            txtNomQuiz = new TextBox();
            lblNombreQuestions = new Label();
            btnGenererQuiz = new Button();
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
            panColor.Size = new Size(657, 330);
            panColor.TabIndex = 0;
            // 
            // card
            // 
            card.BackColor = Color.LightBlue;
            card.Controls.Add(cboNbQuestions);
            card.Controls.Add(lblTitre);
            card.Controls.Add(lblNomQuiz);
            card.Controls.Add(txtNomQuiz);
            card.Controls.Add(lblNombreQuestions);
            card.Controls.Add(btnGenererQuiz);
            card.Location = new Point(22, 19);
            card.Name = "card";
            card.Padding = new Padding(20);
            card.Size = new Size(611, 290);
            card.TabIndex = 1;
            // 
            // cboNbQuestions
            // 
            cboNbQuestions.FlatStyle = FlatStyle.Flat;
            cboNbQuestions.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboNbQuestions.ForeColor = Color.FromArgb(30, 30, 30);
            cboNbQuestions.FormattingEnabled = true;
            cboNbQuestions.Items.AddRange(new object[] { "5", "10", "15", "20" });
            cboNbQuestions.Location = new Point(23, 184);
            cboNbQuestions.Name = "cboNbQuestions";
            cboNbQuestions.Size = new Size(121, 28);
            cboNbQuestions.TabIndex = 6;
            // 
            // lblTitre
            // 
            lblTitre.Font = new Font("Segoe UI Semibold", 16F);
            lblTitre.ForeColor = Color.FromArgb(30, 30, 30);
            lblTitre.Location = new Point(20, 20);
            lblTitre.Name = "lblTitre";
            lblTitre.Size = new Size(568, 45);
            lblTitre.TabIndex = 0;
            lblTitre.Text = "Générer un nouveau quiz";
            // 
            // lblNomQuiz
            // 
            lblNomQuiz.Font = new Font("Segoe UI", 11F);
            lblNomQuiz.ForeColor = Color.FromArgb(30, 30, 30);
            lblNomQuiz.Location = new Point(20, 85);
            lblNomQuiz.Name = "lblNomQuiz";
            lblNomQuiz.Size = new Size(200, 25);
            lblNomQuiz.TabIndex = 1;
            lblNomQuiz.Text = "Nom du quiz";
            // 
            // txtNomQuiz
            // 
            txtNomQuiz.BackColor = Color.FromArgb(245, 245, 245);
            txtNomQuiz.BorderStyle = BorderStyle.None;
            txtNomQuiz.Font = new Font("Segoe UI", 11F);
            txtNomQuiz.Location = new Point(20, 115);
            txtNomQuiz.Name = "txtNomQuiz";
            txtNomQuiz.Size = new Size(350, 20);
            txtNomQuiz.TabIndex = 2;
            // 
            // lblNombreQuestions
            // 
            lblNombreQuestions.Font = new Font("Segoe UI", 11F);
            lblNombreQuestions.ForeColor = Color.FromArgb(30, 30, 30);
            lblNombreQuestions.Location = new Point(20, 155);
            lblNombreQuestions.Name = "lblNombreQuestions";
            lblNombreQuestions.Size = new Size(250, 25);
            lblNombreQuestions.TabIndex = 3;
            lblNombreQuestions.Text = "Nombre de questions";
            // 
            // btnGenererQuiz
            // 
            btnGenererQuiz.BackColor = Color.FromArgb(0, 120, 215);
            btnGenererQuiz.FlatAppearance.BorderSize = 0;
            btnGenererQuiz.FlatStyle = FlatStyle.Flat;
            btnGenererQuiz.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGenererQuiz.ForeColor = Color.White;
            btnGenererQuiz.Location = new Point(20, 235);
            btnGenererQuiz.Name = "btnGenererQuiz";
            btnGenererQuiz.Size = new Size(160, 35);
            btnGenererQuiz.TabIndex = 5;
            btnGenererQuiz.Text = "Générer le quiz";
            btnGenererQuiz.UseVisualStyleBackColor = false;
            btnGenererQuiz.Click += btnGenererQuiz_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 354);
            Controls.Add(panColor);
            Name = "FrmPrincipal";
            Text = "Générer un quiz";
            panColor.ResumeLayout(false);
            card.ResumeLayout(false);
            card.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panColor;
        private Panel card;
        private Label lblTitre;
        private Label lblNomQuiz;
        private TextBox txtNomQuiz;
        private Label lblNombreQuestions;
        private Button btnGenererQuiz;
        private ComboBox cboNbQuestions;
    }
}