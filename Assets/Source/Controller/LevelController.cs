using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    private Object ground = null;
    private Vector3 groundPosition = new Vector3(0, 0, 100);
    /// <summary>
    /// The difference for the z position of the new ground. On every annexation of the ground it's
    /// incremented by 200, which is the length of the ground.
    /// </summary>
    private int reloadTimeValue = 200;

    // Use this for initialization
    void Start()
    {
        // ground = Resources.Load("Ground");
        generateObstacles(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        // Map
        if (collision.gameObject.name.Equals("NextLevel"))
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
        for (int i = 1; i <= 10; i++)
        {
            float obstacleZPosition = newGroundZPosition + i * 20;
            int obstacleType = Random.Range(1, 5);

            switch (obstacleType)
            {
                // Jump
                case 1:
                    var obstacle_1Position = new Vector3(0, 2.5F, obstacleZPosition);
                    GameObject obstacle_1 = Instantiate(Resources.Load("Prefabs/Obstacle_1", typeof(GameObject)) as GameObject, obstacle_1Position, Quaternion.identity);
                    obstacle_1.transform.Rotate(0, 0, 90, Space.Self);
                    break;

                // Duck
                case 2:
                    var obstacle_2Position = new Vector3(0, 2.25F, obstacleZPosition);
                    GameObject obstacle_2 = Instantiate(Resources.Load("Prefabs/Obstacle_2", typeof(GameObject)) as GameObject, obstacle_2Position, Quaternion.identity);
                    obstacle_2.transform.Rotate(0, 0, 90, Space.Self);
                    break;

                // Longer Jump
                case 3:
                    var obstacle_3Position = new Vector3(0, 3.25F, obstacleZPosition);
                    GameObject obstacle_3 = Instantiate(Resources.Load("Prefabs/Obstacle_3", typeof(GameObject)) as GameObject, obstacle_3Position, Quaternion.identity);
                    obstacle_3.transform.Rotate(0, 0, 90, Space.Self);
                    break;

                // Comet
                case 4:
                    var obstacle_4Position = new Vector3(0, 3.5F, obstacleZPosition);
                    GameObject obstacle_4 = Instantiate(Resources.Load("Prefabs/Obstacle_4", typeof(GameObject)) as GameObject, obstacle_4Position, Quaternion.identity);
                    break;
            }

            // NextLevel
            if(obstacleZPosition == newGroundZPosition + 100)
            {
                var nextLevelBlock = new Vector3(0, 5.5F, obstacleZPosition);
                GameObject obstacle_4 = Instantiate(Resources.Load("Prefabs/NextLevel", typeof(GameObject)) as GameObject, nextLevelBlock, Quaternion.identity);

            }
        }
    }
}
