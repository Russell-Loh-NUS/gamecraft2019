using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blindness : MonoBehaviour
{
    public GameObject directionalLight;
    public float blinkRate = 0.1f;

    private float startBlindnessTimer;
    private float blindnessTimer;
    private float blinkTimer;
    private bool isBlind = false;
    private bool shouldBlink = false;

    // Start is called before the first frame update
    void Start()
    {
        blinkTimer = blinkRate;
        RandomStartBlindnessTimer();
        RandomBlindnessTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if(startBlindnessTimer > 0.0f && startBlindnessTimer <= 1.0f && !isBlind) {
            if (blinkTimer <= 0.0f) {
                blinkTimer = Random.Range(blinkRate, blinkRate + 0.15f);
                directionalLight.SetActive(!directionalLight.activeSelf);
            }
        }
        else if (startBlindnessTimer <= 0.0f && !isBlind)
        {
            SetBlind(true);
            RandomBlindnessTimer();
        }

        if (blindnessTimer <= 0.0f && isBlind)
        {
            RandomStartBlindnessTimer();
            SetBlind(false);
        }

        UpdateTimers();
    }

    private void UpdateTimers()
    {
        startBlindnessTimer -= Time.deltaTime;
        blindnessTimer -= Time.deltaTime;
        blinkTimer -= Time.deltaTime;
    }

    private void RandomStartBlindnessTimer()
    {
        startBlindnessTimer = Random.Range(15.0f, 30.0f);
    }

    private void RandomBlindnessTimer()
    {
        blindnessTimer = Random.Range(3.0f, 7.0f);
    }

    private void SetBlind(bool isBlind) {
        directionalLight.SetActive(!isBlind);
        this.isBlind = isBlind;
    }
}
