using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArmNamespace;
using NUnit.Framework;
using Unity.IO.LowLevel.Unsafe;


public class ArmTest
{
    [Test]
    [TestCase()]


    public void Arm_StartAngle_LeftArm_Test()
    {
        var gameObject = new GameObject();
        var armType = gameObject.AddComponent<ArmType>();
        var arm = gameObject.AddComponent<Arm>();

        armType.ArmScript = arm;
        armType.startAngle_ = 60.0f;

        armType.chooseArmType = ArmType.ChooseArmType.LeftArm;
        armType.SetStartAngle();

        Assert.That(arm.StartAngle, Is.EqualTo(armType.startAngle_));        
    }

    [TestCase()]

    public void Arm_StartAngle_RightArm_Test()
    {
        var gameObject = new GameObject();
        var armType = gameObject.AddComponent<ArmType>();
        var arm = gameObject.AddComponent<Arm>();

        armType.ArmScript = arm;
        armType.startAngle_ = 60.0f;

        armType.chooseArmType = ArmType.ChooseArmType.RightArm;
        armType.SetStartAngle();

        Assert.That(arm.StartAngle, Is.EqualTo(-armType.startAngle_));
    }

    [TestCase()]

    public void Arm_TargetAngle_LeftArm_Test()
    {
        var gameObject = new GameObject();
        var armType = gameObject.AddComponent<ArmType>();
        var arm = gameObject.AddComponent<Arm>();

        armType.ArmScript = arm;
        armType.startAngle_ = 60.0f;
        armType.rotateAngle_ = 90.0f;

        armType.chooseArmType = ArmType.ChooseArmType.LeftArm;
        armType.TryControllLeftArm();
        float targetAngle = - (armType.rotateAngle_ - armType.startAngle_);
        Assert.That(arm.TargetAngle, Is.EqualTo(targetAngle));
    }

    [TestCase()]

    public void Arm_TargetAngle_RightArm_Test()
    {
        var gameObject = new GameObject();
        var armType = gameObject.AddComponent<ArmType>();
        var arm = gameObject.AddComponent<Arm>();

        armType.ArmScript = arm;
        armType.startAngle_ = 60.0f;
        armType.rotateAngle_ = 90.0f;

        armType.chooseArmType = ArmType.ChooseArmType.RightArm;
        armType.TryControllRightArm();
        float targetAngle = (armType.rotateAngle_ - armType.startAngle_);
        Assert.That(arm.TargetAngle, Is.EqualTo(targetAngle));
    }
}
