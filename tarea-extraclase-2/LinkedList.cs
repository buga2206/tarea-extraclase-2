using System;

namespace tarea_extraclase_2
{
    public interface Ilist
    {
        void InsertInOrder(int value);
        int DeleteFirst();
        int DeleteLast();
        bool DeleteValue(int value);
        int GetMiddle();
        void MergeSorted(LinkedList lista, SortDirection direction);
    }

    public class Node
    {
        public int Value;
        public Node Next;
        public Node Prev;

        public Node(int value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }
    }

    public class LinkedList : Ilist
    {
        private Node head;
        private Node last;
        private Node mid;
        
        public LinkedList()
        {
            head = null;
            last = null;
            mid = null;
        }

        public void InsertInOrder(int value)
        {
            return;
        }

        public int DeleteFirst()
        {
            return;
        }

        public int DeleteLast()
        {
            return;
        }

        public bool DeleteValue(int value)
        {
            return;
        }

        public int GetMiddle()
        {
            return;
        }

        public void MergeSorted(LinkedList lista, SortDirection direction)
        {
            return;
        }
    }
}