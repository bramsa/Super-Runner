﻿using System;
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
            InvokeRepeating("changeColors", 0, 1);
        }

        /// <summary>
        /// Changes the color of every collision object except the player itself in the game.
        /// </summary>
        public void changeColors()
        {
            //GameObject gameObject = Resources.Load("Prefabs/Obstacle_1", typeof(GameObject)) as GameObject;
            //GameObject[] gameObjects = (FindObjectsOfType(gameObject.GetType())) as GameObject[];
            // Create an array with all obstacle game objects and convert it afterwards to a list
            List<GameObject> gameObjects = (GameObject.FindGameObjectsWithTag("Obstacle")).OfType<GameObject>().ToList();

            // Grounds
            foreach(GameObject ground in GameObject.FindGameObjectsWithTag("Ground"))
            {
                gameObjects.Add(ground);
            }
            
            Debug.Log("changeColors called");

            foreach (GameObject obstacle in gameObjects)
            {
                // Only these objects
                if (obstacle.name.Equals("Obstacle_1(Clone)")
                    || obstacle.name.Equals("Obstacle_2(Clone)")
                    || obstacle.name.Equals("Obstacle_3(Clone)")
                    || obstacle.name.Equals("Ground")
                    || obstacle.name.Equals("Ground(Clone)"))
                {
                    Renderer obstacleRenderer = obstacle.GetComponent<MeshRenderer>();
                    if (obstacleRenderer != null)
                    {
                        if (obstacleRenderer.material != null)
                        {
                            float red = UnityEngine.Random.Range(0F, 1F);
                            float green = UnityEngine.Random.Range(0F, 1F);
                            float blue = UnityEngine.Random.Range(0F, 1F);
                            obstacleRenderer.material.color = new Color(red, green, blue);
                            //obstacleRenderer.material.color = Color.red;

                        }
                    }
                }
            }
        }
    }
}
