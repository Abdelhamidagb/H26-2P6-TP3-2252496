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

        public List<string> ChoixReponses { get; private set; }

        public List<string> BonnesReponses { get; private set; }

        public QuestionReponsesMultiples(string enonce,
                                         Categorie categorie,
                                         int points,
                                         List<string> choixReponses,
                                         List<string> bonnesReponses)
        {
            if (string.IsNullOrWhiteSpace(enonce))
                throw new ArgumentException();

            if (points <= 0)
                throw new ArgumentOutOfRangeException(nameof(points));

            if (choixReponses == null || choixReponses.Count < 2)
                throw new ArgumentException();

            if (bonnesReponses == null || bonnesReponses.Count == 0)
                throw new ArgumentException();

            Enonce = enonce;
            Categorie = categorie;
            Points = points;
            ChoixReponses = choixReponses;
            BonnesReponses = bonnesReponses;
        }

        public double CorrigerReponse(string reponse)
        {
            return ValiderReponse(reponse) ? Points : 0;
        }

        public bool ValiderReponse(string reponse)
        {
            List<string> reponsesUtilisateur =
                reponse.Split(';')
                        .Select(r => r.Trim().ToLower())
                        .ToList();

            List<string> bonnes =
                BonnesReponses.Select(r => r.Trim().ToLower())
                               .ToList();

            return bonnes.All(reponsesUtilisateur.Contains)
                   && bonnes.Count == reponsesUtilisateur.Count;
        }
    }
}
