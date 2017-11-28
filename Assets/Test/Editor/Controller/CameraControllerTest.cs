using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class CameraControllerTest {

    private GameObject instance = null;
    private CameraController x = null;

    [SetUp]
    public void SetUp()
    {
        instance = new GameObject();
        instance.transform.position = new Vector3(3, 3, 3);

        GameObject[] threePos = new GameObject[3];
        threePos[0] = new GameObject();
        threePos[1] = new GameObject();
        threePos[2] = new GameObject();

        instance.AddComponent<CameraController>();
        x = instance.GetComponent<CameraController>();
        x.positionLeft = threePos[0];
        x.positionBehind = threePos[1];
        x.positionRight = threePos[2];
    }

    [TearDown]
    public void TearDown()
    {
        x = null;
        instance = null;
    }

	[Test]
	public void TestSwitchToRandomPosition()
    {
        Assert.AreEqual(3, instance.transform.position.x);
        Assert.AreEqual(3, instance.transform.position.y);
        Assert.AreEqual(3, instance.transform.position.z);

        x.SwitchToRandomPosition();

        Assert.AreNotEqual(3, instance.transform.position.x);
        Assert.AreNotEqual(3, instance.transform.position.y);
        Assert.AreNotEqual(3, instance.transform.position.z);
    }
}
