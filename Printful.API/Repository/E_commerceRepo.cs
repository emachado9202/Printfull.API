using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Printful.API.Manager;
using Printful.API.Model.Page;

namespace Printful.API.Repository
{
    public interface E_commerceRepo
    {
        Task<SyncProductsResult> ListAsync(Proxy Proxy, string API, string Status, int OffSet, int Limit);
        Task<SyncProductResult> GetAsync(Proxy Proxy, string API, string Id);
        Task<SyncVariantResult> GetVariantAsync(Proxy Proxy, string API, string Id);
        Task<SyncVariantResult> DeleteVariantAsync(Proxy Proxy, string API, string Id);
        Task<SyncProductResult> DeleteAsync(Proxy Proxy, string API, string Id);
    }

    public class E_commerceImplRepo : E_commerceRepo
    {
        public async Task<SyncProductsResult> ListAsync(Proxy proxy, string api, string status, int offset, int limit)
        {
            return await Task.Factory.StartNew(() =>
            {
                HttpWebRequest webRequest =
                    WebRequest.Create("https://api.printful.com/sync/products") as HttpWebRequest;

                if (proxy != null)
                {
                    webRequest.Proxy = proxy.Get();
                    webRequest.Credentials = proxy.GetCredential();
                }
                webRequest.Method = "GET";
                webRequest.ContentType = "application/json; charset=utf-8";
                webRequest.Headers.Add("Authorization", "Basic " + Manager.API.Encode(api));

                string data = $"status={status}&offset={offset}&limit={limit}"; //replace <value>
                byte[] data_form = Encoding.UTF8.GetBytes(data);

                webRequest.ContentLength = data_form.Length;
                Stream newStream = webRequest.GetRequestStream();
                // Send the data.
                newStream.Write(data_form, 0, data_form.Length);
                newStream.Close();

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
                        SyncProductsResult result =
                            JsonConvert.DeserializeObject<SyncProductsResult>(responseFromServer, Converter.Settings);

                        return result;
                    }
                }
                return null;
            });
        }

        public async Task<SyncProductResult> GetAsync(Proxy proxy, string api, string id)
        {
            return await Task.Factory.StartNew(() =>
            {
                HttpWebRequest webRequest =
                    WebRequest.Create($"https://api.printful.com/sync/products/{id}") as HttpWebRequest;

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
                        SyncProductResult result =
                            JsonConvert.DeserializeObject<SyncProductResult>(responseFromServer, Converter.Settings);

                        return result;
                    }
                }
                return null;
            });
        }

        public async Task<SyncVariantResult> GetVariantAsync(Proxy proxy, string api, string id)
        {
            return await Task.Factory.StartNew(() =>
            {
                HttpWebRequest webRequest =
                    WebRequest.Create($" https://api.printful.com/sync/variant/{id}") as HttpWebRequest;

                if (proxy != null)
                {
                    webRequest.Proxy = proxy.Get();
                    webRequest.Credentials = proxy.GetCredential();
                }
                webRequest.Method = "GET";
                webRequest.ContentType = "application/json; charset=utf-8";
                webRequest.Headers.Add("Authorization", "Basic " + Manager.API.Encode(api));

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
                        SyncVariantResult result =
                            JsonConvert.DeserializeObject<SyncVariantResult>(responseFromServer, Converter.Settings);

                        return result;
                    }
                }
                return null;
            });
        }

        public async Task<SyncVariantResult> DeleteVariantAsync(Proxy proxy, string api, string id)
        {
            return await Task.Factory.StartNew(() =>
            {
                HttpWebRequest webRequest =
                    WebRequest.Create($" https://api.printful.com/sync/variant/{id}") as HttpWebRequest;

                if (proxy != null)
                {
                    webRequest.Proxy = proxy.Get();
                    webRequest.Credentials = proxy.GetCredential();
                }
                webRequest.Method = "DELETE";
                webRequest.ContentType = "application/json; charset=utf-8";
                webRequest.Headers.Add("Authorization", "Basic " + Manager.API.Encode(api));

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
                        SyncVariantResult result =
                            JsonConvert.DeserializeObject<SyncVariantResult>(responseFromServer, Converter.Settings);

                        return result;
                    }
                }
                return null;
            });
        }

        public async Task<SyncProductResult> DeleteAsync(Proxy proxy, string api, string id)
        {
            return await Task.Factory.StartNew(() =>
            {
                HttpWebRequest webRequest =
                    WebRequest.Create($"https://api.printful.com/sync/products/{id}") as HttpWebRequest;

                if (proxy != null)
                {
                    webRequest.Proxy = proxy.Get();
                    webRequest.Credentials = proxy.GetCredential();
                }
                webRequest.Method = "DELETE";
                webRequest.ContentType = "application/json; charset=utf-8";
                webRequest.Headers.Add("Authorization", "Basic " + Manager.API.Encode(api));

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
                        SyncProductResult result =
                            JsonConvert.DeserializeObject<SyncProductResult>(responseFromServer, Converter.Settings);

                        return result;
                    }
                }
                return null;
            });
        }
    }
}