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

        if (logic == null)
        {
            GameObject logicObj = GameObject.FindGameObjectWithTag("Logic");
            if (logicObj != null)
            {
                logic = logicObj.GetComponent<LogicScript>();
            }
            else
            {
                Debug.LogWarning("Logic object with tag 'Logic' not found!");
            }
        }
    }

    void Update()
    {
        if (Alive && Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasCollided) return;

        TriggerGameOver();
    }

    private void OnTriggerEnter2D(Collider2D other)
{
    if (hasCollided) return;

    if (other.CompareTag("Obstacle"))  // Make sure obstacle has this tag
    {
        TriggerGameOver();
    }
}

    private void TriggerGameOver()
    {
        hasCollided = true;
        Alive = false;

        if (backgroundMusic != null) backgroundMusic.Stop();
        if (audioSource != null && collisionClip != null)
        {
            audioSource.PlayOneShot(collisionClip);
        }

        StartCoroutine(PlayGameOverAfterDelay());
    }

    IEnumerator PlayGameOverAfterDelay()
    {
        if (collisionClip != null)
        {
            yield return new WaitForSeconds(collisionClip.length);
        }

        if (audioSource != null && gameOverClip != null)
        {
            audioSource.PlayOneShot(gameOverClip);
            yield return new WaitForSeconds(gameOverClip.length * 0.8f);
        }

        if (logic != null)
        {
            logic.gameOver();
        }
        else
        {
            Debug.LogWarning("Logic script not found when trying to trigger game over.");
        }
    }

    public void ForceGameOver()
    {
        if (!hasCollided)
        {
            TriggerGameOver();
        }
    }
}
