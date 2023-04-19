using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using GameManagerNamespace;
using MissionNamespace;
using ScoreManagerNamespace;
using System;

public class GameManagerTest
{
    [Test]
    //試験重力値
    [TestCase(-50)]
    public void GameManager_Gravity_Test(float x)
    {
        var gameObject = new GameObject();
        var gameManager_ = gameObject.AddComponent<GameManager>();

        var gravity_ = gameManager_.Gravity;

        Assert.That(gravity_, Is.EqualTo(x));
    }
}





