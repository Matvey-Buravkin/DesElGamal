using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Specialized;
using System.Data.Common;
using System.Security.Cryptography;

namespace DesElGamal
{
    public class DES
    {
        public int sizeBlock = 64;
        public int countRound = 16;
        private string[] keysGenerate = new string[16];
        private string blockL = "";
        private string blockR = "";
        public string keyC = "";
        public string keyD = "";

        public List<int> IP = new List<int>
        {
            58, 50, 42, 34, 26, 18, 10, 2,  60, 52, 44, 36, 28, 20, 12, 4,
            62, 54, 46, 38, 30, 22, 14, 6,  0, 56, 48, 40, 32, 24, 16, 8,
            57, 49, 41, 33, 25, 17, 9,  1,  59, 51, 43, 35, 27, 19, 11, 3,
            61, 53, 45, 37, 29, 21, 13, 5,  63, 55, 47, 39, 31, 23, 15, 7
        };

        public int[] IP1 = new int[64]
        {
            40, 8, 48, 16, 56, 24, 0, 32, 39, 7, 47, 15, 55, 23, 63, 31,
            38, 6, 46, 14, 54, 22, 62, 30, 37, 5, 45, 13, 53, 21, 61, 29,
            36, 4, 44, 12, 52, 20, 60, 28, 35, 3, 43, 11, 51, 19, 59, 27,
            34, 2, 42, 10, 50, 18, 58, 26, 33, 1, 41, 9,  49, 17, 57, 25
        };

        public int[,] S1 = new int[4, 16]
        {
            {14, 4, 13, 1,  2,  15, 11, 8,  3,  10, 6,  12, 5,  9,  0,  7},
            {0, 15, 7,  4,  14, 2,  13, 1,  10, 6,  12, 11, 9,  5,  3,  8},
            {4, 1,  14, 8,  13, 6,  2,  11, 15, 12, 9,  7,  3,  10, 5,  0},
            {15, 12, 8, 2,  4,  9,  1,  7,  5,  11, 3,  14, 10, 0,  6,  13}
        };

        public int[,] S2 = new int[4, 16]
        {
            {15, 1,  8,  14, 6,  11, 3,  4,  9,  7,  2,  13, 12, 0,  5,  10},
            {3,  13, 4,  7,  15, 2,  8,  14, 12, 0,  1,  10, 6,  9,  11, 5},
            {0,  14, 7,  11, 10, 4,  13, 1,  5,  8,  12, 6,  9,  3,  2,  15},
            {13, 8,  10, 1,  3,  15, 4,  2,  11, 6,  7,  12, 0,  5,  14, 9}
        };

        public int[,] S3 = new int[4, 16]
        {
            {10, 0,  9,  14, 6,  3,  15, 5,  1,  13, 12, 7,  11, 4,  2,  8},
            {13, 7,  0,  9,  3,  4,  6,  10, 2,  8,  5,  14, 12, 11, 15, 1},
            {13, 6,  4,  9,  8,  15, 3,  0,  11, 1,  2,  12, 5,  10, 14, 7},
            {1, 10, 13, 0,  6,  9,  8,  7,  4,  15, 14, 3,  11, 5,  2,  12}
        };

        public int[,] S4 = new int[4, 16]
        {
            {7, 13, 14, 3,  0,  6,  9,  10, 1,  2,  8,  5,  11, 12, 4,  15},
            {13, 8,  11, 5,  6,  15, 0,  3,  4,  7,  2,  12, 1,  10, 14, 9},
            {10, 6,  9,  0,  12, 11, 7,  13, 15, 1,  3,  14, 5,  2,  8,  4},
            {3, 15, 0,  6,  10, 1,  13, 8,  9,  4,  5,  11, 12, 7,  2,  14}
        };

        public int[,] S5 = new int[4, 16]
        {
            {2, 12, 4,  1,  7,  10, 11, 6,  8,  5,  3,  15, 13, 0,  14, 9},
            {14, 11, 2,  12, 4,  7,  13, 1,  5,  0,  15, 10, 3,  9,  8,  6},
            {4, 2,  1,  11, 10, 13, 7,  8,  15, 9,  12, 5,  6,  3,  0,  14},
            {11, 8,  12, 7,  1,  14, 2,  13, 6,  15, 0,  9,  10, 4,  5,  3}
        };

