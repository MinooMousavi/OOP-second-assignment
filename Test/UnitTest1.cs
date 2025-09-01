using Microsoft.VisualStudio.TestTools.UnitTesting;
using assignment2;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class ColonyTests
    {
        [TestMethod]
        public void TestLemm()
        {
            var lemming = new Colony.Lemming("l", 70);
            Assert.AreEqual(70, lemming.getCount());
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void TestNegative()
        {
            var lemming = new Colony.Lemming("l", -50);
        }

        [TestMethod]
        public void TestDouble()
        {
            var lem = new Colony.Lemming("l", 40);
            lem.Turn();
            lem.Turn();
            Assert.AreEqual(80, lem.getCount());
        }

        [TestMethod]
        public void TestAttacked()
        {
            var lem = new Colony.Lemming("l", 100);
            var predator = new Colony.Wolf("W", 10);
            int remain = lem.AttackedBy(predator);
            Assert.AreEqual(60, lem.getCount());
            Assert.AreEqual(15, remain);
        }

        [TestMethod]
        public void TestAttackedHare()
        {
            var hare = new Colony.Hare("h", 20);
            var predator = new Colony.Wolf("W", 20);
            hare.AttackedBy(predator);
            Assert.AreEqual(0, hare.getCount());
        }

        [TestMethod]
        public void GhopherTest()
        {
            var gopher = new Colony.Gopher("g", 100);
            gopher.Turn();
            gopher.Turn();
            gopher.Turn();
            gopher.Turn();
            Assert.AreEqual(200, gopher.getCount());
        }

        [TestMethod]
        public void TestAttackOwl()
        {
            var prey = new List<Colony.Prey> {
                new Colony.Hare("h", 75),
                new Colony.Gopher("g", 75)
            };
            var Owl = new Colony.SnowyOwl("o", 15);
            Owl.Attack(prey);
            Assert.IsTrue(prey[0].getCount() < 75 || prey[1].getCount() < 75);
        }

        [TestMethod]
        public void TestAttackFox()
        {
            var prey = new List<Colony.Prey> {
                new Colony.Gopher("g", 150)
            };
            var Fox = new Colony.ArcticFox("f", 10);
            Fox.Attack(prey);
            Fox.Attack(prey);
            Assert.IsTrue(prey[0].getCount() < 150);
        }

 

    
    }
}
