﻿using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TransportLibrary
{
    public class DataLignesProximite
    {
        private IConnectApi connectApi;

        public DataLignesProximite(IConnectApi connectApi)
        {
            this.connectApi = connectApi;
        }

        private List<Arret> proximite(String lon, String lat, Int32 distance) { 
            // New instance of the connection
            //ConnectApi conect = new ConnectApi();

            String url = "http://data.metromobilite.fr/api/linesNear/json?x=" + lon + "&y=" + lat + "&dist=" + distance + "&details=true";
            String responseFromServer = connectApi.ConnectionApi(url);
            
            // Convert to C# object
            List<Arret> stopList = JsonConvert.DeserializeObject<List<Arret>>(responseFromServer);

            return stopList;
        }

        private List<String> GetLines(List<String> stopList)
        {
            //Liste vide pour stocker les lignes d'un arret
            List<String> listeLignes = new List<String>();

            //Boucler sur les lignes de l'arrêt pour les ajouter dans la liste
            foreach (String line in stopList)
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
            return listeLignes;
        }
                
        public Dictionary<String, List<String>> DataNoDuplicates(String lon, String lat, Int32 distance)
        {
            List<Arret> stopList = proximite(lon, lat, distance);
            Dictionary<String, List<String>> noDuplicate = new Dictionary<String, List<String>>();
            foreach (Arret stop in stopList)
            {
                if (!noDuplicate.ContainsKey(stop.name))
                {
                    //List<String> listeLignes = GetLines(stop.lines);
                    noDuplicate.Add(stop.name, stop.lines);
                }
                //Mon arret est déjà dans la liste, je vais donc vérifier que toutes les lignes de l'arrêt sont déjà dans la liste
                else
                {
                    //Boucler sur les lignes de l'arrêt
                    foreach (String line in stop.lines)
                    {
                        //Si la ligne n'est pas déjà dans la liste des lignes de l'arret dans le Dictionary (liste sans doublons)
                        if (!noDuplicate[stop.name].Contains(line))
                        {
                            //J'ajoute maligne dans le "Value" de mon arrêt à la liste des lignes
                            noDuplicate[stop.name].Add(line);
                        }
                    }
                }
                noDuplicate[stop.name] = noDuplicate[stop.name].Distinct().ToList();
            }
            return noDuplicate;
        }

        //Récupérer un Dictionnaire <String Arret, List<Ligne>> sans doublons
        public Dictionary<String, List<Ligne>> GetDataDetailsLigneProximite(String latitude, String longitude, Int32 distance)
        {
            Dictionary<String, List<Ligne>> superDico = new Dictionary<String, List<Ligne>>();
            Dictionary<String, List<String>> dicoDeBase = DataNoDuplicates(latitude, longitude, distance);

            foreach (KeyValuePair<String, List<String>> kvp in dicoDeBase)
            {
                List<Ligne> listeLigne = new List<Ligne>();
                foreach (String idLigne in kvp.Value)
                {
                    DataTypeTransport dataType = new DataTypeTransport(new ConnectApi());
                    Ligne ligne = dataType.GetTransportType(idLigne);
                    listeLigne.Add(ligne);
                }
                superDico.Add(kvp.Key, listeLigne);
            }
            return superDico;
        }
    }
}
