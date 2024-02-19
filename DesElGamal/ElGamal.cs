using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesElGamal
{
    public class ElGamal
    {
        public BigInteger p;
        public BigInteger g;
        public BigInteger x;
        public BigInteger y;
        public BigInteger k;
        public BigInteger a;
        public BigInteger b;
        public BigInteger message;
        public BigInteger decryptedMessage;


        private static Random random = new Random();

        // ------------------------------
        // Генерируем p
        // ------------------------------
        public string GenerateP()
        {
            p = PrimeNumberGenerator.GenerateRandomPrime(256);
            return p.ToString();
        }

        // ------------------------------
        // Генерируем g
        // ------------------------------
        public string GenerateG()
        {
            g = GenerateRandomGenerator(p);
            return g.ToString();
        }

        private static BigInteger GenerateRandomGenerator(BigInteger p)
        {
            BigInteger g;

            do
            {
                g = GenerateRandomNumber(p);
            }
            while (BigInteger.ModPow(g, p - 1, p) != 1);

            return g;
        }

        private static BigInteger GenerateRandomNumber(BigInteger max)
        {
            byte[] bytes = max.ToByteArray();
            BigInteger result;

            do
            {
                random.NextBytes(bytes);
                bytes[bytes.Length - 1] &= (byte)0x7F; // Установка самого старшего бита в 0 для положительного числа
                result = new BigInteger(bytes);
            }
            while (result >= max);

            return result;
        }

        // ------------------------------
        // Генерируем x
        // ------------------------------
        public string GenerateX()
        {
            x = GenerateRandomNumber(p - 1);
            return x.ToString();
        }

        // ------------------------------
        // Генерируем y
        // ------------------------------
        public string GenerateY()
        {
            y = BigInteger.ModPow(g, x, p); 

            return y.ToString();
        }

        public string GenerateMessage()
        {
            message = GenerateRandomNumber(p - 1);
            return message.ToString();
        }

        // ------------------------------
        // Генерируем k
        // ------------------------------
        public string GenerateK()
        {
            k = GenerateRandomNumber(p - 2);

            return k.ToString();
        }

        // ------------------------------
        // Генерируем a
        // ------------------------------
        public string GenerateA()
        {
            a = BigInteger.ModPow(g, k, p);
            return a.ToString();
        }

        // ------------------------------
        // Генерируем b
        // ------------------------------
        public string GenerateB(ref BigInteger message)
        {
            b = (BigInteger.ModPow(y, k, p) * message) % p;
            return b.ToString();
        }

        // ------------------------------
        // Расшифровка
        // ------------------------------
        public string Decrypt() 
        {
            decryptedMessage = (b * BigInteger.ModPow(a, p - 1 - x, p)) % p;
            return decryptedMessage.ToString();

        }
    }
}
