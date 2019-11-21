using System;
using System.Collections.Generic;
using System.Text;
using Tag_API;

namespace Tag_API_Test
{
    class FakeApiCallStation : IApiCall
    {
        public string getData(string url)
        {
            string data = "[{\"id\":\"SEM:1986\",\"name\":\"GRENOBLE, CASERNE DE BONNE\",\"lon\":5.72533,\"lat\":45.18506,\"zone\":\"SEM_GENCASBONNE\",\"lines\":[\"SEM:16\"]}]";
            return data;
        }
    }
}
