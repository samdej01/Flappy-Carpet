using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -85;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
      
      
    }
}
