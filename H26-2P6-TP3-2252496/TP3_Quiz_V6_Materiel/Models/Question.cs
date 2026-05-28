using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Classe abstraite représentant la base commune à tous les types de questions.
    /// Implémente IQuestion et contient les propriétés partagées (énoncé, catégorie, points).
    /// </summary>
    public abstract class Question : IQuestion
    {
        #region Champs privés

        private string _enonce;
        private int _points;

        #endregion

        #region Propriétés

        /// <summary>
        /// Énoncé de la question.
        /// </summary>
        /// <exception cref="ArgumentException">Lancée si l'énoncé est null, vide ou composé uniquement d'espaces.</exception>
        public string Enonce
        {
            get => _enonce;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("L'énoncé ne peut pas être null, vide ou composé uniquement d'espaces.", nameof(value));
                _enonce = value;
            }
        }

        /// <summary>
        /// Catégorie de la question.
        /// </summary>
        public Categorie Categorie { get; set; }

        /// <summary>
        /// Nombre de points associés à la question.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Lancée si les points sont inférieurs ou égaux à 0.</exception>
        public int Points
        {
            get => _points;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Le nombre de points doit être strictement supérieur à 0.");
                _points = value;
            }
        }

        #endregion

        #region Constructeur

        /// <summary>
        /// Initialise une question avec un énoncé, une catégorie et un nombre de points.
        /// </summary>
        /// <param name="enonce">Énoncé de la question.</param>
        /// <param name="categorie">Catégorie de la question.</param>
        /// <param name="points">Nombre de points.</param>
        protected Question(string enonce, Categorie categorie, int points)
        {
            Enonce = enonce;
            Categorie = categorie;
            Points = points;
        }

        #endregion

        #region Méthodes abstraites

        /// <summary>
        /// Valide si la réponse fournie est correcte.
        /// </summary>
        /// <param name="reponse">Réponse de l'utilisateur.</param>
        /// <returns>true si la réponse est correcte ; sinon false.</returns>
        public abstract bool ValiderReponse(string reponse);

        /// <summary>
        /// Corrige la réponse et retourne le score obtenu.
        /// Une réponse valide donne tous les points ; une réponse invalide donne 0.
        /// </summary>
        /// <param name="reponse">Réponse de l'utilisateur.</param>
        /// <returns>Score obtenu (Points ou 0).</returns>
        public abstract double CorrigerReponse(string reponse);

        #endregion
    }
}
