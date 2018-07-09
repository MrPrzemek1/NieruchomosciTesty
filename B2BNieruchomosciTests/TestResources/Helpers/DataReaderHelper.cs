using System.IO;
using System.Linq;

namespace TestResources.Helpers
{
    public static class DataReaderHelper
    {
        public static string GetLogin()
        {
            string login;
            return login = File.ReadLines(@"D:\DaneLogowania.txt").First();
        }
        public static string GetPassword()
        {
            string password;
            return password = File.ReadLines(@"D:\DaneLogowania.txt").Skip(1).Take(2).First();
        }
    }
}
