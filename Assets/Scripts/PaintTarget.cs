using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintTarget : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] int colourIndex = 1;

    // type 1 is house, type 2 is gravestone for referencing scripts
    [SerializeField] int itemIndex = 1;

    // Cache
    private BoxCollider2D myCollider;
    LevelCompletion levelCompletion;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        levelCompletion = FindObjectOfType<LevelCompletion>();
    }

    // This passes the colour index value required to the player
    public int ShowColour()
    {
        return colourIndex;
    }

    // The house changes colour in this method, deactivates collider to prevent double painting
    public void ChangeColour()
    {
        myCollider.enabled = !myCollider.enabled;
        levelCompletion.AddCompletedColour();

        // if red house
        if (colourIndex == 1 && itemIndex == 1)
        {
            FindObjectOfType<HouseRed>().TriggerColourChange();
        }

        // if yellow house
        if (colourIndex == 2 && itemIndex == 1)
        {
            FindObjectOfType<HouseYellow>().TriggerColourChange();
        }

        // if blue house
        if (colourIndex == 3 && itemIndex == 1)
        {
            FindObjectOfType<HouseBlue>().TriggerColourChange();
        }
    }

    // This thing can glow up under interaction to show the correct colour
    public void Glow()
    {
        // if red house
        if(colourIndex == 1 && itemIndex == 1)
        {
            FindObjectOfType<HouseRed>().TriggerGlowAnim();
        }

        // if yellow house
        if (colourIndex == 2 && itemIndex == 1)
        {
            FindObjectOfType<HouseYellow>().TriggerGlowAnim();
        }

        // if blue house
        if (colourIndex == 3 && itemIndex == 1)
        {
            FindObjectOfType<HouseBlue>().TriggerGlowAnim();
        }
    }
}
