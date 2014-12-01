using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class RBTree
    {
        RBNode Root { set; get; }
        private void Left_Rotate(RBNode x)
        {
            RBNode y = x.Right;
            x.Right = y.Left;

            if (y.Left != null)
                y.Left.Parent = x;
            y.Parent = x.Parent;
            if (x.Parent == null)
                Root = y;
            else if (x == x.Parent.Left)
                x.Parent.Left = y;
            else
                x.Parent.Right = y;

            y.Left = x;
            x.Parent = y;
        }
    }
}
