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

        }

        private void AfficherQuestionChoixMultiples(IQuestion question, string reponse)
        {

            checkedListBox.Visible = true;
            checkedListBox.Items.Clear();

            // TODO FQ 2: Afficher les options de ce type de question
            // Si l'utilisteur a dêja répondu à la question, vous pouvez sélectionner ses choix de réponse

          
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

          
            return "";
           
        }
        private void AfficherCouleurResultat(double score)
        {
            // TODO FQ 5: Mettre à jouyr la couleur de panColor selon le résultat
           
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            // TODO FQ 6: Naviguer vers la question suivante si elle existe
            // et mettre à jour l’affichage.

           

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            // TODO FQ 7: Naviguer vers la question précédente si elle existe
            // et mettre à jour l’affichage.

          


        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MettreAJourBoutons()
        {
            // TODO FQ8: Activer/Désactiver les boutons selon le type de question et la question courante.
            
           

        }

        private void btnUtiliserIndice_Click(object sender, EventArgs e)
        {
            // TODO FQ9: Vérifier si la question courante permet l’utilisation d’un indice.
            // Si oui :
            // - utiliser l’indice de la question;
            // - afficher le texte de l’indice dans le label prévu.

           

        }
    }
}

