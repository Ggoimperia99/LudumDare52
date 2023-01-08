using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    // plot colour name
    [SerializeField] string plotType;

    // count of times waterd
    [SerializeField] int timesWatered;

    // switch for need to water
    [SerializeField] public bool needToWater = true;

    // check if having plants in plot
    [SerializeField] bool hasPlant = false;

    // different colours of plants stored here
    [SerializeField] GameObject[] differentPlants;

    // cooldown timers
    bool cooldown = false;
    float maxTime = 5;
    float time;

    void Update()
    {
        //if wtered it executes this
        if (needToWater == false && cooldown == false)
        {
            timesWatered++;
            cooldown = true;
        }

        // cooldwon and reset
        if (cooldown)
        {
            if (time < maxTime)
            {
                time += Time.deltaTime;
            }
            if (time > maxTime)
            {
                cooldown = false;
                needToWater = true;
                time = 0;
            }
        }
    }

    // Instantiate plant as child of plot
    public void spawnPlant()
    {
        Instantiate(differentPlants[Random.Range(0, differentPlants.Length)],
            new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity, transform);
        hasPlant = true;
    }

    // this is called in player script, accesses the watering method in plant
    public void TransferWaterToPlant()
    {
        if (hasPlant)
        {
            GetComponentInChildren<Plant>().ReceiveWater();
        }
    }
}
