using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Interfaces;

namespace Models
{
    /// <summary>
    /// Représente un quiz composé de plusieurs questions.
    /// Permet de gérer la navigation, les réponses et le calcul du score.
    /// </summary>
    public class Quiz
    {
        #region Champs et Propriétés
        /// <summary>
        /// Nom par défaut d’un quiz.
        /// </summary>
        public const string NOM_QUIZ_DEFAUT = "Inconnu";

        /// <summary>
        /// Nom du quiz.
        /// </summary>
        public string Nom { get; private set; }

        /// <summary>
        /// Liste des questions du quiz.
        /// </summary>
        public List<IQuestion> Questions { get; private set; }

        /// <summary>
        /// Liste des réponses de l'utilisateur.
        /// Chaque réponse correspond à une question.
        /// </summary>
        public List<string> Reponses { get; private set; }

        /// <summary>
        /// Index de la question actuellement affichée.
        /// </summary>
        public int IndexQuestionCourante { get; private set; }

        /// <summary>
        /// Retourne la question courante ou null si aucune question n'est disponible.
        /// </summary>
        public IQuestion QuestionCourante
        {
            get
            {
                if (Questions == null || Questions.Count == 0)
                    return null;
                

                if (IndexQuestionCourante < 0 || IndexQuestionCourante >= Questions.Count)
                    return null;
                  

                return Questions[IndexQuestionCourante];
            }
        }
        
        /// <summary>
        /// Retourne la question à une position donnée.
        /// </summary>
        /// <param name="position">Index de la question.</param>
        /// <returns>La question correspondante.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Lancée lorsque la position est invalide.
        /// </exception>
        public IQuestion QuestionAt(int position)
        {
            if (position < 0 || position >= Questions.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return Questions[position];
        }
        /// <summary>
        /// Retourne la réponse associée à la question courante.
        /// </summary>
        public string ReponseQuestionCourante
        {
            get
            {
                if (IndexQuestionCourante >= 0 &&
                    IndexQuestionCourante < Reponses.Count)
                {
                    return Reponses[IndexQuestionCourante];
                }

                return "";
            }

        }
        /// <summary>
        /// Calcule le score obtenu par l'utilisateur.
        /// </summary>
        public double ScoreObtenu
        {
            get
            {
                // TODO QUIZ 1: Calculer et retourner le score total obtenu par l'utilisateur
                // en parcourant toutes les questions et en utilisant la méthode CorrigerReponse.

               
                return 0;

            }
        }

        /// <summary>
        /// Calcule le score total possible du quiz.
        /// </summary>
        public double ScoreTotal
        {
            get
            {
                // TODO QUIZ 2: Calculer et retourner le score total possible du quiz
                // en additionnant les points de toutes les questions.

               
                return 0;

            }
        }

        /// <summary>
        /// Retourne le nombre de bonnes réponses.
        /// </summary>
        public int NombreBonnesReponses
        {
            get
            {
                // TODO QUIZ 3: Calculer et retourner le nombre de bonnes réponses
                // en vérifiant chaque réponse avec la méthode ValiderReponse.

               
                return 0;

            }
        }
        #endregion

        #region Constructuers
        /// <summary>
        /// Initialise un quiz vide avec un nom.
        /// </summary>
        /// <param name="nom">Nom du quiz.</param>
        public Quiz(string nom)
        {
            if (nom == null || nom == "")
            {
                Nom = NOM_QUIZ_DEFAUT;
            }
            else
            {
                Nom = nom;
            }
                     
           Questions = new List<IQuestion>();
           Reponses = new List<string>();
           IndexQuestionCourante = -1;
        }

        /// <summary>
        /// Initialise un quiz avec une liste de questions.
        /// </summary>
        /// <param name="nom">Nom du quiz.</param>
        /// <param name="questions">Liste des questions.</param>
        public Quiz(string nom, List<IQuestion> questions)
        {
            if (nom == null  || nom == "")
            {
                Nom = NOM_QUIZ_DEFAUT;
            }
            else
            {
                Nom = nom;
            }

            if (questions == null)
            {
                throw new ArgumentNullException("La liste des questions ne peut pas être null.");
            }
            if (questions.Count == 0)
                throw new ArgumentException("La liste des questions ne peut pas être vide.", nameof(questions));

            Questions = questions;
           
            Reponses = new List<string>();
            for (int i = 0; i < Questions.Count; i++)
            {
                Reponses.Add("");
            }
            IndexQuestionCourante = 0;
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Ajoute une nouvelle question au quiz.
        /// </summary>
        /// <param name="question">Question à ajouter.</param>
        /// <exception cref="ArgumentNullException">
        /// Lancée lorsque la question est null.
        /// </exception>
        public void AjouterQuestion(IQuestion question)
        {
            if (question == null)
            {
                throw new ArgumentNullException("La question ne peut pas être null.");
            }
           
            Questions.Add(question);
            Reponses.Add("");
            IndexQuestionCourante = 0;
        }
        /// <summary>
        /// Enregistre la réponse de l'utilisateur pour la question courante.
        /// </summary>
        /// <param name="reponse">Réponse de l'utilisateur.</param>
        /// <exception cref="InvalidOperationException">
        /// Lancée lorsqu'il n'y a aucune question courante.
        /// </exception>  
        public void RepondreQuestionCourante(string reponse)
        {
            if (IndexQuestionCourante < 0 || IndexQuestionCourante >= Reponses.Count)
            {
                throw new InvalidOperationException("Aucune question courante n'est disponible.");
            }

            Reponses[IndexQuestionCourante] = reponse;
        }
        /// <summary>
        /// Passe à la question suivante.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">
        /// Lancée lorsque la question courante est déjà la dernière.
        /// </exception>
        public void QuestionSuivante()
        {            
            if (IndexQuestionCourante == Questions.Count-1)
            {
                throw new InvalidOperationException("Impossible de passer à la question suivante : vous êtes déjà à la dernière question.");
            }
            IndexQuestionCourante++;
        }
        /// <summary>
        /// Revient à la question précédente.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">
        /// Lancée lorsque la question courante est déjà la première.
        /// </exception>
        public void QuestionPrecedente()
        {
            if (IndexQuestionCourante == 0)
            {
                throw new InvalidOperationException("Impossible de revenir à la question précédente : vous êtes déjà à la première question.");
            }
            IndexQuestionCourante--;
        }
        #endregion

    }

}
