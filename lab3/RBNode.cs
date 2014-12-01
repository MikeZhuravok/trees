using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class RBNode : Node
    {
        public new RBNode Right { set; get; }

        public new RBNode Left { set; get; }

        public new RBNode Parent { set; get; }

        public string Color { set; get; }

        public const string Red = "Red";

        public const string Black = "Black";

        public RBNode(int data, RBNode pr, string color)
            : base(data)
        {
            if (color != Red || color != Black)
                throw new Exception();
            Color = color;
            Parent = pr;
        }
    }
}
