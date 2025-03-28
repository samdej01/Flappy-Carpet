using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnScript : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnRate = 2;
    private float timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            Vector3 spawnPosition = transform.position;
            spawnPosition.x += 10f; 

            Instantiate(obstacle, spawnPosition, transform.rotation);
            timer = 0;
        }

    }
}
