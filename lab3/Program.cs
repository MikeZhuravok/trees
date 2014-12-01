using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree bt = new BinaryTree();
            foreach (int i in new int[] { 8,3,10,1,6,14,4,7,13}) // adding new keys
                bt.Add(i);
            Console.WriteLine(bt); // print a tree
            Console.WriteLine(bt.ContainsKey(10));
            Console.WriteLine(bt.ContainsKey(11)); // finding a key.
 

            Console.WriteLine("1: Print all leaves");
            bt.PrintAllLeaves();

            Console.WriteLine("2: Print all non-leaves");
            bt.PrintAllNonLeaves();

            Console.WriteLine("3: Print all nodes with only left son");
            bt.PrintLeftSonNodes();

            Console.WriteLine("4: Print all nodes with only right son");
            bt.PrintRightSonNodes();

            Console.WriteLine("5: Depth of the min element");
            Console.WriteLine(bt.DepthOfMin());

            Console.WriteLine("6: Depth of the max element");
            Console.WriteLine(bt.DepthOfMax());

            Console.WriteLine("7: Count of elements");
            Console.WriteLine(bt.Count);

            Console.WriteLine("8: Count of leaves");
            Console.WriteLine(bt.LeavesCount);

            Console.WriteLine("9: Count of internal nodes");
            Console.WriteLine(bt.InternalNodesCount);

            Console.WriteLine("10: Count of two sons fathers");
            Console.WriteLine(bt.TwoSonsFathersCount);

            Console.WriteLine("11: Count of one son fathers (i mean only one)");
            Console.WriteLine(bt.OneSonFathersCount);

            Console.WriteLine("12: Count of fathers with left son");
            Console.WriteLine(bt.LeftSonFathersCount); 
            
            Console.WriteLine("13: Count of fathers with right son");
            Console.WriteLine(bt.RigthSonFathersCount);

            Console.WriteLine("14: Count of fathers with left son only");
            Console.WriteLine(bt.LeftSonOnlyFathersCount);

            Console.WriteLine("15: Count of fathers with right son only");
            Console.WriteLine(bt.RightSonOnlyFathersCount);

            Console.WriteLine("16: AverageKey");
            Console.WriteLine(bt.AverageKey);

            Console.WriteLine("17: Height of the tree");
            Console.WriteLine(bt.Height);


            Console.WriteLine("18: Value that goes after given"); 
            BinTreeWithBackLinks btwbl = new BinTreeWithBackLinks();
            int[] array1 = new int[] { 8, 3, 10, 1, 6, 14, 4, 7, 13 };
            foreach (int i in array1)
                btwbl.Add(i);
            foreach (int i in new int[] { 8, 3, 10, 1, 6, 4, 7, 13 })
                Console.WriteLine("{0} - {1}", i, btwbl.AfterThat(i));


            Console.WriteLine("19: Value that goes before given");
            Console.WriteLine(btwbl.BeforeThat(10));
            foreach (int i in new int[] { 8, 3, 10, 6, 14, 4, 7, 13 })
                Console.WriteLine("{0} - {1}", i, btwbl.BeforeThat(i));

            Console.WriteLine("20: Delete node with such data");
            btwbl.Delete(10);
            foreach (NodeP i in btwbl)
                Console.WriteLine(i.Data);

            Console.WriteLine("21: Sort an array with a binary heap");
            int[] array = new int[] { 8, 3, 10, 1, 6, 14, 4, 7, 13 };
            BinaryHeap.SortArray(ref array); 
            foreach(int i in array)
            Console.WriteLine(i);
        }
    }
}
