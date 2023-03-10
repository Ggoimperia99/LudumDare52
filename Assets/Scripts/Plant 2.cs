using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] bool canGrow = true;
    [SerializeField] int growthStage = 1;
    [SerializeField] int growthLimit = 3;
    [SerializeField] int waterCount = 0;
    [SerializeField] int waterLimit = 3;

    // Colour reference, 1 = green, 2 = purple, 3 = blue
    [SerializeField] int plantType = 1;

    // Cache
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the plant reaches its final stage
        if(growthStage == growthLimit) 
        {
            canGrow = false;
        }
    }

    // Receiving water for the plant
    public void ReceiveWater()
    {
        // Check if the plant has been watered enough
        if (waterCount < waterLimit)
        {
            waterCount++;
        }

        // if Yes then grow to next stage
        if (waterCount >= waterLimit)
        {
            if (canGrow)
            {
                // So far increase in size (replace with sprite change?)
                transform.localScale += new Vector3(0.3f, 0.3f, 0);
                waterCount = 0;
                growthStage++;
            }

            // if can no longer grow then just harvest
            else if (!canGrow)
            {
                player.HarvestPlant(plantType);
                Destroy(gameObject);
            }
        }
    }

    // Tells the plant type
    public int ShowPlantType()
    {
        return plantType;
    }
}
