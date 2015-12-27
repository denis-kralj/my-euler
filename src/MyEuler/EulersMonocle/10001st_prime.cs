using EulerMonocle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulersMonocle
{
    class _10001st_prime : IProblem
    {
        public const Int16 PROBLEM_NUMBER = 7;

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
            var primeList = new List<UInt64>();

            while (primeList.Count != 10001)
            {
                if (primeList.Count == 0)
                { 
                    primeList.Add(2);
                    continue;
                }

                UInt64 candidate = primeList.Last();

                candidate++;
                
                while(primeList.Any(p => candidate % p == 0))
                    candidate++;

                primeList.Add(candidate);
            }
            

            return primeList.Last().ToString();
        }


        private string GetProblemText()
        {
            return

                "By listing the first six prime numbers: 2, 3, 5, 7,"+
                " 11, and 13, we can see that the 6th prime is 13. What "+
                "is the 10 001st prime number ?";
        }
    }
}
