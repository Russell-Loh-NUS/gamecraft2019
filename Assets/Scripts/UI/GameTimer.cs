using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public int timer = 60;
    public Text timerText;
    public Manager manager;

    private bool isTimerStarted;
    // Start is called before the first frame update
    void Start()
    {
        isTimerStarted = false;
        timerText.text = "Next shift: 60 seconds";
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.isGameStarted && !isTimerStarted) {
            InvokeRepeating("decreaseTimer", 1.0f, 1.0f);
            isTimerStarted = true;
        }
        //decrease timer value in GUI

    }

    void decreaseTimer() {
        if (timer > 0)
        {
            if (!manager.isGameStarted) {
                return;
            }

            timer -= 1;
            timerText.text = "Next shift: " + timer + " seconds";
            if (timer % 10 == 0) {
                manager.IncreaseDifficulty();
            }
        }
        else
        {
            isTimerStarted = false;
            manager.GameEnd();
            CancelInvoke();
        }
    }
}
