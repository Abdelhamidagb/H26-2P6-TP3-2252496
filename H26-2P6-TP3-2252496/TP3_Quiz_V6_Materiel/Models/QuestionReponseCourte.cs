using System;
using Models.Interfaces;

namespace Models
{
    /// <summary>
    /// Représente une question dont la réponse est un court texte.
    /// La comparaison ignore la casse et les espaces en début et fin.
    /// Implémente IReponseAvecIndice via QuestionAvecIndice.
    /// </summary>
    public class QuestionReponseCourte : QuestionAvecIndice
    {
        #region Champs privés

        private string _bonneReponse;

        #endregion

        #region Propriétés

        /// <summary>
        /// Bonne réponse attendue (texte court).
        /// </summary>
        /// <exception cref="ArgumentException">Lancée si la bonne réponse est null, vide ou composée uniquement d'espaces.</exception>
        public string BonneReponse
        {
            get => _bonneReponse;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La bonne réponse ne peut pas être null, vide ou composée uniquement d'espaces.", nameof(value));
                _bonneReponse = value;
            }
        }

        #endregion

        #region Constructeur

        /// <summary>
        /// Initialise une question à réponse courte.
        /// </summary>
        /// <param name="enonce">Énoncé de la question.</param>
        /// <param name="categorie">Catégorie de la question.</param>
        /// <param name="points">Nombre de points.</param>
        /// <param name="bonneReponse">Bonne réponse attendue.</param>
        /// <param name="indice">Texte de l'indice.</param>
        /// <param name="penaliteIndice">Pénalité appliquée si l'indice est utilisé (entre 0 et 1).</param>
        public QuestionReponseCourte(string enonce, Categorie categorie, int points,
            string bonneReponse, string indice, double penaliteIndice)
            : base(enonce, categorie, points, indice, penaliteIndice)
        {
            BonneReponse = bonneReponse;
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