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
    public interface FileRepo
    {
        Task<FilesResult> ListAsync(Proxy Proxy, string API, string Status, int OffSet, int Limit);
        Task<FileResult> NewFileAsync(Proxy Proxy, string API, File File);
        Task<FileResult> GetAsync(Proxy Proxy, string API, int Id);
    }

    public class FileImplRepo : FileRepo
    {
        public async Task<FilesResult> ListAsync(Proxy proxy, string api, string status, int offset, int limit)
        {
            return await Task.Factory.StartNew(() =>
            {
                HttpWebRequest webRequest = WebRequest.Create("https://api.printful.com/files") as HttpWebRequest;

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
                        FilesResult result =
                            JsonConvert.DeserializeObject<FilesResult>(responseFromServer, Converter.Settings);

                        return result;
                    }
                }
                return null;
            });
        }

        public async Task<FileResult> NewFileAsync(Proxy proxy, string api, File file)
        {
            return await Task.Factory.StartNew(() =>
            {
                HttpWebRequest webRequest = WebRequest.Create("https://api.printful.com/files") as HttpWebRequest;

                if (proxy != null)
                {
                    webRequest.Proxy = proxy.Get();
                    webRequest.Credentials = proxy.GetCredential();
                }
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json; charset=utf-8";
                webRequest.Headers.Add("Authorization", "Basic " + Manager.API.Encode(api));

                string data = JsonConvert.SerializeObject(file);
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
                        FileResult result =
                            JsonConvert.DeserializeObject<FileResult>(responseFromServer, Converter.Settings);

                        return result;
                    }
                }
                return null;
            });
        }

        public async Task<FileResult> GetAsync(Proxy proxy, string api, int id)
        {
            return await Task.Factory.StartNew(() =>
            {
                HttpWebRequest webRequest =
                    WebRequest.Create($"https://api.printful.com/files/{id}") as HttpWebRequest;

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
                        FileResult result =
                            JsonConvert.DeserializeObject<FileResult>(responseFromServer, Converter.Settings);

                        return result;
                    }
                }
                return null;
            });
        }
    }
}