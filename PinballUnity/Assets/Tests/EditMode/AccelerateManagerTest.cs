using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using AccelerateManagerNamespace;

public class AccelerateManagerTest
{
    [Test]
    //tag
    [TestCase(100.0f)]

    public void AccelerateManager_Test(float f)
    {
        var gameObject = new GameObject();
        var accelerateManager_ = gameObject.AddComponent<AccelerateManager>();

        var acceleration = accelerateManager_.Acceleration;
        Assert.That(acceleration, Is.EqualTo(f));
    }

}