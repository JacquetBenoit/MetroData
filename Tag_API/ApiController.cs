using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace Tag_API
{
    public class ApiController
    {

        public Dictionary<String, List<Station>> getNearStations(string x, string y, int dist)
        {
            WebRequest request = WebRequest.Create("http://data.metromobilite.fr/api/linesNear/json?x=" + x + "&y=" + y + "&dist=" + dist + "&details=true");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            List<Station> stations = JsonConvert.DeserializeObject<List<Station>>(responseFromServer);
            Dictionary<String, List<Station>> sortedStations = new Dictionary<string, List<Station>>();


            foreach (Station station in stations)
            {
                if (!sortedStations.ContainsKey(station.name))
                {
                    List<Station> stationList = new List<Station>();
                    stationList.Add(station);
                    sortedStations.Add(station.name, stationList);   
                }
                else
                {
                    sortedStations[station.name].Add(station);
                }       
            }

            return sortedStations;
        }

        public string getLineInfo(string id)
        {
            WebRequest request = WebRequest.Create("http://data.metromobilite.fr/api/routers/default/index/routes?codes=" + id);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            List<Ligne> lignes = JsonConvert.DeserializeObject<List<Ligne>>(responseFromServer);

            string infos = lignes[0].type + " " + lignes[0].shortname + " Ligne : " + lignes[0].longName;

            return infos;
        }

    }
}
