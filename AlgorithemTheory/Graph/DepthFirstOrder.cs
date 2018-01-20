using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class DepthFirstOrder 
    {
        protected bool[] _marks;
        private Queue<int> _pre,_post;
        private Stack<int> _reversePost;

        public Queue<int> Pre { get { return _pre; } }
        public Queue<int> Post { get { return _post; } }
        public Stack<int> ReversePost { get { return _reversePost; } }

        public DepthFirstOrder(Graph g)
        {
            _marks = new bool[g.Vertice()];
            _pre = new Queue<int>();
            _post = new Queue<int>();
            _reversePost = new Stack<int>();

            for (int i = 0; i < g.Vertice(); i++)
            {
                if (!_marks[i])
                {
                    Search(g, i);
                }
            }
        }

        public void Search(Graph g, int s)
        {
            _pre.Enqueue(s);

            _marks[s] = true;

            foreach (var temp in g.Adj(s))
            {
                if (!_marks[temp])
                {
                    Search(g, temp);
                }
            }

            _post.Enqueue(s);
            _reversePost.Push(s);
        }
    }
}
