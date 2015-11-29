using EulerMonocle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheat
{
    class Program
    {
        static void Main(string[] args)
        {
            // have to implement get enumerator into Monocle 
            // so i can access the collection directly from the class
            foreach(var problem in Monocle.Instance)
            {
                Console.WriteLine("Problem {0}: {1}", problem.GetProblemNumber(), problem.GetSolution().Result);
            }

            Console.ReadLine();
        }
    }
}
