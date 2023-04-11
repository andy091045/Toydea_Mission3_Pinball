using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Count;
using GameManagerNamespace;
using AccelerateManagerNamespace;

public class CountTest
{
    [Test]
    [TestCase(10, '+', 2, 12)]
    [TestCase(10, '-', 2, 8)]
    [TestCase(10, '*', 2, 20)]
    [TestCase(500, '/', 10, 50)]
    public void Calculate_Test(float x, char pointer, float y, float result)
    {
        var Calculator = new Calculator(x, y, pointer);

        var score = Calculator.ScoreCount();

        Assert.That(score, Is.EqualTo(result));
    }


}

public class GameManagerTest
{
    [Test]
    //試験重力値
    [TestCase(-5000)]

    //[TestCase(-10)]

    public void GameManager_Test(float x)
    {
        var gameManager_ = new GameManagerExtra();

        var gravity_ = gameManager_.Gravity;

        Assert.That(gravity_, Is.EqualTo(x));
    }

}

public class AccelerateManagerTest
{
    [Test]
    //tag
    [TestCase(1000.0f)]
   
    public void GameManager_Test(float f)
    {
        var accelerateManager_ = new AccelerateManagerExtra();

        var acceleration = accelerateManager_.acceleration;
        Assert.That(acceleration, Is.EqualTo(f));        
    }

}
