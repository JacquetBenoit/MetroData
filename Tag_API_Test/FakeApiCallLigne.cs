using System;
using System.Collections.Generic;
using System.Text;
using Tag_API_ClassLibrary;

namespace Tag_API_Test
{
    class FakeApiCallLigne : IApiCall
    {
        public string getData(string url)
        {
            string data = "[{\"id\":\"C38:6020\",\"gtfsId\":\"C38:6020\",\"shortName\":\"6020\",\"longName\":\"CROLLES-MEYLAN-GRENOBLE\",\"color\":\"ff7917\",\"textColor\":\"FFFFFF\",\"mode\":\"BUS\",\"type\":\"C38\"}]";
            return data;
        }
    }
}
