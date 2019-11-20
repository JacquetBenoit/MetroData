using System;
using System.Collections.Generic;
using System.Net;

namespace Tag_API
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            ApiController apiController = new ApiController();

            Dictionary<String, List<Station>> stations = apiController.getNearStations("5.727718", "45.185603", 700);

            foreach (KeyValuePair<string, List<Station>> station in stations)
            {
                Console.WriteLine(station.Key + "\n" + "Lignes :");

                foreach (Station val in station.Value)
                {
                    foreach (string line in val.lines)
                    {
                        Console.WriteLine(apiController.getLineInfo(line));
                    }
                }
                Console.WriteLine("-------------------------------------------------------------------");
            }
            
        }
    }
}
