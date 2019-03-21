using System;
using System.Security.Cryptography;
using System.Text;

namespace DeterministicGuidBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DeterministicGuidBuilder.Build("hello"));
            Console.WriteLine("press any key to exit");
            Console.ReadLine();
        }
    }

    class DeterministicGuidBuilder
    {
        public static Guid Build(string input)
        {
            //use MD5 hash to get a 16-byte hash of the string
            using (var provider = new MD5CryptoServiceProvider())
            {
                var inputBytes = Encoding.Default.GetBytes(input);
                var hashBytes = provider.ComputeHash(inputBytes);
                //generate a guid from the hash:
                return new Guid(hashBytes);
            }
        }
    }
}
