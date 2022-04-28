using System;

namespace RotmgNetworkingLib.Utilities
{
    public static class TimeUtil
    {
        public static long UnixMillis() => new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
    }
}
