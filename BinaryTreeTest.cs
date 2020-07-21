using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWF_PreEvaluation
{
    public class BinaryTreeTest
    {
        public TreeNode RootNode { get; set; }       

        public int GetTreeHeight(int k)
        {
            while(RootNode.Data != k)
            {
                Remove(RootNode.Data);
            }
            return this.GetTreeHeight(this.RootNode);
        }

        private int GetTreeHeight(TreeNode parent)
        {
            return parent == null ? 0 : Math.Max(GetTreeHeight(parent.LeftNode), GetTreeHeight(parent.RightNode)) + 1;
        }

        public bool Add(int value)
        {
            TreeNode preNode = null, postNode = this.RootNode;
            while (postNode != null)
            {
                preNode = postNode;
                if (value < postNode.Data) //Is new node in left tree? 
                    postNode = postNode.LeftNode;
                else if (value > postNode.Data) //Is new node in right tree?
                    postNode = postNode.RightNode;
                else
                {
                    //Exist same value
                    return false;
                }
            }

            TreeNode newNode = new TreeNode();
            newNode.Data = value;

            if (this.RootNode == null)//Tree ise empty
                this.RootNode = newNode;
            else
            {
                if (value < preNode.Data)
                    preNode.LeftNode = newNode;
                else
                    preNode.RightNode = newNode;
            }
            return true;
        }

        public void Remove(int value)
        {
            this.RootNode = Remove(this.RootNode, value);
        }

        private TreeNode Remove(TreeNode parent, int key)
        {
            if (parent == null) return parent;

            if (key < parent.Data) parent.LeftNode = Remove(parent.LeftNode, key);
            else if (key > parent.Data)
                parent.RightNode = Remove(parent.RightNode, key);

            else
            {
                if (parent.LeftNode == null)
                    return parent.RightNode;
                else if (parent.RightNode == null)
                    return parent.LeftNode;

                parent.Data = MinValue(parent.RightNode);

                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }

            return parent;
        }

        private int MinValue(TreeNode node)
        {
            int minv = node.Data;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data;
                node = node.LeftNode;
            }

            return minv;
        }

        internal static void SolveBinaryTree()
        {
            Console.WriteLine("Please enter tree node values by Comma Separated (Ex: 1,2,5,12): ");
            string inputString = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Please enter root node from the Tree : ");
            int rootNode = Convert.ToInt32(Console.ReadLine());
            string[] strArray = inputString.Split(',');
            int height = Solve(strArray, rootNode);
            Console.WriteLine();
            Console.WriteLine($"Height of the Binary Tree for Root Node {rootNode} is : {height}");
            Console.ReadLine();
        }

        public static int Solve(string[] strArray, int rootNode)
        {
            if (!strArray.Any(s => s.Trim() == (rootNode.ToString())))
            {
                Console.WriteLine();
                Console.WriteLine($"Entered node {rootNode} is not present in the Tree.");
                Console.ReadLine();
                return 0;
            }
            BinaryTreeTest binaryTree = new BinaryTreeTest();
            foreach (string value in strArray)
            {
                if (!string.IsNullOrEmpty(value))
                    binaryTree.Add(Convert.ToInt32(value.Trim()));
            }

            int height = binaryTree.GetTreeHeight(rootNode);
            return height;
        }
    }

    public class TreeNode
    {
        public TreeNode LeftNode { get; set; }
        public TreeNode RightNode { get; set; }
        public int Data { get; set; }
    }
}
