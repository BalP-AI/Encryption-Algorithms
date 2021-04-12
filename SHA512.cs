using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SHA_512
{
    class SHA_512
    {
        public static void SHARunner()
        {
            string Original = Console.ReadLine(); //original text input by user.
            var OriginalBytes = Encoding.ASCII.GetBytes(Original); //get the number of bytes from the inputted text. 
            var sha = new SHA512Managed();  //create a new object of sha512 to manage all the hashing.
            var hashed = sha.ComputeHash(OriginalBytes);    //generate the hashed text.
            Console.WriteLine("Hashed:");  //print the final result 
            foreach (byte i in hashed)
            {
                Console.Write(i.ToString());
            }

        }
        
    }
}