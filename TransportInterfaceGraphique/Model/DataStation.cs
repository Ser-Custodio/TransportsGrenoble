using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportLibrary;

namespace TransportInterfaceGraphique.Model
{
    public class DataStation : Mere
    {
        public String Arret { get; set; }

        public List<Ligne> Lignes { get; set; }

        public DataStation(String arret, List<Ligne> lignes)
        {
            this.Arret = arret;
            this.Lignes = lignes;
        }
    }
}
