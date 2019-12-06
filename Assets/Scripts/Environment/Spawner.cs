using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject rat;
    public GameObject ratSpawn;
    public float ratsSpawnRate = 15.0f;

    private float ratsSpawnTimer = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        ratsSpawnTimer = ratsSpawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(ratsSpawnTimer <= 0.0f) {
            Instantiate(rat, ratSpawn.transform.position, Quaternion.identity)
            .transform.SetParent(ratSpawn.transform);

            ratsSpawnTimer = ratsSpawnRate;
        }

        UpdateTimers();
    }

    private void UpdateTimers() {
        ratsSpawnTimer -= Time.deltaTime;
    }
}
