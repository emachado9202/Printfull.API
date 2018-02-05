using System;
using System.Net;

namespace Printful.API.Manager
{
    public class Proxy
    {
        public string HttpUrl { get; set; }
        public bool BypassProxyOnLocal { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public bool NeedAuthentication { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        private NetworkCredential credentials { get; set; }

        /// <summary>    
        /// Proxy Constructor.    
        /// </summary>    
        /// <param name="HttpUrl">Url for the Proxy</param>    
        /// <returns>Returns - String API Encoded</returns>
        public Proxy(string HttpUrl, bool BypassProxyOnLocal, bool UseDefaultCredentials, bool NeedAuthentication,
            string Username, string Password)
        {
            this.HttpUrl = HttpUrl;
            this.BypassProxyOnLocal = BypassProxyOnLocal;
            this.UseDefaultCredentials = UseDefaultCredentials;
            this.NeedAuthentication = NeedAuthentication;
            this.Username = Username;
            this.Password = Password;
        }

        public Proxy()
        {
        }

        public WebProxy Get()
        {
            WebProxy proxy = new WebProxy();

            proxy.BypassProxyOnLocal = BypassProxyOnLocal;
            proxy.UseDefaultCredentials = UseDefaultCredentials;
            credentials = new NetworkCredential(Username, Password);
            if (NeedAuthentication)
            {
                proxy.Credentials = credentials;
            }
            
            proxy.Address = new Uri(HttpUrl);

            return proxy;
        }

        public NetworkCredential GetCredential()
        {
            if (credentials == null)
            {
                credentials = new NetworkCredential(Username, Password);
            }
            return credentials;
        }
    }
}