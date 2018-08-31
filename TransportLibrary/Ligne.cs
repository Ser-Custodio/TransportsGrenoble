using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportLibrary
{
    public class Ligne
    {
        public string image;

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

        public string Image
        {
            get
            {
                
                return image;
            }
            set
            {
                if (mode == "BUS")
                    image = "icon.png";
                else
                    image = "i.png";
            }
        }
    }
}
