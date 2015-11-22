using EulerMonocle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulersMonocle
{
    class Even_Fibonacci_numbers : IProblem
    {
        public const Int16 PROBLEM_NUMBER = 2;
        public Int16 GetProblemNumber()
        {
            return PROBLEM_NUMBER;
        }

        public Solution GetSolution()
        {
            throw new NotImplementedException();
        }
    }
}
