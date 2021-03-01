using System;
using System.Text;

namespace ExpositTestTask
{
    public static class CommonMethods
    { 
        public static string GenerateRandomString(int length = 10)
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var result = new StringBuilder(length);

            for (var i = 0; i < length; i++)
            {
                result.Append(characters[new Random().Next(characters.Length)]);
            }

            return result.ToString();
        }
    }
}
