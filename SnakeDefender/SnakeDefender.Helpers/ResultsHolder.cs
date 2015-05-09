using System;
using System.Xml.Serialization;

namespace SnakeDefender.Helpers
{
    #region SerializableClass

    [XmlRoot("Top 10 scores")]
    public class ResultsHolder : IComparable<ResultsHolder>
    {
        #region Properties

        [XmlElement("Player")]
        public string Name { get; set; }

        [XmlElement("Score")]
        public int Score { get; set; }

        #endregion

        #region Constructors

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

        #endregion

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
