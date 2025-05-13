using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength = 15f;
    public LogicScript logic;
    public bool Alive = true;

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
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            TriggerGameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasCollided) return;

        if (other.CompareTag("Obstacle"))
        {
            TriggerGameOver();
        }
    }

    private void TriggerGameOver()
    {
        hasCollided = true;
        Alive = false;

        SoundManager.Instance.PlaySound(SoundManager.Instance.collisionClip);
        StartCoroutine(PlayGameOverAfterDelay());
    }

    IEnumerator PlayGameOverAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SoundManager.Instance.PlaySound(SoundManager.Instance.gameOverClip);

        yield return new WaitForSeconds(1f); // Optional short wait before game ends
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
