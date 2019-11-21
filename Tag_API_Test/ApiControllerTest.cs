using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Tag_API;

namespace Tag_API_Test
{
    [TestClass]
    public class ApiControllerTest
    {
        [TestMethod]
        public void TestGetNearStations()
        {
            IApiCall apiCall = new FakeApiCallStation();
            ApiController apiController = new ApiController(apiCall);

            Dictionary<string, List<Station>> dataToTest = apiController.getNearStations("444", "444", 25);

            Station station = new Station();
                station.id = "SEM:1986";
                station.name = "GRENOBLE, CASERNE DE BONNE";
                station.lon = 5.72533;
                station.lat = 45.18506;
                station.zone = "SEM_GENCASBONNE";
                station.lines = new List<string>();
                station.lines.Add("SEM:16");

            Assert.AreEqual(dataToTest["GRENOBLE, CASERNE DE BONNE"][0].lines[0], station.lines[0]);
            Assert.AreEqual(dataToTest["GRENOBLE, CASERNE DE BONNE"][0].id, station.id);
            Assert.AreEqual(dataToTest["GRENOBLE, CASERNE DE BONNE"][0].name, station.name);
            Assert.AreEqual(dataToTest["GRENOBLE, CASERNE DE BONNE"][0].lon, station.lon);
            Assert.AreEqual(dataToTest["GRENOBLE, CASERNE DE BONNE"][0].lat, station.lat);
            Assert.AreEqual(dataToTest["GRENOBLE, CASERNE DE BONNE"][0].zone, station.zone);
        }

        [TestMethod]
        public void TestgetLineInfo()
        {
            IApiCall apiCall = new FakeApiCallLigne();
            ApiController apiController = new ApiController(apiCall);

            string dataToTest = apiController.getLineInfo("test");

            Assert.AreEqual(dataToTest, "C38 6020 Ligne : CROLLES-MEYLAN-GRENOBLE");
        }
    }
}
