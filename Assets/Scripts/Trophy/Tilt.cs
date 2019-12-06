using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour
{

    //game objects
    GameObject trophy;
    GameObject rightCircle;
    GameObject leftCircle;

    //game componenets
    private Rigidbody2D trophyRigid;

    //attributes
    private Vector2 topLeft;
    private Vector2 topRight;
    private float force = 100;
    private Vector2 originalPosition;
    private bool isMoving;

    private void Start() {
        trophy = gameObject;
        trophyRigid = trophy.GetComponent<Rigidbody2D>();

        //get child object
        rightCircle = trophy.transform.GetChild(0).gameObject;
        leftCircle = trophy.transform.GetChild(1).gameObject;

        originalPosition = trophy.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            toppleLeft();
        }

        if (Input.GetMouseButtonDown(1)) {
            toppleRight();
        }

        StartCoroutine(checkIfTrophyMoving());

        //if it is not moving, rectify the position to original
        if (!isMoving) {
            rectifyTrophyPosition();
        }
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("Collide");
        }
    }

    void toppleLeft() {
        Rigidbody2D rigid2D = rightCircle.GetComponent<Rigidbody2D>();
        Vector2 rightCircleVector = rigid2D.transform.position;

        trophyRigid.AddForceAtPosition(rightCircleVector * force, rightCircleVector);

        isMoving = true;
    }

    void toppleRight() {
        Rigidbody2D rigid2D = leftCircle.GetComponent<Rigidbody2D>();
        Vector2 leftCircleVector = rigid2D.transform.position;

        trophyRigid.AddForceAtPosition(-leftCircleVector * force, leftCircleVector);

        isMoving = true;
    }

    void rectifyTrophyPosition() {
        trophy.transform.position = Vector2.Lerp(trophy.transform.position, originalPosition, 0.5f);
    }

    IEnumerator checkIfTrophyMoving() {
        //check if it is moving
        var p1 = transform.position;
        yield return new WaitForSeconds(0.1f);
        var p2 = transform.position;

        isMoving = (p1 != p2);
    }
}
