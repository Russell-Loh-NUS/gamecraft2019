using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuActions : MonoBehaviour
{
    public GameObject menuPanel;
    public Blindness blindness;
    public Spawner spawner;

    public void StartGame() {
        blindness.enabled = true;
        spawner.enabled = true;
        menuPanel.SetActive(false);
        Manager.Instance.isGameStarted = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
