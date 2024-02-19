using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DesElGamal
{
    public class PrimeNumberGenerator
    {
        private static Random random = new Random();

        public static bool IsPrime(BigInteger number, int iterations = 10)
        {
            if (number <= 1) return false;
            if (number <= 3) return true;
            if (number % 2 == 0) return false;

            BigInteger d = number - 1;
            int s = 0;
            while (d % 2 == 0)
            {
                d /= 2;
                s++;
            }

            for (int i = 0; i < iterations; i++)
            {
                BigInteger a = new BigInteger(random.Next(2, (int)BigInteger.Min((number - 2), int.MaxValue)));
                BigInteger x = BigInteger.ModPow(a, d, number);
                if (x == 1 || x == number - 1) continue;
                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, number);
                    if (x == 1) return false;
                    if (x == number - 1) break;
                }
                if (x != number - 1) return false;
            }
            return true;
        }

        public static BigInteger GenerateRandomPrime(int bitLength)
        {
            BigInteger primeCandidate;
            do
            {
                primeCandidate = BigInteger.Remainder(BigInteger.Abs(RandomBigInteger(bitLength)), (BigInteger.One << bitLength - 1)) + (BigInteger.One << bitLength - 1);
            } while (!IsPrime(primeCandidate));
            return primeCandidate;
        }

        private static BigInteger RandomBigInteger(int bitLength)
        {
            byte[] bytes = new byte[bitLength / 8];
            random.NextBytes(bytes);
            bytes[bytes.Length - 1] = (byte)(bytes[bytes.Length - 1] | 0x80);  // установка старшего бита в 1 для обеспечения длины в битах
            return new BigInteger(bytes);
        }
    }
}
