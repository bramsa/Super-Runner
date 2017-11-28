using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float minSecondsPassedToSwichAgain = 5;
    public float averageSecondsToSwichAgain = 10;

    public GameObject positionLeft = null;
    public GameObject positionBehind = null;
    public GameObject positionRight = null;

    private float secondsPassedSinceLastSwitch = 0f;

    // Use this for initialization
    void Start()
    {
        SwitchToRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        secondsPassedSinceLastSwitch += Time.deltaTime;

        if (secondsPassedSinceLastSwitch >= averageSecondsToSwichAgain)
        {
            if (RandomBool())
            {
                SwitchToRandomPosition();
                secondsPassedSinceLastSwitch = 0f;
            }
        }
    }

    /// <summary>
    /// Chooses a random position of the three (positionLeft, positionBehind, positionRight) and switches
    /// the gameobject to the local position of the choosen one
    /// </summary>
    public void SwitchToRandomPosition()
    {
        int position = Random.Range(1, 4);
        switch (position)
        {
            case 1:
                SwitchToPosition(positionLeft);
                break;
            case 2:
                SwitchToPosition(positionBehind);
                break;
            case 3:
                SwitchToPosition(positionRight);
                break;
        }
    }

    /// <summary>
    /// Switchs the gameobject to the local position of the passed GameObject
    /// </summary>
    /// <param name="pos"></param>
    void SwitchToPosition(GameObject pos)
    {
        gameObject.transform.localPosition = pos.transform.localPosition;
        gameObject.transform.localRotation = pos.transform.localRotation;
    }

    /// <summary>
    /// Generates a random boolean. The larger averageSecondsToSwichAgain is, the more likely it returns true
    /// The duration of the time since the last frame has an effect too
    /// </summary>
    /// <returns></returns>
    bool RandomBool()
    {
        return Mathf.RoundToInt(Random.Range(0, (1 / Time.deltaTime) * averageSecondsToSwichAgain)) == 0;
    }
}
