using System;
using Models.Interfaces;

namespace Models
{
    public class QuestionReponseCourte : IQuestion
    {
        public string Enonce { get; private set; }

        public Categorie Categorie { get; private set; }

        public int Points { get; private set; }

        public string BonneReponse { get; private set; }

        public string Indice { get; private set; }

        public double PenaliteIndice { get; private set; }

        public bool IndiceUtilise { get; private set; }

        public QuestionReponseCourte(string enonce,
                                     Categorie categorie,
                                     int points,
                                     string bonneReponse,
                                     string indice,
                                     double penaliteIndice)
        {
            if (string.IsNullOrWhiteSpace(enonce))
                throw new ArgumentException();

            if (points <= 0)
                throw new ArgumentOutOfRangeException(nameof(points));

            if (string.IsNullOrWhiteSpace(bonneReponse))
                throw new ArgumentException();

            if (string.IsNullOrWhiteSpace(indice))
                throw new ArgumentException();

            if (penaliteIndice < 0 || penaliteIndice > 1)
                throw new ArgumentOutOfRangeException(nameof(penaliteIndice));

            Enonce = enonce;
            Categorie = categorie;
            Points = points;
            BonneReponse = bonneReponse;
            Indice = indice;
            PenaliteIndice = penaliteIndice;
        }

        public void UtiliserIndice()
        {
            IndiceUtilise = true;
        }

        public double CorrigerReponse(string reponse)
        {
            if (!ValiderReponse(reponse))
                return 0;

            return IndiceUtilise
                ? Points * (1 - PenaliteIndice)
                : Points;
        }

        public bool ValiderReponse(string reponse)
        {
            return BonneReponse.Trim().ToLower() ==
                   reponse.Trim().ToLower();
        }
    }
}