using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSS.pgr866.Practica_02;

namespace PSS.pgr866.Practica_02
{
    [TestClass]
    public class TestUsuarioView
    {

        [TestMethod]
        public void EqualsIEquality_MismoIdDiferenteObjeto()
        {
            UsuarioView user1 = new UsuarioView(1, "Pepe", "palabra1", "Investigador", false);
            UsuarioView user2 = new UsuarioView(1, "Pablo", "palabra2", "Investigador", true);
            
            Assert.IsTrue(Equals(user1, user2));
        }

        [TestMethod]
        public void EqualsIEquality_MismaReferencia()
        {
            UsuarioView user1 = new UsuarioView(7, "Pepe", "palabra1", "Investigador", true);
            UsuarioView user2 = user1;

            Assert.IsTrue(Equals(user1, user2));
        }

        [TestMethod]
        public void EqualsIEquality_DiferenteId()
        {
            UsuarioView user1 = new UsuarioView(9, "Luis", "palabra3", "Docente", true);
            UsuarioView user2 = new UsuarioView(3, "Oscar", "palabra2", "Ingeniero", false);

            Assert.IsFalse(Equals(user1, user2));
        }


        [TestMethod]
        public void EqualsIEquality_ParametroNull()
        {
            UsuarioView user1 = new UsuarioView(8, "Luis", "palabra3", "Docente", false);
            UsuarioView user2 = null;

            Assert.IsFalse(Equals(user1, user2));
        }

        [TestMethod]
        public void EqualsIEquality_ParametrosNull()
        {
            UsuarioView user1 = null;
            UsuarioView user2 = null;

            Assert.IsTrue(Equals(user1, user2));
        }

        [TestMethod]
        public void EqualsIEquatable_MismoIdDiferenteObjeto()
        {
            UsuarioView user1 = new UsuarioView(1, "Felipe", "palabra1", "Investigador" ,false);
            UsuarioView user2 = new UsuarioView(1, "Antonio", "palabra2", "Ingeniero", false);

            Assert.IsTrue(user1.Equals(user2));
        }

        [TestMethod]
        public void EqualsIEquatable_MismaReferencia()
        {
            UsuarioView user1 = new UsuarioView(4, "Felipe", "palabra1", "Investigador", false);
            UsuarioView user2 = user1;

            Assert.IsTrue(user1.Equals(user2));
        }

        [TestMethod]
        public void EqualsIEquatable_DiferenteId()
        {
            UsuarioView user1 = new UsuarioView(2, "Felipe", "palabra1", "Investigador", true);
            UsuarioView user2 = new UsuarioView(5, "Antonio", "palabra2", "Ingeniero", false);

            Assert.IsFalse(user1.Equals(user2));
        }

        [TestMethod]
        public void EqualsIEquatable_ParametroNull()
        {
            UsuarioView user1 = new UsuarioView(1, "Felipe", "palabra3", "Investigador", false);
            UsuarioView user2 = null;

            Assert.IsFalse(user1.Equals(user2));
        }

        [TestMethod]
        public void EqualsObject_MismoIdDiferenteObjeto()
        {
            UsuarioView user1 = new UsuarioView(2, "Felipe", "palabra1", "Investigador", false);
            UsuarioView user2 = new UsuarioView(2, "Antonio", "palabra2", "Investigador", false);

            Assert.IsTrue(user1.Equals(user2 as object));
        }

        [TestMethod]
        public void EqualsObject_MismaReferencia()
        {
            UsuarioView user1 = new UsuarioView(1, "Felipe", "palabra1", "Investigador", true);
            UsuarioView user2 = user1;

            Assert.IsTrue(user1.Equals(user2 as object));
        }

        [TestMethod]
        public void EqualsObject_DiferenteId()
        {
            UsuarioView user1 = new UsuarioView(1, "Felipe", "palabra3", "Investigador", false);
            UsuarioView user2 = new UsuarioView(3, "Antonio", "palabra2", "Investigador", true);

            Assert.IsFalse(user1.Equals(user2 as object));
        }

        [TestMethod]
        public void EqualsObject_ParametroNull()
        {
            UsuarioView user1 = new UsuarioView(6, "Felipe", "palabra3", "Investigador", true);
            UsuarioView user2 = null;

            Assert.IsFalse(user1.Equals(user2 as object));
        }

        [TestMethod]
        public void OpIgualQue_MismoIdDiferenteObjeto()
        {
            UsuarioView user1 = new UsuarioView(1, "Antonio", "palabra3", "Ingeniero", false);
            UsuarioView user2 = new UsuarioView(1, "Felipe", "palabra1", "Ingeniero", true);

            Assert.IsTrue(user1 == user2);
        }

        [TestMethod]
        public void OpIgualQue_MismaReferencia()
        {
            UsuarioView user1 = new UsuarioView(1, "Antonio", "palabra3", "Ingeniero", false);
            UsuarioView user2 = user1;

            Assert.IsTrue(user1 == user2);
        }

