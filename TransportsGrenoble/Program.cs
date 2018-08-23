using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TransportsGrenoble
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            // Give the coordinates of current location
            String lat = "45.185476";
            String lon = "5.727772";

            // Search perimetre
            Int32 distance = 500;

            // Create a new instance of the Object Ligne
            Ligne ligne = new Ligne();

            Console.WriteLine("Bienvenue à Grenoble, vous serez toujours en retard avec nous");
            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create("http://data.metromobilite.fr/api/linesNear/json?x="+lon+"&y="+lat+"&dist="+distance+"&details=true");
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.
            Console.WriteLine(response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            //// Convert to C# object
            List<Ligne> stopList = JsonConvert.DeserializeObject<List<Ligne>>(responseFromServer);
            // Display the id from the fist stop on the list
            Console.WriteLine("\n LIST OF STOPS IN A 500m RADIUS FROM THE CAMPUS \n");
            // Go through the list of objects
            foreach (Ligne stop in stopList) {
                foreach(String oneStop in stop.lines)
                {
                    int delimeter = oneStop.IndexOf(":");
                    Console.WriteLine("Stop name: "+stop.name+"; Line no: "+oneStop.Substring(delimeter+1));
                }
            }
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();
        }
    }
}
