using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeDefender.GameEngine.Test;
using SnakeDefender.GameEngine;
using SnakeDefender.GameEngine.GameObject;
using System.Linq;

namespace SnakeDefender.GameEngine.Test
{
    [TestClass]
    public class GameTest
    {
      
        #region Game Lifecycle
        [TestMethod]
        public void TestUsualLifecycle()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,                 
            };
            var generator = new RandomTest();
            generator.genPoints.Add(new Point(7,7));
          
            var game = new Game(settings, generator);
            Assert.AreEqual(GameStatus.ReadyToStart, game.Status);
            game.Start();
            Assert.AreEqual(GameStatus.InProgress, game.Status);
            game.Stop();
            Assert.AreEqual(GameStatus.Completed, game.Status);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestStart_WrongStatus_1()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,               
            };
            var generator = new RandomTest();
            generator.genPoints.Add(new Point(7, 7));

            var game = new Game(settings, generator);
            game.Start();
            game.Start();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestStart_WrongStatus_2()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,
            };
            var generator = new RandomTest();
            generator.genPoints.Add(new Point(7, 7));

            var game = new Game(settings, generator);
            game.Start();
            game.Stop();
            game.Start();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestStop_WrongStatus_1()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,             
            };
            var generator = new RandomTest();
            generator.genPoints.Add(new Point(7, 7));

            var game = new Game(settings, generator);
            game.Stop();           
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestStop_WrongStatus_2()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,                
            };
            var generator = new RandomTest();
            generator.genPoints.Add(new Point(7, 7));

            var game = new Game(settings, generator);
            game.Start();
            game.Stop();
            game.Stop();
        }
        #endregion

        #region Test Property
        [TestMethod]
        public void TestGameScoreGetter()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,                
            };
            var generator = new RandomTest();
            generator.genPoints.Add(new Point(7, 7));

            var game = new Game(settings, generator);
            Assert.AreEqual(40, game.Score);           
        }

        #endregion

        #region Game Control

        #region Constructor

        [TestMethod]
        public void TestGameConstructor()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left
            };

            var generator = new RandomTest();
            generator.genPoints.Add(new Point(7, 7));

            var game = new Game(settings, generator);
            Assert.IsNotNull(game.Head);
            Assert.AreEqual(GameStatus.ReadyToStart, game.Status);                  
        }

        #endregion

        #region TestMovement

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestMovement_WrongMove()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,
            };
            var generator = new RandomTest();
            generator.genPoints.Add(new Point(7, 7));

            var game = new Game(settings, generator);
            game.Move();
        }

        [TestMethod]
        public void TestMovement_CheckTailRemove()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,                
            };

            var generator = new RandomTest();
            generator.genPoints.Add(new Point(7, 7));

            var game = new Game(settings, generator);                   
            game.Start();
            game.Move();
            var tail = game.Tail;
            game.Move();
            Assert.AreNotEqual(tail.Y, game.Tail.Y);
            Assert.AreEqual(tail.X, game.Tail.X);            
        }

        [TestMethod]
        public void TestMovement_TurnLeft()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,
            };

            var generator = new RandomTest();
            generator.genPoints.Add(new Point(7, 7));

            var game = new Game(settings, generator);
            game.Start();
            var head = game.Head;            
            game.Move();
            Assert.AreEqual(head.X -1, game.Head.X);
            Assert.AreEqual(head.Y, game.Head.Y);
        }

        [TestMethod]
        public void TestMovement_TurnRight()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,
            };

            var generator = new RandomTest();
            generator.genPoints.Add(new Point(7, 7));

            var game = new Game(settings, generator);
            game.Start();
            var head = game.Head;
            game.MoveDirection = Direction.Right;
            game.Move();
            Assert.AreEqual(head.X + 1, game.Head.X);
            Assert.AreEqual(head.Y, game.Head.Y);         
        }

        [TestMethod]
        public void TestMovement_TurnUp()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,             
            };

            var generator = new RandomTest();
            generator.genPoints.Add(new Point(7, 7));

            var game = new Game(settings, generator);
            game.Start();
            var head = game.Head;
            game.MoveDirection = Direction.Up;
            game.Move();
            Assert.AreEqual(head.X, game.Head.X);
            Assert.AreEqual(head.Y - 1, game.Head.Y);           
        }

        [TestMethod]
        public void TestMovement_TurnDown()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,           
            };

            var generator = new RandomTest();
            generator.genPoints.Add(new Point(7, 7));

            var game = new Game(settings, generator);
            game.Start();
            var head = game.Head;
            game.MoveDirection = Direction.Down;
            game.Move();
            Assert.AreEqual(head.X, game.Head.X);
            Assert.AreEqual(head.Y + 1, game.Head.Y);          
        }
        #endregion

        #region TestMoveCheck
        [TestMethod]
        public void TestMoveCheck_CollisionWithTopBorder()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Up,
            };

            var generator = new RandomTest();
            generator.genPoints.Add(new Point(7, 7));

            var game = new Game(settings, generator);            
            game.Start();
            game.Move();
            game.Move();
            Assert.AreEqual(GameStatus.Completed, game.Status);
        }

        [TestMethod]
        public void TestMoveCheck_CollisionWithBottomBorder()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,                
            };

            var generator = new RandomTest();
            generator.genPoints.Add(new Point(7, 7));

            var game = new Game(settings, generator);
            game.Start();
            game.Move();
            game.MoveDirection = Direction.Down;                
            while (game.Head.Y != settings.GameBoardHeight)
            {
                game.Move();
            }            
            Assert.AreEqual(GameStatus.Completed, game.Status);
        }

        [TestMethod]
        public void TestMoveCheck_CollisionWithLeftBorder()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,
            };

            var generator = new RandomTest();
            generator.genPoints.Add(new Point(7, 7));

            var game = new Game(settings, generator);
            game.Start();           
            while (game.Head.X != 0)
            {
                game.Move();
            }
            game.Move();
            Assert.AreEqual(GameStatus.Completed, game.Status);
        }

        [TestMethod]
        public void TestMoveCheck_CollisionWithRightBorder()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Right,
            };

            var generator = new RandomTest();
            generator.genPoints.Add(new Point(7, 7));

            var game = new Game(settings, generator);
            game.Start();
            while (game.Head.X != settings.GameBoardWidth)
            {
                game.Move();
            }            
            Assert.AreEqual(GameStatus.Completed, game.Status);
        }

        [TestMethod]
        public void TestMoveCheck_CollisionWithBody()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,         
            };

            var generator = new RandomTest();
            generator.genPoints.Add(new Point(7, 7));

            var game = new Game(settings, generator);         
            game.Start();
            game.Move();
            game.MoveDirection = Direction.Down;
            game.Move();
            game.MoveDirection = Direction.Right;
            game.Move();            
            Assert.AreEqual(GameStatus.Completed, game.Status);            
        }

        [TestMethod]
        public void TestMoveCheck_CollisionWithEmptyField()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,                
            };

            var generator = new RandomTest();
            generator.genPoints.Add(new Point(7, 7));

            var game = new Game(settings, generator);           
            game.Start();
            game.Move();
            game.MoveDirection = Direction.Down;
            for (int i = 0; i < 15; i++)
            {
                game.Move();
            }
            game.MoveDirection = Direction.Right;
            game.Move();
            game.MoveDirection = Direction.Up;
            for (int i = 0; i < 6; i++)
            {
                game.Move();
            }
            game.MoveDirection = Direction.Left;
            game.Move();
            Assert.AreEqual(GameStatus.Completed, game.Status);
        }

        #endregion
        
        #region TestGenerateFood

        [TestMethod]
        public void TestGenerateFood_RandomGenerate_Case1()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,
            };

            var generator = new RandomTest();
            generator.genPoints.Add(new Point(7, 7));

            var game = new Game(settings, generator);
            game.Start();
            Assert.IsNotNull(game.Food);           
           
        }

        [TestMethod]
        public void TestGenerateFood_RandomGenerate_Case2()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,
            };

            var generator = new RandomTest();
            generator.genPoints.Add(new Point(7, 7));

            var game = new Game(settings, generator);
            game.Start();
            Assert.IsNotNull(game.Food); 
            Assert.AreEqual(7, game.Food.X);
            Assert.AreEqual(7,game.Food.Y);
        }

        [TestMethod]
        public void TestGenerateFood_ColissionsWithBody()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,
            };

            var generator = new RandomTest();
            generator.genPoints.Add(new Point(3, 1));
            generator.genPoints.Add(new Point(5,2));
            generator.genPoints.Add(new Point(9, 9));
            var game = new Game(settings, generator);
            game.Start();
            game.Move();
            game.Move();
            
            Assert.IsNotNull(game.Food);
            Assert.AreNotEqual(5, game.Food.X);
            Assert.AreNotEqual(2, game.Food.Y);        
        }

        [TestMethod]
        public void TestGenerateFood_ColissionsWithEmptyField()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,
            };

            var generator = new RandomTest();
            generator.genPoints.Add(new Point(3, 1));
            generator.genPoints.Add(new Point(5, 5));
            generator.genPoints.Add(new Point(9, 9));
            var game = new Game(settings, generator);
            game.Start();
            game.Move();
            game.Move();

            Assert.IsNotNull(game.Food);
            Assert.AreNotEqual(5, game.Food.X);
            Assert.AreNotEqual(5, game.Food.Y);
        }

        [TestMethod]
        public void TestGenerateFood_ColissionsWithEmptyField_2()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,
            };

            var generator = new RandomTest();
            generator.genPoints.Add(new Point(3, 1));
            generator.genPoints.Add(new Point(5, 5));
            generator.genPoints.Add(new Point(9, 4));
            var game = new Game(settings, generator);
            game.Start();
            game.Move();
            game.Move();

            Assert.IsNotNull(game.Food);
            Assert.AreEqual(9, game.Food.X);
            Assert.AreEqual(4, game.Food.Y);
        }
        #endregion

        #region TestEat

        [TestMethod]
        public void TestEat_EatBigFood()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 0,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,          
            };

            var generator = new RandomTest();
            generator.genPoints.Add(new Point(3, 1));
            generator.genPoints.Add(new Point(8,8));
            // Food(3,1)
            var game = new Game(settings, generator);
            game.Start();
            game.Move();
            game.Move();
            Assert.AreEqual(50.2, game.Score);

        }

        [TestMethod]
        public void TestEat_EatBigFood_2()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 0,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,
            };

            var generator = new RandomTest();
            generator.genPoints.Add(new Point(3, 1));
            generator.genPoints.Add(new Point(8, 9));
            // Food(3,1)
            var game = new Game(settings, generator);
            game.Start();
            Assert.AreEqual(3, game.Food.X);
            Assert.AreEqual(1, game.Food.Y);
            game.Move();
            game.Move();
            Assert.AreEqual(8, game.Food.X);
            Assert.AreEqual(9, game.Food.Y);
        }
      
        [TestMethod]
        public void TestEat_EatSimple()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,         
            };

            var generator = new RandomTest();            
            generator.genPoints.Add(new Point(8, 9));
         
            var game = new Game(settings, generator);
            game.Start();
            game.Move();
            Assert.AreEqual(40.7, game.Score);
            
        }

        [TestMethod]
        public void TestEat_Addspeed()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 200,
                GameScore = 50,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,               
            };

            var generator = new RandomTest();
            generator.genPoints.Add(new Point(8, 9));

            var game = new Game(settings, generator);
            game.Start();
            game.Move();
            Assert.AreEqual(155, game.Speed);                 
        }

        [TestMethod]
        public void TestEat_MaxSpeed()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 45,
                GameScore = 50,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,                
            };

            var generator = new RandomTest();
            generator.genPoints.Add(new Point(8, 9));

            var game = new Game(settings, generator);
            game.Start();
            game.Move();
            Assert.AreEqual(45, game.Speed);
        }

        #endregion

        #endregion
         
    }
}
