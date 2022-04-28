using QR9ProxyLib.HTTP;
using QR9ProxyLib.Pool;
using RotmgNetworkingLib.Reference;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace RotmgNetworkingLib.Networking
{
    public class RotmgWebClient
    {
        private const int INTERNAL_ERROR_TIMEOUT = 30000;
        private const int DEFAULT_MAX_SAFE_FAILURES = 8;

        public readonly string UserAgent;

        public DynamicProxyPool<HTTPProxy> ProxyPool;
        public int MaxSafeFailures;

        public HTTPProxy CurrentProxy { get; private set; }

        public RotmgWebClient(DynamicProxyPool<HTTPProxy> proxyPool, string userAgent, int maxSafeFailures)
        {
            ProxyPool = proxyPool;
            UserAgent = userAgent;
            MaxSafeFailures = maxSafeFailures;
        }

        public RotmgWebClient(DynamicProxyPool<HTTPProxy> proxyPool) : base()
        {
            ProxyPool = proxyPool;
        }

        public RotmgWebClient()
        {
            UserAgent = Constants.API_USER_AGENT;
            MaxSafeFailures = DEFAULT_MAX_SAFE_FAILURES;
        }

        public string Upload(string path, NameValueCollection parameters)
        {
            using WebClient client = new WebClient();

            client.Headers.Add("user-agent", UserAgent);

            if (ProxyPool != null)
                return UploadProxied(client, path, parameters);
            else
                return UploadValues(client, path, parameters);
        }

        public bool UploadSafe(string path, NameValueCollection parameters, out string response, out Exception exception)
        {
            exception = null;

            using WebClient client = new WebClient();

            client.Headers.Add("user-agent", UserAgent);

            int failures = 0;
            response = null;

            while (failures < MaxSafeFailures)
            {
                try
                {
                    if (ProxyPool != null)
                        response = UploadProxied(client, path, parameters);
                    else
                        response = UploadValues(client, path, parameters);
                }
                catch (Exception e)
                {
                    exception = e;
                    failures++;
                    continue;
                }

                return true;
            }

            return false;
        }

        private string UploadProxied(WebClient client, string path, NameValueCollection parameters)
        {
            while (!ProxyPool.IsEmpty(true))
            {
                CurrentProxy = ProxyPool.Request(true);

                // fetch another proxy if request resulted in null
                if (CurrentProxy is null)
                    continue;

                string response;

                System.Console.WriteLine("Using: " + CurrentProxy.ToString());

                try
                {
                    client.Proxy = CurrentProxy.AsWebProxy();
                    response = UploadValues(client, path, parameters);
                }
                catch (WebException we)
                {
                    if (we.Message.Contains("actively refused"))
                    {
                        ProxyPool.Surrender(CurrentProxy, ProxySanction.BLACKLIST);
                        continue;
                    }

                    if (we.Message.Contains("properly respond")
                        || we.Message.Contains("Unable to read data from the transport connection")
                        || we.Message.Contains("The response ended prematurely")
                        || we.Message.Contains("Bad Request"))
                    {
                        ProxyPool.Surrender(CurrentProxy, ProxySanction.NONE);
                        continue;
                    }

                    throw we; // throw exception if not handled
                }

                if(!string.IsNullOrEmpty(response))
                {
                    if (response.Contains("wait 5 minutes"))
                        ProxyPool.Surrender(CurrentProxy, INTERNAL_ERROR_TIMEOUT); //surrender proxy w/ timeout
                    else
                    {
                        ProxyPool.Surrender(CurrentProxy, ProxySanction.VOUCH);
                        CurrentProxy = null;
                        return response;
                    }
                }
            }

            ProxyPool.PokeEmpty(true); //will throw proxy pool empty exception if empty

            return null;
        }

        private string UploadValues(WebClient client, string path, NameValueCollection parameters)
        {
            return Encoding.UTF8.GetString(client.UploadValues(Constants.API_ENDPOINT + path, parameters));
        }
    }
}
