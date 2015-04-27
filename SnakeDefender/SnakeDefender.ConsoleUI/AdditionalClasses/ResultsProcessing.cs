using System;
using System.Xml.Serialization;
using System.IO;

namespace SnakeDefender.ConsoleUI.AdditionalClasses
{
    public class ResultsProcessing
    {
        #region Public Property
        public ResultsHolder[] Results { get; set; }

        #endregion

        public ResultsProcessing()
        {
            Results = new ResultsHolder[10];
        }

        #region Public Methods
        public void CheckResult(int point)
        {
            if (File.Exists("Results.xml"))
            {
                Results = Deserialization();
                if (Results[9] == null ||
                    Results[9].Score < point)
                {
                    Console.WriteLine("Write your name: ");
                    string name = Console.ReadLine();
                    Serialization(AddScore(point, name));
                }
            }
            else
            {
                Console.WriteLine("Write your name: ");
                string name = Console.ReadLine();
                Serialization(AddScore(point, name));
            }

        }
        public void ShowResults()
        {
            Console.WriteLine("Top 10 scores:");
            foreach (var res in Results)
            {
                if (res != null)
                {
                    Console.WriteLine("{0,3} -- {1}", res.Score.ToString(), res.Name);
                }
            }
        }

        #endregion

        #region Private Methods
        private void Serialization(ResultsHolder[] results)
        {
            XmlSerializer xmlForamt = new XmlSerializer(typeof (ResultsHolder[]));
            using (FileStream fstream = new FileStream("Results.xml",
                 FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlForamt.Serialize(fstream, results);
            }                     
        }
        private ResultsHolder[] Deserialization()
        {
            XmlSerializer xmlForamt = new XmlSerializer(typeof(ResultsHolder[]));
            ResultsHolder[] results;
            using (FileStream fstream = new FileStream("Results.xml",
                FileMode.Open, FileAccess.Read, FileShare.None))
            {
                results = (ResultsHolder[]) xmlForamt.Deserialize(fstream);
            }    
            return results;
        }     
        private ResultsHolder[] AddScore(int score, string name)
        {
            Results[9] = new ResultsHolder(name, score);
            Array.Sort(Results);
            Array.Reverse(Results);
            return Results;
        }
        #endregion
    }

    #region SerializableClass
    [XmlRoot("Top 10 scores")]
    public class ResultsHolder : IComparable<ResultsHolder>
    {
        [XmlElement("Player")]
        public string Name { get; set; }
        [XmlElement("Score")]
        public int Score { get; set; }

        public ResultsHolder()
        {
            Name = "Player";
            Score = 0;
        }
        public ResultsHolder(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public int CompareTo(ResultsHolder item)
        {
            if (item == null || this.Score > item.Score)
            {
                return 1;
            }
            if (this.Score < item.Score)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
    #endregion
}
