using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    public GameObject menuPanel;
    public Blindness blindness;
    public Spawner spawner;
    public Manager manager;

    public void StartGame() {
        blindness.enabled = true;
        spawner.enabled = true;
        menuPanel.SetActive(false);
        manager.isGameStarted = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
