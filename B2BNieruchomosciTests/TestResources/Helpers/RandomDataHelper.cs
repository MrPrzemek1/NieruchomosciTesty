using System;
using System.Linq;

namespace TestResources
{
    public static class RandomDataHelper
    {
        public static string RandomString(int lenght)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, lenght)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static int RandomPostCode()
        {
            Random random = new Random();
            int randomnumber = random.Next(10000,20000);
            return randomnumber;
        }
    }
}
