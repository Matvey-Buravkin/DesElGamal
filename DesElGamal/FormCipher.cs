using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Numerics;
using static DesElGamal.DES;
using System.Security.Cryptography;

namespace DesElGamal
{
    public partial class FormCipher : Form
    {
        public FormCipher()
        {
            InitializeComponent();
        }

        string inputText;
        string key8symbol = File.ReadAllText(@"key.txt");

        Convertor convertor = new Convertor();
        DES des = new DES();
        ElGamal elGamal = new ElGamal();

        string fullEncryptText = "";
        int countBlock = 1;

        string koefP = null;
        string koefG = null;
        string koefX = null;
        string koefY = null;
        string koefK = null;
        string koefA = null;
        string koefB = null;
        BigInteger M;

        byte[] key;
        byte[] iv = Encoding.UTF8.GetBytes("tommorow");
        byte[] encrypted;
        byte[] encryptedData;
        string decryptedData;

        private void buttonLoadMessage_Click(object sender, EventArgs e)
        {
            inputText = File.ReadAllText(@"inputText.txt");
            textBoxLoadMessage.Text = inputText;
        }

        private void buttonGenerateKey_Click(object sender, EventArgs e)
        {
            textBoxLoadKey.Text = key8symbol;
        }

        private void buttonCipherMessage_Click(object sender, EventArgs e)
        {
            // 1 - ступень 
            // Метод DES

            key8symbol = textBoxLoadKey.Text;

            key = Encoding.UTF8.GetBytes(key8symbol);
            //File.WriteAllText(@"text.txt", inputText);

            //Перевод ключа 8 символов в 64 бит
            string key64bit = convertor.ConvertTextToBits(key8symbol);

            // Перевод текста в биты
            string inputTextToBits = convertor.ConvertTextToBits(inputText);

            //--------------------------------------------------------------------------------------
            //------------------------------Алгоритм Шифрования DES---------------------------------
            //--------------------------------------------------------------------------------------

            for (int i = 0; i < inputTextToBits.Length; i += des.sizeBlock)
            {
                // Делим текст-биты на блока по 64
                string block = inputTextToBits.Substring(i, Math.Min(des.sizeBlock, inputTextToBits.Length - i));

                Console.WriteLine("\t\t\t" + countBlock + " Блок данных");
                countBlock++;

                // Началаьная перестановка
                string initalPermution = des.Permutoin(ref block);

                // Делим блок данных на 2 по 32 бита
                des.DivideBlock(ref initalPermution);

                // Генерация блоков C и D ключа
                des.GenerateKeys();

                // Генерация 16 ключей
                des.CreateKeys();

                // Цикл шифрований 16 раз
                for (int j = 0; j < des.countRound; j++)
                {
                    des.Cipher(j);
                }

                // Конченая перестановка IP^-1
                string cipherText = des.FinalPermution();

                // Перевод бит в текст
                string encryptText = convertor.ConvertBitsToText(cipherText);
                fullEncryptText = encryptText;
            }

            encryptedData = des.EncryptStringToBytes(inputText, key, iv);
            Console.WriteLine("Encrypted: " + Convert.ToBase64String(encryptedData));

            textBoxCipherMessage.Text = Convert.ToBase64String(encryptedData);


            //--------------------------------------------------------------------------------------
            //------------------------------Алгоритм Шифрования DES---------------------------------
            //--------------------------------------------------------------------------------------


            // 2 - ступень
            // Метод Эль-Гамаль

            //--------------------------------------------------------------------------------------
            //---------------------Алгоритм Шифрования Эль-Гамаль-----------------------------------
            //--------------------------------------------------------------------------------------

            //  Сгенерировать p
            koefP = elGamal.GenerateP();
            labelP.Text = "p = " + koefP;

            //  Сгенерировать g
            koefG = elGamal.GenerateG();
            labelG.Text = "g = " + koefG;

            //  Сгенерировать x
            koefX = elGamal.GenerateX();

            //  Сгенерировать y
            koefY = elGamal.GenerateY();
            labelY.Text = "y = " + koefY;

            //  Сгенерировать k
            koefK = elGamal.GenerateK();

            //  Сгенерировать a
            koefA = elGamal.GenerateA();
            labelA.Text = "a = " + koefA;

            //  Сгенерировать b
            M = BigInteger.Parse(convertor.ConvertTextToBits(key8symbol));
            koefB = elGamal.GenerateB(ref M);
            labelB.Text = "b = " + koefB;

            //textBoxCipherKey.Text = convertor.ConvertText(koefA + koefB);
            textBoxCipherKey.Text = Convert.ToBase64String(Encoding.UTF8.GetBytes(koefA + koefB));

            //--------------------------------------------------------------------------------------
            //---------------------Алгоритм Шифрования Эль-Гамаль-----------------------------------
            //--------------------------------------------------------------------------------------
        }

        private void buttonSaveCipherMessage_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"cipherText.txt", textBoxCipherMessage.Text);
        }

        private void buttonDecryptMessage_Click(object sender, EventArgs e)
        {
            decryptedData = des.DecryptStringFromBytes(encryptedData, key, iv);
            Console.WriteLine("Decrypted: " + decryptedData);
            textBoxDecryptMessage.Text = decryptedData;
        }

        private void buttonEnterSms_Click(object sender, EventArgs e)
        {
            inputText = textBoxLoadMessage.Text;
        }

    }
}
