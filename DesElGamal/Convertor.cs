using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DesElGamal
{
    public class Convertor
    {
        public string ConvertTextToBits(string text)
        {
            // Преобразование сообщения в массив байтов, используя кодировку ASCII
            byte[] byteArray = Encoding.ASCII.GetBytes(text);

            // Конвертация массива байтов в строку из 0 и 1
            StringBuilder binarySequence = new StringBuilder();
            foreach (byte b in byteArray)
            {
                string binaryString = Convert.ToString(b, 2).PadLeft(8, '0');
                binarySequence.Append(binaryString);
            }

            return binarySequence.ToString();
        }

        public string ConvertBitsToText(string textBits)
        {
            StringBuilder textBuilder = new StringBuilder();

            for (int i = 0; i < textBits.Length; i += 8)
            {
                string binary = textBits.Substring(i, 8);
                int decimalValue = Convert.ToInt32(binary, 2);
                char character = Convert.ToChar(decimalValue);
                textBuilder.Append(character);
            }

            return textBuilder.ToString();
        }

        public string ConvertTextToBit(byte[] byteArray)
        {
            // Преобразование сообщения в массив байтов, используя кодировку ASCII

            // Конвертация массива байтов в строку из 0 и 1
            StringBuilder binarySequence = new StringBuilder();
            foreach (byte b in byteArray)
            {
                string binaryString = Convert.ToString(b, 2).PadLeft(8, '0');
                binarySequence.Append(binaryString);
            }

            return binarySequence.ToString();
        }

        public string ConvertText(string number)
        {
            string result = "";

            for (int i = 0; i < number.Length; i += 2)
            {
                string chunk = number.Substring(i, 2);
                int charCode = int.Parse(chunk);
                result += (char)charCode;
            }

            return result;
        }
    }
}