        [TestMethod]
        public void OpIgualQue_ParametrosNull()
        {
            UsuarioView user1 = null;
            UsuarioView user2 = null;

            Assert.IsTrue(user1 == user2);

        }

        [TestMethod]
        public void OpIgualQue_DiferenteId()
        {
            UsuarioView user1 = new UsuarioView(1, "Antonio", "palabra3", "Ingeniero", true);
            UsuarioView user2 = new UsuarioView(13, "Felipe", "palabra1", "Informatica ", false);

            Assert.IsFalse(user1 == user2);
        }

        [TestMethod]
        public void OpIgualQue_ParametroNull()
        {
            UsuarioView user1 = new UsuarioView(1, "Antonio", "palabra3", "Ingeniero", true);
            UsuarioView user2 = null;

            Assert.IsFalse(user2 == user1);
        }

        [TestMethod]
        public void OpDistintoDe_DiferenteId()
        {
            UsuarioView user1 = new UsuarioView(1, "Luis", "palabra2", "Investigador", false);
            UsuarioView user2 = new UsuarioView(17, "Pablo", "palabra1", "Investigador ", true);

            Assert.IsTrue(user1 != user2);

        }

        [TestMethod]
        public void OpDistintoDe_ParametrosNull()
        {
            UsuarioView user1 = null;
            UsuarioView user2 = null;

            Assert.IsFalse(user1 != user2);
        }

        [TestMethod]
        public void OpDistintoDe_ParametroNull()
        {
            UsuarioView user1 = new UsuarioView(5, "Oscar", "palabra3", "Docente", false);
            UsuarioView user2 = null;

            Assert.IsTrue(user1 != user2);
        }

        [TestMethod]
        public void OpDistintoDe_MismoIdDiferenteObjeto()
        {
            UsuarioView user1 = new UsuarioView(5, "Antonio", "palabra2", "Ingeniero", false);
            UsuarioView user2 = new UsuarioView(5, "Pepe", "palabra3", "Investigador", false);

            Assert.IsFalse(user1 != user2);
        }

        [TestMethod]
        public void OpDistintoDe_MismaReferencia()
        {
            UsuarioView user1 = new UsuarioView(5, "Antonio", "palabra3", "Ingeniero", false);
            UsuarioView user2 = user1;

            Assert.IsFalse(user1 != user2);
        }

        [TestMethod]
        public void GetHashCode_MismoYDistintoId()
        {
            UsuarioView user1 = new UsuarioView(1, "Anotnio", "palabra1", "Investigador", false);
            UsuarioView user2 = new UsuarioView(1, "Oscar", "palabra2", "Docente", true);
            UsuarioView user3 = new UsuarioView(3, "Felipe", "palabra3", "Docente", false);
            UsuarioView user4 = new UsuarioView(3, "Pepe", "palabra1", "Ingeniero", true);

            Assert.AreEqual(user1.GetHashCode(), user1.GetHashCode(user2));
            Assert.AreNotEqual(user1.GetHashCode(), user1.GetHashCode(user3));
            Assert.AreNotEqual(user2.GetHashCode(), user2.GetHashCode(user4));
        }

        [TestMethod]
        public void CompareTo_MismaReferencia()
        {
            UsuarioView A = new UsuarioView(1, "Pepe", "palabra1", "Investigador", false);

            Assert.IsTrue(A.CompareTo(A) == 0);
        }

        [TestMethod]
        public void CompareTo_MismoId()
        {
            UsuarioView A = new UsuarioView(1, "Pepe", "palabra1", "Investigador", false);
            UsuarioView B = new UsuarioView(1, "Oscar", "palabra2", "Docente", true);

            Assert.IsTrue(A.CompareTo(B) == 0 && B.CompareTo(A) == 0);
        }

        [TestMethod]
        public void CompareTo_TresMismoId()
        {
            UsuarioView A = new UsuarioView(1, "Pepe", "palabra1", "Investigador", false);
            UsuarioView B = new UsuarioView(1, "Oscar", "palabra2", "Docente", true);
            UsuarioView C = new UsuarioView(1, "Anotnio", "palabra1", "Investigador", false);

            Assert.IsTrue(A.CompareTo(B) == 0 && B.CompareTo(C) == 0 && A.CompareTo(C) == 0);
        }

        [TestMethod]
        public void CompareTo_DistintoId()
        {
            UsuarioView A = new UsuarioView(1, "Pepe", "palabra1", "Investigador", false);
            UsuarioView B = new UsuarioView(2, "Oscar", "palabra2", "Docente", true);

            Assert.IsTrue(A.CompareTo(B) != 0 && B.CompareTo(A) == -1 * A.CompareTo(B));
        }

