using System.Collections;
using System.Collections.Generic;
using ArmNamespace;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameInputTest
{
    [Test]
    [TestCase()]

    public void GameInput_Parameter_Gravity_Test()
    {
        var gameObject = new GameObject();
        var gameInput = gameObject.AddComponent<GameInput>();

        Assert.That(gameInput.Gravity, Is.EqualTo(-150.0f));
    }

    [TestCase()]

    public void GameInput_Parameter_BounceMaxForce_Test()
    {
        var gameObject = new GameObject();
        var gameInput = gameObject.AddComponent<GameInput>();

        Assert.That(gameInput.BounceMaxForce, Is.EqualTo(200.0f));
    }

    [TestCase()]

    public void GameInput_Parameter_BounceMinForce_Test()
    {
        var gameObject = new GameObject();
        var gameInput = gameObject.AddComponent<GameInput>();

        Assert.That(gameInput.BounceMinForce, Is.EqualTo(150.0f));
    }

    [TestCase()]

    public void GameInput_Parameter_AccelerateForce_Test()
    {
        var gameObject = new GameObject();
        var gameInput = gameObject.AddComponent<GameInput>();

        Assert.That(gameInput.AccelerateForce, Is.EqualTo(300.0f));
    }

    [TestCase()]

    public void GameInput_Parameter_BounceScore_Test()
    {
        var gameObject = new GameObject();
        var gameInput = gameObject.AddComponent<GameInput>();

        Assert.That(gameInput.BounceScore, Is.EqualTo(10));
    }

    [TestCase()]

    public void GameInput_Parameter_TotalScore_Test()
    {
        var gameObject = new GameObject();
        var gameInput = gameObject.AddComponent<GameInput>();

        Assert.That(gameInput.TotalScore, Is.EqualTo(0));
    }

    [TestCase()]

    public void GameInput_Parameter_Lifetimes_Test()
    {
        var gameObject = new GameObject();
        var gameInput = gameObject.AddComponent<GameInput>();

        Assert.That(gameInput.Lifetimes, Is.EqualTo(5));
    }

    [TestCase()]

    public void GameInput_Parameter_HiddenEndingScore_Test()
    {
        var gameObject = new GameObject();
        var gameInput = gameObject.AddComponent<GameInput>();

        Assert.That(gameInput.HiddenEndingScore, Is.EqualTo(20000));
    }

    [TestCase()]

    public void GameInput_Parameter_BallCanMove_Test()
    {
        var gameObject = new GameObject();
        var gameInput = gameObject.AddComponent<GameInput>();

        Assert.IsTrue(gameInput.BallCanMove);
    }

    [TestCase()]

    public void GameInput_Parameter_IsHeartMissionStart_Test()
    {
        var gameObject = new GameObject();
        var gameInput = gameObject.AddComponent<GameInput>();

        Assert.IsTrue(!gameInput.IsHeartMissionStart);
    }
}
