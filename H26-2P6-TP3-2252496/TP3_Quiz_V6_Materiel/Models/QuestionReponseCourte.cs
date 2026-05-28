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

        private bool indiceUtilise;

        public QuestionReponseCourte(string enonce, Categorie categorie, int points,
            string bonneReponse, string indice, double penaliteIndice)
        {
            if (string.IsNullOrWhiteSpace(bonneReponse))
                throw new ArgumentException("Bonne réponse invalide");

            if (string.IsNullOrWhiteSpace(enonce))
                throw new ArgumentException("Enoncé invalide");

            Enonce = enonce;
            Categorie = categorie;
            Points = points;
            BonneReponse = bonneReponse;
            Indice = indice;
            PenaliteIndice = penaliteIndice;
        }

        public void UtiliserIndice()
        {
            indiceUtilise = true;
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
            if (!ValiderReponse(reponse))
                return 0;

            return indiceUtilise ? Points * 0.5 : Points;
        }
    }
}