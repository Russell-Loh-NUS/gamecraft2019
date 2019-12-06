using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : Singleton<Manager>
{
    public bool isGameStarted;
    public GameObject GUI;

    // Start is called before the first frame update
    void Start()
    {
        isGameStarted = false;
        GUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStarted) {
            GUI.SetActive(true);
        }
    }
}
