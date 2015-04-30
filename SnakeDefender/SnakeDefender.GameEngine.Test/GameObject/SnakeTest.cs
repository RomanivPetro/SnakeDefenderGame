using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeDefender.GameEngine.GameObject;

namespace SnakeDefender.GameEngine.Test.GameObject
{
    [TestClass]
    public class SnakeTest
    {
        [TestMethod]
        public void TestSnakeCtrWithoutParameters()
        {
            Snake playerSnake = new Snake();
            // MR: для тестування колекцій потрібно використовувати класс CollectionAssert замість класу Asserts
            //     з цією метою, в класі Point необхідно перевизначити оператори == і !=
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(5, playerSnake.Body[i].X);
                Assert.AreEqual(i+1, playerSnake.Body[i].Y);
            }
        }
        
    }
}
