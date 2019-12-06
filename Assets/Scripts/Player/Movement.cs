using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform[] positions = new Transform[6];
    private AudioSource movementSound;
    private int currentPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        movementSound = GetComponent<AudioSource>();
        MovePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        PositionMovement();
        MouseMovement();
    }

    private void PositionMovement() {
        if (Input.GetButtonDown("Right"))
        {
            if (currentPos < (positions.Length - 1))
            {
                currentPos++;
                MovePlayer();
                movementSound.Play();
            }


        }
        else if (Input.GetButtonDown("Left"))
        {
            if (currentPos > 0)
            {
                currentPos--;
                MovePlayer();
                movementSound.Play();
            }
        }
    }

    private void MouseMovement() {
        bool playerOnLeft = (currentPos % 2) == 0;
        if (Input.GetAxis("Mouse X") > 0 && playerOnLeft)
        {
            //Right
        }

        if (Input.GetAxis("Mouse X") < 0 && !playerOnLeft)
        {
            //Left
        }
    }

    private void MovePlayer() {
        if((currentPos % 2) == 0) {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        gameObject.transform.position = positions[currentPos].position;
    }
}
