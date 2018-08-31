using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TransportLibrary;

namespace TransportsGrenoble
{
    class Program
    {
        static void Main(string[] args)
        {
            IConnectApi connectApi = new ConnectApi();
            // New instance 
            DataLignesProximite dataLignesProximite = new DataLignesProximite(connectApi);

            // Give the coordinates of current location
            String lat = "45.185476";
            String lon = "5.727772";
            // Search perimetre
            Int32 distance = 400;

            Dictionary<String, List<Ligne>> noDuplicate = dataLignesProximite.GetDataDetailsLigneProximite(lon, lat, distance);

            Console.WriteLine("Bienvenue à Grenoble, vous serez toujours en retard avec nous");
            Console.WriteLine("\n LIST OF STOPS IN A 500m RADIUS FROM THE CAMPUS \n");
            //Parcourir la lite sans doublons (type Dictionary) pour afficher la paire "key - value"
            foreach (KeyValuePair<String, List<Ligne>> kvp in noDuplicate)
            {
                Console.WriteLine("******* " + kvp.Key + " *******");
                foreach (Ligne ligne in kvp.Value)
                {
                    Console.WriteLine(ligne.mode + " - " + ligne.shortName + " : " + ligne.longName);
                }
                Console.WriteLine("\n");
            }
        }
    }
}
