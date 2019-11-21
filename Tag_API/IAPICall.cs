using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag_API
{
    public interface IApiCall
    {
        string getData(string url);
    }
}
