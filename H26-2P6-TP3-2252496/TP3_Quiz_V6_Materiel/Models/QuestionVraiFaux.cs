using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Interfaces;

namespace Models
{ /// <summary>
  /// Représente une question dont la réponse est soit true, soit false.
  /// </summary>
    public class QuestionVraiFaux : Question
    {
        #region Propriétés

        /// <summary>
        /// Bonne réponse attendue (true ou false).
        /// </summary>
        public bool BonneReponse { get; set; }

        #endregion

        #region Constructeur

        /// <summary>
        /// Initialise une question vrai/faux.
        /// </summary>
        /// <param name="enonce">Énoncé de la question.</param>
        /// <param name="categorie">Catégorie de la question.</param>
        /// <param name="points">Nombre de points.</param>
        /// <param name="bonneReponse">Bonne réponse (true ou false).</param>
        public QuestionVraiFaux(string enonce, Categorie categorie, int points, bool bonneReponse)
            : base(enonce, categorie, points)
        {
            BonneReponse = bonneReponse;
        }

        #endregion

        #region Méthodes

        /// <summary>
        /// Valide si la réponse fournie correspond à la bonne réponse.
        /// </summary>
        /// <param name="reponse">Réponse de l'utilisateur sous forme de chaîne ("true" ou "false").</param>
        /// <returns>true si la réponse est correcte ; sinon false.</returns>
        public override bool ValiderReponse(string reponse)
        {
            if (reponse == null)
                return false;

            bool estBool = bool.TryParse(reponse, out bool valeur);
            if (!estBool)
                return false;

            return valeur == BonneReponse;
        }

        /// <summary>
        /// Corrige la réponse et retourne le score obtenu.
        /// </summary>
        /// <param name="reponse">Réponse de l'utilisateur.</param>
        /// <returns>Points si la réponse est correcte ; 0 sinon.</returns>
        public override double CorrigerReponse(string reponse)
        {
            return ValiderReponse(reponse) ? Points : 0;
        }

        #endregion
    }
}
