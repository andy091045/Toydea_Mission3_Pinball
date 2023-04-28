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


    public void ArmType_LeftArm_Test()
    {        
        var gameObject = new GameObject();
        var gameInput = gameObject.AddComponent<GameInput>();
        var arm = gameObject.AddComponent<Arm>();
        var armType = gameObject.AddComponent<ArmType>();
        

        armType.chooseArmType = ArmType.ChooseArmType.LeftArm;

        Assert.That(armType.chooseArmType, Is.EqualTo(ArmType.ChooseArmType.LeftArm));        
    }
}
