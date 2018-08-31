using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportLibrary
{
    public class Ligne
    {
        public string id { get; set; }
        public string shortName { get; set; }
        public string longName { get; set; }
        public string color { get; set; }
        public string textColor { get; set; }
        public string mode { get; set; }
        public string type { get; set; }
        public string realColor
        {
            get
            {
                return "#" + color;
            }
        }

        public Uri Image
        {
            get
            {
                // Solution trouvée par MARION CHAPUIS
                if (mode == "BUS")
                    return new Uri(@"\images\bus2.png", UriKind.RelativeOrAbsolute);
                else
                    return new Uri(@"\images\tram2.png", UriKind.RelativeOrAbsolute);
            }
        }
    }
}
