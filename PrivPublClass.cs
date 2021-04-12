using System;  
using System.IO;  
using System.Security.Cryptography;  
using System.Text;   
  
namespace Asymmetric  
{  
    class PrivPublClass 
    {  
  
        public static void PrivPublRunner()  
        {  
            // Create an instance of the RSA algorithm class.  
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();  
            // Get the public key.   
            string publicKey = rsa.ToXmlString(false); // false to get the public key.   
            string privateKey = rsa.ToXmlString(true); // true to get the private key.   

            byte[] encrypted = new byte[] { };        //this is used to store the encrypted text can also be made with .dat file. 
            string decrypted ;                          // this is used to store the decrypted data aka original message (if it is in byte[] form it creates spaces between each character so it is needed to be in string form).
            string password = Console.ReadLine();   //user input of password.
            
            Console.WriteLine("Original text:{0}",password);
            // Call the encryptText method.   
            EncryptText(publicKey, password, out encrypted);  
            Console.WriteLine("Encrypted:"); // For testing purposes only in case we need to see the encrypted text.
            foreach (byte i in encrypted)
            {
                Console.Write(i.ToString());
            }

            // Call the decryptData method and print the result on the screen. 
            decrypted = DecryptData(privateKey, encrypted);
            Console.WriteLine("\nDecrypted:{0}", decrypted);   
  
        }  
  
        // Create a method to encrypt a text and save it to a specific file using a RSA algorithm public key.   
        static void EncryptText(string publicKey ,string text,out byte[] encrypted)  
        {  
            // Check argument.
            if (text == null || text.Length <= 0)
                throw new ArgumentNullException("NULLTEXT");
           
            // Convert the text to an array of bytes   
            UnicodeEncoding byteConverter = new UnicodeEncoding();  
            byte[] dataToEncrypt = byteConverter.GetBytes(text);  
  
            // Create a byte array to store the encrypted data in it.   
            byte[] encryptedData;   
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())  
            {  
                // Set the rsa pulic key.   
                rsa.FromXmlString(publicKey);  
  
                // Encrypt the data and store it in the encyptedData Array.   
                encryptedData = rsa.Encrypt(dataToEncrypt, false);   
            }  
            // Save the encypted data array into a variable.   
            encrypted=encryptedData;  
            Console.WriteLine("Encryption Completed");   
        }  
  
        // Method to decrypt the data withing a specific file using a RSA algorithm private key.   
        static string DecryptData(string privateKey,byte[] encrypted)  
        {  
            // read the encrypted bytes from the file.   
            byte[] dataToDecrypt = encrypted;  
  
            // Create an array to store the decrypted data in it.   
            byte[] decryptedData;  
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())  
            {  
                // Set the private key of the algorithm .  
                rsa.FromXmlString(privateKey);  
                decryptedData = rsa.Decrypt(dataToDecrypt, false);   
            }  
  
            // Get the string value from the decryptedData byte array. 
            UnicodeEncoding byteConverter = new UnicodeEncoding();  
            return byteConverter.GetString(decryptedData);   
               
        }  
    }  
}  