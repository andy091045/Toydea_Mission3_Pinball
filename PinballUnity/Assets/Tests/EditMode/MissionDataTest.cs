using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using MissionNamespace;

public class MissionDataTest
{
    [Test]
    [TestCase()]
    public void MissionData_Test()
    {
        var mission1 = new Mission();
        Assert.IsInstanceOf(typeof(int), mission1.Number);
        Assert.IsInstanceOf(typeof(string), mission1.Description);
        Assert.IsInstanceOf(typeof(int), mission1.NextNumber);
        Assert.IsInstanceOf(typeof(int), mission1.Score);
        Assert.IsInstanceOf(typeof(Vector3), mission1.Position);
    }
}
