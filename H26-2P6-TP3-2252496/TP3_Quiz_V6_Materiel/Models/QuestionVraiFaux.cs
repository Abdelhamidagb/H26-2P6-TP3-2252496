using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Interfaces;

namespace Models
{
    public class QuestionVraiFaux : IQuestion
    {
        public string Enonce { get; private set; }

        public Categorie Categorie { get; private set; }

        public int Points { get; private set; }

        public bool BonneReponse { get; private set; }

        public QuestionVraiFaux(string enonce,
                                Categorie categorie,
                                int points,
                                bool bonneReponse)
        {
            if (string.IsNullOrWhiteSpace(enonce))
                throw new ArgumentException(nameof(enonce));

            if (points <= 0)
                throw new ArgumentOutOfRangeException(nameof(points));

            Enonce = enonce;
            Categorie = categorie;
            Points = points;
            BonneReponse = bonneReponse;
        }

        public double CorrigerReponse(string reponse)
        {
            return ValiderReponse(reponse) ? Points : 0;
        }

        public bool ValiderReponse(string reponse)
        {
            bool estBool = bool.TryParse(reponse, out bool valeur);

            if (!estBool)
                return false;

            return valeur == BonneReponse;
        }
    }
}
