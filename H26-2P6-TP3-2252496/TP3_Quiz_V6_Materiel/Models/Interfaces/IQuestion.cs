using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IQuestion
    {
        string Enonce { get;  }   
        
        Categorie Categorie { get;  }
        int Points { get;  }

        bool ValiderReponse(string reponse);
        double CorrigerReponse(string reponse);
    }
   
}
