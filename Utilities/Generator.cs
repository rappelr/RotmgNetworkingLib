using System;

namespace RotmgNetworkingLib.Utilities
{
    public static class Generator
    {
        private static readonly char[] _userTokenChars = "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();

        public static string GenerateUserToken()
        {
            string content = "";
            Random random = new Random();

            while (content.Length < 40)
                content += _userTokenChars[random.Next(0, _userTokenChars.Length)];

            return content;
        }
    }
}
