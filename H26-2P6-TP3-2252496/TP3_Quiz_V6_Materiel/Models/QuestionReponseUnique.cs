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

        public List<string> ChoixReponses { get; private set; }

        public string BonneReponse { get; private set; }

        public QuestionReponseUnique(string enonce,
                                     Categorie categorie,
                                     int points,
                                     List<string> choixReponses,
                                     string bonneReponse)
        {
            if (string.IsNullOrWhiteSpace(enonce))
                throw new ArgumentException();

            if (points <= 0)
                throw new ArgumentOutOfRangeException(nameof(points));

            if (choixReponses == null || choixReponses.Count < 2)
                throw new ArgumentException();

            if (string.IsNullOrWhiteSpace(bonneReponse))
                throw new ArgumentException();

            Enonce = enonce;
            Categorie = categorie;
            Points = points;
            ChoixReponses = choixReponses;
            BonneReponse = bonneReponse;
        }

        public double CorrigerReponse(string reponse)
        {
            return ValiderReponse(reponse) ? Points : 0;
        }

        public bool ValiderReponse(string reponse)
        {
            return BonneReponse.Trim().ToLower() ==
                   reponse.Trim().ToLower();
        }
    }
}
