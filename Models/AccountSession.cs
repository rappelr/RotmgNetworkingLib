using RotmgNetworkingLib.Utilities;

namespace RotmgNetworkingLib.Models
{
    public class AccountSession
    {
        public readonly string Guid;
        public readonly string Password;
        public readonly bool IsSteamAccount;
        public readonly string UserToken;

        public string Name;
        public AccessToken AccessToken;
        public int TargetChar;

        public AccountSession(string guid, string password, string userToken) : this()
        {
            Guid = guid;
            Password = password;
            UserToken = userToken;

            IsSteamAccount = Guid.StartsWith("steamworks:");
        }

        public AccountSession(string guid, string password) : this()
        {
            Guid = guid;
            Password = password;
            UserToken = Generator.GenerateUserToken();

            IsSteamAccount = Guid.StartsWith("steamworks:");
        }

        public AccountSession()
        {
            Reset();
        }

        public void Reset()
        {
            Name = null;
            AccessToken = null;
            TargetChar = -1;
        }
    }
}
