using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransportLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportLibraryTests1.Fakes;
using TransportLibraryTests1;

namespace TransportLibrary.Tests
{
    [TestClass()]
    public class DataTypeTransportTests
    {
        [TestMethod()]
        public void GetTransportTypeTest()
        {
            FakeConnectApi fakeConnectApi = new FakeConnectApi();
            fakeConnectApi.resultatJson = Ressources.transportType;

            DataTypeTransport dataTypeTransport = new DataTypeTransport(fakeConnectApi);
            Ligne typeTransport = dataTypeTransport.GetTransportType("SEM:12");

            Assert.AreEqual(typeTransport.shortName, "12");
            Assert.AreEqual(typeTransport.longName, "Eybens Maisons Neuves / Saint-Martin-d'Hères Les Alloves");
            Assert.AreEqual(typeTransport.mode, "BUS");
            Assert.AreEqual(typeTransport.color, "009930");
            Assert.AreEqual(typeTransport.type, "PROXIMO");
        }
    }
}