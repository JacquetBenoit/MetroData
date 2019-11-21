using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Tag_API_ClassLibrary
{
    public class ApiController
    {
        IApiCall APICall;

       public ApiController()
            :this(new ApiCall())
        {
            
        }

        internal ApiController(IApiCall api)
        {
            this.APICall = api;
        }

        public Dictionary<String, List<Station>> getNearStations(string x, string y, int dist)
        {
            IApiCall apiCall = this.APICall;
            string data = apiCall.getData("http://data.metromobilite.fr/api/linesNear/json?x=" + x + "&y=" + y + "&dist=" + dist + "&details=true");

            List<Station> stations = JsonConvert.DeserializeObject<List<Station>>(data);
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
            IApiCall apiCall = this.APICall;
            string data = apiCall.getData("http://data.metromobilite.fr/api/routers/default/index/routes?codes=" + id);

            List<Ligne> lignes = JsonConvert.DeserializeObject<List<Ligne>>(data);

            string infos = lignes[0].type + " " + lignes[0].shortname + " Ligne : " + lignes[0].longName;

            return infos;
        }

    }
}
