using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength = 15f;
    public LogicScript logic;
    public bool Alive = true;

    public AudioSource backgroundMusic;
    public AudioSource audioSource;
    public AudioClip collisionClip;
    public AudioClip gameOverClip;

    private bool hasCollided = false;

    void Start()
    {
        if (myRigidbody == null)
        {
            myRigidbody = GetComponent<Rigidbody2D>();
        }

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (Alive && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SPACE PRESSED");
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasCollided) return;
        hasCollided = true;
        Alive = false;

        backgroundMusic.Stop();
        audioSource.PlayOneShot(collisionClip);
        StartCoroutine(PlayGameOverAfterDelay());
    }

    IEnumerator PlayGameOverAfterDelay()
    {
        yield return new WaitForSeconds(collisionClip.length);
        audioSource.PlayOneShot(gameOverClip);
        yield return new WaitForSeconds(gameOverClip.length * 0.8f);
        logic.gameOver();
    }

    public void ForceGameOver()
    {
        if (!hasCollided)
        {
            hasCollided = true;
            Alive = false;
            backgroundMusic.Stop();
            audioSource.PlayOneShot(collisionClip);
            StartCoroutine(PlayGameOverAfterDelay());
        }
    }
}
