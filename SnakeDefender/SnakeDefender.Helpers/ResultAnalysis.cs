using System;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using SnakeDefender.GameEngine.GameObject;

namespace SnakeDefender.Helpers
{
    public class ResultAnalysis
    {
        
        #region Private field

        private ResultsHolder[] _resultsHolders;
        private readonly string _resultsPath;

        #endregion

        public event EventHandler<ResultsHolder> RaiseMyEvent;

        #region Constructor

        public ResultAnalysis(IGameSettings settings)
        {
            _resultsHolders = new ResultsHolder[10];
            this._resultsPath = settings.ResultPath;
        }

        #endregion

        #region Public Methods
        public bool CheckResult(int point)
        {
            var isBigger = new bool();
            if (File.Exists(this._resultsPath))
            {
                _resultsHolders = Deserialization();
                if (_resultsHolders[9] == null ||
                    _resultsHolders[9].Score < point)
                {
                    isBigger = true;
                }            
            }
            else
            {
                isBigger = true;
            }
            return isBigger;

        }

        public void ShowResults()
        {
            OnRaiseMyEvent();
        }

        public void AddScore(int score, string name)
        {
            _resultsHolders[9] = new ResultsHolder(name, score);
            Array.Sort(_resultsHolders);
            Array.Reverse(_resultsHolders);
            Serialization(_resultsHolders);
        }

        protected virtual void OnRaiseMyEvent()
        {
            EventHandler<ResultsHolder> handler = RaiseMyEvent;
            foreach (var res in _resultsHolders.Where(res => res != null))
            {
                if (handler != null)
                {
                    handler(this, res);
                }
            }            
        }

        #endregion

        #region Private Methods

        private void Serialization(ResultsHolder[] results)
        {
            var xmlForamt = new XmlSerializer(typeof (ResultsHolder[]));
            using (var fstream = new FileStream(this._resultsPath,
                 FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlForamt.Serialize(fstream, results);
            }                     
        }

        private ResultsHolder[] Deserialization()
        {
            ResultsHolder[] results;
            var xmlForamt = new XmlSerializer(typeof(ResultsHolder[]));            
            using (var fstream = new FileStream(this._resultsPath,
                FileMode.Open, FileAccess.Read, FileShare.None))
            {
                results = (ResultsHolder[]) xmlForamt.Deserialize(fstream);
            }    
            return results;
        }     
     
        #endregion

    } 
}
