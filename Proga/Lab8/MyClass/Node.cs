using System;
using System.Collections.Generic;
using System.Text;

namespace MyClasses
{
    public class Node
    {
        public long x;
        public Node prev;
        public Node next;
        public Node(long data)
        {
            x = data;
        }
    }
}
