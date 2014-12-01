using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class BinTreeWithBackLinks : BinaryTree, IEnumerable
    {
        public BinTreeWithBackLinks() { }
        public BinTreeWithBackLinks(NodeP i)
        {
            Root = i;
        }
        public override int Min()
        {
            return MinAsNode().Data;
        }
        public NodeP MinAsNode()
        {
            NodeP i = Root;
            while (i.Left != null)
                i = i.Left;
            return i;
        }
        private new NodeP Root { set; get; }
       

        public override void Add(int data)
        {
            if (Root == null)
            {
                Root = new NodeP(data);
                return;
            }
            NodeP i = Root;
            while (true)
            {
                if (i.Data > data)
                {
                    if (i.Left == null)
                    {
                        i.Left = new NodeP(data, i);
                        return;
                    }
                    i = i.Left;
                }
                else
                {
                    if (i.Right == null)
                    {
                        i.Right = new NodeP(data, i);
                        return;
                    }
                    i = i.Right;
                }
            }
        }

        public void Prefix_Traverse(ref List<NodeP> trav, NodeP first)
        {
            NodeP i = first;
            if (i != null)
            {
                trav.Add(i);
            }
            if (i == null)
                return;
            Prefix_Traverse(ref trav, i.Left);
            Prefix_Traverse(ref trav, i.Right);
        }

        public override IEnumerable<Node> TreeTraverse()
        {
            if (Root == null)
                throw new Exception("Root is empty");
            List<NodeP> trav = new List<NodeP>();
            Prefix_Traverse(ref trav, Root);
            return trav;
        }

        public int AfterThat(int data)
        {
            return AT(data).Data;
        }

        public NodeP AT(int data)
        {
            NodeP i = null;
            foreach (NodeP l in TreeTraverse())
                if (l.Data == data)
                {
                    i = l; // Нашли наш элемент. O(n)
                }
            if (i == null)
                throw new Exception();
            if (i.Right != null)
            {
                return new BinTreeWithBackLinks(i.Right).MinAsNode();
            }
            NodeP y = i.Parent;
            while (y != null)
            {
                if (i == y.Left)
                    return y;
                i = y;
                y = y.Parent;
                
            }
            throw new Exception("This is max value");
        }

        public int BeforeThat(int data)
        {
            return BThat(data).Data;
        }

        public NodeP BThat(int data)
        {
            NodeP i = null;
            foreach (NodeP l in TreeTraverse())
                if (l.Data == data)
                {
                    i = l; // Нашли наш элемент.
                }
            if (i == null)
                throw new Exception();
            if (i.Left != null)
            {
                return new BinTreeWithBackLinks(i.Left).MaxAsNode();
            }
            NodeP y = i.Parent;
            while (y != null)
            {
                if (i == y.Right)
                    return y;
                i = y;
                y = y.Parent;

            }
            throw new Exception("This is min value");
        }

        private NodeP MaxAsNode()
        {
            NodeP i = Root;
            while (i.Right != null)
                i = i.Right;
            return i;
        }

        public void Delete(int i)
        {
            NodeP a = null;
            foreach (NodeP l in TreeTraverse())
                if (l.Data == i)
                {
                    a = l;
                }
            Delete(a);
        }
        private void Delete(NodeP i)
        {
            NodeP y, x;
            if (i.Left == null || i.Right == null) // если есть дети
                y = i; // вырежем эту вершину, если у нее не более одного ребенка
            else
                y = AT(i.Data); // Возвращает элемент, следующий за данным и соотв. не нарушает последовательности
            if (y.Left != null) // если правый или левый потомок есть он попадет в х
                x = y.Left;
            else
                x = y.Right;
            if (x != null) // если один ребенок то он просто замещается
            {
                x.Parent = y.Parent;
            }
            if (y.Parent == null)
                Root = x; // отдельно если корень
            else
                if (y == y.Parent.Left)
                    y.Parent.Left = x;
                else
                    y.Parent.Right = x;
            if (y != i)
            {
                int temp = i.Data;
                i.Data = y.Data;
                y.Data = temp;
            }


        }

        public IEnumerator GetEnumerator()
        {
            return TreeTraverse().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return TreeTraverse().GetEnumerator();
        }
    }
}
