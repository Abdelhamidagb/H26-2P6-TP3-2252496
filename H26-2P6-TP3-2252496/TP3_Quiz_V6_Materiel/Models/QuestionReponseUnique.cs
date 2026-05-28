using System;
using System.Collections.Generic;
using Models.Interfaces;

namespace Models
{
    /// <summary>
    /// Représente une question avec plusieurs options et une seule bonne réponse.
    /// </summary>
    public class QuestionReponseUnique : QuestionAvecOptions
    {
        #region Champs privés

        private string _bonneReponse;

        #endregion

        #region Propriétés

        /// <summary>
        /// Bonne réponse (doit être présente dans la liste des options).
        /// </summary>
        /// <exception cref="ArgumentException">Lancée si la bonne réponse est null, vide ou absente des options.</exception>
        public string BonneReponse
        {
            get => _bonneReponse;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La bonne réponse ne peut pas être null, vide ou composée uniquement d'espaces.", nameof(value));
                if (Options != null && !OutilsQuiz.Contient(Options, value))
                    throw new ArgumentException("La bonne réponse doit être présente dans la liste des options.", nameof(value));
                _bonneReponse = value;
            }
        }

        #endregion

        #region Constructeur

        /// <summary>
        /// Initialise une question à réponse unique.
        /// </summary>
        /// <param name="enonce">Énoncé de la question.</param>
        /// <param name="categorie">Catégorie de la question.</param>
        /// <param name="points">Nombre de points.</param>
        /// <param name="bonneReponse">Bonne réponse parmi les options.</param>
        /// <param name="options">Liste des options disponibles.</param>
        public QuestionReponseUnique(string enonce, Categorie categorie, int points,
            string bonneReponse, List<string> options)
            : base(enonce, categorie, points, options)
        {
            // Valider bonneReponse après avoir assigné les options
            if (string.IsNullOrWhiteSpace(bonneReponse))
                throw new ArgumentException("La bonne réponse ne peut pas être null, vide ou composée uniquement d'espaces.", nameof(bonneReponse));
            if (!OutilsQuiz.Contient(Options, bonneReponse))
                throw new ArgumentException("La bonne réponse doit être présente dans la liste des options.", nameof(bonneReponse));
            _bonneReponse = bonneReponse;
        }

        #endregion

        #region Méthodes

        /// <summary>
        /// Valide si la réponse fournie correspond à la bonne réponse,
        /// en ignorant la casse et les espaces inutiles.
        /// </summary>
        /// <param name="reponse">Réponse de l'utilisateur.</param>
        /// <returns>true si la réponse est correcte ; sinon false.</returns>
        public override bool ValiderReponse(string reponse)
        {
            if (reponse == null)
                return false;

            return reponse.Trim().Equals(BonneReponse.Trim(), StringComparison.OrdinalIgnoreCase);
        }

        #endregion
    }
}