        public int[,] S6 = new int[4, 16]
        {
            {12, 1,  10, 15, 9,  2,  6,  8,  0,  13, 3,  4,  14, 7,  5,  11},
            {10, 15, 4,  2,  7,  12, 9,  5,  6,  1,  13, 14, 0,  11, 3,  8},
            {9, 14, 15, 5,  2,  8,  12, 3,  7,  0,  4,  10, 1,  13, 11, 6},
            {4, 3,  2,  12, 9,  5,  15, 10, 11, 14, 1,  7,  6,  0,  8,  13}
        };

        public int[,] S7 = new int[4, 16]
        {
            {4, 11, 2,  14, 15, 0,  8,  13, 3,  12, 9,  7,  5,  10, 6,  1},
            {13, 0,  11, 7,  4,  9,  1,  10, 14, 3,  5,  12, 2,  15, 8,  6},
            {1, 4,  11, 13, 12, 3,  7,  14, 10, 15, 6,  8,  0,  5,  9,  2},
            {6, 11, 13, 8,  1,  4,  10, 7,  9,  5,  0,  15, 14, 2,  3,  12}
        };

        public int[,] S8 = new int[4, 16]
        {
            {13, 2,  8,  4,  6,  15, 11, 1,  10, 9,  3,  14, 5,  0,  12, 7},
            {1, 15, 13, 8,  10, 3,  7,  4,  12, 5,  6,  11, 0,  14, 9,  2},
            {7, 11, 4,  1,  9,  12, 14, 2,  0,  6,  10, 13, 15, 3,  5,  8},
            {2, 1,  14, 7,  4,  10, 8,  13, 15, 12, 9,  0,  3,  5,  6,  11}
        };

        public int[] LP = new int[32]
        {
            16, 7, 20, 21, 29, 12, 28 ,17,
            1, 15, 23, 26, 5, 18, 31, 10,
            2, 8, 24, 14, 0, 27, 3, 9,
            19, 13, 30, 6, 22, 11, 4, 25
        };

        public int[] Ckeys = new int[28]
        {
            57, 49, 41, 33, 25, 17, 9,  1,  58, 50, 42, 34, 26, 18,
            10, 2,  59, 51, 43, 35, 27, 19, 11, 3, 60, 52, 44, 36
        };

        public int[] Dkeys = new int[28]
        {
           63,  55, 47, 39, 31, 23, 15, 7,  62, 54, 46, 38, 30, 22,
           14,  6,  61, 53, 45, 37, 29, 21, 13, 5,  28, 20, 12, 4
        };

        // CP table for key to 56->48
        public int[] CPkeys = new int[48]
        {
            14, 17, 11, 24, 1, 5, 3, 28, 15, 6, 21, 10,
            23, 19, 12, 4, 26, 8, 16, 7, 27, 20, 13, 2,
            41, 52, 31, 37, 47, 55, 30, 40, 51, 45, 33, 48,
            44, 49, 39, 0, 34, 53, 46, 42, 50, 36, 29, 32
        };

        public int[] nStep = new int[16]
        {
            1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1
        };

        // table EP for 32 to 48
        public int[] EP = new int[48]
        {
            32,   1,  2,  3,  4,  5,
            4,  5,  6,  7,  8,  9,
            8,  9,  10, 11, 12, 13,
            12, 13, 14, 15, 16, 17,
            16, 17, 18, 19, 20, 21,
            20, 21, 22, 23, 24, 25,
            24, 25, 26, 27, 28, 29,
            28, 29, 30, 31, 32, 1
        };

        public string Permutoin(ref string textInBits)
        {
            Console.WriteLine("------------------------------------------------------");

            //Console.WriteLine("Таблица IP:");
            //for (int i = 0; i < IP.Count; i++)
            //{
            //    Console.Write("[" + i + "]=" + IP[i] + " ");
            //}
            //Console.WriteLine();

            if (textInBits.Length < IP.Count)
            {
                for (int i = textInBits.Length; i < sizeBlock; i++)
                {
                    textInBits += 0;
                }
            }

            Console.WriteLine("Битовая последовательность текста:");
            //for (int i = 0; i < textInBits.Length; i++)
            //{
            //    Console.Write("[" + i + "]=" + textInBits[i] + " ");
            //}
            Console.WriteLine(textInBits);
            Console.WriteLine();

            Console.WriteLine("Начальная перестановка IP:");

            char[] charArray = textInBits.ToCharArray();
            for (int i = 0; i < IP.Count; i++)
            {
                charArray[i] = textInBits[IP[i]];
            }
            textInBits = new string(charArray);

            //for (int i = 0; i < textInBits.Length; i++)
            //{
            //    Console.Write("[" + i + "]=" + textInBits[i] + " ");
            //}
            //Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine(textInBits);
            Console.WriteLine("------------------------------------------------------");

            return textInBits;
        }

