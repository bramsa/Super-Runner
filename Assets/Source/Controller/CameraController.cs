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

    public bool switched = false;

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

    void SwitchToRandomPosition()
    {
        int position = Mathf.RoundToInt(Random.Range(1, 4));
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

    void SwitchToPosition(GameObject pos)
    {
        gameObject.transform.localPosition = pos.transform.localPosition;
        gameObject.transform.localRotation = pos.transform.localRotation;
    }

    bool RandomBool()
    {
        return Mathf.RoundToInt(Random.Range(0, (1 / Time.deltaTime) * averageSecondsToSwichAgain)) == 0;
    }
}
