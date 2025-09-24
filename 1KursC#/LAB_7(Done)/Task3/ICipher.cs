namespace Task3
{
    public interface ICipher
    {
        public string Encrypt(string text);
        public string Decrypt(string text);
    }
}