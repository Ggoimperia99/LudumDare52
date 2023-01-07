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
    bool cooldown = false;
    // cooldown timers
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
}
