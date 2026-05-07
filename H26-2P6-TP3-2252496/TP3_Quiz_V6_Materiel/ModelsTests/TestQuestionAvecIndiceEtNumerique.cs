//#define _TESTS_QUESTION_AVEC_INDICE_NUMERIQUE

using Models;

namespace TestsUnitaires
{
    [TestClass]
    public sealed class TestQuestionAvecIndiceEtNumerique
    {
        const string ENONCE_TEST = "Combien font 2 + 2 ?";
        const int POINTS_TEST = 10;

        const double BONNE_REPONSE = 4.0;

        const string INDICE_TEST = "Addition simple";
        const double PENALITE_TEST = 0.5;

        const string REPONSE_VALIDE = "4";
        const string REPONSE_INVALIDE = "5";
        const string REPONSE_NON_NUMERIQUE = "abc";

        // =========================
        // CREATION OBJET
        // =========================
#if _TESTS_QUESTION_AVEC_INDICE_NUMERIQUE
        QuestionNumerique CréerQuestionValide()
        {
            return new QuestionNumerique(
                ENONCE_TEST,
                Categorie.Mathematiques,
                POINTS_TEST,
                BONNE_REPONSE,
                INDICE_TEST,
                PENALITE_TEST);
        }



        // =========================
        // TESTS QUESTION AVEC INDICE
        // =========================

        [TestMethod]
        public void TestIndiceVide()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new QuestionNumerique(
                    ENONCE_TEST,
                    Categorie.Mathematiques,
                    POINTS_TEST,
                    BONNE_REPONSE,
                    "",
                    PENALITE_TEST));
        }

        [TestMethod]
        public void TestPenaliteHorsBornesNegatif()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                new QuestionNumerique(
                    ENONCE_TEST,
                    Categorie.Mathematiques,
                    POINTS_TEST,
                    BONNE_REPONSE,
                    INDICE_TEST,
                    -0.1));
        }

        [TestMethod]
        public void TestPenaliteHorsBornesTropGrand()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                new QuestionNumerique(
                    ENONCE_TEST,
                    Categorie.Mathematiques,
                    POINTS_TEST,
                    BONNE_REPONSE,
                    INDICE_TEST,
                    1.5));
        }

        [TestMethod]
        public void TestIndiceStocke()
        {
            var q = CréerQuestionValide();
            Assert.AreEqual(INDICE_TEST, q.Indice);
        }

        [TestMethod]
        public void TestPenaliteStockee()
        {
            var q = CréerQuestionValide();
            Assert.AreEqual(PENALITE_TEST, q.PenaliteIndice);
        }

        [TestMethod]
        public void TestIndiceUtilisation()
        {
            var q = CréerQuestionValide();

            Assert.IsFalse(q.IndiceUtilise);

            q.UtiliserIndice();

            Assert.IsTrue(q.IndiceUtilise);
        }

        [TestMethod]
        public void TestCorrigerSansIndice()
        {
            var q = CréerQuestionValide();
            Assert.AreEqual(POINTS_TEST, q.CorrigerReponse(REPONSE_VALIDE));
        }

        [TestMethod]
        public void TestCorrigerAvecIndice()
        {
            var q = CréerQuestionValide();

            q.UtiliserIndice();

            Assert.AreEqual(0, q.CorrigerReponse(REPONSE_VALIDE));
        }

        // =========================
        // TESTS QUESTION NUMERIQUE
        // =========================

        [TestMethod]
        public void TestBonneReponseStockee()
        {
            var q = CréerQuestionValide();
            Assert.AreEqual(BONNE_REPONSE, q.BonneReponse);
        }

        [TestMethod]
        public void TestValiderReponseCorrecte()
        {
            var q = CréerQuestionValide();
            Assert.IsTrue(q.ValiderReponse(REPONSE_VALIDE));
        }

        [TestMethod]
        public void TestValiderReponseIncorrecte()
        {
            var q = CréerQuestionValide();
            Assert.IsFalse(q.ValiderReponse(REPONSE_INVALIDE));
        }

        [TestMethod]
        public void TestValiderReponseNonNumerique()
        {
            var q = CréerQuestionValide();
            Assert.IsFalse(q.ValiderReponse(REPONSE_NON_NUMERIQUE));
        }

        [TestMethod]
        public void TestValiderReponseNull()
        {
            var q = CréerQuestionValide();
            Assert.IsFalse(q.ValiderReponse(null));
        }

#endif
    }
}