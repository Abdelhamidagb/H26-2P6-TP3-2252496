using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{ /// <summary>
  /// Classe abstraite représentant une question avec une liste d'options.
  /// Fournit les validations communes et la méthode de mélange des options.
  /// </summary>
    public abstract class QuestionAvecOptions : Question
    {
        #region Champs privés

        private List<string> _options;

        #endregion

        #region Propriétés

        /// <summary>
        /// Liste des options disponibles pour la question.
        /// </summary>
        /// <exception cref="ArgumentNullException">Lancée si la liste est null.</exception>
        /// <exception cref="ArgumentException">Lancée si la liste contient moins de 2 éléments.</exception>
        public List<string> Options
        {
            get => _options;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value), "La liste des options ne peut pas être null.");
                if (value.Count < 2)
                    throw new ArgumentException("La liste des options doit contenir au moins 2 éléments.", nameof(value));
                _options = value;
            }
        }

        #endregion

        #region Constructeur

        /// <summary>
        /// Initialise une question avec des options.
        /// </summary>
        /// <param name="enonce">Énoncé de la question.</param>
        /// <param name="categorie">Catégorie de la question.</param>
        /// <param name="points">Nombre de points.</param>
        /// <param name="options">Liste des options disponibles.</param>
        protected QuestionAvecOptions(string enonce, Categorie categorie, int points, List<string> options)
            : base(enonce, categorie, points)
        {
            Options = options;
        }

        #endregion

        #region Méthodes

        /// <summary>
        /// Mélange aléatoirement l'ordre des options.
        /// </summary>
        public void MelangerOptions()
        {
            Random random = new Random();
            int n = Options.Count;

            for (int k = 0; k < n * 4; k++)
            {
                int i = random.Next(n);
                int j = random.Next(n);
                string temp = Options[i];
                Options[i] = Options[j];
                Options[j] = temp;
            }
        }

        /// <summary>
        /// Corrige la réponse de base : points si valide, 0 sinon.
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
