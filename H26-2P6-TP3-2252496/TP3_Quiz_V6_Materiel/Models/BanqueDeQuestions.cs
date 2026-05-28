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

                // Questions Vrai/Faux
                new QuestionVraiFaux(
                    "Le langage C# est un langage orienté objet.",
                    Categorie.Programmation, 1, true),

                new QuestionVraiFaux(
                    "La Terre est plus grande que le Soleil.",
                    Categorie.CultureGenerale, 1, false),

                new QuestionVraiFaux(
                    "Le nombre PI est environ égal à 3.14.",
                    Categorie.Mathematiques, 1, true),

                // Questions Numériques
                new QuestionNumerique(
                    "Combien font 7 multiplié par 8 ?",
                    Categorie.Mathematiques, 2, 56,
                    "Pensez aux tables de multiplication.", 0.5),

                new QuestionNumerique(
                    "Combien y a-t-il de mois dans une année ?",
                    Categorie.CultureGenerale, 1, 12,
                    "C'est un nombre entre 10 et 15.", 0.25),

                new QuestionNumerique(
                    "Quelle est la valeur approximative de PI arrondie à l'entier le plus proche ?",
                    Categorie.Mathematiques, 2, 3,
                    "C'est un chiffre entre 2 et 5.", 0.5),

                // Questions à Réponse Courte
                new QuestionReponseCourte(
                    "Quelle est la capitale du Canada ?",
                    Categorie.CultureGenerale, 2, "Ottawa",
                    "C'est une ville située en Ontario.", 0.5),

                new QuestionReponseCourte(
                    "Quel mot-clé C# permet de créer un objet ?",
                    Categorie.Programmation, 2, "new",
                    "C'est un mot-clé de 3 lettres.", 0.5),

                // Questions à Réponse Unique
                new QuestionReponseUnique(
                    "Quel est le symbole chimique de l'eau ?",
                    Categorie.CultureGenerale, 2, "H2O",
                    new List<string> { "H2O", "CO2", "O2", "NaCl" }),

                new QuestionReponseUnique(
                    "Lequel de ces langages est orienté objet ?",
                    Categorie.Programmation, 2, "Java",
                    new List<string> { "Java", "HTML", "CSS", "SQL" }),

                new QuestionReponseUnique(
                    "Quelle structure de données suit le principe LIFO ?",
                    Categorie.Programmation, 3, "Pile",
                    new List<string> { "Pile", "File", "Liste", "Tableau" }),

                // Questions à Réponses Multiples
                new QuestionReponsesMultiples(
                    "Quels langages sont utilisés pour le développement web côté client ?",
                    Categorie.Programmation, 3,
                    new List<string> { "HTML", "CSS", "JavaScript" },
                    new List<string> { "HTML", "CSS", "JavaScript", "Python", "C#" }),

                new QuestionReponsesMultiples(
                    "Quels sont les principes de la programmation orientée objet ?",
                    Categorie.Programmation, 3,
                    new List<string> { "Héritage", "Polymorphisme", "Encapsulation" },
                    new List<string> { "Héritage", "Polymorphisme", "Encapsulation", "Compilation", "Récursivité" }),

                new QuestionReponsesMultiples(
                    "Quels pays font partie du G7 ?",
                    Categorie.CultureGenerale, 2,
                    new List<string> { "Canada", "France", "Japon" },
                    new List<string> { "Canada", "France", "Japon", "Chine", "Russie" }),


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