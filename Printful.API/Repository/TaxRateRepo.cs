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
    public interface TaxRateRepo
    {
        Task<CountryStateResult> ListAsync(Proxy Proxy, string API);
        Task<TaxRateResult> CalculateAsync(Proxy Proxy, string API, TaxRequest Request);
    }

    public class TaxRateImplRepo : TaxRateRepo
    {
        public async Task<CountryStateResult> ListAsync(Proxy proxy, string api)
        {
            return await Task.Factory.StartNew(() =>
            {
                HttpWebRequest webRequest =
                    WebRequest.Create("https://api.printful.com/tax/countries") as HttpWebRequest;

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

        public async Task<TaxRateResult> CalculateAsync(Proxy proxy, string api, TaxRequest request)
        {
            return await Task.Factory.StartNew(() =>
            {
                HttpWebRequest webRequest = WebRequest.Create("https://api.printful.com/orders") as HttpWebRequest;

                if (proxy != null)
                {
                    webRequest.Proxy = proxy.Get();
                    webRequest.Credentials = proxy.GetCredential();
                }
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json; charset=utf-8";
                webRequest.Headers.Add("Authorization", "Basic " + Manager.API.Encode(api));

                string data = JsonConvert.SerializeObject(request);
                byte[] data_form = Encoding.UTF8.GetBytes(data);

                webRequest.ContentLength = data_form.Length;
                Stream newStream = webRequest.GetRequestStream();
                // Send the data.
                newStream.Write(data_form, 0, data_form.Length);
                newStream.Close();

                WebResponse response = webRequest.GetResponse();
                if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
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
                        TaxRateResult result =
                            JsonConvert.DeserializeObject<TaxRateResult>(responseFromServer, Converter.Settings);

                        return result;
                    }
                }
                return null;
            });
        }
    }
}