using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col) {
        Tilt parentScript = this.transform.parent.GetComponent<Tilt>();

        if (col.gameObject.CompareTag("Rat")) {
            //Destroy(col.gameObject);
            if (gameObject.name == "LeftRectangle") {
                parentScript.toppleRight(18);
            }

            if (gameObject.name == "RightRectangle") {
                parentScript.toppleLeft(18);
            }
        }
    }
}
