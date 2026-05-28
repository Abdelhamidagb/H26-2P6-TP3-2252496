using System;
using Models.Interfaces;

namespace Models
{    /// <summary>
     /// Représente une question dont la réponse attendue est un nombre.
     /// Implémente IReponseAvecIndice via QuestionAvecIndice.
     /// </summary>
    public class QuestionNumerique : QuestionAvecIndice
    {
        #region Propriétés

        /// <summary>
        /// Bonne réponse numérique attendue.
        /// </summary>
        public double BonneReponse { get; set; }

        #endregion

        #region Constructeur

        /// <summary>
        /// Initialise une question numérique.
        /// </summary>
        /// <param name="enonce">Énoncé de la question.</param>
        /// <param name="categorie">Catégorie de la question.</param>
        /// <param name="points">Nombre de points.</param>
        /// <param name="bonneReponse">Valeur numérique attendue.</param>
        /// <param name="indice">Texte de l'indice.</param>
        /// <param name="penaliteIndice">Pénalité appliquée si l'indice est utilisé (entre 0 et 1).</param>
        public QuestionNumerique(string enonce, Categorie categorie, int points,
            double bonneReponse, string indice, double penaliteIndice)
            : base(enonce, categorie, points, indice, penaliteIndice)
        {
            BonneReponse = bonneReponse;
        }

        #endregion

        #region Méthodes

        /// <summary>
        /// Valide si la réponse fournie correspond exactement à la bonne réponse numérique.
        /// Si la réponse n'est pas un nombre valide, elle est considérée comme incorrecte.
        /// </summary>
        /// <param name="reponse">Réponse de l'utilisateur sous forme de chaîne.</param>
        /// <returns>true si la réponse est correcte ; sinon false.</returns>
        public override bool ValiderReponse(string reponse)
        {
            if (reponse == null)
                return false;

            bool estNumerique = double.TryParse(reponse, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out double valeur);

            if (!estNumerique)
                return false;

            return valeur == BonneReponse;
        }

        #endregion
    }
}
