using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] float playerMoveSpeed = 10;

    int waterLevel = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
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

    private void OnTriggerStay2D(Collider2D collision)
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

    }






}
