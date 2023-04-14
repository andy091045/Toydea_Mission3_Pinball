using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArmNamespace;
using NUnit.Framework;
using Unity.IO.LowLevel.Unsafe;

public class ArmTest
{
    [Test]
    //tag
    [TestCase()]

    public void Arm_Test()
    {
        var gameObject = new GameObject();
        var arm_ = gameObject.AddComponent<Arm>();
        var leftArm_ = Arm.ArmType.LeftArm;
        var rightArm_ = Arm.ArmType.RightArm;

        Assert.IsTrue(arm_.TypeIsLeftArm(leftArm_));
        Assert.IsFalse(arm_.TypeIsLeftArm(rightArm_));
    }

}
