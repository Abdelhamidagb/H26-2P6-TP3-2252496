using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Interfaces;

namespace Models
{
    public static class OutilsQuiz
    {
        public static void MelangerQuestions(List<IQuestion> liste)
        {
            Random random = new Random();

            int nbPermutations = liste.Count * 4;

            for (int k = 0; k < nbPermutations; k++)
            {
                int i = random.Next(liste.Count);
                int j = random.Next(liste.Count);

                IQuestion temp = liste[i];
                liste[i] = liste[j];
                liste[j] = temp;

            }
        }
        /// <summary>
        /// Vérifie si tous les éléments d’une liste sont présents dans une autre liste.
        /// </summary>
        /// <param name="sousListe">Liste dont on veut vérifier l’inclusion.</param>
        /// <param name="liste">Liste principale dans laquelle on recherche les éléments.</param>
        /// <returns>
        /// true si tous les éléments de <paramref name="sousListe"/> sont contenus dans <paramref name="liste"/>, sinon false.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Lancée si l’une des listes est null.
        /// </exception>
        public static bool EstSousListe(List<string> sousListe, List<string> liste)
        {
            if (sousListe == null)
                throw new ArgumentNullException(nameof(sousListe));

            if (liste == null)
                throw new ArgumentNullException(nameof(liste));

            for (int i = 0; i < sousListe.Count; i++)
            {
                bool trouve = false;

                for (int j = 0; j < liste.Count; j++)
                {
                    if (sousListe[i].Equals(liste[j], StringComparison.OrdinalIgnoreCase))
                    {
                        trouve = true;
                        break;
                    }
                }

                if (!trouve)
                    return false;
            }

            return true;
        }
        /// <summary>
        /// Vérifie si les éléments d'une chaîne (séparés par un séparateur)
        /// sont tous présents dans une liste.
        /// </summary>
        /// <param name="chaine">Chaîne contenant les éléments (ex : "A,B,C").</param>
        /// <param name="liste">Liste de référence.</param>
        /// <param name="separateur">Caractère séparateur (ex : ',').</param>
        /// <returns>
        /// true si tous les éléments de la chaîne sont présents dans la liste ; sinon false.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Lancée si la chaîne ou la liste est null.
        /// </exception>
        public static bool EstSousListe(string chaine, List<string> liste, char separateur = ',')
        {
            if (chaine == null)
                throw new ArgumentNullException(nameof(chaine));

            if (liste == null)
                throw new ArgumentNullException(nameof(liste));

            string[] elements = chaine.Split(separateur);

            for (int i = 0; i < elements.Length; i++)
            {
                string element = elements[i].Trim();

                bool trouve = false;

                for (int j = 0; j < liste.Count; j++)
                {
                    if (element.Equals(liste[j], StringComparison.OrdinalIgnoreCase))
                    {
                        trouve = true;
                        break;
                    }
                }

                if (!trouve)
                    return false;
            }

            return true;
        }
        /// <summary>
        /// Vérifie si une liste contient une valeur donnée, sans tenir compte de la casse.
        /// </summary>
        /// <param name="liste">Liste dans laquelle effectuer la recherche.</param>
        /// <param name="valeur">Valeur à rechercher.</param>
        /// <returns>
        /// true si la valeur est présente dans la liste ; sinon false.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Lancée si la liste ou la valeur est null.
        /// </exception>
        public static bool Contient(List<string> liste, string valeur)
        {
            if (liste == null)
                throw new ArgumentNullException(nameof(liste));

            if (valeur == null)
                throw new ArgumentNullException(nameof(valeur));

            for (int i = 0; i < liste.Count; i++)
            {
                if (valeur.Equals(liste[i], StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }
    }
}
