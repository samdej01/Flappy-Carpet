using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampSpawner : MonoBehaviour
{
    [Header("Spawning Settings")]
    public GameObject lampPrefab;
    public float spawnRate = 4f;
    public float heightOffset = 2f;
    public float spawnX = 10f;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float deadZone = -15f;

    private float timer = 0;

    void Awake()
    {
        // Adjust settings based on game mode
        switch (GameModeManager.SelectedMode)
        {
            case GameMode.Easy:
                spawnRate = 4f;
                moveSpeed = 4f;
                break;
            case GameMode.Hard:
                spawnRate = 2f;
                moveSpeed = 8f;
                break;
            case GameMode.Mission:
                spawnRate = 3f;
                moveSpeed = 6f;
                break;
        }
    }

    void Update()
    {
        // Handle spawn timing
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnLamp();
            timer = 0;
        }
    }

    void SpawnLamp()
    {
        float randomY = Random.Range(transform.position.y - heightOffset, transform.position.y + heightOffset);
        GameObject lamp = Instantiate(lampPrefab, new Vector3(spawnX, randomY, 0), Quaternion.identity);

        // Attach mover to the lamp
        LampMover mover = lamp.AddComponent<LampMover>();
        mover.moveSpeed = moveSpeed;
        mover.deadZone = deadZone;
    }
}

public class LampMover : MonoBehaviour
{
    public float moveSpeed;
    public float deadZone;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
