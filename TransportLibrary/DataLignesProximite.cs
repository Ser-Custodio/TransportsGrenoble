using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TransportLibrary
{
    public class DataLignesProximite
    {
        public List<Ligne> proximite(String lon, String lat, Int32 distance) { 
            // New instance of the connection
            ConnectApi conect = new ConnectApi();

            String url = "http://data.metromobilite.fr/api/linesNear/json?x=" + lon + "&y=" + lat + "&dist=" + distance + "&details=true";
            String responseFromServer = conect.ConnectionApi(url);
            
            // Convert to C# object
            List<Ligne> stopList = JsonConvert.DeserializeObject<List<Ligne>>(responseFromServer);

            return stopList;
        }

        public Dictionary<String, List<String>> DataNoDuplicates(String lon, String lat, Int32 distance)
        {
            List<Ligne> stopList = proximite(lon, lat, distance);
            Dictionary<String, List<String>> noDuplicate = new Dictionary<String, List<String>>();
            foreach (Ligne stop in stopList)
            {
                if (!noDuplicate.ContainsKey(stop.name))
                {
                    //Liste vide pour stocker les lignes d'un arret
                    List<String> listeLignes = new List<String>();

                    //Boucler sur les lignes de l'arrêt pour les ajouter dans la liste
                    foreach (String line in stop.lines)
                    {
                        int d = line.IndexOf(":");
                        String numLine = line.Substring(d + 1);
                        //Si la ligne n'est pas déjà dans la liste des lignes
                        if (!listeLignes.Contains(numLine))
                        {
                            //Alors j'ajoute la ligne dans la liste des lignes de cet arret
                            listeLignes.Add(numLine);
                        }
                    }
                    //Ajouter dans la liste sans doublons la paire "Key : nom arret, value : listeLignes"
                    noDuplicate.Add(stop.name, listeLignes);
                }
                //Mon arret est déjà dans la liste, je vais donc vérifier que toutes les lignes de l'arrêt sont déjà dans la liste
                else
                {
                    //Boucler sur les lignes de l'arrêt
                    foreach (String line in stop.lines)
                    {
                        int d = line.IndexOf(":");
                        String numLine = line.Substring(d + 1);
                        //Si la ligne n'est pas déjà dans la liste des lignes de l'arret dans le Dictionary (liste sans doublons)
                        if (!noDuplicate[stop.name].Contains(numLine))
                        {
                            //J'ajoute maligne dans le "Value" de mon arrêt à la liste des lignes
                            noDuplicate[stop.name].Add(numLine);
                        }
                    }
                }
            }
            return noDuplicate;
        }
    }
}
