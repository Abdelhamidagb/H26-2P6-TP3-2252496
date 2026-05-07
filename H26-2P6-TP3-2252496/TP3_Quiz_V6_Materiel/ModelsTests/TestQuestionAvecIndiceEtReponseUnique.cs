//#define _TESTS_QUESTION_REPONSE_UNIQUE

using Models;
using System.Collections.Generic;
using System.Linq;

namespace TestsUnitaires
{
    [TestClass]
    public sealed class TestQuestionAvecIndiceEtReponseUnique
    {
        const string ENONCE_TEST = "Quelle est la capitale ?";
        const int POINTS_TEST = 10;

        List<string> OPTIONS_VALIDES = new List<string>
        {
            "Paris",
            "Lyon",
            "Marseille",
            "Nice"
        };

        const string BONNE_REPONSE = "Paris";

        const string REPONSE_VALIDE = "Paris";
        const string REPONSE_VALIDE_CASSE = "paris";
        const string REPONSE_VALIDE_ESPACES = "  Paris  ";
        const string REPONSE_INVALIDE = "Lyon";
#if _TESTS_QUESTION_REPONSE_UNIQUE
        // =========================
        // CREATION OBJET
        // =========================
        QuestionReponseUnique CréerQuestionValide()
        {
            return new QuestionReponseUnique(
                ENONCE_TEST,
                Categorie.CultureGenerale,
                POINTS_TEST,
                BONNE_REPONSE,
                new List<string>(OPTIONS_VALIDES));
        }



        // =========================
        // TESTS CONSTRUCTEUR
        // =========================

        [TestMethod]
        public void TestOptionsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
                new QuestionReponseUnique(
                    ENONCE_TEST,
                    Categorie.CultureGenerale,
                    POINTS_TEST,
                    BONNE_REPONSE,
                    null));
        }

        [TestMethod]
        public void TestOptionsTropPeu()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new QuestionReponseUnique(
                    ENONCE_TEST,
                    Categorie.CultureGenerale,
                    POINTS_TEST,
                    BONNE_REPONSE,
                    new List<string> { "Paris" }));
        }

        [TestMethod]
        public void TestBonneReponseHorsOptions()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new QuestionReponseUnique(
                    ENONCE_TEST,
                    Categorie.CultureGenerale,
                    POINTS_TEST,
                    "Tokyo",
                    OPTIONS_VALIDES));
        }

        [TestMethod]
        public void TestBonneReponseStockee()
        {
            var q = CréerQuestionValide();
            Assert.AreEqual(BONNE_REPONSE, q.BonneReponse);
        }

        [TestMethod]
        public void TestOptionsStockees()
        {
            var q = CréerQuestionValide();
            CollectionAssert.AreEqual(OPTIONS_VALIDES, q.Options);
        }



        // =========================
        // TESTS VALIDATION REPONSE
        // =========================

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

#endif
    }
}