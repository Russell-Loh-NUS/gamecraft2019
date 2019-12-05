using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpHeight;
    private Rigidbody2D rb;
    private bool canJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Use user defined inputs for movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        bool jump = Input.GetButton("Jump");

        // Moving
        rb.velocity = new Vector2(horizontal * movementSpeed, rb.velocity.y);

        // Jumping
        if (jump && canJump) {
            canJump = false;
            rb.AddForce(Vector2.up * jumpHeight);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Floor")) {
            canJump = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Floor")) {
            canJump = false;
        }
    }
}
