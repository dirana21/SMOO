namespace Task3
{
    public class ACipher : ICipher
    {
        public string Encrypt(string textToEncrypt)
        {
            string encryptedText = string.Empty;
            for (int i = 0; i < textToEncrypt.Length; i++)
            {
                char letter = textToEncrypt[i];
                if (char.ToUpper(letter) >= 'A' && char.ToUpper(letter) <= 'Z')
                {
                    if(char.ToUpper(letter) == 'Z') encryptedText += 'A';
                    else encryptedText += (char)(letter + 1);
                }
                else
                {
                    encryptedText = $"This is wrong letter: {letter}, input must start with 'A' to 'B'";
                    break;
                }
            }

            return encryptedText;
        }
        
        public string Decrypt(string textToDecrypt)
        {
            string decryptedText = string.Empty;
            for (int i = 0; i < textToDecrypt.Length; i++)
            {
                char letter = textToDecrypt[i];
                if (char.ToUpper(letter) >= 'A' && char.ToUpper(letter) <= 'Z')
                {
                    if(char.ToUpper(letter) == 'A') decryptedText += 'Z';
                    else decryptedText += (char)(letter - 1);
                }
                else
                {
                    decryptedText = $"This is wrong letter: {letter}, input must start with 'A' to 'B'";
                    break;
                }
            }

            return decryptedText;
        }
    }
}   