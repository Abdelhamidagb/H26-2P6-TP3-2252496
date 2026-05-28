using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Models;
using Models.Interfaces;
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{


    public partial class FrmQuiz : Form
    {
        private Quiz QuizCourant;
        private double scoreTotal = 0;

        public FrmQuiz(Quiz quiz)
        {
            QuizCourant = quiz;

            InitializeComponent();

            AfficherQuestionCourante();
            lblScore.Text = $"Score total: {QuizCourant.ScoreObtenu}/{QuizCourant.ScoreTotal}";
        }




        private void AfficherQuestionCourante()
        {
            // TODO FQ 1: Afficher la question courante dans le formulaire.
            //
            // - Adapter dynamiquement l’interface en fonction du type de la question
            // - Afficher le contrôle approprié
            // - Réafficher la réponse déjà donnée (si applicable)
            // - Mettre à jour les boutons
            //
            // Remarque : Les méthodes d’affichage spécifiques à chaque type de question
            // (ex : QuestionVraiFaux, QuestionReponseUnique, etc.) sont déjà fournies.
            // Vous devez les utiliser de manière appropriée.

            IQuestion question = QuizCourant.QuestionCourante;

            if (question == null)
            {
                return;
            }

            // Compléter ici

            ReinitialiserZoneReponse();

            if (question is QuestionVraiFaux vf)
            {
                AfficherQuestionVraiFaux(QuizCourant.ReponseQuestionCourante);
            }
            else if (question is QuestionReponseUnique ru)
            {
                AfficherQuestionChoixUnique(question, QuizCourant.ReponseQuestionCourante);
            }
            else if (question is QuestionReponsesMultiples rm)
            {
                AfficherQuestionChoixMultiples(question, QuizCourant.ReponseQuestionCourante);
            }
            else
            {
                AfficherQuestionTexte(QuizCourant.ReponseQuestionCourante);
            }



            MettreAJourBoutons();
        }
        private void AfficherQuestionVraiFaux(string reponse)
        {
            comboTrueFalse.Visible = true;
            comboTrueFalse.SelectedItem = reponse;
        }

        private void AfficherQuestionTexte(string reponse)
        {
            txtAnswer.Visible = true;
            txtAnswer.Text = reponse;


        }

        private void AfficherQuestionChoixUnique(IQuestion question, string reponse)
        {
            listBoxChoices.Visible = true;
            listBoxChoices.Items.Clear();

            // TODO FQ 1: Afficher les options de ce type de question
            // Si l'utilisteur a dêja répondu à la question, vous pouvez sélectionner son choix de réponse
            QuestionReponseUnique q = question as QuestionReponseUnique;

            if (q == null)
                return;

            // Ajouter les options dans la liste
            foreach (string option in q.Options)
            {
                listBoxChoices.Items.Add(option);
            }

            // Si une réponse existe déjà, la sélectionner
            if (!string.IsNullOrWhiteSpace(reponse))
            {
                for (int i = 0; i < listBoxChoices.Items.Count; i++)
                {
                    if (listBoxChoices.Items[i].ToString().Trim()
                        .Equals(reponse.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        listBoxChoices.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void AfficherQuestionChoixMultiples(IQuestion question, string reponse)
        {

            checkedListBox.Visible = true;
            checkedListBox.Items.Clear();

            // TODO FQ 2: Afficher les options de ce type de question
            // Si l'utilisteur a dêja répondu à la question, vous pouvez sélectionner ses choix de réponse

            QuestionReponsesMultiples q = question as QuestionReponsesMultiples;

            if (q == null)
                return;

            // Ajouter les options
            foreach (string option in q.Options)
            {
                checkedListBox.Items.Add(option);
            }

            // Réafficher les réponses déjà choisies (si existantes)
            if (!string.IsNullOrWhiteSpace(reponse))
            {
                string[] reponses = reponse.Split(',');

                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    string item = checkedListBox.Items[i].ToString().Trim();

                    for (int j = 0; j < reponses.Length; j++)
                    {
                        if (item.Equals(reponses[j].Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            checkedListBox.SetItemChecked(i, true);
                            break;
                        }
                    }
                }
            }

        }
        private int TrouverIndex(CheckedListBox listBox, string texte)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                if (listBox.Items[i].ToString().Trim().ToLower() == texte.Trim().ToLower())
                {
                    return i;
                }
            }

            return -1;
        }
        private void ReinitialiserZoneReponse()
        {
            txtAnswer.Visible = false;
            txtAnswer.Text = "";

            listBoxChoices.Visible = false;
            listBoxChoices.Items.Clear();

            checkedListBox.Visible = false;
            checkedListBox.Items.Clear();

            comboTrueFalse.Visible = false;
            comboTrueFalse.SelectedIndex = -1;

            btnUtiliserIndice.Visible = false;
            //lblIndice.Visible = false;
            lblIndice.Text = "";


        }

        private void btnValidate_Click(object sender, EventArgs e)
        {

            // TODO FQ 3: Valider la réponse de l'utilsiateur 
            // et mettre à jour le score

            string reponse = RecupererReponseUtilisateur();

            QuizCourant.RepondreQuestionCourante(reponse);

            double score = QuizCourant.ScoreObtenu;

            lblScore.Text = $"Score: {score}/{QuizCourant.ScoreTotal}";

            AfficherCouleurResultat(score);

        }
        private string RecupererReponseUtilisateur()
        {
            // TODO FQ 4: Récupérer la réponse saisie ou sélectionnée par l’utilisateur
            // selon le type de la question courante.
            //
            // - QuestionVraiFaux : récupérer la valeur sélectionnée dans le ComboBox
            // - QuestionNumerique et QuestionReponseCourte : récupérer le texte saisi
            // - QuestionReponseUnique : récupérer l’option sélectionnée dans la ListBox
            // - QuestionReponsesMultiples : récupérer toutes les options cochées
            //   et les regrouper dans une seule chaîne séparée par des virgules
            //
            // Si aucune réponse n’est fournie, retourner une chaîne vide.

            IQuestion q = QuizCourant.QuestionCourante;

            if (q is QuestionVraiFaux)
            {
                return comboTrueFalse.Text;
            }
            else if (q is QuestionReponseUnique)
            {
                return listBoxChoices.SelectedItem?.ToString() ?? "";
            }
            else if (q is QuestionReponsesMultiples)
            {
                List<string> rep = new List<string>();

                foreach (var item in checkedListBox.CheckedItems)
                    rep.Add(item.ToString());

                return string.Join(",", rep);
            }
            else
            {
                return txtAnswer.Text;
            }

        }
        private void AfficherCouleurResultat(double score)
        {
            // TODO FQ 5: Mettre à jouyr la couleur de panColor selon le résultat

            double total = QuizCourant.ScoreTotal;

            if (total == 0)
                return;

            double pourcentage = (score / total) * 100;

            if (pourcentage >= 70)
            {
                panColor.BackColor = System.Drawing.Color.Green;
            }
            else if (pourcentage >= 50)
            {
                panColor.BackColor = System.Drawing.Color.Orange;
            }
            else
            {
                panColor.BackColor = System.Drawing.Color.Red;
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            // TODO FQ 6: Naviguer vers la question suivante si elle existe
            // et mettre à jour l’affichage.

            if (QuizCourant.IndexQuestionCourante < QuizCourant.Questions.Count - 1)
            {
                QuizCourant.QuestionSuivante();
                AfficherQuestionCourante();
            }

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            // TODO FQ 7: Naviguer vers la question précédente si elle existe
            // et mettre à jour l’affichage.

            if (QuizCourant.IndexQuestionCourante > 0)
            {
                QuizCourant.QuestionPrecedente();
                AfficherQuestionCourante();
            }


        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MettreAJourBoutons()
        {
            // TODO FQ8: Activer/Désactiver les boutons selon le type de question et la question courante.

            btnPrevious.Enabled = QuizCourant.IndexQuestionCourante > 0;

            btnNext.Enabled =
                QuizCourant.IndexQuestionCourante < QuizCourant.Questions.Count - 1;

        }

        private void btnUtiliserIndice_Click(object sender, EventArgs e)
        {
            // TODO FQ9: Vérifier si la question courante permet l’utilisation d’un indice.
            // Si oui :
            // - utiliser l’indice de la question;
            // - afficher le texte de l’indice dans le label prévu.



        }

        private void listBoxChoices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

