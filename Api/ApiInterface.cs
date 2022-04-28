using QR9ProxyLib.HTTP;
using QR9ProxyLib.Pool;
using RotmgNetworkingLib.Api.Models;
using RotmgNetworkingLib.Models;
using RotmgNetworkingLib.Networking;
using RotmgNetworkingLib.Utilities;
using System;
using System.Collections.Specialized;

namespace RotmgNetworkingLib.Api
{
    public class ApiInterface
    {
        public DynamicProxyPool<HTTPProxy> ProxyPool
        {
            get => _webClient.ProxyPool;
            set => _webClient.ProxyPool = value;
        }

        public bool SafeMode;

        private readonly RotmgWebClient _webClient;

        public ApiInterface(RotmgWebClient webClient)
        {
            _webClient = webClient ?? throw new ArgumentNullException(nameof(webClient));
            SafeMode = true;
        }

        public ApiInterface(DynamicProxyPool<HTTPProxy> proxyPool, bool safeMode) : this()
        {
            _webClient.ProxyPool = proxyPool;
            SafeMode = safeMode;
        }

        public ApiInterface()
        {
            _webClient = new RotmgWebClient();
            SafeMode = true;
        }

        public ApiResponse<AccountElement> VerifyAccount(AccountSession account, bool muleDump = false)
        {
            var @params = new NameValueCollection
            {
                ["guid"] = account.Guid,
                [account.IsSteamAccount ? "secret" : "password"] = account.Password,
                ["clientToken"] = account.UserToken,
                ["game_net"] = account.IsSteamAccount ? "Unity_steam" : "Unity",
                ["play_platform"] = account.IsSteamAccount ? "Unity_steam" : "Unity",
                ["game_net_user_id"] = ""
            };

            if (muleDump)
            {
                @params.Add("muleDump", "true");
                @params.Add("__source", "jakcodex-v965");
            }

            return Query<AccountElement>("account/verify", @params);
        }

        public ApiResponse<SuccessElement> VerifyAccessTokenClient(AccountSession account)
        {
            if (account.AccessToken == null)
                throw new ArgumentException("AccessToken null for given AccountSession");

            var @params = new NameValueCollection   
            {
                ["accessToken"] = account.AccessToken.Value,
                ["clientToken"] = account.UserToken,
                ["game_net"] = account.IsSteamAccount ? "Unity_steam" : "Unity",
                ["play_platform"] = account.IsSteamAccount ? "Unity_steam" : "Unity",
                ["game_net_user_id"] = ""
            };

            return Query<SuccessElement>("account/verifyAccessTokenClient", @params);
        }

        public ApiResponse<CharsElement> FetchCharList(AccountSession account, bool doLogin = true, bool muleDump = false)
        {
            if (account.AccessToken == null)
                throw new ArgumentException("AccessToken null for given AccountSession");

            var @params = new NameValueCollection
            {
                ["accessToken"] = account.AccessToken.Value,
                ["game_net"] = account.IsSteamAccount ? "Unity_steam" : "Unity",
                ["play_platform"] = account.IsSteamAccount ? "Unity_steam" : "Unity",
                ["game_net_user_id"] = "",
                ["do_login"] = doLogin.ToString()
            };

            if (muleDump)
            {
                @params.Add("muleDump", "true");
                @params.Add("__source", "jakcodex-v965");
                @params.Add("ignore", new Random().Next(1000, 10000).ToString());
                @params.Add("_=", TimeUtil.UnixMillis().ToString());
            }

            return Query<CharsElement>("char/list", @params);
        }

        public ApiResponse<PackagesElement> FetchPackages(AccountSession account)
        {
            if (account.AccessToken == null)
                throw new ArgumentException("AccessToken null for given AccountSession");

            var @params = new NameValueCollection
            {
                ["language"] = "en",
                ["version"] = "0",
                ["accessToken"] = account.AccessToken.Value,
                ["game_net"] = account.IsSteamAccount ? "Unity_steam" : "Unity",
                ["play_platform"] = account.IsSteamAccount ? "Unity_steam" : "Unity",
                ["game_net_user_id"] = ""
            };

            return Query<PackagesElement>("package/getPackages", @params);
        }

        public ApiResponse<MiniGamesElement> FetchMysteryBoxes(AccountSession account)
        {
            if (account.AccessToken == null)
                throw new ArgumentException("AccessToken null for given AccountSession");

            var @params = new NameValueCollection
            {
                ["language"] = "en",
                ["version"] = "0",
                ["accessToken"] = account.AccessToken.Value,
                ["game_net"] = account.IsSteamAccount ? "Unity_steam" : "Unity",
                ["play_platform"] = account.IsSteamAccount ? "Unity_steam" : "Unity",
                ["game_net_user_id"] = ""
            };

            return Query<MiniGamesElement>("mysterybox/getBoxes", @params);
        }

        public ApiResponse<ServersElement> FetchServers(AccountSession account)
        {
            if (account.AccessToken == null)
                throw new ArgumentException("AccessToken null for given AccountSession");

            var @params = new NameValueCollection
            {
                ["accessToken"] = account.AccessToken.Value,
                ["game_net"] = account.IsSteamAccount ? "Unity_steam" : "Unity",
                ["play_platform"] = account.IsSteamAccount ? "Unity_steam" : "Unity",
                ["game_net_user_id"] = ""
            };

            return Query<ServersElement>("/account/servers", @params);
        }

        private ApiResponse<T> Query<T>(string path, NameValueCollection parameters) where T : IXMLElement, new()
        {
            string rawResponse;

            if (SafeMode)
            {
                if (!_webClient.UploadSafe(path, parameters, out rawResponse, out Exception exception))
                    return new ApiResponse<T>(exception);
            }
            else
            {
                try
                {
                    rawResponse = _webClient.Upload(path, parameters);
                }
                catch (Exception e)
                {
                    return new ApiResponse<T>(e);
                }
            }
                

            ApiResponse<T> response = new ApiResponse<T>(rawResponse);

            response.Parse();

            return response;
        }
    }
}
