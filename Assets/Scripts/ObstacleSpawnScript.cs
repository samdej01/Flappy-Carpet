using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnScript : MonoBehaviour
{
    public GameObject obstacle;

    [HideInInspector] public float spawnRate = 6f;
    [HideInInspector] public float heightOffset = 10f;

    private float timer = 0;

    void Awake()
    {
        switch (GameModeManager.SelectedMode)
        {
            case GameMode.Easy:
                spawnRate = 6f;
                heightOffset = 8f; 
                break;

            case GameMode.Hard:
                spawnRate = 2f;
                heightOffset = 10f;  
                break;

            case GameMode.Mission:
                spawnRate = 4f;
                heightOffset = 9f;
                break;
        }

        //Debug.Log("Obstacle Spawn Settings → spawnRate: " + spawnRate + ", heightOffset: " + heightOffset);
    }

    void Start()
    {
        spawnObstacle();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnObstacle();
            timer = 0;
        }
    }

    void spawnObstacle()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        float randomY = Random.Range(lowestPoint, highestPoint);
        Instantiate(obstacle, new Vector3(transform.position.x, randomY, 0), transform.rotation);
    }
}
