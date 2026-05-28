using System;
using System.Collections.Generic;
using Models.Interfaces;

namespace Models
{
    public class QuestionReponseUnique : IQuestion
    {
        public string Enonce { get; private set; }
        public Categorie Categorie { get; private set; }
        public int Points { get; private set; }

        public string BonneReponse { get; private set; }
        public List<string> Options { get; private set; }

        public QuestionReponseUnique(string enonce, Categorie categorie, int points,
            string bonneReponse, List<string> options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            if (options.Count < 2)
                throw new ArgumentException("Pas assez d'options");

            if (!options.Contains(bonneReponse))
                throw new ArgumentException("Bonne réponse invalide");

            if (string.IsNullOrWhiteSpace(enonce))
                throw new ArgumentException();

            Enonce = enonce;
            Categorie = categorie;
            Points = points;
            BonneReponse = bonneReponse;
            Options = options;
        }

        public bool ValiderReponse(string reponse)
        {
            if (string.IsNullOrWhiteSpace(reponse))
                return false;

            return reponse.Trim()
                .Equals(BonneReponse, StringComparison.OrdinalIgnoreCase);
        }

        public double CorrigerReponse(string reponse)
        {
            return ValiderReponse(reponse) ? Points : 0;
        }
    }
}
