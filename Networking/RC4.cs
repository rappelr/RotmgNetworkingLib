using RotmgNetworkingLib.Utilities;

namespace RotmgNetworkingLib.Networking
{
    public class RC4
    {
        private const int STATE_LENGTH = 256;

        private byte[] engineState;
        private byte[] workingKey;

        private int x;
        private int y;

        public RC4(byte[] key)
        {
            workingKey = key;

            SetKey(workingKey);
        }

        public void Cipher(byte[] packet, int slice) => ProcessBytes(packet, slice, packet.Length - slice, packet, slice);

        public void Reset() => SetKey(workingKey);

        public string VisualizeEngineState() => Conversion.ByteArrayToHex(engineState);

        private void ProcessBytes(byte[] input, int inOff, int length, byte[] output, int outOff)
        {
            for (int index = 0; index < length; ++index)
            {
                x = x + 1 & (int)byte.MaxValue;
                y = (int)engineState[x] + y & (int)byte.MaxValue;
                byte num = engineState[x];
                engineState[x] = engineState[y];
                engineState[y] = num;
                output[index + outOff] = (byte)(input[index + inOff] ^ (uint)engineState[engineState[x] + engineState[y] & byte.MaxValue]);
            }
        }

        private void SetKey(byte[] keyBytes)
        {
            workingKey = keyBytes;

            x = y = 0;

            if (engineState == null)
                engineState = new byte[STATE_LENGTH];

            for (int index = 0; index < STATE_LENGTH; ++index)
                engineState[index] = (byte)index;

            int index1 = 0;
            int index2 = 0;

            for (int index3 = 0; index3 < STATE_LENGTH; ++index3)
            {
                index2 = (keyBytes[index1] & byte.MaxValue) + engineState[index3] + index2 & byte.MaxValue;

                byte num = engineState[index3];
                engineState[index3] = engineState[index2];
                engineState[index2] = num;

                index1 = (index1 + 1) % keyBytes.Length;
            }
        }
    }
}
