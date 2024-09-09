using Microsoft.VisualStudio.TestTools.UnitTesting;
using tarea_extraclase_2;

namespace tarea_extraclase_2.Tests
{
    [TestClass]
    public class OwnLinkedListTests
    {
        // Pruebas para MergeSorted (Problema #1)

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void MergeSorted_ShouldThrowException_WhenListAIsNull()
        {
            OwnLinkedList listaA = null;
            OwnLinkedList listaB = new OwnLinkedList();
            listaB.InsertInOrder(3);

            listaA.MergeSorted(listaB, SortDirection.Ascending);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSorted_ShouldThrowException_WhenListBIsNull()
        {
            OwnLinkedList listaA = new OwnLinkedList();
            listaA.InsertInOrder(3);
            OwnLinkedList listaB = null;

            listaA.MergeSorted(listaB, SortDirection.Ascending);
        }

        [TestMethod]
        public void MergeSorted_ShouldMergeInAscendingOrder()
        {
            OwnLinkedList listaA = new OwnLinkedList();
            OwnLinkedList listaB = new OwnLinkedList();

            listaA.InsertInOrder(0);
            listaA.InsertInOrder(2);
            listaA.InsertInOrder(6);
            listaA.InsertInOrder(10);
            listaA.InsertInOrder(25);

            listaB.InsertInOrder(3);
            listaB.InsertInOrder(7);
            listaB.InsertInOrder(11);
            listaB.InsertInOrder(40);
            listaB.InsertInOrder(50);

            listaA.MergeSorted(listaB, SortDirection.Ascending);

            // Se espera que listaA contenga [0, 2, 3, 6, 7, 10, 11, 25, 40, 50]
            listaA.PrintList();
        }

        [TestMethod]
        public void MergeSorted_ShouldMergeInDescendingOrder()
        {
            OwnLinkedList listaA = new OwnLinkedList();
            OwnLinkedList listaB = new OwnLinkedList();

            listaA.InsertInOrder(10);
            listaA.InsertInOrder(15);

            listaB.InsertInOrder(9);
            listaB.InsertInOrder(40);
            listaB.InsertInOrder(50);

            listaA.MergeSorted(listaB, SortDirection.Descending);

            // Se espera que listaA contenga [50, 40, 15, 10, 9]
            listaA.PrintList();
        }

        [TestMethod]
        public void MergeSorted_ShouldHandleEmptyLists()
        {
            OwnLinkedList listaA = new OwnLinkedList();
            OwnLinkedList listaB = new OwnLinkedList();

            listaB.InsertInOrder(9);
            listaB.InsertInOrder(40);
            listaB.InsertInOrder(50);

            listaA.MergeSorted(listaB, SortDirection.Descending);

            // Se espera que listaA contenga [50, 40, 9]
            listaA.PrintList();
        }

        // Pruebas para Invert (Problema #2)

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Invert_ShouldThrowException_WhenListIsNull()
        {
            OwnLinkedList lista = null;
            lista.Invert();
        }

        [TestMethod]
        public void Invert_ShouldHandleEmptyList()
        {
            OwnLinkedList lista = new OwnLinkedList();
            lista.Invert();

            // Se espera que la lista siga vacía después de la inversión.
            lista.PrintList();
        }

        [TestMethod]
        public void Invert_ShouldInvertListCorrectly()
        {
            OwnLinkedList lista = new OwnLinkedList();
            lista.InsertInOrder(1);
            lista.InsertInOrder(0);
            lista.InsertInOrder(30);
            lista.InsertInOrder(50);
            lista.InsertInOrder(2);

            lista.Invert();

            // Se espera que lista contenga [2, 50, 30, 0, 1] después de la inversión.
            lista.PrintList();
        }

        [TestMethod]
        public void Invert_ShouldHandleSingleElementList()
        {
            OwnLinkedList lista = new OwnLinkedList();
            lista.InsertInOrder(2);

            lista.Invert();

            // Se espera que la lista siga siendo [2] después de la inversión.
            lista.PrintList();
        }

        // Pruebas para GetMiddle (Problema #3)

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetMiddle_ShouldThrowException_WhenListIsNull()
        {
            OwnLinkedList lista = null;
            lista.GetMiddle();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetMiddle_ShouldThrowException_WhenListIsEmpty()
        {
            OwnLinkedList lista = new OwnLinkedList();
            lista.GetMiddle();
        }

        [TestMethod]
        public void GetMiddle_ShouldReturnMiddleValue_WhenListHasOddNumberOfElements()
        {
            OwnLinkedList lista = new OwnLinkedList();
            lista.InsertInOrder(0);
            lista.InsertInOrder(1);
            lista.InsertInOrder(2);

            int middleValue = lista.GetMiddle();
            Assert.AreEqual(1, middleValue); // El elemento central es 1.
        }

        [TestMethod]
        public void GetMiddle_ShouldReturnMiddleValue_WhenListHasEvenNumberOfElements()
        {
            OwnLinkedList lista = new OwnLinkedList();
            lista.InsertInOrder(0);
            lista.InsertInOrder(1);
            lista.InsertInOrder(2);
            lista.InsertInOrder(3);

            int middleValue = lista.GetMiddle();
            Assert.AreEqual(2, middleValue); // El segundo valor central es 2.
        }
    }
}
