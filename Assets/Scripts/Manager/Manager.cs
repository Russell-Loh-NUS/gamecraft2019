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
    public GameObject startMenuParticle;
    public Text resultText;
    public Tilt[] trophiesTilt = new Tilt[3];

    private int currDifficulty = 0;
    private AudioSource bgMusic;
    private AudioSource winMusic;
    private AudioSource loseMusic;
    private bool isWin;

    // Start is called before the first frame update
    void Start()
    {
        isGameStarted = false;
        GUI.SetActive(false);
        bgMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        winMusic = GameObject.Find("WinMusic").GetComponent<AudioSource>();
        loseMusic = GameObject.Find("LoseMusic").GetComponent<AudioSource>();
        isWin = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStarted) {
            GUI.SetActive(true);

            for (int i = 0; i < trophiesTilt.Length; i++)
            {
                if (trophiesTilt[i].isFallen)
                {
                    isWin = false;
                    GameEnd();
                    break;
                }
            }
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
        if (!isGameStarted) {
            return;
        }

        bgMusic.Stop();
        if (isWin)
        {
            resultText.text = "Your shift is secured!\nAt least for now...";
            winMusic.Play();
        }
        else {
            resultText.text = "The sacred treasures were destroyed! You're FIRED!";
            loseMusic.Play();
        }
        blindness.canBlind = false;
        spawner.canSpawn = false;
        resultPanel.SetActive(true);
        isGameStarted = false;
    }
}
