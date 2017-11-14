using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    private Object ground = null;
    private Vector3 groundPosition = new Vector3(0, 0, 100);
    /// <summary>
    /// The difference for the z position of the new ground. On every annexation of the ground it's
    /// incremented by 200, which is the length of the ground.
    /// </summary>
    private int reloadTimeValue = 200;

    // Use this for initialization
    void Start () {
		ground = Resources.Load("Ground");
        generateObstacles(0);
    }
	
	// Update is called once per frame
	void Update () {
	    	
	}

    public void OnCollisionEnter(Collision collision)
    {
        // Map
        if(collision.gameObject.name.Equals("NextLevel"))
        {
            float newGroundZPosition = groundPosition.z + reloadTimeValue;

            var newGroundPosition = new Vector3(0, 0, newGroundZPosition);
            reloadTimeValue += 200;
            Instantiate(ground, newGroundPosition, Quaternion.identity);

            // Obstacles
            generateObstacles(newGroundZPosition);
        }
    }

    public void generateObstacles(float newGroundZPosition)
    {      
        for (int i = 0; i < 10; i++)
        {
            float obstacleYPosition = newGroundZPosition + ++i * 19;
            var obstaclePosition = new Vector3(0, 0, obstacleYPosition);
            int obstacleType = Random.Range(1, 4);

            switch (obstacleType)
            {
                // Jump
                case 1:
                    Instantiate(Resources.Load("Obstacle_1"), obstaclePosition, Quaternion.identity);
                    break;

                // Duck
                case 2:
                    Instantiate(Resources.Load("Obstacle_2"), obstaclePosition, Quaternion.identity);
                    break;

                // Longer Jump
                case 3:
                    Instantiate(Resources.Load("Obstacle_3"), obstaclePosition, Quaternion.identity);
                    break;

                // Comet
                case 4:
                    Instantiate(Resources.Load("Obstacle_4"), obstaclePosition, Quaternion.identity);
                    break;
            }


        }
    }
}
