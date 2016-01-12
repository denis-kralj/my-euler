using EulerMonocle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulersMonocle
{
    class Special_Pythagorean_triplet : IProblem
    {
        public const Int16 PROBLEM_NUMBER = 9;

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
            Int32 a = 3, b = 4, c = 5, target = 1000;
            
            while(ArentPythagoreanTrilpet(a, b, c) && !(a + b + c == target))
            {
                c++;

                if(a+b+c>1000)
                {
                    c =b++ + 2;
                    if( a + b + c > 1000)
                    {
                        b = a++ + 2;
                        c = b + 1;
                        if (a + b + c > 1000)
                            throw new Exception("They went too far!");
                    }

                }
            }

            return (a * b * c).ToString();
        }

        private bool ArentPythagoreanTrilpet(int a, int b, int c)
        {
            return !(a * a + b * b == c * c);
        }

        private string GetProblemText()
        {
            return

                "A Pythagorean triplet is a set of three natural numbers, " +
                "a < b < c, for which a^2 + b^2 = c^2. For example, " +
                "3^2 + 4^2 = 9 + 16 = 25 = 5^2. There exists exactly one " +
                "Pythagorean triplet for which a + b + c = 1000. " +
                "Find the product abc.";
                ;
        }
    }
}
