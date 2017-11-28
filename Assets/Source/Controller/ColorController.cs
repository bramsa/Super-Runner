using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Controller
{
    class ColorController : MonoBehaviour
    {
        public void Start()
        {
            InvokeRepeating("changeColors", 0, 2);
        }

        /// <summary>
        /// Changes the color of every collision object except the player itself in the game.
        /// </summary>
        public void changeColors()
        {
            //GameObject gameObject = Resources.Load("Prefabs/Obstacle_1", typeof(GameObject)) as GameObject;
            //GameObject[] gameObjects = (FindObjectsOfType(gameObject.GetType())) as GameObject[];
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Obstacle");
            Debug.Log("changeColors called");

            foreach (GameObject obstacle in gameObjects)
            {
                // Only these objects
                if (obstacle.name.Equals("Obstacle_1(Clone)")
                    || obstacle.name.Equals("Obstacle_2(Clone)")
                    || obstacle.name.Equals("Obstacle_3(Clone)"))
                {
                    Renderer obstacleRenderer = obstacle.GetComponent<MeshRenderer>();
                    if (obstacleRenderer != null)
                    {
                        if (obstacleRenderer.material != null)
                        {
                            /*int red = UnityEngine.Random.Range(0, 256);
                            int green = UnityEngine.Random.Range(0, 256);
                            int blue = UnityEngine.Random.Range(0, 256);
                            obstacleRenderer.material.color = new Color(red, green, blue);*/
                            obstacleRenderer.material.color = Color.red;
                        }
                    }
                }
            }
        }
    }
}
