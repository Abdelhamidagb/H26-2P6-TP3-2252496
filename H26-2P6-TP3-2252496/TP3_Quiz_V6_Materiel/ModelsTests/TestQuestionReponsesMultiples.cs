//#define _TESTS_QUESTION_REPONSES_MULTIPLES

using Models;
using System.Collections.Generic;

namespace TestsUnitaires
{
    [TestClass]
    public sealed class TestQuestionReponsesMultiples
    {
        const string ENONCE_TEST = "Sélectionner les capitales";
        const int POINTS_TEST = 10;

        List<string> OPTIONS_VALIDES = new List<string>
        {
            "Paris",
            "Lyon",
            "Rome",
            "Madrid"
        };

        List<string> BONNES_REPONSES = new List<string>
        {
            "Paris",
            "Rome"
        };

        const string REPONSE_VALIDE = "Paris,Rome";
        const string REPONSE_VALIDE_ORDRE_DIFFERENT = "Rome,Paris";
        const string REPONSE_INVALIDE = "Paris,Lyon";
        const string REPONSE_VIDE = "";
#if _TESTS_QUESTION_REPONSES_MULTIPLES
        QuestionReponsesMultiples CréerQuestionValide()
        {
            return new QuestionReponsesMultiples(
                ENONCE_TEST,
                Categorie.CultureGenerale,
                POINTS_TEST,
                new List<string>(BONNES_REPONSES),
                new List<string>(OPTIONS_VALIDES));
        }



        [TestMethod]
        public void TestBonneReponseNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
                new QuestionReponsesMultiples(
                    ENONCE_TEST,
                    Categorie.CultureGenerale,
                    POINTS_TEST,
                    null,
                    OPTIONS_VALIDES));
        }

        [TestMethod]
        public void TestBonneReponseVide()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new QuestionReponsesMultiples(
                    ENONCE_TEST,
                    Categorie.CultureGenerale,
                    POINTS_TEST,
                    new List<string>(),
                    OPTIONS_VALIDES));
        }

        [TestMethod]
        public void TestBonneReponseHorsOptions()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new QuestionReponsesMultiples(
                    ENONCE_TEST,
                    Categorie.CultureGenerale,
                    POINTS_TEST,
                    new List<string> { "Tokyo" },
                    OPTIONS_VALIDES));
        }

        [TestMethod]
        public void TestBonneReponseStockee()
        {
            var q = CréerQuestionValide();
            CollectionAssert.AreEqual(BONNES_REPONSES, q.BonneReponse);
        }

        [TestMethod]
        public void TestOptionsStockees()
        {
            var q = CréerQuestionValide();
            CollectionAssert.AreEqual(OPTIONS_VALIDES, q.Options);
        }

        [TestMethod]
        public void TestValiderReponseValide()
        {
            var q = CréerQuestionValide();
            Assert.IsTrue(q.ValiderReponse(REPONSE_VALIDE));
        }

        [TestMethod]
        public void TestValiderReponseOrdreDifferent()
        {
            var q = CréerQuestionValide();
            Assert.IsTrue(q.ValiderReponse(REPONSE_VALIDE_ORDRE_DIFFERENT));
        }

        [TestMethod]
        public void TestValiderReponseInvalide()
        {
            var q = CréerQuestionValide();
            Assert.IsFalse(q.ValiderReponse(REPONSE_INVALIDE));
        }

        [TestMethod]
        public void TestValiderReponseVide()
        {
            var q = CréerQuestionValide();
            Assert.IsFalse(q.ValiderReponse(REPONSE_VIDE));
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