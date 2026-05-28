using System;
using Models.Interfaces;

namespace Models
{
    public class QuestionNumerique : IQuestion
    {
        public string Enonce { get; private set; }
        public Categorie Categorie { get; private set; }
        public int Points { get; private set; }

        public double BonneReponse { get; private set; }

        public string Indice { get; private set; }
        public double PenaliteIndice { get; private set; }
        public bool IndiceUtilise { get; private set; }

        public QuestionNumerique(string enonce, Categorie categorie, int points,
            double bonneReponse, string indice, double penaliteIndice)
        {
            if (string.IsNullOrWhiteSpace(enonce))
                throw new ArgumentException("Enoncé invalide");

            if (points <= 0)
                throw new ArgumentOutOfRangeException(nameof(points));

            if (string.IsNullOrWhiteSpace(indice))
                throw new ArgumentException("Indice invalide");

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

        public bool ValiderReponse(string reponse)
        {
            if (!double.TryParse(reponse, out double val))
                return false;

            return val == BonneReponse;
        }

        public double CorrigerReponse(string reponse)
        {
            if (!ValiderReponse(reponse))
                return 0;

            return IndiceUtilise ? 0 : Points;
        }
    }
}
