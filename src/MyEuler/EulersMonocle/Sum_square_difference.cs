using EulerMonocle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulersMonocle
{
    class Sum_square_difference : IProblem
    {
        public const Int16 PROBLEM_NUMBER = 6;

        public short GetProblemNumber()
        {
            return PROBLEM_NUMBER;
        }

        public Solution GetSolution()
        {

            var result =
                new Solution()
                {
                    ProblemNumber = PROBLEM_NUMBER,                            
                    ProblemText = GetProblemText(),
                    Result = GetResult()
                };

            return result;
        }

        private string GetResult()
        {
            long sum1 = 0;
            foreach(var item in Enumerable.Range(1,100))
            {
                sum1 += item * item;
            }

            long sum2 = 0;
            foreach (var item in Enumerable.Range(1, 100))
            {
                sum2 += item;
            }

            sum2 *= sum2; 

            return (sum2 - sum1).ToString();
        }

        
        private string GetProblemText()
        {
            return
                "The sum of the squares of the first ten natural numbers"+
                " is: 1^2 + 2^2 + ... + 10^2 = 385 The square of the sum"+
                " of the first ten natural numbers is:"+
                " (1 + 2 + ... + 10)^2 = 552 = 3025 Hence the difference "+
                "between the sum of the squares of the first ten natural "+
                "numbers and the square of the sum is 3025 − 385 = 2640. "+
                "Find the difference between the sum of the squares of "+
                "the first one hundred natural numbers and the square of "+
                "the sum.";
        }
    }
}
