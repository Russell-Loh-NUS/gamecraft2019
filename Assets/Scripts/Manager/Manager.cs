using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : Singleton<Manager>
{
    public bool isGameStarted;
    public GameObject GUI;
    public Blindness blindness;
    public Spawner spawner;
    public GameObject resultPanel;
    public Text resultText;

    private int currDifficulty = 0;

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

    public void IncreaseDifficulty() {
        Debug.Log(currDifficulty);
        float minFrequency = blindness.GetMinBlindnessFrequency();
        float maxFrequency = blindness.GetMaxBlindnessFrequency();

        blindness.SetBlindnessFrequency(
            minFrequency - 1.0f,
            maxFrequency - 2.0f);

        float spawnRate = spawner.GetRate();
        spawner.SetRate(spawnRate - 1.0f);

        currDifficulty++;
    }

    public void GameEnd() {
        resultText.text = "Your shift is secured!\nAt least for now...";
        blindness.canBlind = false;
        spawner.canSpawn = false;
        resultPanel.SetActive(true);
    }
}
