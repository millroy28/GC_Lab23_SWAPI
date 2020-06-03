using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GC_D30_API_Breakout.Models
{
    public class SwapiDal
    {
        public string GetAPIJson(string endpoint, int Id)
        {
            string url = $"https://swapi.dev/api/{endpoint}/{Id}/";

            try
            {            //Roy adding this to experiment
                HttpWebRequest request = WebRequest.CreateHttp(url);                //requires using System.Net
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                StreamReader sr = new StreamReader(response.GetResponseStream());       //req system.io
                string output = sr.ReadToEnd();
                return output;
            }
            catch
            {
                return "{\"name\": \"Not found\"}";
            }

        }

        public Person GetPerson(string endpoint, int Id)
        {
            string personData = GetAPIJson(endpoint, Id);
            Person p = JsonConvert.DeserializeObject<Person>(personData); //need to install NEwtonsoft Json in nuget package manager then add the using statement

            return p;
        }

        public Planet GetPlanet(string endpoint, int Id)
        {
            string planetData = GetAPIJson(endpoint, Id);
            Planet p = JsonConvert.DeserializeObject<Planet>(planetData);
            return p;
        }

        public Starship GetStarship(string endpoint, int Id)
        {
            string starshipData = GetAPIJson(endpoint, Id);
            Starship s = JsonConvert.DeserializeObject<Starship>(starshipData);
            return s;
        }

        public List<Person> GetAllPeople ()
        {
            List<Person> characters = new List<Person>();
            bool run = true;
            int i = 1;
            while (run)
            {
                string personData = GetAPIJson("people", i);
                Person p = JsonConvert.DeserializeObject<Person>(personData);
                if (p.name == "Not found")
                {
                    run = false;
                } else
                {
                    characters.Add(p);
                }

            }
            return characters;
                
        }

    }
}
