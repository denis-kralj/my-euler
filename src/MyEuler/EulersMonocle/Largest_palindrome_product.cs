using EulerMonocle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulersMonocle
{
    class Largest_palindrome_product : IProblem
    {
        public const Int16 PROBLEM_NUMBER = 4;

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
            var candidate = 0;
            for (int i = 999; i > 99; i--)
            {
                for (int j = 999; j > 99; j--)
                {
                    if (isPalindrome(i * j) && i*j > candidate)
                        candidate = (i * j);
                }
            }

            return candidate.ToString();
        }

        private bool isPalindrome(int value)
        {
            Int32 i = 0, j = value.ToString().Length - 1;
            
            while(i < j)
            {
                if (value.ToString()[i++] != value.ToString()[j--]) return false;
            }

            return true;
        }

        private string GetProblemText()
        {
            return
                "A palindromic number reads the same both ways. " +
                "The largest palindrome made from the product of " +
                "two 2 - digit numbers is 9009 = 91 × 99.  Find " +
                "the largest palindrome made from the product of " +
                "two 3 - digit numbers.";
        }
    }
}
