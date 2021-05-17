using System;
using System.Collections.Generic;
using System.Collections;

namespace MyClasses
{
    public class MyList
    {
        private Node _head;
        private Node _tail;
        public MyList()
        {
            _head = null;
            _tail = null;
        }
        public void put(long num)
        {
            Node temp = new Node(num);
            this.AddLast(temp);
        }
        public uint Length()
        {
            uint counter = 0;
            Node q = _head;
            while (q.next != null)
            {
                counter++;
                q = q.next;
            }
            return counter;
        }
        public uint CountElemDivBy5OnEvenPos()
        {
            bool IsEven = false;
            uint counter = 0;
            Node q = _head;
            while (q.next != null)
            {
                if (IsEven)
                    if (q.x % 5 == 0)
                        counter++;
                IsEven = !IsEven;
                q = q.next;
            }
            return counter;
        }
        public void RemoveElementsMoreThanAverage()
        {
            Node q = _head;
            long averageLower = CountAverageLower();
            while (q != null)
            {
                Node p = q.next;
                if (q.x > averageLower)
                    DeleteNode(q);
                q = p;
            }
        }
        public long CountAverageLower()
        {
            long sum = 0;
            uint counter = 0;
            Node q = _head;
            while (q != null)
            {
                sum += q.x;
                counter++;
                q = q.next;
            }
            return sum / counter;
        }
        public override string ToString()
        {
            string strOut = "";
            Node q = _head;
            while (q != null)
            {
                strOut += (q.x).ToString();
                if (q.next != null)
                    strOut += ", ";
                else
                    strOut += ".";
                q = q.next;
            }
            return strOut;
        }
        private void AddLast(Node newNode)
        {
            if (_head == null)
            {
                _head = _tail = newNode;
            }
            else
            {
                newNode.prev = _tail;
                _tail.next = newNode;
                _tail = newNode;
            }
        }
        private void DeleteNode(Node p)
        {
            Node q = _head;
            if (_head == p)
            {
                _head = p.next;
            }
            else
            {
                while (q != null && q.next != p)
                {
                    q = q.next;
                }
                if (q != null)
                    q.next = p.next;
            }
        }
    }
}
