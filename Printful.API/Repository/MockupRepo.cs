using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Newtonsoft.Json;
using Printful.API.Manager;
using Printful.API.Model.Entities;
using Printful.API.Model.Page;
using SharpRaven;
using SharpRaven.Data;

namespace Printful.API.Repository
{
    public interface MockupRepo
    {
        Task<GenerationTaskResult> CreateTaskAsync(Proxy Proxy, string API, string Id, CreateGenerationTask Request);
        Task<GenerationTaskResult> GetTaskAsync(Proxy Proxy, string API, string Task_Key);
        GenerationTaskResult GetTask(Proxy Proxy, string API, string Task_Key);
        Task<PrintFileResult> GetPrintFilesAsync(Proxy Proxy, string API, string Id);
    }

    public class MockupImplRepo : MockupRepo
    {
        public ILog logger = LogManager.GetLogger(typeof(MockupImplRepo));

        public async Task<GenerationTaskResult> CreateTaskAsync(Proxy proxy, string api, string id,
            CreateGenerationTask request)
        {
            return await Task.Factory.StartNew(() =>
            {
                HttpWebRequest webRequest =
                    WebRequest.Create($"https://api.printful.com/mockup-generator/create-task/{id}") as HttpWebRequest;

                if (proxy != null)
                {
                    webRequest.Proxy = proxy.Get();
                    webRequest.Credentials = proxy.GetCredential();
                }

                webRequest.Method = "POST";
                webRequest.ContentType = "application/json; charset=utf-8";
                webRequest.Headers.Add("Authorization", "Basic " + Manager.API.Encode(api));

                string data = JsonConvert.SerializeObject(request);

                logger.Info(id + " " + data);

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
                        GenerationTaskResult result =
                            JsonConvert.DeserializeObject<GenerationTaskResult>(responseFromServer, Converter.Settings);

                        return result;
                    }
                }

                return null;
            });
        }

        public async Task<PrintFileResult> GetPrintFilesAsync(Proxy proxy, string api, string id)
        {
            return await Task.Factory.StartNew(() =>
            {
                HttpWebRequest webRequest =
                    WebRequest.Create($"https://api.printful.com/mockup-generator/printfiles/{id}") as HttpWebRequest;

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
                        PrintFileResult result =
                            JsonConvert.DeserializeObject<PrintFileResult>(responseFromServer, Converter.Settings);

                        return result;
                    }
                }

                return null;
            });
        }

        public async Task<GenerationTaskResult> GetTaskAsync(Proxy proxy, string api, string Task_Key)
        {
            return await Task.Factory.StartNew(() =>
            {
                HttpWebRequest webRequest =
                    WebRequest.Create($"https://api.printful.com/mockup-generator/task?task_key={Task_Key}") as
                        HttpWebRequest;
                
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
                        GenerationTaskResult result =
                            JsonConvert.DeserializeObject<GenerationTaskResult>(responseFromServer, Converter.Settings);

                        return result;
                    }
                }

                return null;
            });
        }

        public GenerationTaskResult GetTask(Proxy proxy, string api, string Task_Key)
        {
            HttpWebRequest webRequest =
                WebRequest.Create($"https://api.printful.com/mockup-generator/task?task_key={Task_Key}") as
                    HttpWebRequest;

            logger.Info("Task_Key: " + Task_Key);

            //ravenClient.Capture(new SentryEvent($"Task_Key: {Task_Key}"));

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
                    GenerationTaskResult result =
                        JsonConvert.DeserializeObject<GenerationTaskResult>(responseFromServer, Converter.Settings);

                    return result;
                }
            }

            return null;
        }
    }
}