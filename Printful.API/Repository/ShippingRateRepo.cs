using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Printful.API.Manager;
using Printful.API.Model.Entities;
using Printful.API.Model.Page;

namespace Printful.API.Repository
{
    public interface ShippingRateRepo
    {
        Task<ShippingRatesResult> ListAsync(Proxy Proxy, string API, ShippingRequest ShippingRequest);
    }

    public class ShippingRateImplRepo : ShippingRateRepo
    {
        public async Task<ShippingRatesResult> ListAsync(Proxy proxy, string api, ShippingRequest shippingrequest)
        {
            return await Task.Factory.StartNew(() =>
            {
                HttpWebRequest webRequest =
                    WebRequest.Create("https://api.printful.com/shipping/rates") as HttpWebRequest;

                if (proxy != null)
                {
                    webRequest.Proxy = proxy.Get();
                    webRequest.Credentials = proxy.GetCredential();
                }
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json; charset=utf-8";
                webRequest.Headers.Add("Authorization", "Basic " + Manager.API.Encode(api));

                string data = JsonConvert.SerializeObject(shippingrequest); //replace <value>
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
                        ShippingRatesResult result =
                            JsonConvert.DeserializeObject<ShippingRatesResult>(responseFromServer, Converter.Settings);

                        return result;
                    }
                }
                return null;
            });
        }
    }
}