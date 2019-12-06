using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement : MonoBehaviour
{
    public float movementSpeed = 5;
    public float jumpHeight = 350;

    private Rigidbody2D rb;
    private bool canJump = false;
    private float currentX = 1.0f;
    private float switchDirectionTimer;
    private float jumpTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        RandomJumpTimer();
        RandomDirectionTimer();
    }

    // Update is called once per frame
    void Update()
    {
        // Moving
        rb.velocity = new Vector2(currentX * movementSpeed, rb.velocity.y);
        if (switchDirectionTimer <= 0.0f) {
            currentX *= -1.0f;
            RandomDirectionTimer();
        }

        // Jumping
        if (jumpTimer <= 0.0f) {
            canJump = false;
            rb.AddForce(Vector2.up * jumpHeight);
            RandomJumpTimer();
        }

        UpdateTimers();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Floor")) {
            canJump = true;
        }

        if (col.gameObject.CompareTag("Wall") || col.gameObject.CompareTag("Trophy")) {
            currentX *= -1.0f;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Floor")) {
            canJump = false;
        }
    }

    private void UpdateTimers() {
        switchDirectionTimer -= Time.deltaTime;
        jumpTimer -= Time.deltaTime;
    }

    private void RandomJumpTimer() {
        jumpTimer = Random.Range(2.0f, 10.0f);
    }

    private void RandomDirectionTimer() {
        switchDirectionTimer = Random.Range(4.0f, 10.0f);
    }
}
