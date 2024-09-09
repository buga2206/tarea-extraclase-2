using System;

namespace tarea_extraclase_2
{
    public interface IList
    {
        void InsertInOrder(int value);
        int DeleteFirst();
        int DeleteLast();
        bool DeleteValue(int value);
        int GetMiddle();
        void MergeSorted(OwnLinkedList list, SortDirection direction);
        void Invert();
        void PrintList();
    }

    internal class Node
    {
        internal int Value;
        internal Node Next;
        internal Node Prev;

        public Node(int value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }
    }

    public class OwnLinkedList : IList
    {
        private Node head;
        private Node last;
        private Node mid;

        public OwnLinkedList()
        {
            head = null;
            last = null;
            mid = null;
        }

        public void InsertInOrder(int value)
        {
            Node newNode = new Node(value); // Se crea un nuevo nodo con el valor a insertar.

            if (head == null) // Si la lista está vacía, el nuevo nodo es el primero, último y medio.
            {
                head = newNode;
                last = newNode;
                mid = newNode;
                return;
            }

            Node current = head;
            while (current != null && current.Value < value) // Recorre la lista hasta encontrar dónde insertar el valor.
            {
                current = current.Next;
            }

            if (current == head) // Si el valor va al principio, se actualizan los punteros del nuevo nodo y la cabeza.
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }
            else if (current == null) // Si el valor va al final, se actualizan los punteros del último nodo y el nuevo nodo.
            {
                last.Next = newNode;
                newNode.Prev = last;
                last = newNode;
            }
            else // Si el valor va en el medio, se actualizan los punteros de los nodos anterior y siguiente.
            {
                newNode.Next = current;
                newNode.Prev = current.Prev;
                current.Prev.Next = newNode;
                current.Prev = newNode;
            }

            UpdateMiddle(); // Se actualiza el nodo medio.
        }

        public int DeleteFirst()
        {
            if (head == null) // Si la lista está vacía, lanza una excepción.
                throw new InvalidOperationException("La lista está vacía.");

            int value = head.Value;

            if (head == last) // Si la lista tiene un solo nodo, la vacía completamente.
            {
                head = null;
                last = null;
                mid = null;
            }
            else // Si hay más de un nodo, actualiza la cabeza y elimina el primer nodo.
            {
                head = head.Next;
                head.Prev = null;
                UpdateMiddle(); // Se actualiza el nodo medio.
            }

            return value; // Devuelve el valor del nodo eliminado.
        }

        public int DeleteLast()
        {
            if (last == null) // Si la lista está vacía, lanza una excepción.
                throw new InvalidOperationException("La lista está vacía.");

            int value = last.Value;

            if (head == last) // Si la lista tiene un solo nodo, la vacía completamente.
            {
                head = null;
                last = null;
                mid = null;
            }
            else // Si hay más de un nodo, actualiza el último nodo y elimina el último nodo.
            {
                last = last.Prev;
                last.Next = null;
                UpdateMiddle(); // Se actualiza el nodo medio.
            }

            return value; // Devuelve el valor del nodo eliminado.
        }

        public bool DeleteValue(int value)
        {
            Node current = head;

            while (current != null && current.Value != value) // Recorre la lista buscando el valor.
            {
                current = current.Next;
            }

            if (current == null) return false; // Si no se encuentra el valor, retorna false.

            if (current == head) // Si el valor es el primer nodo, llama a DeleteFirst().
            {
                DeleteFirst();
            }
            else if (current == last) // Si el valor es el último nodo, llama a DeleteLast().
            {
                DeleteLast();
            }
            else // Si el valor está en medio, actualiza los punteros de los nodos anterior y siguiente.
            {
                current.Prev.Next = current.Next;
                current.Next.Prev = current.Prev;
                UpdateMiddle(); // Se actualiza el nodo medio.
            }

            return true; // Retorna true si se eliminó el nodo.
        }

        public int GetMiddle()
        {
            // Verifica si el objeto actual (la lista) es null.
            if (this == null)
                throw new NullReferenceException("La lista es null.");

            // Verifica si la lista está vacía, es decir, si 'mid' es null.
            if (mid == null)
                throw new InvalidOperationException("La lista está vacía.");

            // Devuelve el valor del nodo medio.
            return mid.Value;
        }


