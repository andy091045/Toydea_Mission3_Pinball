using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Count;

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