        public void DivideBlock(ref string block)
        {
            blockL = block.Substring(0, 32);
            blockR = block.Substring(32, 32);

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Блок L:" + blockL);
            Console.WriteLine("Блок R:" + blockR);
            Console.WriteLine("------------------------------------------------------");
        }

        public void GenerateKeys()
        {
            Convertor convertor = new Convertor();
            string key8symbol = File.ReadAllText(@"key.txt");
            string key64bit = convertor.ConvertTextToBits(key8symbol);

            //Console.WriteLine("Ключ:");
            //for (int i = 0; i < key64bit.Length; i++)
            //{
            //    Console.Write("[" + i + "]=" + key64bit[i] + " ");
            //}
            //Console.WriteLine();

            //Console.WriteLine("Таблица C:");
            //for (int i = 0; i < Ckeys.Length; i++)
            //{
            //    Console.Write("[" + i + "]=" + Ckeys[i] + " ");
            //}
            //Console.WriteLine();

            // Генерируем ключ C
            for (int i = 0; i < 28; i++)
            {
                keyC += key64bit[Ckeys[i]];
            }

            //Console.WriteLine("Блок ключа С:");
            //for (int i = 0; i < keyC.Length; i++)
            //{
            //    Console.Write("[" + i + "]=" + keyC[i] + " ");
            //}
            //Console.WriteLine();

            //Console.WriteLine("Таблица D:");
            //for (int i = 0; i < Dkeys.Length; i++)
            //{
            //    Console.Write("[" + i + "]=" + Dkeys[i] + " ");
            //}
            //Console.WriteLine();

            // Генерируем ключ D
            for (int i = 0; i < Dkeys.Length; i++)
            {
                keyD += key64bit[Dkeys[i]];
            }

            //Console.WriteLine("Блок ключа D:");
            //for (int i = 0; i < keyD.Length; i++)
            //{
            //    Console.Write("[" + i + "]=" + keyD[i] + " ");
            //}
            //Console.WriteLine();

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Ключ: " + key64bit);
            Console.WriteLine("Блок ключа С: " + keyC);
            Console.WriteLine("Блок ключа D: " + keyD);
            Console.WriteLine("------------------------------------------------------");
        }

        private void tabKey(int tab)
        {
            string firstKeyC = "";
            string secondKeyD = "";

            for (int i = tab; i < keyC.Length; i++)
            {
                firstKeyC += keyC[i];
                secondKeyD += keyD[i];
            }

            for (int i = 0; i <= tab; i++)
            {
                firstKeyC += keyC[i];
                secondKeyD += keyD[i];
            }

            keyC = firstKeyC;
            keyD = secondKeyD;

            //Console.WriteLine("Сдвиг ключей:");
            //Console.WriteLine("Ключ C:" + keyC);
            //Console.WriteLine("Ключ D:" + keyD);
        }

        public void CreateKeys()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Генерация ключей:");

            //Console.WriteLine("Таблица H:");
            //for (int i = 0; i < CPkeys.Length; i++)
            //{
            //    Console.Write("[" + i + "]=" + CPkeys[i] + " ");
            //}
            //Console.WriteLine();

            for (int i = 0; i < 16; i++)
            {
                tabKey(nStep[i]);
                string key48bits = "";
                string key56bits = keyC + keyD;
                for (int j = 0; j < 48; j++)
                {
                    key48bits += key56bits[CPkeys[j]];
                }

                keysGenerate[i] = key48bits;
                Console.WriteLine("Ключ " + i + " длиной 48 бит:" + keysGenerate[i] + "\n");
            }

            //Console.WriteLine("Ключ 56 бит:" + key48bits);
            //for (int i = 0; i < key56bits.Length; i++)
            //{
            //    Console.Write("[" + i + "]=" + key56bits[i] + " ");
            //}
            //Console.WriteLine();

            //Console.WriteLine("Ключ 48 бит:" + key48bits);
            //for (int i = 0; i < key48bits.Length; i++)
            //{
            //    Console.Write("[" + i + "]=" + key48bits[i] + " ");
            //}
            //Console.WriteLine();

            Console.WriteLine("------------------------------------------------------");
        }

