using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The LevelController handles the loading of each next level.
/// </summary>
public class LevelController : MonoBehaviour
{

    // private Object ground = null;
    private Vector3 groundPosition = new Vector3(0, 0, 100);
    /// <summary>
    /// The difference for the z position of the new ground. On every annexation of the ground it's
    /// incremented by 200, which is the length of the ground.
    /// </summary>
    private int reloadTimeValue = 200;

    /// <summary>
    /// Use this for initialization.
    /// </summary>
    void Start()
    {
        // ground = Resources.Load("Ground");
        generateObstacles(0);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {

    }

    /// <summary>
    /// This method is called when the player touches another game object.
    /// </summary>
    /// <param name="collider"></param>
    public void OnTriggerEnter(Collider collider)
    {
        // Map
        if (collider.gameObject.CompareTag("NextLevelBlock"))
        {
            float newGroundLength =+ reloadTimeValue;
            var newGroundPosition = new Vector3(0, 0, newGroundLength);
            reloadTimeValue += 200;
            GameObject ground = Instantiate(Resources.Load("Prefabs/Ground", typeof(GameObject)) as GameObject, newGroundPosition, Quaternion.identity);

            //GameObject ground = GameObject.FindGameObjectWithTag("Ground");
            //ground.GetComponentInChildren<Renderer>().transform.localScale = new Vector3(0, 0, newGroundLength + 200);


            // Obstacles start on the beginning of the ground
            generateObstacles(newGroundLength - 100);
        }
    }

    /// <summary>
    /// Creates all new obstacles and the "nextLevelBlock" of the following level.
    /// </summary>
    /// <param name="newGroundZPosition"></param>
    public void generateObstacles(float newGroundZPosition)
    {
        for (int i = 1; i <= 5; i++)
        {
            float obstacleZPosition = newGroundZPosition + i * 40;
            int obstacleType = Random.Range(1, 5);

            switch (obstacleType)
            {
                // Jump
                case 1:
                    var obstacle_1Position = new Vector3(0, 1.5F, obstacleZPosition);
                    GameObject obstacle_1 = Instantiate(Resources.Load("Prefabs/Obstacle_1", typeof(GameObject)) as GameObject, obstacle_1Position, Quaternion.identity);
                    obstacle_1.transform.Rotate(0, 0, 90, Space.Self);
                    var obstacle_5Position = new Vector3(0, 0, obstacleZPosition);
                    GameObject obstacle_5 = Instantiate(Resources.Load("Prefabs/Obstacle_5", typeof(GameObject)) as GameObject, obstacle_5Position, Quaternion.identity);
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
                    var obstacle_4Position = new Vector3(0, 4F, obstacleZPosition);
                    GameObject obstacle_4 = Instantiate(Resources.Load("Prefabs/Obstacle_4", typeof(GameObject)) as GameObject, obstacle_4Position, Quaternion.identity);
                    break;

                //// WallOfFire
                //case 5:
                //    var obstacle_5Position = new Vector3(0, 0, obstacleZPosition);
                //    GameObject obstacle_5 = Instantiate(Resources.Load("Prefabs/Obstacle_5", typeof(GameObject)) as GameObject, obstacle_5Position, Quaternion.identity);
                //    break;
            }

            // NextLevel
            if (obstacleZPosition == newGroundZPosition + 120)
            {
                var nextLevelBlock = new Vector3(0, 5.5F, obstacleZPosition);
                GameObject obstacle_4 = Instantiate(Resources.Load("Prefabs/NextLevel", typeof(GameObject)) as GameObject, nextLevelBlock, Quaternion.identity);

            }
        }
    }

    /// <summary>
    /// Exits the application
    /// </summary>
    public void exitApplication()
    {
        SendMessage("BeforeGameExits", null, SendMessageOptions.DontRequireReceiver);
        Application.Quit();
    }
}
