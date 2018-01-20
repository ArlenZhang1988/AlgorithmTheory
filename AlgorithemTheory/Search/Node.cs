using System;
using System.Collections.Generic;
using System.Text;

namespace Search
{
    public class Node<Key,Value>
    {
        Key k;
        Value v;

        public Key KeyPro { get { return k; } set { k = value; } }
        public Value ValuePro { get { return v; } set { v = value; } }

        private Node<Key, Value> nextNode;

        public Node<Key, Value> NextNode { get { return nextNode; } set { nextNode = value; } }

        public Node(Key k,Value v)
        {
            KeyPro = k;
            ValuePro = v;
        }
    }
}
