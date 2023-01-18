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
    [SerializeField] Sprite[] plantStages;

    // Colour reference, 1 = red, 2 = yellow, 3 = blue
    [SerializeField] int plantType = 1;

    // Plant growth stage sprite index
    private int plantStageIndex = 0;

    // Cache
    Player player;
    SpriteRenderer sprtRndr;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        sprtRndr = GetComponent<SpriteRenderer>();

        // Set growth stage sprite
        sprtRndr.sprite = plantStages[plantStageIndex];
    }

    // Update is called once per frame
    void Update()
    {
        // if the plant reaches its final stage
        if(growthStage == growthLimit) 
        {
            canGrow = false;
        }

        // Set growth stage sprite
        sprtRndr.sprite = plantStages[plantStageIndex];
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
                waterCount = 0;
                plantStageIndex++;
                growthStage++;
            }

            // if can no longer grow then just harvest
            else if (!canGrow)
            {
                player.HarvestPlant(plantType);
                player.SpawnSeed();
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
