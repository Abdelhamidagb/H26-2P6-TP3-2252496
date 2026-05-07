//#define _TESTS_QUESTION_REPONSE_COURTE

using Models;

namespace TestsUnitaires
{
    [TestClass]
    public sealed class TestQuestionReponseCourte
    {
        const string ENONCE_TEST = "Capitale de la France ?";
        const int POINTS_TEST = 10;
        const string BONNE_REPONSE_TEST = "Paris";
        const string INDICE_TEST = "Ville lumière";
        const double PENALITE_TEST = 0.5;

        const string REPONSE_VALIDE = "Paris";
        const string REPONSE_VALIDE_CASSE = "paris";
        const string REPONSE_VALIDE_ESPACES = "  Paris  ";
        const string REPONSE_INVALIDE = "Lyon";
#if _TESTS_QUESTION_REPONSE_COURTE
        QuestionReponseCourte CréerQuestionValide()
        {
            return new QuestionReponseCourte(
                ENONCE_TEST,
                Categorie.CultureGenerale,
                POINTS_TEST,
                BONNE_REPONSE_TEST,
                INDICE_TEST,
                PENALITE_TEST);
        }



        [TestMethod]
        public void TestBonneReponseVide()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new QuestionReponseCourte(ENONCE_TEST, Categorie.CultureGenerale,
                    POINTS_TEST, "", INDICE_TEST, PENALITE_TEST));
        }

        [TestMethod]
        public void TestBonneReponse()
        {
            var q = CréerQuestionValide();
            Assert.AreEqual(BONNE_REPONSE_TEST, q.BonneReponse);
        }

        [TestMethod]
        public void TestValiderReponseExacte()
        {
            var q = CréerQuestionValide();
            Assert.IsTrue(q.ValiderReponse(REPONSE_VALIDE));
        }

        [TestMethod]
        public void TestValiderReponseCasseDifferente()
        {
            var q = CréerQuestionValide();
            Assert.IsTrue(q.ValiderReponse(REPONSE_VALIDE_CASSE));
        }

        [TestMethod]
        public void TestValiderReponseAvecEspaces()
        {
            var q = CréerQuestionValide();
            Assert.IsTrue(q.ValiderReponse(REPONSE_VALIDE_ESPACES));
        }

        [TestMethod]
        public void TestValiderReponseInvalide()
        {
            var q = CréerQuestionValide();
            Assert.IsFalse(q.ValiderReponse(REPONSE_INVALIDE));
        }

        [TestMethod]
        public void TestValiderReponseNull()
        {
            var q = CréerQuestionValide();
            Assert.IsFalse(q.ValiderReponse(null));
        }

        [TestMethod]
        public void TestCorrigerReponseValideSansIndice()
        {
            var q = CréerQuestionValide();
            Assert.AreEqual(POINTS_TEST, q.CorrigerReponse(REPONSE_VALIDE));
        }

        [TestMethod]
        public void TestCorrigerReponseAvecIndice()
        {
            var q = CréerQuestionValide();
            q.UtiliserIndice();

            Assert.AreEqual(5, q.CorrigerReponse(REPONSE_VALIDE));
        }

#endif
    }
}