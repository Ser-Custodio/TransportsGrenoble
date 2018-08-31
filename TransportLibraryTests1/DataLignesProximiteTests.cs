using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransportLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportLibraryTests1.Fakes;

namespace TransportLibrary.Tests
{
    [TestClass()]
    public class DataLignesProximiteTests
    {
        [TestMethod()]
        public void DataNoDuplicatesTest()
        {
            FakeConnectApi fakeConnectApi = new FakeConnectApi();
            fakeConnectApi.resultatJson = "[{\"id\":\"SEM:1986\",\"name\":\"GRENOBLE, CASERNE DE BONNE\",\"lon\":5.72533,\"lat\":45.18506,\"lines\":[\"SEM:13\",\"SEM:16\",\"SEM:C4\"]},{\"id\":\"SEM:1987\",\"name\":\"GRENOBLE, CASERNE DE BONNE\",\"lon\":5.72542,\"lat\":45.18509,\"lines\":[\"SEM:16\"]}]";

            //Instance de l'objet que je test
            DataLignesProximite dataLignesProximite = new DataLignesProximite(fakeConnectApi);
            //Paramètres : latitude, longitude et distance
            String latitude = "45.185476";
            String longitude = "5.727772";
            Int32 distance = 400;
            //Stocker le résultat de la méthode testée
            Dictionary<String, List<String>> resultat = dataLignesProximite.DataNoDuplicates(longitude, latitude, distance);
            //Vérification du résultat
            Assert.AreEqual(1, resultat.Count);
            Assert.IsTrue(resultat.ContainsKey("GRENOBLE, CASERNE DE BONNE"));
            Assert.AreEqual(3, resultat["GRENOBLE, CASERNE DE BONNE"].Count);
            Assert.AreEqual("SEM:13", resultat["GRENOBLE, CASERNE DE BONNE"][0]);
            Assert.AreEqual("SEM:16", resultat["GRENOBLE, CASERNE DE BONNE"][1]);
            Assert.AreEqual("SEM:C4", resultat["GRENOBLE, CASERNE DE BONNE"][2]);
        }   
    }
}