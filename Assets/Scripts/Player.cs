using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] float playerMoveSpeed = 10;
    [SerializeField] int waterLevel = 3;

    // used to check if players are interacting with things
    [SerializeField] bool canPlot = false;
    [SerializeField] bool canWell = false;
    [SerializeField] bool canPaint = false;

    // used to measure how many seeds player posseses
    [SerializeField] int seedCount = 1;
    [SerializeField] GameObject seed;

    // Type of colour player is holding now, if it is holding
    [SerializeField] int colourType = 0;
    [SerializeField] bool isHoldingColour = false;

    // Type of colour players will instantiate
    [SerializeField] GameObject plantRed;
    [SerializeField] GameObject plantYellow;
    [SerializeField] GameObject plantBlue;

    // Cache
    Plot plot;
    PaintTarget colourTarget;
    Animator myAnimator;
    HarvestBox harvestBox;
    Well well;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        well = FindObjectOfType<Well>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlantSeed();
        UseColour();
        PlayerRotation();

        //Water the plots or wells
        if (Input.GetKeyDown(KeyCode.E))
        {
            // If player is touching the plot
            if (canPlot && !isHoldingColour)
            {
                if (waterLevel != 0)
                {
                    if (plot.needToWater)
                    {
                        myAnimator.SetTrigger("WaterTrigger");
                    }
                }
            }

            // If player is touching the well
            if (canWell && !isHoldingColour) 
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    well.UseWell();
                    waterLevel = 3;
                }
            }
        }
    }

    // Waters the plant, call in watering animation
    public void WaterPlant()
    {
        plot.TransferWaterToPlant();
        waterLevel--;
        plot.needToWater = false;

        // Gets back to idle animation
        myAnimator.SetTrigger("StandTrigger");
    }

    // The player's movement code using horizontal and vertical axis
    private void PlayerMove()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * playerMoveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * playerMoveSpeed;

        var newXPos = transform.position.x + deltaX;
        var newYPos = transform.position.y + deltaY;
        transform.position = new Vector2(newXPos, newYPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks if this trigger is Plot
        if (collision.tag == "Plot")
        {
            canPlot = true;
            plot = collision.GetComponent<Plot>(); // Indicate the plot is the one colliding with
        }

        //checks if this trigger is Well
        if (collision.tag == "Well")
        {
            canWell = true;
        }

        //checks if this trigger is Colour Target
        if (collision.tag == "ColourTarget")
        {
            colourTarget = collision.GetComponent<PaintTarget>(); // Indicate the target is the one colliding with
            canPaint = true;
        }
    }

    // Rotates the player sprite when turning
    private void PlayerRotation()
    {
        if(Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-0.65f, transform.localScale.y);
        }

        if(Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        //player can no longer interact
        canPlot = false;
        canWell = false;
        canPaint = false;
    }

    private void PlantSeed()
    {
        // if player is in interacting range with plot
        if (canPlot && !isHoldingColour)
        {
            if (Input.GetKeyUp(KeyCode.P))
            {
                // asks the plot to spawnt the plant
                if(seedCount > 0)
                {
                    myAnimator.SetTrigger("SeedTrigger");
                }
            }
        }
    }

    // Sets off the planting to be triggered in animation
    public void PlantSeedExecute()
    {
        seedCount -= 1;
        plot.spawnPlant();
    }

    // Player to get the colour value from the plant object when harvesting, called in plant script
    public void HarvestPlant(int plantColourType)
    {
        // If it is red colour
        if(plantColourType == 1)
        {
            colourType = 1;
            isHoldingColour = true;
            Instantiate(plantRed, new Vector3(transform.position.x, transform.position.y, -9f), Quaternion.identity);
        }
        if(plantColourType == 2)
        {
            colourType = 2;
            isHoldingColour = true;
            Instantiate(plantYellow, new Vector3(transform.position.x, transform.position.y, -9f), Quaternion.identity);
        }
        if(plantColourType == 3)
        {
            colourType = 3;
            isHoldingColour = true;
            Instantiate(plantBlue, new Vector3(transform.position.x, transform.position.y, -9f), Quaternion.identity);
        }
    }

    // Player uses the colour
    private void UseColour()
    {
        if (isHoldingColour && canPaint)
        {
            if (Input.GetKeyUp(KeyCode.P))
            {
                // If colour player is holding is the same as the house required, completes colour change
                if (colourType == colourTarget.ShowColour())
                {
                    colourTarget.ChangeColour();
                    isHoldingColour = false;
                    harvestBox = FindObjectOfType<HarvestBox>();
                    harvestBox.DestroySelf();
                }

                // If colour player has is not the same
                if(colourType != colourTarget.ShowColour())
                {
                    colourTarget.Glow();
                }
            }
        }
    }

    // Add seed to Player
    public void AddSeed()
    {
        seedCount += 1;
    }

    // Spawn a seed object to be collected
    public void SpawnSeed()
    {
        var currentPos = new Vector3(transform.position.x + 1, transform.position.y -1, -9f);
        Instantiate(seed, currentPos, transform.rotation);
    }

    // Show seed count
    public int GetSeedAmount()
    {
        return seedCount;
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        //checks for plot and applies water
        if (collision.tag == "Plot")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (waterLevel != 0)
                {
                    if (collision.GetComponent<Plot>().needToWater)
                    {
                        waterLevel--;
                        collision.GetComponent<Plot>().needToWater = false;
                    }
                }
            }
        }

        // checks for well and refills
        if (collision.tag == "Well")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                waterLevel = 3;
            }   
        }
    }*/
}
