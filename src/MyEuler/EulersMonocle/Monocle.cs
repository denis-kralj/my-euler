using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EulerMonocle
{
    /// <summary>
    /// Main class ment to hold project euler problem 
    /// objects that impement the IProblem interface.
    /// </summary>
    public class Monocle
    {
        private static Monocle instance;

        /// <summary>
        /// Singleton instance of the Monocle object
        /// </summary>
        public static Monocle Instance
        {
            get
            {
                //may need lock here someday??
                if (Monocle.instance == null)
                    Monocle.instance = new Monocle();

                return Monocle.instance;
            }
        }

        private Monocle()
        {
            this.PopulateSolved();
        }

        /// <summary>
        /// Populates the Instance property.
        /// </summary>
        private void PopulateSolved()
        {
            this.Problems = new List<IProblem>();
            List <IProblem> tmpHolder = new List<IProblem>();

            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.GetInterfaces().Contains(typeof(IProblem)) && type.IsInterface == false)
                {
                    tmpHolder.Add((IProblem)Activator.CreateInstance(type));
                }
            }

            this.Problems = tmpHolder.OrderBy(p => (Int32)p.GetProblemNumber()).ToList();

        }

        /// <summary>
        /// Holder of solved problems
        /// </summary>
        public List<IProblem> Problems
        {
            get;
            set;
        }

        /// <summary>
        /// Index to problems for easier accesability
        /// </summary>
        /// <param name="i">the desired problems number</param>
        /// <returns></returns>
        public IProblem this[Int16 i]
        {
            get
            {
                if(i > this.Problems.Count)
                {
                    var message = String.Format("Index out of range, item count is {0}", this.Problems.Count);
                    throw new Exception(message);
                }
                else if (i < 0)
                {
                    var message = "Index can't be negative.";
                    throw new Exception(message);
                }

                return Problems[i-1];
            }
        }
    }
}
