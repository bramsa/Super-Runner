using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class LifesControllerTest {

    private GameObject instance = null;
    private LifesController x = null;

    [SetUp]
    public void SetUp()
    {
        instance = new GameObject();

        instance.AddComponent<LifesController>();
        x = instance.GetComponent<LifesController>();
    }

    [TearDown]
    public void TearDown()
    {
        x = null;
        instance = null;
    }

    [Test]
	public void TestOnObstacleTouchedSubtractsOne() {
        x.lifes = int.MaxValue;

        x.OnObstacleTouched();

        Assert.AreEqual(int.MaxValue - 1, x.lifes);
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator LifesControllerTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame

        int i = 0;

        while (i < 500)
        {
            Debug.Log("Hello World");
            yield return null;
            i++;
        }
	}
}
