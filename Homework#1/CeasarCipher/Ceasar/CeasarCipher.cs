using System;
using System.Text;

namespace Ceasar.Cipher
{
    public class CeasarCipher
    {
        private readonly int _offset;
        private readonly int endASCIIIndex = 126;
        private readonly int startASCIIIndex = 32;

        public CeasarCipher(int offset)
        {
            _offset = offset;
        }

        public string Encrypt(string plaintext)
        {
            ValidateInputString(plaintext);
            return Shift(plaintext, _offset);
        }

        public string Decrypt(string ciphertext)
        {
            ValidateInputString(ciphertext);
            return Shift(ciphertext, _offset*-1);
        }

        public static int Mod(int number, int modBase)
        {
            var mod = number%modBase;
            while (mod < 0)
            {
                mod += modBase;
            }
            return mod;
        }

        public void ValidateInputString(string stringToValidate)
        {
            if (stringToValidate == null)
                throw new ArgumentNullException(nameof(stringToValidate), "Input string can't be NULL");
            var stringToValidateBytes = Encoding.ASCII.GetBytes(stringToValidate);
            foreach (var b in stringToValidateBytes)
            {
                if (b < startASCIIIndex || b > endASCIIIndex)
                {
                    throw new ArgumentOutOfRangeException(nameof(stringToValidate),
                        "Input string contains forbidden symbols");
                }
            }
        }

        public string Shift(string stringToShift, int offset)
        {
            if (offset == 0) return stringToShift;
            var inputBytes = Encoding.ASCII.GetBytes(stringToShift);
            var outputBytes = new byte[stringToShift.Length];
            for (var i = 0; i < outputBytes.Length; i++)
            {
                var temp = Mod(inputBytes[i] + offset, endASCIIIndex);
                if (temp >= startASCIIIndex)
                {
                    outputBytes[i] = BitConverter.GetBytes(temp)[0];
                }
                else
                {
                    outputBytes[i] =
                        BitConverter.GetBytes(temp +
                                              (offset > 0
                                                  ? (startASCIIIndex - 1)
                                                  : (endASCIIIndex - startASCIIIndex + 1)))[0];
                }
            }
            return Encoding.ASCII.GetString(outputBytes);
        }
    }
}