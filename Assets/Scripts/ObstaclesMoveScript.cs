using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMoveScript : MonoBehaviour
{
    [HideInInspector] public float moveSpeed = 5f;
    public float deadZone = -80f;

    private static bool hasLogged = false;

    void Awake()
    {
        switch (GameModeManager.SelectedMode)
        {
            case GameMode.Easy:
                moveSpeed = 5f;
                break;

            case GameMode.Hard:
                moveSpeed = 9f;
                break;

            case GameMode.Mission:
                moveSpeed = 7f;
                break;
        }

        if (!hasLogged)
        {
            //Debug.Log("Obstacle Move Settings → moveSpeed: " + moveSpeed);
            hasLogged = true;
        }
    }

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
