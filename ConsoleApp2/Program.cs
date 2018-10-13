using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net.Config;
using Newtonsoft.Json;
using Printful.API;
using Printful.API.Manager;
using Printful.API.Model.Entities;
using Printful.API.Model.Page;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main()
        {
            string xmlFile = (@"Config\Log4j.config");

            XmlConfigurator.ConfigureAndWatch(new FileInfo(xmlFile));

            RunAsync().Wait();
        }

        static async Task RunAsync()
        {

            GenerationTaskResult result =
                RepositoryBroker.Instance.MockupRepo.GetTask(null, "bzrighxo-lrmy-iae5:srm8-r2h2tbxceh7k", "e423f5835b5a5213d83712080f80c3ed");

            Console.WriteLine(result.result.status);

            Console.WriteLine($"Result: {JsonConvert.SerializeObject(result)}");

        }
    }
}