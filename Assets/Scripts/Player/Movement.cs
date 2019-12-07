using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int noOfHits = 5;

    public Transform[] positions = new Transform[6];
    private AudioSource movementSound;
    private AudioSource pushSound;
    private GameObject pushEffect;
    private int currentPos = 0;


    // Start is called before the first frame update
    void Start()
    {
        movementSound = GetComponent<AudioSource>();
        pushSound = gameObject.transform.GetChild(0).GetComponent<AudioSource>();
        pushEffect = gameObject.transform.GetChild(0).gameObject;
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
        if (Input.GetAxis("Mouse X") > 0 && playerOnLeft && Input.GetMouseButtonDown(0))
        {
            pushEffect.SetActive(true);
            pushSound.Play();
            Debug.Log("activated");
            //trophy move right
            if (currentPos == 0) {
                //get the first trophy and topple right
                GameObject firstTrophy = GameObject.Find("Trophy 1");
                Tilt script = firstTrophy.GetComponent<Tilt>();
                script.toppleRight(noOfHits);
            } else if (currentPos == 2) {
                //toople right 2nd trophy
                GameObject secondTrophy = GameObject.Find("Trophy 2");
                Tilt script = secondTrophy.GetComponent<Tilt>();
                script.toppleRight(noOfHits);
            } else if (currentPos == 4) {
                //toople right 3rd trophy
                GameObject trophyThird = GameObject.Find("Trophy 3");
                trophyThird.GetComponent<Tilt>().toppleRight(noOfHits);
            }
        }

        if (Input.GetAxis("Mouse X") < 0 && !playerOnLeft && Input.GetMouseButtonDown(0))
        {
            pushEffect.SetActive(true);
            pushSound.Play();
            //trophy move left
            if (currentPos == 1) {
                //get the first trophy and topple right
                GameObject firstTrophy = GameObject.Find("Trophy 1");
                firstTrophy.GetComponent<Tilt>().toppleLeft(noOfHits);
            } else if (currentPos == 3) {
                //toople left 2nd trophy
                GameObject secTrophy = GameObject.Find("Trophy 2");
                secTrophy.GetComponent<Tilt>().toppleLeft(noOfHits);
            } else if (currentPos == 5) {
                //toople left 3rd trophy
                GameObject thirdTrophy = GameObject.Find("Trophy 3");
                thirdTrophy.GetComponent<Tilt>().toppleLeft(noOfHits);
            }
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
