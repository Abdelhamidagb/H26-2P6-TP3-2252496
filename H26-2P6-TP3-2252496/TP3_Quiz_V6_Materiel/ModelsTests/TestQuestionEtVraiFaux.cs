//#define _TESTS_QUESTION_VRAI_FAUX

using Models;

namespace TestsUnitaires
{
    [TestClass]
    public sealed class TestQuestionEtVraiFaux
    {
        const string ENONCE_TEST = "Le ciel est bleu ?";
        const int POINTS_TEST = 10;

        const string REPONSE_TRUE = "true";
        const string REPONSE_FALSE = "false";
        const string REPONSE_INVALIDE = "abc";

        // =========================
        // CREATION OBJETS
        // =========================
#if _TESTS_QUESTION_VRAI_FAUX
        QuestionVraiFaux CréerQuestionVraie()
        {
            return new QuestionVraiFaux(
                ENONCE_TEST,
                Categorie.CultureGenerale,
                POINTS_TEST,
                true);
        }

        QuestionVraiFaux CréerQuestionFausse()
        {
            return new QuestionVraiFaux(
                ENONCE_TEST,
                Categorie.CultureGenerale,
                POINTS_TEST,
                false);
        }



        // =========================
        // TESTS QUESTION (classe de base)
        // =========================

        [TestMethod]
        public void TestEnonceVide()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new QuestionVraiFaux("", Categorie.Programmation, POINTS_TEST, true));
        }

        [TestMethod]
        public void TestPointsInvalides()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                new QuestionVraiFaux(ENONCE_TEST, Categorie.Programmation, 0, true));
        }

        [TestMethod]
        public void TestEnonceStocke()
        {
            var q = CréerQuestionVraie();
            Assert.AreEqual(ENONCE_TEST, q.Enonce);
        }

        [TestMethod]
        public void TestPointsStockes()
        {
            var q = CréerQuestionVraie();
            Assert.AreEqual(POINTS_TEST, q.Points);
        }

        [TestMethod]
        public void TestCategorieStockee()
        {
            var q = CréerQuestionVraie();
            Assert.AreEqual(Categorie.CultureGenerale, q.Categorie);
        }

        // =========================
        // TESTS QUESTIONVRAIFAUX
        // =========================

        [TestMethod]
        public void TestBonneReponseTrue()
        {
            var q = CréerQuestionVraie();
            Assert.IsTrue(q.BonneReponse);
        }

        [TestMethod]
        public void TestBonneReponseFalse()
        {
            var q = CréerQuestionFausse();
            Assert.IsFalse(q.BonneReponse);
        }

        [TestMethod]
        public void TestValiderReponseTrueCorrecte()
        {
            var q = CréerQuestionVraie();
            Assert.IsTrue(q.ValiderReponse(REPONSE_TRUE));
        }

        [TestMethod]
        public void TestValiderReponseFalseCorrecte()
        {
            var q = CréerQuestionFausse();
            Assert.IsTrue(q.ValiderReponse(REPONSE_FALSE));
        }

        [TestMethod]
        public void TestValiderReponseMauvaise()
        {
            var q = CréerQuestionVraie();
            Assert.IsFalse(q.ValiderReponse(REPONSE_FALSE));
        }

        [TestMethod]
        public void TestValiderReponseInvalide()
        {
            var q = CréerQuestionVraie();
            Assert.IsFalse(q.ValiderReponse(REPONSE_INVALIDE));
        }

        [TestMethod]
        public void TestValiderReponseNull()
        {
            var q = CréerQuestionVraie();
            Assert.IsFalse(q.ValiderReponse(null));
        }

#endif
    }
}