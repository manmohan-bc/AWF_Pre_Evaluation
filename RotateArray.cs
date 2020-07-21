using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWF_PreEvaluation
{
    public class RotateArray
    {
        internal static void SolveRotateArray()
        {
            try
            {
                Console.WriteLine("Please enter the numbers in Comma Separated (Ex: 1,2,5,12): ");
                string inputString = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Please enter the step number : ");
                int stepNo = Convert.ToInt32(Console.ReadLine());
                if (stepNo < 0)
                {
                    Console.WriteLine("Step number should not be -Ve");
                    Console.ReadLine();
                    return;
                }
                string[] strArray = inputString.Split(',');
                var result = Solve(strArray, stepNo);
                Console.WriteLine();
                Console.WriteLine($"The result is : {result}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        public static string Solve(string[] strArray, int stepNo)
        {
            int arrLength = strArray.Length;
            if (stepNo > arrLength)
            {
                stepNo = stepNo % arrLength;
            }
            List<int> lstResult = new List<int>(arrLength);
            if (arrLength > 0)
            {
                for (int i = stepNo - 1; i < arrLength + (stepNo - 1); i++)
                {
                    if (i < arrLength && !string.IsNullOrEmpty(strArray[i]))
                        lstResult.Add(Convert.ToInt32(strArray[i].Trim()));
                    else if (i >= arrLength && !string.IsNullOrEmpty(strArray[i - arrLength]))
                        lstResult.Add(Convert.ToInt32(strArray[i - arrLength].Trim()));
                }
            }
            return string.Join(", ", lstResult);
        }
    }
}
