using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class BinaryTree
    {
        public Node Root { set; get; }

        public BinaryTree(Node r)
        {
            Root = r;
        }

        public BinaryTree() { }

        public int Count { get { return TreeTraverse().Count(); }  }

        public int LeavesCount { get { 
            int num = 0;
            foreach (Node i in TreeTraverse())
                if (i.Left == null && i.Right == null)
                    num++;
            return num;      
        }}

        public int InternalNodesCount // проверяем правое ли левое является внутренним
        {
            get
            {
                int num = 0;
                foreach (Node i in TreeTraverse())
                {
                    if (i.Left != null)
                        if (i.Left.Left != null || i.Left.Right != null)
                            num++;
                    if (i.Right != null)
                        if (i.Right.Left != null || i.Right.Right != null)
                            num++;
                }
                return num;
            }
        }

        public int TwoSonsFathersCount 
        {
            get
            {
                int num = 0;
                foreach (Node i in TreeTraverse())
                {
                    if (i.Left != null && i.Right!= null)
                            num++;
                }
                return num;
            }
        }

        public int OneSonFathersCount 
        {
            get
            {
                int num = 0;
                foreach (Node i in TreeTraverse())
                {
                    if ((i.Left != null && i.Right == null) || (i.Left == null && i.Right != null))
                        num++;
                }
                return num;
            }
        }

        public int LeftSonFathersCount
        {
            get
            {
                int num = 0;
                foreach (Node i in TreeTraverse())
                {
                    if (i.Left != null)
                        num++;
                }
                return num;
            }  
        }

        public int RigthSonFathersCount
        {
            get
            {
                int num = 0;
                foreach (Node i in TreeTraverse())
                {
                    if (i.Right != null)
                        num++;
                }
                return num;
            }
        }

        public int LeftSonOnlyFathersCount
        {
            get
            {
                int num = 0;
                foreach (Node i in TreeTraverse())
                {
                    if (i.Left != null && i.Right == null)
                        num++;
                }
                return num;
            }
        }

        public int RightSonOnlyFathersCount
        {
            get
            {
                int num = 0;
                foreach (Node i in TreeTraverse())
                {
                    if (i.Right != null && i.Left == null)
                        num++;
                }
                return num;
            }
        }

        public double AverageKey {
            get {
                var tt = TreeTraverse();
                return tt.Sum(x => x.Data) / (tt.Count() * 1.00);
            }
        }

        public int Height { // todo
            get 
            {              
                return getHeight(Root);
            }
        }

        public virtual void Add(int data)
        {
            if (Root == null)
            {
                Root = new Node(data);
                return;
            }
            Node i = Root;
            while (true)
            {
                if (i.Data > data)
                {
                    if (i.Left == null)
                    {
                        i.Left = new Node(data);
                        return;
                    }
                    i = i.Left;
                }
                else
                {
                    if (i.Right == null)
                    {
                        i.Right = new Node(data);
                        return;
                    }
                    i = i.Right;
                }
            }
        }

        public bool ContainsKey(int data) {
            Node i = Root;
            while (true)
            {
                if (i.Data == data)
                {
                    return true;
                }
                if (i.Data > data)
                {
                    if (i.Left == null)
                    {
                        return false;
                    }                 
                    i = i.Left;
                }
                else
                {
                    if (i.Right == null)
                    {                        
                        return false;
                    }
                    i = i.Right;
                }
            }
        }

        public void Prefix_Traverse(ref List<Node> trav, Node first) // Обойти всё дерево, следуя порядку (вершина, левое поддерево, правое поддерево)
        {
            Node i = first;
            if (i != null)
            {
                trav.Add(i);
            }
            if (i == null)
                return;
            Prefix_Traverse(ref trav, i.Left);
            Prefix_Traverse(ref trav, i.Right);
        }

        public virtual IEnumerable<Node> TreeTraverse()
        {
            if (Root == null)
                throw new Exception("Root is empty");
            List<Node> trav = new List<Node>();
            Prefix_Traverse(ref trav, Root);
            return trav; // ref trav = null нельзя
        }

        public override string ToString()
        {
            string result = "";
            foreach (Node i in TreeTraverse())
                result += i.Data.ToString() + "\n";
            return result;
        }

        public void PrintAllLeaves() 
        { 
            foreach (Node i in TreeTraverse())
                if (i.Left == null && i.Right == null)
                    Console.WriteLine(i.Data);          
        }

        public void PrintAllNonLeaves()
        {
            foreach (Node i in TreeTraverse())
                if (i.Left != null || i.Right != null)
                    Console.WriteLine(i.Data);
        }

        public void PrintLeftSonNodes()
        {
            foreach (Node i in TreeTraverse())
                if (i.Left != null && i.Right == null)
                    Console.WriteLine(i.Data);
        }

        public void PrintRightSonNodes()
        {
            foreach (Node i in TreeTraverse())
                if (i.Left == null && i.Right != null)
                    Console.WriteLine(i.Data);
        }

        public int DepthOfMin()
        {
            int num = 0;
            foreach (Node i in TreeTraverse())
            {
                num++;
                if (i.Left == null)
                    break;
            }
            return num;
        }

        public virtual int Min()
        {
            Node i = Root;
            while (i.Left != null)
                i = i.Left;
            return i.Data;
        }

        public int DepthOfMax() // идем вручную вправо
        {
            int num = 1;
            Node i = Root;
            while (i.Right != null)
            {
                i = i.Right;
                num++;
            }
            return num;
        }

        public int getHeight(Node i)
        {
            if (i == null)
                return 0;
            int r = getHeight(i.Right);
            int l = getHeight(i.Left);
            return r > l ? r + 1 : l + 1;
        }

          
    }
}
