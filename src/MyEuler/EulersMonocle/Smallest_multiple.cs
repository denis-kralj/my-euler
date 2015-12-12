using EulerMonocle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulersMonocle
{
    class Smallest_multiple : IProblem
    {
        public const Int16 PROBLEM_NUMBER = 5;

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
            var result = String.Empty;
            int i = 20;
            while(true)
            {
                checked
                {
                    if (Enumerable.Range(1, 20).All(e => i % e == 0))
                    {
                        result = i.ToString();
                        break;
                    }
                    i += 20;
                }


                //Console.WriteLine(i);
                //Console.WriteLine(int.MaxValue);
            }

            return result;
        }

        private string GetProblemText()
        {
            return
                "2520 is the smallest number that can "+
                "be divided by each of the numbers from "+
                "1 to 10 without any remainder. What is "+
                "the smallest positive number that is "+
                "evenly divisible by all of the numbers "+
                "from 1 to 20 ";
        }
    }
}
