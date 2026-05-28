using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Interfaces;

namespace Models
{
    /// <summary>
    /// Classe abstraite représentant une question pouvant fournir un indice à l'utilisateur.
    /// Implémente IReponseAvecIndice en plus de Question.
    /// </summary>
    public abstract class QuestionAvecIndice : Question
    {
        #region Champs privés

        private string _indice;
        private double _penaliteIndice;

        #endregion

        #region Propriétés

        /// <summary>
        /// Texte de l'indice associé à la question.
        /// </summary>
        /// <exception cref="ArgumentException">Lancée si l'indice est null, vide ou composé uniquement d'espaces.</exception>
        public string Indice
        {
            get => _indice;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("L'indice ne peut pas être null, vide ou composé uniquement d'espaces.", nameof(value));
                _indice = value;
            }
        }

        /// <summary>
        /// Pénalité appliquée au score si l'indice est utilisé. Valeur comprise entre 0 et 1 inclus.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Lancée si la pénalité n'est pas entre 0 et 1.</exception>
        public double PenaliteIndice
        {
            get => _penaliteIndice;
            set
            {
                if (value < 0 || value > 1)
                    throw new ArgumentOutOfRangeException(nameof(value), "La pénalité de l'indice doit être comprise entre 0 et 1 inclus.");
                _penaliteIndice = value;
            }
        }

        /// <summary>
        /// Indique si l'indice a déjà été utilisé.
        /// </summary>
        public bool IndiceUtilise { get; private set; }

        #endregion

        #region Constructeur

        /// <summary>
        /// Initialise une question avec indice.
        /// </summary>
        /// <param name="enonce">Énoncé de la question.</param>
        /// <param name="categorie">Catégorie de la question.</param>
        /// <param name="points">Nombre de points.</param>
        /// <param name="indice">Texte de l'indice.</param>
        /// <param name="penaliteIndice">Pénalité appliquée si l'indice est utilisé (entre 0 et 1).</param>
        protected QuestionAvecIndice(string enonce, Categorie categorie, int points, string indice, double penaliteIndice)
            : base(enonce, categorie, points)
        {
            Indice = indice;
            PenaliteIndice = penaliteIndice;
            IndiceUtilise = false;
        }

        #endregion

        #region Méthodes

        /// <summary>
        /// Marque l'indice comme utilisé.
        /// </summary>
        public void UtiliserIndice()
        {
            IndiceUtilise = true;
        }

        /// <summary>
        /// Corrige la réponse en tenant compte de la pénalité si l'indice a été utilisé.
        /// </summary>
        /// <param name="reponse">Réponse de l'utilisateur.</param>
        /// <returns>Score obtenu (avec ou sans pénalité selon l'utilisation de l'indice).</returns>
        public override double CorrigerReponse(string reponse)
        {
            if (!ValiderReponse(reponse))
                return 0;

            if (IndiceUtilise)
                return Points * (1 - PenaliteIndice);

            return Points;
        }

        #endregion
    }
}
