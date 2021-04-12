using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RSA_2048
{
    class RSA2048
    {
        public static void RsaRunner() 
        {
            // Create variables and objects that will convert the text to an encrypted one.
            
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();  
            byte[] Original;  
            byte[] Encrypted;
            byte[] Decrypted;
            string Input = Console.ReadLine();    //User input is always in string format.
            Original= System.Text.Encoding.UTF8.GetBytes (Input);    //Due to how RSA protocol methods work the string needs to be byte array thus a conversion using standard UTF-8 is needed ASCII based conversion is also available.

            //Original for test purposes only.
            Console.WriteLine("Original:{0}", Encoding.Default.GetString(Original));
            //Encrypted .
            Encrypted=RsaEncryption(Original, RSA.ExportParameters(false), false);
            Console.WriteLine("Encrypted:"); // For testing purposes only in case we need to see the encrypted text.
            foreach (byte i in Encrypted)
            {
                Console.Write(i.ToString());
            }
            //Decrypted Original. 
            Decrypted=RsaDecryption(Encrypted, RSA.ExportParameters(true), false);
            Console.WriteLine("\nDecrypted:{0}", Encoding.Default.GetString(Decrypted));
        }
        //Method used for encrypting data. 
        static public byte[] RsaEncryption(byte[] Original, RSAParameters RSAKey, bool DoOAEPPadding)  
        {  
            try  //try-catch block if the user enters a null string of text.
            {  
                byte[] encryptedData;  //use a new byte[] in order to return the encrypted result.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())  
                {  
                    RSA.ImportParameters(RSAKey);  
                    encryptedData = RSA.Encrypt(Original, DoOAEPPadding);  
                }   
                return encryptedData;  //return the encrypted text.
            }  
            catch (CryptographicException e)  
            {  
                Console.WriteLine(e.Message);  
                return null;  
            }  
        }
        
        static public byte[] RsaDecryption(byte[]Encrypted, RSAParameters RSAKey, bool DoOAEPPadding)  
        {  
            try  //try-catch block if the user enters a null string of text.
            {  
                byte[] decryptedData;  
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())  
                {  
                    RSA.ImportParameters(RSAKey);  
                    decryptedData = RSA.Decrypt(Encrypted, DoOAEPPadding);  
                }  
                return decryptedData;  
            }  
            catch (CryptographicException e)  
            {  
                Console.WriteLine(e.ToString());  
                return null;  
            }          
        }
    }
}