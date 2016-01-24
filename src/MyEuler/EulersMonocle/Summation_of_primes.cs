using EulerMonocle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace EulersMonocle
{
    class Summation_of_primes : IProblem
    {
        public const Int16 PROBLEM_NUMBER = 10;

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
            while (Primer.Primes.Last() < 2000000)
                Primer.GeneratePrimes(5000);

            
            return Primer.Primes.TakeWhile(p => p < 2000000).Aggregate(
                (UInt64)0, (curr, next) =>
                    curr + Convert.ToUInt64(next)
                ).ToString();
        }

        private string GetProblemText()
        {
            return

                "The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.Find "+
                "the sum of all the primes below two million.";
            ;
        }
    }
}
