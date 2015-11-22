using EulerMonocle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulersMonocle
{
    class Multiples_of_3_and_5 : IProblem
    {
        public const Int16 PROBLEM_NUMBER = 1;
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

        private String GetResult()
        {
            var sum = 0;
            var start = 0;
            
            while (start < 1000)
            {
                if (start % 3 == 0 || start % 5 == 0)
                    sum += start;

                start++;
            }

            return sum.ToString();
        }

        private String GetProblemText()
        {
            return 
                "If we list all the natural numbers below 10 that "+
                "are multiples of 3 or 5, we get 3, 5, 6 and 9.The "+
                "sum of these multiples is 23. Find the sum of all "+
                "the multiples of 3 or 5 below 1000.";
        }

        public Int16 GetProblemNumber()
        {
            return PROBLEM_NUMBER;
        }
    }
}
