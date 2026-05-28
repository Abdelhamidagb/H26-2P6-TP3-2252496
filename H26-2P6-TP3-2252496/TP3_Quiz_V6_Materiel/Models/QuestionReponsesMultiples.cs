using System;
using System.Collections.Generic;
using System.Linq;
using Models.Interfaces;

namespace Models
{
    public class QuestionReponsesMultiples : IQuestion
    {
        public string Enonce { get; private set; }
        public Categorie Categorie { get; private set; }
        public int Points { get; private set; }

        public List<string> BonneReponse { get; private set; }
        public List<string> Options { get; private set; }

        public QuestionReponsesMultiples(string enonce, Categorie categorie, int points,
            List<string> bonneReponse, List<string> options)
        {
            if (bonneReponse == null)
                throw new ArgumentNullException(nameof(bonneReponse));

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            if (bonneReponse.Count == 0)
                throw new ArgumentException("Réponse vide");

            if (!bonneReponse.All(o => options.Contains(o)))
                throw new ArgumentException("Réponse hors options");

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

            List<string> reponses = reponse
                .Split(',')
                .Select(r => r.Trim())
                .ToList();

            return reponses.Count == BonneReponse.Count &&
                   reponses.All(r => BonneReponse.Contains(r));
        }

        public double CorrigerReponse(string reponse)
        {
            return ValiderReponse(reponse) ? Points : 0;
        }
    }
}
