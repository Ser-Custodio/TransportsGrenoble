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
        private IConnectApi connectApi;

        public DataTypeTransport(IConnectApi connectApi)
        {
            this.connectApi = connectApi;
        }

        public Ligne GetTransportType(String lineId)
        {

            String url = "https://data.metromobilite.fr/api/routers/default/index/routes?codes="+lineId;
            String responseFromServer = connectApi.ConnectionApi(url);

            // Convert to C# object
            List<Ligne> typeList = JsonConvert.DeserializeObject<List<Ligne>>(responseFromServer);
            return typeList[0];
        }
        
    }
}
