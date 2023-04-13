using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Count;
using GameManagerNamespace;
using AccelerateManagerNamespace;
using MissionNamespace;

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
    [TestCase(-25)]

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
    [TestCase(100.0f)]
   
    public void AccelerateManager_Test(float f)
    {
        var accelerateManager_ = new AccelerateManagerExtra();

        var acceleration = accelerateManager_.acceleration;
        Assert.That(acceleration, Is.EqualTo(f));        
    }

}

public class MissionDataTest
{   
    [Test]    
    [TestCase()]
    public void MissionData_Test()
    {
        var mission1 = new Mission();
        Assert.IsInstanceOf(typeof(int), mission1.number_);
        Assert.IsInstanceOf(typeof(string), mission1.description_);
        Assert.IsInstanceOf(typeof(int), mission1.nextNumber_);
        Assert.IsInstanceOf(typeof(int), mission1.score_);
        Assert.IsInstanceOf(typeof(Vector3), mission1.position_);
    }
}