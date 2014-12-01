using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Node
    {
        public int Data { set; get; }

        public Node Right { set; get; }

        public Node Left { set; get; }

        public Node(int data)
        {
            Data = data;
        }
    }
}
