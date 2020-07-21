using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWF_PreEvaluation
{
    public class StringCombinationTest
    {
        internal static void SolveStringCombination()
        {
            Console.Write("Enter the string: ");
            string inputString = Console.ReadLine();
            string result = Solve(inputString);
            Console.WriteLine();
            Console.WriteLine(string.Format("Result is : [{0}]", result));
            Console.ReadLine();
        }

        public static string Solve(string strInput)
        {
            char[] str = strInput.ToCharArray();
            List<string> outputString = new List<string>();
            outputString.Add(@"""""");
            for (int len = 1; len <= str.Length; len++)
            {
                for (int i = 0; i <= str.Length - len; i++)
                {
                    int j = i + len - 1;
                    string res = "";
                    for (int k = i; k <= j; k++)
                        res += str[k];
                    outputString.Add(res);
                }
            }
            return string.Join(", ", outputString);
        }
    }
}
