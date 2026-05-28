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

        public double MargeErreur { get; private set; }

        public string Indice { get; private set; }

        public double PenaliteIndice { get; private set; }

        public bool IndiceUtilise { get; private set; }

        public QuestionNumerique(string enonce,
                                 Categorie categorie,
                                 int points,
                                 double bonneReponse,
                                 double margeErreur,
                                 string indice,
                                 double penaliteIndice)
        {
            if (string.IsNullOrWhiteSpace(enonce))
                throw new ArgumentException();

            if (points <= 0)
                throw new ArgumentOutOfRangeException(nameof(points));

            if (margeErreur < 0)
                throw new ArgumentOutOfRangeException(nameof(margeErreur));

            if (string.IsNullOrWhiteSpace(indice))
                throw new ArgumentException();

            if (penaliteIndice < 0 || penaliteIndice > 1)
                throw new ArgumentOutOfRangeException(nameof(penaliteIndice));

            Enonce = enonce;
            Categorie = categorie;
            Points = points;
            BonneReponse = bonneReponse;
            MargeErreur = margeErreur;
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
            bool estNombre = double.TryParse(reponse, out double valeur);

            if (!estNombre)
                return false;

            return Math.Abs(valeur - BonneReponse) <= MargeErreur;
        }
    }
}
