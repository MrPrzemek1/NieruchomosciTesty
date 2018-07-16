using System;
using System.Linq;

namespace TestResources
{
    public static class RandomDataHelper
    {
        static Random random = new Random();

        public static string RandomString(int lenght)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, lenght)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static int RandomInt()
        {
            int randomnumber = random.Next(10000,20000);
            return randomnumber;
        }

    }
}
