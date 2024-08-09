using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AmisDeOutdoorApp.Services
{
    public class GetMeteo
    {
        string url = "http://www.infoclimat.fr/public-api/gfs/json?_ll=";
        string auth = "&_auth=AhgHEFEvU3FWewE2D3lSewNrAjcNewgvAX0CYQtuVisAa1Q1UTEAZgVrAXwAL1ZgVnsDYFliADBQOwd%2FWihQMQJoB2tROlM0VjkBZA8gUnkDLQJjDS0ILwFrAmQLeFY0AGRUMVEsAGUFYwF9ADdWZlZ6A3xZZwA%2FUDEHYlo%2FUDUCaQdiUTVTOFYmAXwPOVJgA2ICYg1nCDEBNgJmC2BWPABkVDdRYQBhBXQBYgA0VmtWZANkWWAAMVA3B39aKFBKAhIHflFyU3NWbAElDyJSMwNuAjY%3D&_c=f3ae6576315b837ae1fc21bbb1f1f6c8";
        public string GetMeteoOnLL(string latitude, string longitude)
        {
            string reqUrl = $"{url}{latitude},{longitude}{auth}";
            // Create a request for the URL. 		
            WebRequest myReq = WebRequest.Create(reqUrl);
            // If required by the server, set the credentials.
            myReq.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)myReq.GetResponse();
            // Display the status.
            Console.WriteLine("Response status: " + response.StatusDescription);
            Console.WriteLine();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine();
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            if (responseFromServer.StartsWith(responseFromServer))
            {
                Console.WriteLine("Got it!");
            }
            else
            {
                Console.WriteLine("Error! " + response.StatusCode);
            }
            Console.WriteLine();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine();
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }
    }
}
