//https://projecteuler.net/problem=37
namespace euler_thirtyseven
{
    class Program {
        

        static void Main()
        {
            int sum = 0;
            int sumCount = 0;
            int[] primes = GenPrimes(1000000);
            foreach (int prime in primes) {
                if (prime > 7 && CheckLeftToRight(prime, primes) && CheckRightToLeft(prime, primes)){
                    sum += prime;
                    sumCount++;
                    Console.WriteLine($"{prime} is truncatable");
                }
            }
            Console.WriteLine($"{sumCount} trun Primes found with a total of {sum}");
        }

        private static bool CheckRightToLeft(int prime, int[] primes)
        {
            string primeAsString = Convert.ToString(prime);
            for (int i = 0; i < primeAsString.Length ; i++)
            {
                char[] subprimeAsString = new char[(primeAsString.Length)-i];
                primeAsString.CopyTo(i,subprimeAsString,0,(primeAsString.Length)-i);
                int subprime = int.Parse(subprimeAsString);
                if (!primes.Contains(subprime)){
                    return false;
                }
            }
            return true;
        }

        private static bool CheckLeftToRight(int prime, int[] primes)
        {
            string primeAsString = Convert.ToString(prime);
            for (int i = 0; i < primeAsString.Length; i++)
            {
                char[] subprimeAsString = new char[(primeAsString.Length)-i];
                primeAsString.CopyTo(0,subprimeAsString,0,(primeAsString.Length)-i);
                int subprime = int.Parse(subprimeAsString);
                if (!primes.Contains(subprime)){
                    return false;
                }
            }
            return true;
        }
        private static int[] GenPrimes(int max)
        {
            List<int> output = new List<int>();
            for (int i = 2; i <= max; i++)
            {
                bool isPrime = true;
                foreach (int number in output)
                {
                    if (i % number == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    output.Add(i);
                }
            }
            return output.ToArray();
        }
    }
}