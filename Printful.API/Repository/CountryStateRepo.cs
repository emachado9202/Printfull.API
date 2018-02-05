using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Printful.API.Manager;
using Printful.API.Model.Entities;
using Printful.API.Model.Page;
using File = Printful.API.Model.Entities.File;

namespace Printful.API.Repository
{
    public interface CountryStateRepo
    {
        Task<CountryStateResult> ListAsync(Proxy Proxy, string API);
    }

    public class CountryStateImplRepo : CountryStateRepo
    {
        public async Task<CountryStateResult> ListAsync(Proxy proxy, string api)
        {
            return await Task.Factory.StartNew(() =>
            {
                HttpWebRequest webRequest =
                    WebRequest.Create("https://api.printful.com/countries") as HttpWebRequest;

                if (proxy != null)
                {
                    webRequest.Proxy = proxy.Get();
                    webRequest.Credentials = proxy.GetCredential();
                }
                webRequest.Method = "GET";
                webRequest.ContentType = "application/json; charset=utf-8";
                webRequest.Headers.Add("Authorization", "Basic " + Manager.API.Encode(api));

                WebResponse response = webRequest.GetResponse();
                if (((HttpWebResponse) response).StatusCode == HttpStatusCode.OK)
                {
                    // Get the stream containing content returned by the server.
                    Stream dataStream = response.GetResponseStream();
                    if (dataStream != null)
                    {
                        // Open the stream using a StreamReader for easy access.
                        StreamReader reader = new StreamReader(dataStream);
                        // Read the content.
                        string responseFromServer = reader.ReadToEnd();
                        // Display the content.
                        CountryStateResult result =
                            JsonConvert.DeserializeObject<CountryStateResult>(responseFromServer, Converter.Settings);

                        return result;
                    }
                }
                return null;
            });
        }
    }
}