using System;
using System.Text;

namespace RotmgNetworkingLib.Utilities
{
    public static class Conversion
    {
        public static byte[] HexToByteArray(string input)
        {
            byte[] numArray = (uint)(input.Length % 2) <= 0U ? new byte[input.Length / 2] : throw new ArgumentException("Invalid hex string");
            char[] charArray = input.ToCharArray();

            for (int index = 0; index < charArray.Length; index += 2)
            {
                int int32 = Convert.ToInt32(new StringBuilder(2).Append(charArray[index]).Append(charArray[index + 1]).ToString(), 16);
                numArray[index / 2] = (byte)int32;
            }

            return numArray;
        }

        public static string ByteArrayToHex(byte[] input)
        {
            StringBuilder hex = new StringBuilder(input.Length * 2);
            foreach (byte b in input)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public static bool StringToBool(string input) => input != null && (input == "1" || input == "True" || input == "true");

        public static int[] NullableUShortArrayToIntArray(ushort?[] input) => Array.ConvertAll(input, NullableUShortToInt);

        public static int NullableUShortToInt(ushort? input) => input ?? -1;

        public static ushort?[] IntArrayToNullableUShortArray(int[] input) => Array.ConvertAll(input, IntToNullableUShort);

        public static ushort? IntToNullableUShort(int input)
        {
            if (input == -1)
                return null;
            else
                return (ushort)input;
        }
    }
}
