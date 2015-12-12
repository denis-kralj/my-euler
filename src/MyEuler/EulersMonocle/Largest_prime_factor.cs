using EulerMonocle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

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

            var primeLimit = (Int32)Math.Sqrt(num);
            var numbers = Enumerable.Range(2, primeLimit);
            var primes = new List<Int32>();

            foreach (var item in numbers)
                if(primes.Count == 0 || !primes.Any(n => !(n > item/2) && item % n == 0 ))
                    primes.Add(item);

            foreach (var item in primes.OrderByDescending(k => k))
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
