using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportLibrary
{
    public class DataTypeTransport
    {
        public TypeTransport GetTransportType(String lineId)
        {
            // New instance of the connection
            ConnectApi conect = new ConnectApi();

            String url = "https://data.metromobilite.fr/api/routers/default/index/routes?codes="+lineId;
            String responseFromServer = conect.ConnectionApi(url);

            // Convert to C# object
            List<TypeTransport> typeList = JsonConvert.DeserializeObject<List<TypeTransport>>(responseFromServer);
            return typeList[0];
        }
        
    }
}
