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
            if (plaintext == null) throw new ArgumentNullException(nameof(plaintext), "Plaintext can't be NULL");
            var plaintextBytes = Encoding.ASCII.GetBytes(plaintext);
            foreach (var b in plaintextBytes)
            {
                if (b < startASCIIIndex || b > endASCIIIndex)
                {
                    throw new ArgumentOutOfRangeException(nameof(plaintext), "Plaintext contains forbidden symbols");
                }
            }
            var ciphertextBytes = new byte[plaintext.Length];
            for (var i = 0; i < ciphertextBytes.Length; i++)
            {
                var encryptedTemp = Mod(plaintextBytes[i] + _offset, endASCIIIndex);
                if (encryptedTemp >= startASCIIIndex)
                {
                    ciphertextBytes[i] = BitConverter.GetBytes(encryptedTemp)[0];
                }
                else
                {
                    ciphertextBytes[i] = BitConverter.GetBytes(encryptedTemp + startASCIIIndex - 1)[0];
                }
            }
            return Encoding.ASCII.GetString(ciphertextBytes);
        }

        public string Decrypt(string ciphertext)
        {
            if (ciphertext == null) throw new ArgumentNullException(nameof(ciphertext), "Ciphertext can't be NULL");
            var ciphertextBytes = Encoding.ASCII.GetBytes(ciphertext);
            foreach (var b in ciphertextBytes)
            {
                if (b < startASCIIIndex || b > endASCIIIndex)
                {
                    throw new ArgumentOutOfRangeException(nameof(ciphertext), "Ciphertext contains forbidden symbols");
                }
            }
            var plaintextBytes = new byte[ciphertext.Length];
            for (var i = 0; i < plaintextBytes.Length; i++)
            {
                var decryptedTemp = Mod(ciphertextBytes[i] - _offset, endASCIIIndex);
                if (decryptedTemp >= startASCIIIndex)
                {
                    plaintextBytes[i] = BitConverter.GetBytes(decryptedTemp)[0];
                }
                else
                {
                    plaintextBytes[i] = BitConverter.GetBytes(endASCIIIndex - startASCIIIndex + decryptedTemp + 1)[0];
                }
            }
            return Encoding.ASCII.GetString(plaintextBytes);
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
    }
}