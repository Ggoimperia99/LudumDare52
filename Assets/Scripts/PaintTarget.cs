using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintTarget : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] int colourIndex = 1;

    // Cache
    private BoxCollider2D myCollider;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
    }

    // This passes the colour index value required to the player
    public int ShowColour()
    {
        return colourIndex;
    }

    // The house changes colour in this method, deactivates collider to prevent double painting
    public void ChangeColour()
    {
        Debug.Log("House changes colour");
        myCollider.enabled = !myCollider.enabled;
    }

    // This thing can glow up under interaction to show the correct colour
    public void Glow()
    {
        Debug.Log("You need colour 1");
    }
}
