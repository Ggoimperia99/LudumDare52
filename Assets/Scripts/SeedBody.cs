using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBody : MonoBehaviour
{
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

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(transform.parent.gameObject);
            player.AddSeed();
        }
    }
}
