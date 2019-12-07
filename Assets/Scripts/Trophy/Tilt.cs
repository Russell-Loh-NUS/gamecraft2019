using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour
{

    //game objects
    public GameObject trophy;
    GameObject rightCircle;
    GameObject leftCircle;

    public float force = 600;

    //game componenets
    private Rigidbody2D trophyRigid;

    //attributes
    private Vector2 topLeft;
    private Vector2 topRight;
    private Vector2 originalPosition;
    private Vector2 originalLeftCircle;
    private Vector2 originalRightCircle;

    //flag
    private bool isMoving;
    public bool isFallen;

    private void Start() {
        trophy = gameObject;
        trophyRigid = trophy.GetComponent<Rigidbody2D>();

        //get child object
        rightCircle = trophy.transform.GetChild(0).gameObject;
        leftCircle = trophy.transform.GetChild(1).gameObject;

        originalPosition = trophy.transform.position;
        originalRightCircle = rightCircle.transform.position;
        originalLeftCircle = leftCircle.transform.position;

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

    public void toppleLeftByRat(float force) {
        Vector2 rightCircleVector = rightCircle.transform.position;
        trophyRigid.AddForceAtPosition(Vector2.left * force * 1.5f, rightCircleVector);
        isMoving = true;
    }

    public void toppleRightByRat(float force) {
        Vector2 leftCircleVector = leftCircle.transform.position;
        trophyRigid.AddForceAtPosition(Vector2.right * force, leftCircleVector);
        isMoving = true;
    }

    public void toppleLeft(int noOfHit) {
        for (int i = 0; i < noOfHit; i++) {
            Vector2 rightCircleVector = rightCircle.transform.position;
            Vector2 leftCircleVector = leftCircle.transform.position;

            /*
            if (!(originalLeftCircle.x + 0.2 < leftCircleVector.x)) {
                break;
            }
            */

            trophyRigid.AddForceAtPosition(Vector2.left * force * 1.5f, rightCircleVector);

            isMoving = true;
        }
    }

    public void toppleRight(int noOfHit) {
        Debug.Log("ToPPLE RIGHTTTTTTTTTTTT");
        for (int i = 0; i < noOfHit; i++) {
            Vector2 leftCircleVector = leftCircle.transform.position;
            Vector2 rightCircleVector = rightCircle.transform.position;

            /*
            if (!(leftCircleVector.x < originalLeftCircle.x - 0.2)) {
                break;
            }
            */

            trophyRigid.AddForceAtPosition(Vector2.right * force, leftCircleVector);

            isMoving = true;
        }
    }

    bool isOriginalPosition(Vector2 currentPos, Vector2 originalPos) {
        return currentPos == originalPos;
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
        if (!isMoving) {
            GameObject.Find("Player").transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    void toggleIsFallen() {
        float z = Mathf.Round(trophy.transform.rotation.eulerAngles.z);

        if ((z >= 0 && z <= 45) || (z <= 360 && z >= 315)) {
            isFallen = false;
        } else {
            isFallen = true;
        }
    }

    IEnumerator lowersCenterOfMass() {
        float originalMass = trophyRigid.mass;
        Vector2 originalCenterOfMass = trophyRigid.centerOfMass;

        trophyRigid.mass = originalMass * 10000;
        trophyRigid.centerOfMass = new Vector2(originalCenterOfMass.x, originalCenterOfMass.y - 2);
        yield return new WaitForSeconds(0.1f);

        trophyRigid.mass = originalMass;
        trophyRigid.centerOfMass = originalCenterOfMass;
    }
}
