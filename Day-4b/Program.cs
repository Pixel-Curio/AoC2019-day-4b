using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_4b
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> potentialPasswords = Enumerable.Range(108457, 453584);

            var matchingPasswords = potentialPasswords
                //Is a six digit number.
                .Where(x => x >= 100000 && x < 1000000)
                .Select(x => x.ToString().ToCharArray())
                //Two adjacent digits are the same.
                .Where(x =>
                {
                    for (int i = 0; i < x.Length - 1; i++)
                        if (x[i] == x[i + 1])
                            if (i - 1 < 0 || x[i - 1] != x[i])
                                if (i + 2 >= x.Length || x[i + 2] != x[i])
                                    return true;

                    return false;
                })
                //Going from left to right, the digits never decrease
                .Where(x =>
                {
                    for (int i = 1; i < x.Length; i++)
                        if (int.Parse(x[i].ToString()) < int.Parse(x[i - 1].ToString()))
                            return false;

                    return true;
                })
                .Select(x => int.Parse(new string(x))).ToArray();

            Console.WriteLine($"Found {matchingPasswords.Length} matching passwords.");
        }
    }
}
