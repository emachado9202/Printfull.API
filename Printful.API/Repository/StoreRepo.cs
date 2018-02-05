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
    public interface StoreRepo
    {
        Task<StoreInformationResult> GetAsync(Proxy Proxy, string API);

        Task<PackingSlipResult> ChangeAsync(Proxy Proxy, string API, PackingSlip Request);
    }

    public class StoreImplRepo : StoreRepo
    {
        public async Task<StoreInformationResult> GetAsync(Proxy proxy, string api)
        {
            return await Task.Factory.StartNew(() =>
            {
                HttpWebRequest webRequest =
                    WebRequest.Create("https://api.printful.com/store") as HttpWebRequest;

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
                        StoreInformationResult result =
                            JsonConvert.DeserializeObject<StoreInformationResult>(responseFromServer, Converter.Settings);

                        return result;
                    }
                }
                return null;
            });
        }

        public async Task<PackingSlipResult> ChangeAsync(Proxy proxy, string api, PackingSlip request)
        {
            return await Task.Factory.StartNew(() =>
            {
                HttpWebRequest webRequest = WebRequest.Create(" https://api.printful.com/store/packing-slip") as HttpWebRequest;

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
                        PackingSlipResult result =
                            JsonConvert.DeserializeObject<PackingSlipResult>(responseFromServer, Converter.Settings);

                        return result;
                    }
                }
                return null;
            });
        }
    }
}