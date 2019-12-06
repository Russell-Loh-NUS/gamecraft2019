using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blindness : MonoBehaviour
{
    public GameObject directionalLight;

    private float startBlindnessTimer;
    private float blindnessTimer;
    private bool isBlind = false;

    // Start is called before the first frame update
    void Start()
    {
        RandomStartBlindnessTimer();
        RandomBlindnessTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (startBlindnessTimer <= 0.0f && !isBlind)
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
    }

    private void RandomStartBlindnessTimer()
    {
        startBlindnessTimer = Random.Range(15.0f, 22.0f);
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
