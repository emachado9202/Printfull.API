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
            Proxy proxy = new Proxy("http://10.20.0.21:3128", true, false, true, "erick.machado", "avi2017***");
            PrintFileResult print_result =
                await RepositoryBroker.Instance.MockupRepo.GetPrintFilesAsync(proxy,
                    "bzrighxo-lrmy-iae5:srm8-r2h2tbxceh9k", "5");

            VariantPrintFile variant =
                print_result.result.variant_printfiles.FirstOrDefault(x => x.variant_id == 68);

            List<PrintfullPrintFileAdminModels> result = new List<PrintfullPrintFileAdminModels>();

            if (variant.placements.@default != 0)
            {
                PrintFile printFile =
                    print_result.result.printfiles.FirstOrDefault(x => x.printfile_id == variant.placements.@default);
                result.Add(new PrintfullPrintFileAdminModels()
                {
                    placement_id = "default",
                    printfile_id = printFile.printfile_id,
                    dpi = printFile.dpi,
                    height = printFile.height,
                    width = printFile.width
                });
            }
            if (variant.placements.front != 0)
            {
                PrintFile printFile =
                    print_result.result.printfiles.FirstOrDefault(x => x.printfile_id == variant.placements.front);
                result.Add(new PrintfullPrintFileAdminModels()
                {
                    placement_id = "front",
                    printfile_id = printFile.printfile_id,
                    dpi = printFile.dpi,
                    height = printFile.height,
                    width = printFile.width
                });
            }
            if (variant.placements.label_outside != 0)
            {
                PrintFile printFile =
                    print_result.result.printfiles.FirstOrDefault(
                        x => x.printfile_id == variant.placements.label_outside);
                result.Add(new PrintfullPrintFileAdminModels()
                {
                    placement_id = "label_outside",
                    printfile_id = printFile.printfile_id,
                    dpi = printFile.dpi,
                    height = printFile.height,
                    width = printFile.width
                });
            }
            if (variant.placements.back != 0)
            {
                PrintFile printFile =
                    print_result.result.printfiles.FirstOrDefault(x => x.printfile_id == variant.placements.back);
                result.Add(new PrintfullPrintFileAdminModels()
                {
                    placement_id = "back",
                    printfile_id = printFile.printfile_id,
                    dpi = printFile.dpi,
                    height = printFile.height,
                    width = printFile.width
                });
            }
            if (variant.placements.label_inside != 0)
            {
                PrintFile printFile =
                    print_result.result.printfiles.FirstOrDefault(
                        x => x.printfile_id == variant.placements.label_inside);
                result.Add(new PrintfullPrintFileAdminModels()
                {
                    placement_id = "label_inside",
                    printfile_id = printFile.printfile_id,
                    dpi = printFile.dpi,
                    height = printFile.height,
                    width = printFile.width
                });
            }
            if (variant.placements.embroidery_back != 0)
            {
                PrintFile printFile =
                    print_result.result.printfiles.FirstOrDefault(
                        x => x.printfile_id == variant.placements.embroidery_back);
                result.Add(new PrintfullPrintFileAdminModels()
                {
                    placement_id = "embroidery_back",
                    printfile_id = printFile.printfile_id,
                    dpi = printFile.dpi,
                    height = printFile.height,
                    width = printFile.width
                });
            }
            if (variant.placements.embroidery_front != 0)
            {
                PrintFile printFile =
                    print_result.result.printfiles.FirstOrDefault(
                        x => x.printfile_id == variant.placements.embroidery_front);
                result.Add(new PrintfullPrintFileAdminModels()
                {
                    placement_id = "embroidery_front",
                    printfile_id = printFile.printfile_id,
                    dpi = printFile.dpi,
                    height = printFile.height,
                    width = printFile.width
                });
            }
            if (variant.placements.embroidery_left != 0)
            {
                PrintFile printFile =
                    print_result.result.printfiles.FirstOrDefault(
                        x => x.printfile_id == variant.placements.embroidery_left);
                result.Add(new PrintfullPrintFileAdminModels()
                {
                    placement_id = "embroidery_left",
                    printfile_id = printFile.printfile_id,
                    dpi = printFile.dpi,
                    height = printFile.height,
                    width = printFile.width
                });
            }
            if (variant.placements.embroidery_right != 0)
            {
                PrintFile printFile =
                    print_result.result.printfiles.FirstOrDefault(
                        x => x.printfile_id == variant.placements.embroidery_right);
                result.Add(new PrintfullPrintFileAdminModels()
                {
                    placement_id = "embroidery_right",
                    printfile_id = printFile.printfile_id,
                    dpi = printFile.dpi,
                    height = printFile.height,
                    width = printFile.width
                });
            }

            foreach (var printfullPrintFileAdminModelse in result)
            {
                Console.WriteLine(printfullPrintFileAdminModelse.placement_id);
            }
        }
    }
}

public class PrintfullPrintFileAdminModels
{
    public string placement_id { get; set; }
    public int printfile_id { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public int dpi { get; set; }
}