using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Documents;

namespace PasswordGenerator
{
//TODO: 1. create empty result string
//TODO: 2. generate byte and convert to char
//TODO: 3. if char is valid append to result string
//TODO: 4. create list of strings
    public static class PasswordGeneratorModel
    {
        const string _validCompl = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~`@#$&^'<>?!/{}[]+=-_)(*%";
        const string _validSimple = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";


        public static IEnumerable<PasswordModel> GetPasswords(int lenght, int count, PasswordCompl compl)
        {
            var result = new List<PasswordModel>();

            for (int i = 0; i < count; i++)
            {
                switch (compl)
                {
                    case PasswordCompl.Simple:
                        result.Add(new PasswordModel { Password = GetRandomString(lenght, _validSimple) });
                        break;
                    case PasswordCompl.Complicated:
                        result.Add(new PasswordModel { Password = GetRandomString(lenght, _validCompl) });
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(compl), compl, null);
                }
                
            }

            return result;
        }

        public static string GetRandomString(int length, string template)
        {
            var result = "";
            using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
            {
                while (result.Length != length)
                {
                    byte[] oneByte = new byte[1];

                    rngCsp.GetBytes(oneByte);

                    char character = (char)oneByte[0];

                    if (template.Contains(character))
                    {
                        result += character;
                    }
                }
            }

            return result;
        }


     }
}