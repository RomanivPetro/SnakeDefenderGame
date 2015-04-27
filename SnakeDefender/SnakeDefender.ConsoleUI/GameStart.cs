using System;
using SnakeDefender.ConsoleUI.AdditionalClasses;
using SnakeDefender.GameEngine;

namespace SnakeDefender.ConsoleUI
{
    class GameStart
    {            
        static void Main(string[] args)
        {
            var resultsAnalysis = new ResultsProcessing();

            Console.WriteLine("Snake Defender");
            Console.WriteLine("Press 'Enter' for start");
            ConsoleKeyInfo key_info = Console.ReadKey();
           
            if (key_info.Key == ConsoleKey.Enter)
            {
                while (key_info.Key == ConsoleKey.Enter)
                {
                    var game = new ConsoleGame();
                    game.StartGame();
                    // when Game Over
                    Console.WriteLine("Your score --> {0}",game.Score);
                    resultsAnalysis.CheckResult(game.Score);
                    resultsAnalysis.ShowResults();
                    Console.WriteLine("Press 'Enter' for restart");
                    key_info = Console.ReadKey();                    
                    Console.Clear();
                }

            }
            
        }
    }
}
