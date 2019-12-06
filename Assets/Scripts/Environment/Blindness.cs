using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blindness : MonoBehaviour
{
    public GameObject directionalLight;
    public float blinkRate = 0.1f;
    public float maxFrequency = 30.0f;
    public float minFrequency = 10.0f;

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
        if (startBlindnessTimer > 0.0f && startBlindnessTimer <= 1.0f && !isBlind) {
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

    public void SetBlindnessFrequency(float minFrequency, float maxFrequency) {
        this.minFrequency = minFrequency;
        this.maxFrequency = maxFrequency;
    }

    public float GetMinBlindnessFrequency() {
        return this.minFrequency;
    }

    public float GetMaxBlindnessFrequency()
    {
        return this.maxFrequency;
    }

    private void UpdateTimers()
    {
        startBlindnessTimer -= Time.deltaTime;
        blindnessTimer -= Time.deltaTime;
        blinkTimer -= Time.deltaTime;
    }

    private void RandomStartBlindnessTimer()
    {
        startBlindnessTimer = Random.Range(minFrequency, maxFrequency);
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
