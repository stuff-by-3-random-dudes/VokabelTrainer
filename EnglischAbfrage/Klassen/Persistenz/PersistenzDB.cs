using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace EnglischAbfrage
{
    class PersistenzDB
    {
        static Random rdm = new Random();
        /*var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://reeeapi20191013024943.azurewebsites.net/api/login/login?username=" + UNE.Text+"&email="+UNE.Text+"&password="+PW.Password);

              var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();*/
              // string = Deutsches wort, List<string> = Englische Wörter
<<<<<<< Updated upstream:EnglischAbfrage/PersistenzDB.cs
       public static Aufgabe GetVokabeln(List<int> ids)
=======
       public async static Task<Aufgabe_VOK> GetVokabeln(List<int> ids)
>>>>>>> Stashed changes:EnglischAbfrage/Klassen/Persistenz/PersistenzDB.cs
        {
            var id = RandomID(ids);
            var deutsch = string.Empty;
            List<string> englisch = new List<string>();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://vokabelapi.azurewebsites.net/api/de_vok/deutschvok?vok=" + id);
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                deutsch = FixResponse(result);
            }
            httpWebRequest = (HttpWebRequest)WebRequest.Create("https://vokabelapi.azurewebsites.net/api/en_vok/englischvok?vok=" + id);
            httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var fixr = FixResponse(result).Split(';');
                foreach(string s in fixr)
                {
                    englisch.Add(s);
                }
            }

            return new Aufgabe_VOK(deutsch,englisch, id);
        }

        private static string FixResponse(string response)
        {
            return response.Replace("\"", "").Replace("\\","").Trim();
        }

        private static int RandomID(List<int> ids)
        {
           return ids[rdm.Next(0, ids.Count)];
        }

       public static List<int> GetIdList()
        {
            List<int> ids = new List<int>();
            int anz = 0;
            //Id anzahl über api bekommen
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://vokabelapi.azurewebsites.net/api/anz_vok/anzvok");
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            //api antwort in anzahl umwandeln
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var splitres = FixResponse(result);
                anz = Convert.ToInt32(splitres);
                
            }



            //id's "berechnen"

            for (int i = 1; i <= anz; i++)
            {
                ids.Add(i);
            }
            return ids;
        }
    }
}
