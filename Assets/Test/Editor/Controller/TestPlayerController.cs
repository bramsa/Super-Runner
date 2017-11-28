using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class jumpAnd {

    private GameObject instance = null;
    private PlayerController player = null;

    [SetUp]
    public void SetUp()
    {
        instance = new GameObject();
        instance.transform.position = new Vector3(3, 3, 3);

       

        instance.AddComponent<Rigidbody>();
        instance.AddComponent<PlayerController>();
        player = instance.GetComponent<PlayerController>();
    }

    [TearDown]
    public void TearDown()
    {
        player = null;
        instance = null;
    }

    [UnityTest]
    public IEnumerator TestJump()
    {
        yield return null;

        player.Jump();
        Assert.IsTrue(3 < instance.transform.position.y);

        yield return null;
    }
}
