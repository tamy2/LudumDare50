using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public WomanController womanController;
    public ManagerController managerController;

    public float timeFrequencyMultiplierSpeed;

    private float phoneSpawnTime;
    private float coffeeSpawnTime;

    public float phoneBaseSpawnFrequency;
    public float phoneMinSpawnFrequency;
    private float phoneTimeToNextSpawn;
    
    public float coffeeBaseSpawnFrequency;
    public float coffeeMinSpawnFrequency;
    private float coffeeTimeToNextSpawn;

    // Update is called once per frame
    void Update()
    {
        if (!SequencingManager.isGameRunning) {
            return;
        }

        phoneTimeToNextSpawn -= Time.deltaTime;

        if (phoneTimeToNextSpawn <= 0) {
            phoneTimeToNextSpawn = phoneBaseSpawnFrequency - (Time.time * timeFrequencyMultiplierSpeed);
            phoneTimeToNextSpawn = Mathf.Max(phoneTimeToNextSpawn, phoneMinSpawnFrequency);
            //print(phoneTimeToNextSpawn);
            womanController.GetUp();
        }

        coffeeTimeToNextSpawn -= Time.deltaTime;

        if (coffeeTimeToNextSpawn <= 0) {
            coffeeTimeToNextSpawn = coffeeBaseSpawnFrequency - (Time.time * timeFrequencyMultiplierSpeed);
            coffeeTimeToNextSpawn = Mathf.Max(coffeeTimeToNextSpawn, coffeeMinSpawnFrequency);
            //print(coffeeTimeToNextSpawn);
            //managerController.walk();
        }
    }
}
