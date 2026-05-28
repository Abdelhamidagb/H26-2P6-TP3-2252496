using System;
using System.Collections.Generic;
using System.Linq;
using Models.Interfaces;

namespace Models
{
    /// <summary>
    /// Représente une question avec plusieurs options et plusieurs bonnes réponses possibles.
    /// La réponse utilisateur est une chaîne de valeurs séparées par des virgules.
    /// </summary>
    public class QuestionReponsesMultiples : QuestionAvecOptions
    {
        #region Champs privés

        private List<string> _bonneReponse;

        #endregion

        #region Propriétés

        /// <summary>
        /// Liste des bonnes réponses (chaque réponse doit être présente dans les options).
        /// </summary>
        /// <exception cref="ArgumentNullException">Lancée si la liste est null.</exception>
        /// <exception cref="ArgumentException">Lancée si la liste est vide ou si une réponse n'est pas dans les options.</exception>
        public List<string> BonneReponse
        {
            get => _bonneReponse;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value), "La liste des bonnes réponses ne peut pas être null.");
                if (value.Count == 0)
                    throw new ArgumentException("La liste des bonnes réponses ne peut pas être vide.", nameof(value));
                if (Options != null && !OutilsQuiz.EstSousListe(value, Options))
                    throw new ArgumentException("Chaque bonne réponse doit être présente dans la liste des options.", nameof(value));
                _bonneReponse = value;
            }
        }

        #endregion

        #region Constructeur

        /// <summary>
        /// Initialise une question à réponses multiples.
        /// </summary>
        /// <param name="enonce">Énoncé de la question.</param>
        /// <param name="categorie">Catégorie de la question.</param>
        /// <param name="points">Nombre de points.</param>
        /// <param name="bonnesReponses">Liste des bonnes réponses.</param>
        /// <param name="options">Liste des options disponibles.</param>
        public QuestionReponsesMultiples(string enonce, Categorie categorie, int points,
            List<string> bonnesReponses, List<string> options)
            : base(enonce, categorie, points, options)
        {
            // Valider bonnesReponses après avoir assigné les options
            if (bonnesReponses == null)
                throw new ArgumentNullException(nameof(bonnesReponses), "La liste des bonnes réponses ne peut pas être null.");
            if (bonnesReponses.Count == 0)
                throw new ArgumentException("La liste des bonnes réponses ne peut pas être vide.", nameof(bonnesReponses));
            if (!OutilsQuiz.EstSousListe(bonnesReponses, Options))
                throw new ArgumentException("Chaque bonne réponse doit être présente dans la liste des options.", nameof(bonnesReponses));
            _bonneReponse = bonnesReponses;
        }

        #endregion

        #region Méthodes

        /// <summary>
        /// Valide si la réponse fournie correspond exactement à l'ensemble des bonnes réponses.
        /// La réponse est une chaîne de valeurs séparées par des virgules.
        /// L'ordre n'a pas d'importance.
        /// </summary>
        /// <param name="reponse">Réponse de l'utilisateur (ex : "Paris,Rome").</param>
        /// <returns>true si la réponse contient exactement les bonnes réponses ; sinon false.</returns>
        public override bool ValiderReponse(string reponse)
        {
            if (reponse == null)
                return false;

            if (reponse.Trim() == "")
                return false;

            // Vérifier que toutes les bonnes réponses sont dans la réponse de l'utilisateur
            bool toutesPresentes = OutilsQuiz.EstSousListe(BonneReponse, ConvertirEnListe(reponse));

            // Vérifier que toutes les réponses de l'utilisateur sont dans les bonnes réponses
            bool pasDeSuperflu = OutilsQuiz.EstSousListe(ConvertirEnListe(reponse), BonneReponse);

            return toutesPresentes && pasDeSuperflu;
        }

        /// <summary>
        /// Convertit une chaîne séparée par des virgules en liste de chaînes.
        /// </summary>
        private List<string> ConvertirEnListe(string chaine)
        {
            List<string> liste = new List<string>();
            string[] elements = chaine.Split(',');
            foreach (string element in elements)
            {
                liste.Add(element.Trim());
            }
            return liste;
        }

        #endregion
    }
}