        [TestMethod]
        public void CompareTo_TresDistintoId()
        {
            UsuarioView A = new UsuarioView(1, "Pepe", "palabra1", "Investigador", false);
            UsuarioView B = new UsuarioView(2, "Oscar", "palabra2", "Docente", true);
            UsuarioView C = new UsuarioView(3, "Anotnio", "palabra1", "Investigador", false);

            Assert.IsTrue(A.CompareTo(B) != 0 && A.CompareTo(B) == B.CompareTo(C) && A.CompareTo(B) == A.CompareTo(C));
        }

        [TestMethod]
        public void CompareTo_Menor()
        {
            UsuarioView A = new UsuarioView(1, "Pepe", "palabra1", "Investigador", false);
            UsuarioView B = new UsuarioView(2, "Oscar", "palabra2", "Docente", true);

            Assert.IsTrue(A.CompareTo(B) < 0);
        }

        [TestMethod]
        public void CompareTo_Mayor()
        {
            UsuarioView A = new UsuarioView(1, "Pepe", "palabra1", "Investigador", false);
            UsuarioView B = new UsuarioView(2, "Oscar", "palabra2", "Docente", true);

            Assert.IsTrue(B.CompareTo(A) > 0);
        }

        [TestMethod]
        public void CompareTo_Null()
        {
            UsuarioView A = new UsuarioView(1, "Pepe", "palabra1", "Investigador", false);
            UsuarioView B = null;

            Assert.IsTrue(A.CompareTo(B) > 0);
        }

        [TestMethod]
        public void OpMenorQue_ParametroNull()
        {
            UsuarioView A = new UsuarioView(1, "Pepe", "palabra1", "Investigador", false);
            UsuarioView B = null;

            Assert.IsTrue(B < A);
        }

        [TestMethod]
        public void OpMenorQue_ParametrosNull()
        {
            UsuarioView A = null;
            UsuarioView B = null;

            Assert.IsFalse(B < A);
        }

        [TestMethod]
        public void OpMenorQue_DistintoId()
        {
            UsuarioView A = new UsuarioView(1, "Pepe", "palabra1", "Investigador", false);
            UsuarioView B = new UsuarioView(2, "Oscar", "palabra2", "Docente", true);

            Assert.IsTrue(A < B);
        }

        [TestMethod]
        public void OpMenorQue_MismaReferencia()
        {
            UsuarioView A = new UsuarioView(1, "Pepe", "palabra1", "Investigador", false);

            Assert.IsFalse(A < A);
        }

        [TestMethod]
        public void OpMenorQue_MismoIdDiferenteObjeto()
        {
            UsuarioView A = new UsuarioView(1, "Pepe", "palabra1", "Investigador", false);
            UsuarioView B = new UsuarioView(1, "Oscar", "palabra2", "Docente", true);

            Assert.IsFalse(A < B);
        }

        [TestMethod]
        public void OpMayorQue_ParametroNull()
        {
            UsuarioView A = new UsuarioView(1, "Pepe", "palabra1", "Investigador", false);
            UsuarioView B = null;

            Assert.IsTrue(A > B);
        }

        [TestMethod]
        public void OpMayorQue_ParametrosNull()
        {
            UsuarioView A = null;
            UsuarioView B = null;

            Assert.IsFalse(A > B);
        }

        [TestMethod]
        public void OpMayorQue_DistintoId()
        {
            UsuarioView A = new UsuarioView(1, "Pepe", "palabra1", "Investigador", false);
            UsuarioView B = new UsuarioView(2, "Oscar", "palabra2", "Docente", true);

            Assert.IsTrue(B > A);
        }

        [TestMethod]
        public void OpMayorQue_MismaReferencia()
        {
            UsuarioView A = new UsuarioView(1, "Pepe", "palabra1", "Investigador", false);

            Assert.IsFalse(A > A);
        }

        [TestMethod]
        public void OpMayorQue_MismoIdDiferenteObjeto()
        {
            UsuarioView A = new UsuarioView(1, "Pepe", "palabra1", "Investigador", false);
            UsuarioView B = new UsuarioView(1, "Oscar", "palabra2", "Docente", true);

            Assert.IsFalse(B > A);
        }

        [TestMethod]
        public void OpMenorIgualQue()
        {
            UsuarioView A = new UsuarioView(1, "Pepe", "palabra1", "Investigador", false);
            UsuarioView B = new UsuarioView(1, "Oscar", "palabra2", "Docente", true);
            UsuarioView C = new UsuarioView(3, "Anotnio", "palabra1", "Investigador", false);

            Assert.IsTrue(A <= B);
            Assert.IsTrue(A <= C);
        }

        [TestMethod]
        public void OpMayorIgualQue()
        {
            UsuarioView A = new UsuarioView(1, "Pepe", "palabra1", "Investigador", false);
            UsuarioView B = new UsuarioView(1, "Oscar", "palabra2", "Docente", true);
            UsuarioView C = new UsuarioView(3, "Anotnio", "palabra1", "Investigador", false);

            Assert.IsTrue(A >= B);
            Assert.IsTrue(C >= A);
        }

    }
}