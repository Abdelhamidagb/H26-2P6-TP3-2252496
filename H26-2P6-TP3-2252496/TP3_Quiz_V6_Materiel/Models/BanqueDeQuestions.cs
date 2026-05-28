using System;
using System.Collections.Generic;
using Models.Interfaces;

namespace Models
{
    /// <summary>
    /// Représente une banque de questions utilisée pour générer des quiz.
    /// Contient un ensemble de questions de différents types.
    /// </summary>
    public class BanqueQuestions
    {
        #region Propriétés

        /// <summary>
        /// Liste des questions disponibles dans la banque.
        /// Cette liste est accessible en lecture seule.
        /// </summary>
        public IReadOnlyList<IQuestion> Questions { get; protected set; }

        #endregion

        #region Constructeur

        /// <summary>
        /// Initialise une banque de questions avec un ensemble prédéfini
        /// de questions de différents types (numériques, vrai/faux, QCM, etc.).
        /// </summary>
        public BanqueQuestions()
        {

            Questions = new List<IQuestion>()
            {
                ////TODO BQ 1: Ajouter au moins 10 questions de types variés :
                // -QuestionNumerique
                // - QuestionVraiFaux
                // - QuestionReponseUnique
                // - QuestionReponsesMultiples
                // - QuestionReponseCourte
                 // =========================
                // VRAI / FAUX
                // =========================
                new QuestionVraiFaux("Le ciel est bleu ?", Categorie.CultureGenerale, 10, true),
                new QuestionVraiFaux("2 + 2 = 5 ?", Categorie.Mathematiques, 10, false),

                // =========================
                // NUMERIQUE
                // =========================
                new QuestionNumerique("Combien font 3 + 3 ?", Categorie.Mathematiques, 10, 6, "Addition simple", 0.5),
                new QuestionNumerique("10 / 2 ?", Categorie.Mathematiques, 10, 5, "Division par 2", 0.5),

                // =========================
                // REPONSE COURTE
                // =========================
                new QuestionReponseCourte("Capitale du Canada ?", Categorie.CultureGenerale, 10, "Ottawa", "Ville politique", 0.5),
                new QuestionReponseCourte("Pays de la tour Eiffel ?", Categorie.CultureGenerale, 10, "France", "Europe", 0.5),

                // =========================
                // REPONSE UNIQUE
                // =========================
                new QuestionReponseUnique(
                    "Capitale de la France ?",
                    Categorie.CultureGenerale,
                    10,
                    "Paris",
                    new List<string>{ "Paris", "Lyon", "Marseille", "Nice" }
                ),

                new QuestionReponseUnique(
                    "Couleur du ciel par beau temps ?",
                    Categorie.CultureGenerale,
                    10,
                    "Bleu",
                    new List<string>{ "Bleu", "Vert", "Rouge", "Noir" }
                ),

                // =========================
                // REPONSES MULTIPLES
                // =========================
                new QuestionReponsesMultiples(
                    "Sélectionner les capitales européennes",
                    Categorie.CultureGenerale,
                    10,
                    new List<string>{ "Paris", "Rome" },
                    new List<string>{ "Paris", "Rome", "Berlin", "Madrid" }
                ),

                new QuestionReponsesMultiples(
                    "Sélectionner les animaux",
                    Categorie.CultureGenerale,
                    10,
                    new List<string>{ "Chat", "Chien" },
                    new List<string>{ "Chat", "Chien", "Table", "Chaise" }
                )


            };
        }

        #endregion

        #region Génération de quiz

        /// <summary>
        /// Génère un nouveau quiz en sélectionnant aléatoirement un nombre donné
        /// de questions à partir de la banque.
        /// </summary>
        /// <param name="nom">Nom du quiz à créer.</param>
        /// <param name="nombreQuestions">Nombre de questions à inclure.</param>
        /// <returns>
        /// Un objet <see cref="Quiz"/> contenant les questions sélectionnées.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Lancée si le nombre de questions demandé est inférieur ou égal à 0.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Lancée si le nombre de questions demandé dépasse le nombre disponible.
        /// </exception>
        public Quiz GenererQuiz(string nom, int nombreQuestions)
        {
            if (nombreQuestions <= 0)
                throw new ArgumentOutOfRangeException(nameof(nombreQuestions));

            if (Questions == null || nombreQuestions > Questions.Count)
                throw new InvalidOperationException("Il n'y a pas assez de questions dans la banque.");

            // Copie de la liste
            List<IQuestion> questionsCopiees = new List<IQuestion>(Questions);

            // Mélange aléatoire
            OutilsQuiz.MelangerQuestions(questionsCopiees);

            // Sélection des premières questions
            List<IQuestion> questionsSelectionnees = new List<IQuestion>();

            for (int i = 0; i < nombreQuestions; i++)
            {
                questionsSelectionnees.Add(questionsCopiees[i]);
            }

            // Création du quiz
            return new Quiz(nom, questionsSelectionnees);
        }

        #endregion
    }
}