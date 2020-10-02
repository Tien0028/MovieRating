using Newtonsoft.Json;
using ProductionCode.BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace XUnitTestMovieRating
{
    public class UnitTest1
    {

        private const string PATH = "../../../../ratings.json";

        private readonly HashSet<BERating> firstTen = new HashSet<BERating>();
        private readonly HashSet<BERating> allReviews = new HashSet<BERating>();


        public UnitTest1()
        {

            firstTen = ReadJSONTop10(PATH).ToHashSet();
            allReviews = ReadJSON(PATH).ToHashSet();

        }

        #region ReadFile
        List<BERating> ReadJSONTop10(string path)
        {
            List<BERating> ratings = new List<BERating>();

            using (StreamReader sr = new StreamReader(path))
            {
                sr.ReadLine();
                for (int i = 0; i < 10; i++)
                {
                    string json = sr.ReadLine();
                    json = json.Substring(0, json.Length - 2);
                    ratings.Add(JsonConvert.DeserializeObject<BERating>(json));
                }
            }

            return ratings;
        }

        List<BERating> ReadJSON(string path)
        {
            List<BERating> ratings = new List<BERating>();

            using (StreamReader sr = new StreamReader(path))
            {
                // TODO: Optional task: do not read everything at once.
                string json = sr.ReadToEnd();
                ratings = JsonConvert.DeserializeObject<List<BERating>>(json);
            }

            return ratings;
        }
    }
}
