using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using ScoreManagerNamespace;
using System;

public class ScoreManagerTest
{
    [Test]
    [TestCase(10, 1)]
    public void Add_Test_Return_Int(object a, object b)
    {
        var gameObject = new GameObject();
        var mission1 = gameObject.AddComponent<ScoreManager>();
        Assert.IsInstanceOf(typeof(int), mission1.Add(a, b));
        Assert.That(mission1.Add(a, b), Is.EqualTo(11));
    }

    [TestCase(10, 1.0f)]
    [TestCase(10.0f, 1.0f)]
    public void Add_Test_Throws_Float_Exception(object a, object b)
    {
        var gameObject = new GameObject();
        var mission1 = gameObject.AddComponent<ScoreManager>();
        Assert.Throws<ArgumentException>(() => mission1.Add(a, b));
    }

    [TestCase(10, 'a')]
    [TestCase(10, "asdfg")]
    public void Add_Test_Throws_Char_Or_String_Exception(object a, object b)
    {
        var gameObject = new GameObject();
        var mission1 = gameObject.AddComponent<ScoreManager>();
        Assert.Throws<ArgumentException>(() => mission1.Add(a, b));
    }
}
