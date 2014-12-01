using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class NodeP : Node
    {
        public NodeP Parent { set; get; }

        public new NodeP Right { set; get; }

        public new NodeP Left { set; get; }

        public NodeP(int a) : base(a) {}
        public NodeP(int data, NodeP parent) : this(data) {
            Parent = parent;
        }
    }
}
