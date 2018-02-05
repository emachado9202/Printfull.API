using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Printful.API.Manager;
using Printful.API.Model.Page;

namespace Printful.API.Repository
{
    public interface ProductRepo
    {
        Task<ProductResult> ListAsync(Proxy Proxy, string API);
        Task<VariantResult> GetVariantAsync(Proxy Proxy, string API, int Id);
        Task<VariantListResult> GetVariantListAsync(Proxy Proxy, string API, int Id);
    }

    public class ProductImplRepo : ProductRepo
    {
        public async Task<ProductResult> ListAsync(Proxy proxy, string api)
        {
            return await Task.Factory.StartNew(() =>
            {
                HttpWebRequest webRequest = WebRequest.Create("https://api.printful.com/products") as HttpWebRequest;

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
                        ProductResult product =
                            JsonConvert.DeserializeObject<ProductResult>(responseFromServer, Converter.Settings);

                        return product;
                    }
                }
                return null;
            });
        }
        
        public async Task<VariantResult> GetVariantAsync(Proxy Proxy, string API, int Id)
        {
            return await Task.Factory.StartNew(() =>
            {
                HttpWebRequest webRequest =
                    WebRequest.Create($"https://api.printful.com/products/variant/{Id}") as HttpWebRequest;

                if (Proxy != null)
                {
                    webRequest.Proxy = Proxy.Get();
                    webRequest.Credentials = Proxy.GetCredential();
                }
                webRequest.Method = "GET";
                webRequest.ContentType = "application/json; charset=utf-8";
                webRequest.Headers.Add("Authorization", "Basic " + Manager.API.Encode(API));

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
                        VariantResult result =
                            JsonConvert.DeserializeObject<VariantResult>(responseFromServer, Converter.Settings);

                        return result;
                    }
                }
                return null;
            });
        }

        public async Task<VariantListResult> GetVariantListAsync(Proxy Proxy, string API, int Id)
        {
            return await Task.Factory.StartNew(() =>
            {
                HttpWebRequest webRequest =
                    WebRequest.Create($"https://api.printful.com/products/{Id}") as HttpWebRequest;

                if (Proxy != null)
                {
                    webRequest.Proxy = Proxy.Get();
                    webRequest.Credentials = Proxy.GetCredential();
                }
                webRequest.Method = "GET";
                webRequest.ContentType = "application/json; charset=utf-8";
                webRequest.Headers.Add("Authorization", "Basic " + Manager.API.Encode(API));

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
                        VariantListResult result =
                            JsonConvert.DeserializeObject<VariantListResult>(responseFromServer, Converter.Settings);

                        return result;
                    }
                }
                return null;
            });
        }
    }
}