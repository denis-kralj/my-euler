using EulerMonocle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Utility;

namespace EulersMonocle
{
    class Largest_prime_factor : IProblem
    {

        public const Int16 PROBLEM_NUMBER = 3;

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
            var num = 600851475143;
            var result = String.Empty;

            if (Primer.Primes.Count == 0)
                Primer.GeneratePrimes(5000);

            while (Primer.Primes.Last() < (Int32)Math.Sqrt(num))
            {
                Primer.GeneratePrimes(5000);
            }
           
            foreach (var item in Primer.Primes.OrderByDescending(k => k))
                if (num % item == 0) { result = item.ToString(); break; }
           
            return result;
        }



        private string GetProblemText()
        {
            return
                "The prime factors of 13195 are 5, 7, 13 and 29."+
                "What is the largest prime factor of the number 600851475143 ?";
        }
    }
}
