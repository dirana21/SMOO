namespace Task3
{
    public class BCipher : ICipher
    {
        public string Encrypt(string textToEncrypt)
        {
            string encryptedText = string.Empty;
            for (int i = 0; i < textToEncrypt.Length; i++)
            {
                char letter = textToEncrypt[i];
                if (char.ToUpper(letter) >= 'A' && char.ToUpper(letter) <= 'Z')
                {
                    if (char.ToUpper(letter) == 'Z') encryptedText += (char)('A' + 1); 
                    else encryptedText += (char)(letter + (i + 1));
                }
                else
                {
                    encryptedText = $"This is wrong letter: {letter}, input must start with 'A' to 'B'";
                }
            }
            return encryptedText;
        }

        public string Decrypt(string TextToDecrypt)
        {
            string decryptedText = string.Empty;
            for (int i = 0; i < TextToDecrypt.Length; i++)
            {
                char letter = TextToDecrypt[i];
                if (char.ToUpper(letter) >= 'A' && char.ToUpper(letter) <= 'Z')
                {
                    if (char.ToUpper(letter) == 'A') decryptedText += (char)('Z' - 1); 
                    else decryptedText += (char)(letter + (i - 1));
                }
                else
                {
                    decryptedText = $"This is wrong letter: {letter}, input must start with 'A' to 'B'";
                }
            }
            return decryptedText;
        }
    }
}