using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    private Object ground = Resources.Load("Ground");
    private Vector3 groundPosition = new Vector3(0, 0, 100);
    /// <summary>
    /// The difference for the z position of the new ground. On every annexation of the ground it's
    /// incremented by 200, which is the length of the ground.
    /// </summary>
    private int reloadTimeValue = 200;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    	
	}

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Equals("NextLevel"))
        {
            var newPosition = new Vector3(0, 0, groundPosition.z + reloadTimeValue);
            reloadTimeValue += 200;
            Instantiate(ground, newPosition, Quaternion.identity);
        }
    }
}
