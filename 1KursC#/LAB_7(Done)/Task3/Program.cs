namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ACipher acp = new ACipher();
            string AencodedText = acp.Encrypt("AbCd");
            Console.WriteLine("Encoded text A:");
            Console.WriteLine(AencodedText);
            Console.WriteLine("Decoded text A:");
            Console.WriteLine(acp.Decrypt(AencodedText));
            
            BCipher bcp = new BCipher();
            string BencodedText = bcp.Decrypt("AbCd");
            Console.WriteLine("Encoded text B:");
            Console.WriteLine(BencodedText);
            Console.WriteLine("Decoded text B:");
            Console.WriteLine(bcp.Decrypt(BencodedText));
        }
    }
}