        public void MergeSorted(OwnLinkedList list, SortDirection direction)
        {
            if (this == null) // Verifica si la lista actual es nula.
                throw new NullReferenceException("La lista principal es nula.");

            if (list == null) // Verifica si la lista a mezclar es nula.
                throw new ArgumentNullException("La lista que se quiere mezclar es nula.");

            Node principalNode = this.head;
            Node secundaryNode = list.head;

            OwnLinkedList tempList = new OwnLinkedList();

            while (principalNode != null && secundaryNode != null) // Mezcla ambas listas ordenadas.
            {
                if (direction == SortDirection.Descending) // Si es descendente, compara de mayor a menor.
                {
                    if (principalNode.Value >= secundaryNode.Value)
                    {
                        tempList.InsertInOrder(principalNode.Value);
                        principalNode = principalNode.Next;
                    }
                    else
                    {
                        tempList.InsertInOrder(secundaryNode.Value);
                        secundaryNode = secundaryNode.Next;
                    }
                }
                else // Si es ascendente, compara de menor a mayor.
                {
                    if (principalNode.Value <= secundaryNode.Value)
                    {
                        tempList.InsertInOrder(principalNode.Value);
                        principalNode = principalNode.Next;
                    }
                    else
                    {
                        tempList.InsertInOrder(secundaryNode.Value);
                        secundaryNode = secundaryNode.Next;
                    }
                }
            }

            while (principalNode != null) // Inserta los nodos restantes de la lista principal.
            {
                tempList.InsertInOrder(principalNode.Value);
                principalNode = principalNode.Next;
            }

            while (secundaryNode != null) // Inserta los nodos restantes de la lista secundaria.
            {
                tempList.InsertInOrder(secundaryNode.Value);
                secundaryNode = secundaryNode.Next;
            }

            // Reemplaza la lista actual con la lista temporal.
            this.head = tempList.head;
            this.last = tempList.last;
            this.mid = tempList.mid;
        }

        public void Invert()
        {
            // Verifica si la lista es null
            if (this == null)
                throw new ArgumentNullException("La lista es null.");

            Node current = head;
            Node temp = null;

            while (current != null) // Invierte los punteros de la lista.
            {
                temp = current.Prev;
                current.Prev = current.Next;
                current.Next = temp;
                current = current.Prev;
            }

            if (temp != null) // Actualiza la cabeza de la lista.
            {
                head = temp.Prev;
            }
        }

        private void UpdateMiddle()
        {
            if (head == null) // Si la lista está vacía, no hay nodo medio.
            {
                mid = null;
                return;
            }

            Node slow = head;
            Node fast = head;

            // El puntero "fast" avanza el doble de rápido que "slow" para encontrar el nodo medio.
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            mid = slow; // El nodo "slow" será el nodo medio.
        }

        public void PrintList()
        {
            Node current = head;
            Console.Write("[");

            while (current != null) // Recorre la lista e imprime los valores.
            {
                Console.Write(current.Value);

                if (current.Next != null)
                {
                    Console.Write(", "); // Imprime una coma si no es el último elemento.
                }

                current = current.Next;
            }

            Console.WriteLine("]"); // Cierra el corchete y hace un salto de línea.
        }
    }

    public class Program
    {
        public static void Main()
        {
            // Crear dos listas enlazadas dobles
            OwnLinkedList listaA = new OwnLinkedList();
            OwnLinkedList listaB = new OwnLinkedList();

            // Insertar valores en orden en ambas listas
            listaA.InsertInOrder(1);
            listaA.InsertInOrder(9);
            listaA.InsertInOrder(5);

            listaB.InsertInOrder(10);
            listaB.InsertInOrder(6);
            listaB.InsertInOrder(2);

            Console.WriteLine("Lista A: ");
            listaA.PrintList();
            Console.ReadLine();

            Console.WriteLine("Lista B: ");
            listaB.PrintList();
            Console.ReadLine();

            // Mezclar ambas listas en orden ascendente
            listaA.MergeSorted(listaB, SortDirection.Ascending);

            Console.WriteLine("Lista A después de mezclar con B (ascendente): ");
            listaA.PrintList();
            Console.ReadLine();

            // Invertir la lista A
            listaA.Invert();
            Console.WriteLine("Lista A invertida: ");
            listaA.PrintList();
            Console.ReadLine();

            // Obtener el valor del nodo medio
            Console.WriteLine("El valor del nodo medio es: " + listaA.GetMiddle());
            Console.ReadLine();
        }
    }
}

