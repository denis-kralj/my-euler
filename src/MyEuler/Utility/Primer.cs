using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Primer
    {
        private static String _defaultFilePath = @"c:\primes.txt";

        private static String filePath = String.Empty;

        public static String FilePath
        {
            get
            {
                return String.IsNullOrEmpty(filePath) ? 
                    _defaultFilePath : filePath;
            }
            set
            {
                FileAttributes atr = File.GetAttributes(value);
                if ((atr & FileAttributes.Directory) != FileAttributes.Directory)
                    filePath = value;
                else
                    filePath = $@"{value}\primes.txt";
            }
        }

        public static void GeneratePrimes(int count = 500)
        {
            var seed = 2;
            var counter = 0;

            if (Primes.Count != 0)
                seed = Primes.Last() + 1;

            var primes = new List<Int32>();

            while (primes.Count < count)
            {
                var numbers = Enumerable.Range(seed, seed + count);

                foreach (var item in numbers)
                {
                    if (Primes.Count == 0 || !Primes.Any(n => !(n > item / 2) && item % n == 0))
                    {
                        primes.Add(item);
                        counter++;
                        seed = item;
                    }
                }
            }

            Primes.AddRange(primes);

            File.AppendAllLines(
                            FilePath,
                            primes.Select(i => i.ToString())
                            );
        }
        
        private static List<Int32> GetPrimesFromFile()
        {
            var list = File.ReadAllLines(FilePath);
            return list.Select(Int32.Parse).ToList();
        }

        private static List<Int32> primes = null;

        public static List<Int32> Primes
        {
            get
            {
                if (!File.Exists(FilePath)) File.Create(FilePath).Dispose();
                
                if(primes == null)
                    primes = GetPrimesFromFile();

                return primes;
            }
        }


    }
}
