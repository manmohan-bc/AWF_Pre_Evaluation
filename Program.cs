using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWF_PreEvaluation
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter the question no from [1, 2, 4]");
                int queNo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (queNo)
                {
                    case 1:
                        BinaryTreeTest.SolveBinaryTree();
                        break;
                    case 2:
                        RotateArray.SolveRotateArray();
                        break;
                    case 4:
                        StringCombinationTest.SolveStringCombination();
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
