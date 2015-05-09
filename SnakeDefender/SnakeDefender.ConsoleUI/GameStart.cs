using System;
using SnakeDefender.Helpers;

namespace SnakeDefender.ConsoleUI
{
    class GameStart
    {
        #region Private Fields

        private static GameSettings _gameSettings;
        private static ResultAnalysis _resultsAnalysis;
        private static RandomGenerator _randomGenerator;

        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("Snake Defender");
            Console.WriteLine("Press 'Enter' for start");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
           
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                do
                {                   
                    var game = new ConsoleGame(_gameSettings, _randomGenerator);
                    _resultsAnalysis.RaiseMyEvent += game.ShowResults;
                    game.StartGame();
                    // when Game Over
                    GameCompleted(game);
                    Console.WriteLine("Press 'Enter' for restart");
                    keyInfo = Console.ReadKey();
                    Console.Clear();

                } while (keyInfo.Key == ConsoleKey.Enter);
                
            }
            
        }

        private static void GameCompleted(ConsoleGame game)
        {
            Console.SetCursorPosition(0, _gameSettings.GameBoardHeight + 3);
            Console.WriteLine("Your score --> {0}", game.Score);
            if (_resultsAnalysis.CheckResult(game.Score))
            {
                Console.WriteLine("Your name:");
                string name = Console.ReadLine();
                _resultsAnalysis.AddScore(game.Score, name);
            }           
            _resultsAnalysis.ShowResults();
            _gameSettings.ReadFromConfig();
            _resultsAnalysis = new ResultAnalysis(_gameSettings);
        }

        static GameStart()
        {
            _gameSettings = new GameSettings();
            _gameSettings.ReadFromConfig();
            _resultsAnalysis = new ResultAnalysis(_gameSettings);
            _randomGenerator = new RandomGenerator(_gameSettings.GameBoardWidth,
            _gameSettings.GameBoardHeight);
        }

    }
}
