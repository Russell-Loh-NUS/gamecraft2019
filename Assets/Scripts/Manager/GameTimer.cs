using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public int timer = 60;
    private bool isTimerStarted;
    // Start is called before the first frame update
    void Start()
    {
        isTimerStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.Instance.isGameStarted == true || !isTimerStarted) {
            InvokeRepeating("decreaseTimer", 1.0f, 1.0f);
            isTimerStarted = true;
        }
        //decrease timer value in GUI

    }

    void decreaseTimer() {
        if (timer > 0)
        {
            timer -= 1;
        }
        else
        {
            isTimerStarted = false;
            CancelInvoke();
        }
    }
}
