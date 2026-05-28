using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace WinFormsApp1
{
    public partial class FrmPrincipal : Form
    {
        private BanqueQuestions BanqueQuestions = new BanqueQuestions();
        public FrmPrincipal()
        {
            InitializeComponent();
        }



        private void btnGenererQuiz_Click(object sender, EventArgs e)
        {


            // TODO FP 1 : Générer un quiz à partir de la banque de questions,
            // puis ouvrir le formulaire FrmQuiz.

            string nomQuiz = txtNomQuiz.Text.Trim();

            if (string.IsNullOrWhiteSpace(nomQuiz))
            {
                MessageBox.Show("Veuillez entrer un nom pour le quiz.", "Avertissement",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboNbQuestions.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner le nombre de questions.", "Avertissement",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nombreQuestions = int.Parse(cboNbQuestions.SelectedItem.ToString());

            try
            {
                Quiz quiz = BanqueQuestions.GenererQuiz(nomQuiz, nombreQuestions);
                FrmQuiz frmQuiz = new FrmQuiz(quiz);
                frmQuiz.ShowDialog();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void card_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
