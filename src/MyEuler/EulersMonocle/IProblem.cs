using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerMonocle
{
    public interface IProblem
    {
        Solution GetSolution(Int32 problemNumber);
    }
}
