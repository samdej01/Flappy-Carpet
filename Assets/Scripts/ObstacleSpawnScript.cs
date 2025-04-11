using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnScript : MonoBehaviour
{
    public GameObject obstacle;

    [HideInInspector] public float spawnRate = 2f;
    [HideInInspector] public float heightOffset = 10f;

    private float timer = 0;

    // Use Awake so it runs before Start and before Unity overrides Inspector values
    void Awake()
    
    {
        switch (GameModeManager.SelectedMode)
        {
            case GameMode.Easy:
                spawnRate = 6f;
                heightOffset = 10f;
                break;

            case GameMode.Hard:
                spawnRate = 4f;   // Faster spawns
                heightOffset = 8f;  // Narrow gap
                break;

            case GameMode.Mission:
                spawnRate = 5f;
                heightOffset = 9f;
                break;
        }

        Debug.Log("Obstacle Spawn Settings → Mode: " + GameModeManager.SelectedMode +
                  ", spawnRate: " + spawnRate + ", heightOffset: " + heightOffset);
    }

    void Start()
    {
        spawnObstacle(); // Spawn one immediately
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
