using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportLibrary;

namespace TransportLibraryTests1.Fakes
{
    class FakeConnectApi : IConnectApi
    {
        public String resultatJson { get; set; }

        public String ConnectionApi(String url)
        {
            return resultatJson;
        }
    }
}
