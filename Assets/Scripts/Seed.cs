using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Seed : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] float seedSpeed = 10;

    // Cache
    Player player;
    Rigidbody2D seedRgdbdy;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        seedRgdbdy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        var positionTarget = player.transform.position;

        transform.position = Vector3.Lerp(transform.position, positionTarget, seedSpeed * Time.deltaTime);
    }
}
