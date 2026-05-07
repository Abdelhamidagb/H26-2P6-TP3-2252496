using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Interfaces;

namespace Models
{
    public class QuestionVraiFaux:IQuestion
    {
        public string Enonce { get; set; }
        public Categorie Categorie { get; set; }
        public int Points { get; set; }
        public bool BonneReponse { get; set; }
        
        
      
        public QuestionVraiFaux(string enonce,
                                Categorie categorie,
                                int points,
                                bool bonneReponse)

        {
            Enonce = enonce;
            Categorie = categorie;
            Points = points;
            BonneReponse = bonneReponse;
        }

        public double CorrigerReponse(string reponse)
        {
           
            bool estValide = bool.TryParse(reponse, out bool val);
            if(!estValide)
            {
                return 0;
                
            }

            return val == BonneReponse ? Points : 0;
        }
        public bool ValiderReponse(string reponse)
        {
            bool estBool = bool.TryParse(reponse, out bool val);
            if (estBool)
            {
                return val == BonneReponse;
            }
            return false;

        }

    }


    
}
