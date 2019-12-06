using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour
{

    //game objects
    GameObject trophy;
    GameObject rightCircle;
    GameObject leftCircle;

    public float force = 1000000;

    //game componenets
    private Rigidbody2D trophyRigid;

    //attributes
    private Vector2 topLeft;
    private Vector2 topRight;
    private Vector2 originalPosition;

    //flag
    private bool isMoving;
    private bool isFallen;

    private void Start() {
        trophy = gameObject;
        trophyRigid = trophy.GetComponent<Rigidbody2D>();

        //get child object
        rightCircle = trophy.transform.GetChild(0).gameObject;
        leftCircle = trophy.transform.GetChild(1).gameObject;

        originalPosition = trophy.transform.position;

        //default values
        isFallen = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(checkIfTrophyMoving());
        toggleIsFallen();

        //if it is not moving, rectify the position to original
        if (!isMoving) {
            rectifyTrophyPosition();
        }
    }

    public void toppleLeft(int noOfHit) {
        for (int i = 0; i < noOfHit; i++) {
            Rigidbody2D rigid2D = rightCircle.GetComponent<Rigidbody2D>();
            Vector2 rightCircleVector = rigid2D.transform.position;

            trophyRigid.AddForceAtPosition(rightCircleVector * force, rightCircleVector);

            isMoving = true;
        }
    }

    public void toppleRight(int noOfHit) {
        for (int i = 0; i < noOfHit; i++) {
            Rigidbody2D rigid2D = leftCircle.GetComponent<Rigidbody2D>();
            Vector2 leftCircleVector = rigid2D.transform.position;

            trophyRigid.AddForceAtPosition(-leftCircleVector * force, leftCircleVector);

            isMoving = true;
        }
    }

    void rectifyTrophyPosition() {
        if (!isFallen) {
            trophy.transform.position = Vector2.Lerp(trophy.transform.position, originalPosition, 0.5f);
        }
    }

    IEnumerator checkIfTrophyMoving() {
        //check if it is moving
        var p1 = transform.position;
        yield return new WaitForSeconds(0.1f);
        var p2 = transform.position;

        isMoving = (p1 != p2);
    }

    void toggleIsFallen() {
        float z = trophy.transform.rotation.eulerAngles.z;

        if ((z >= 0 && z <= 45) || (z <= 360 && z >= 315)) {
            isFallen = false;
        } else {
            isFallen = true;
        }
    }
}