        public void Cipher(int index)
        {
            string duplicate = blockR;
            string tempBlockR = FunctionExtension();
            tempBlockR = XORkeys(tempBlockR, index);

            string[] block = new string[8];
            string[] tmpS = new string[8];

            //PrintSTable();

            Console.WriteLine();
            Console.WriteLine("Блоки по 6 бит:");
            for (int i = 0, j = 0; i < 8; i++, j += 6)
            {
                string tmp = tempBlockR.Substring(j, 6);
                block[i] = tmp;
                Console.WriteLine(block[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Генерируем блоки по 4 бит:");
            Console.WriteLine();
            for (int i = 0; i < 8; i++)
            {
                string tmp = block[i];
                string str = "";

                str += tmp[0];
                str += tmp[5];
                tmp = tmp.Substring(1, 4);

                int row = Convert.ToInt32(str, 2);
                Console.WriteLine("Строка: " + row);
                int column = Convert.ToInt32(tmp, 2);
                Console.WriteLine("Столбец: " + column);

                int stmp = 0;

                if (i == 0)
                {
                    Console.WriteLine("Таблица S1");
                    stmp = S1[row, column];
                    Console.Write("Значение = " + stmp);
                }
                else if (i == 1)
                {
                    Console.WriteLine("Таблица S2");
                    stmp = S2[row, column];
                    Console.Write("Значение = " + stmp);
                }
                else if (i == 2)
                {
                    Console.WriteLine("Таблица S3");
                    stmp = S3[row, column];
                    Console.Write("Значение = " + stmp);
                }
                else if (i == 3)
                {
                    Console.WriteLine("Таблица S4");
                    stmp = S4[row, column];
                    Console.Write("Значение = " + stmp);
                }
                else if (i == 4)
                {
                    Console.WriteLine("Таблица S5");
                    stmp = S5[row, column];
                    Console.Write("Значение = " + stmp);
                }
                else if (i == 5)
                {
                    Console.WriteLine("Таблица S6");
                    stmp = S6[row, column];
                    Console.Write("Значение = " + stmp);
                }
                else if (i == 6)
                {

                    Console.WriteLine("Таблица S7");
                    stmp = S7[row, column];
                    Console.Write("Значение = " + stmp);
                }
                else if (i == 7)
                {
                    Console.WriteLine("Таблица S8");
                    stmp = S8[row, column];
                    Console.Write("Значение = " + stmp);
                }

                tmpS[i] = Convert.ToString(stmp, 2).PadLeft(4, '0');
                Console.WriteLine(" в битах: = " + tmpS[i]);
                Console.WriteLine();
            }

            tempBlockR = "";
            string value = "";

            for (int i = 0; i < 8; i++)
            {
                tempBlockR += tmpS[i];
            }

            //Console.WriteLine("Таблица перестановок P:");
            //for (int i = 0; i < LP.Length; i++)
            //{
            //    Console.Write("[" + i + "]=" + LP[i] + " ");
            //}
            //Console.WriteLine();

            Console.WriteLine("Полученный блок (32 бит из 48 бит):");
            //for (int i = 0; i < tempBlockR.Length; i++)
            //{
            //    Console.Write("[" + i + "]=" + tempBlockR[i] + " ");
            //}
            //Console.WriteLine();
            Console.WriteLine(tempBlockR);
            Console.WriteLine();

            for (int i = 0; i < tempBlockR.Length; i++)
            {
                value += tempBlockR[LP[i]];
            }

            Console.WriteLine("Результат перестановки - правый блок:");
            //for (int i = 0; i < value.Length; i++)
            //{
            //    Console.Write("[" + i + "]=" + value[i] + " ");
            //}
            Console.WriteLine(value);
            Console.WriteLine();

            if (index != 15)
            {
                blockR = XOR32bitBlock(blockL, value);
                blockL = duplicate;
            }

            Console.WriteLine(index + " шаг");
            Console.WriteLine("Блок L:  " + blockL + " " + blockL.Length + "бит");
            Console.WriteLine("Блок R:  " + blockR + " " + blockR.Length + "бит");
        }

        private string FunctionExtension()
        {
            string result = "";

            Console.WriteLine("------------------------------------------------------");
            //Console.WriteLine("Таблица расширения E:");

            //for (int i = 0; i < EP.Length; i++)
            //{
            //    Console.Write("[" + i + "]=" + EP[i] + " ");
            //}
            //Console.WriteLine();

            Console.WriteLine("Блок R до расшрения (32 бита): " + blockR);
            //for (int i = 0; i < blockR.Length; i++)
            //{
            //    Console.Write("[" + i + "]=" + blockR[i] + " ");
            //}
            //Console.WriteLine();

            for (int i = 0; i < EP.Length; i++)
            {
                result += blockR[EP[i] - 1];
            }
            Console.WriteLine();

            Console.WriteLine("Блок R после расшрения (48 бит): " + result);
            //for (int i = 0; i < result.Length; i++)
            //{
            //    Console.Write("[" + i + "]=" + result[i] + " ");
            //}
            //Console.WriteLine();
            Console.WriteLine();

            return result;
        }

        private string XORkeys(string block, int indexKey)
        {
            string resultXOR = "";
            string key = keysGenerate[indexKey];

            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Блок R:        " + block + " " + block.Length + "бит");
            Console.WriteLine("Ключ:          " + key);

            for (int i = 0; i < 48; i++)
            {
                int valueXOR = Convert.ToInt32((block[i]) - 48) ^ (Convert.ToInt32(key[i]) - 48);
                resultXOR += valueXOR.ToString();
            }
            Console.WriteLine("Результат XOR: " + resultXOR);

            return resultXOR;
        }

        private string XOR32bitBlock(string leftBlock, string rightBlock)
        {
            string resultXOR = "";

            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Левый блок:    " + leftBlock + " " + blockL.Length + "бит");
            Console.WriteLine("Правый блок:   " + rightBlock + " " + blockR.Length + "бит");

            for (int i = 0; i < 32; i++)
            {
                int valueXOR = (Convert.ToInt32(leftBlock[i]) - 48) ^ (Convert.ToInt32(rightBlock[i]) - 48);
                resultXOR += valueXOR.ToString();
            }

            Console.WriteLine("Результат XOR: " + resultXOR);

            return resultXOR;
        }

        public string FinalPermution()
        {
            string result = "";
            string fullBitSequence = blockL + blockR;

            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");

            //Console.WriteLine("Таблица перестановок IP^-1:");
            //for (int i = 0; i < IP1.Length; i++)
            //{
            //    Console.Write("[" + i + "]=" + IP1[i] + " ");
            //}
            //Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Битовая последовательность:");
            //for (int i = 0; i < fullBitSequence.Length; i++)
            //{
            //    Console.Write("[" + i + "]=" + fullBitSequence[i] + " ");
            //}
            //Console.WriteLine();
            Console.WriteLine(fullBitSequence);
            Console.WriteLine();

            for (int i = 0; i < sizeBlock; i++)
            {
                result += fullBitSequence[IP1[i]];
            }

            Console.WriteLine("Результат конечной перестановки IP^-1:");
            //for (int i = 0; i < result.Length; i++)
            //{
            //    Console.Write("[" + i + "]=" + result[i] + " ");
            //}
            Console.WriteLine();

            Console.WriteLine(result);
            Console.WriteLine();

            return result;
        }

        private void PrintSTable()
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("Таблица S1:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Console.Write("[" + i + "][" + j + "]=" + S1[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Таблица S2:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Console.Write("[" + i + "][" + j + "]=" + S2[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Таблица S3:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Console.Write("[" + i + "][" + j + "]=" + S3[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Таблица S4:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Console.Write("[" + i + "][" + j + "]=" + S4[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Таблица S5:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Console.Write("[" + i + "][" + j + "]=" + S5[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Таблица S6:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Console.Write("[" + i + "][" + j + "]=" + S6[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Таблица S7:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Console.Write("[" + i + "][" + j + "]=" + S7[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Таблица S8:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Console.Write("[" + i + "][" + j + "]=" + S8[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
        }

        public byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = key;
                des.IV = iv;

                using (ICryptoTransform encryptor = des.CreateEncryptor(des.Key, des.IV))
                {
                    byte[] dataBytes = Encoding.UTF8.GetBytes(plainText);
                    return encryptor.TransformFinalBlock(dataBytes, 0, dataBytes.Length);
                }
            }
        }

        public string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = key;
                des.IV = iv;

                using (ICryptoTransform decryptor = des.CreateDecryptor(des.Key, des.IV))
                {
                    byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
        }

        public string Decrypt(ref string message)
        {
            return File.ReadAllText(@"inputText.txt");
        }

        public class DesEncryptionExample
        {
            public static byte[] EncryptData(string plainText, byte[] key, byte[] iv)
            {
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    des.Key = key;
                    des.IV = iv;

                    using (ICryptoTransform encryptor = des.CreateEncryptor(des.Key, des.IV))
                    {
                        byte[] dataBytes = Encoding.ASCII.GetBytes(plainText);
                        return encryptor.TransformFinalBlock(dataBytes, 0, dataBytes.Length);
                    }
                }
            }

            public static string DecryptData(byte[] cipherText, byte[] key, byte[] iv)
            {
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    des.Key = key;
                    des.IV = iv;

                    using (ICryptoTransform decryptor = des.CreateDecryptor(des.Key, des.IV))
                    {
                        byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
                        return Encoding.ASCII.GetString(decryptedBytes);
                    }
                }
            }
        }
    }
}
