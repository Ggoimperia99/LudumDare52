using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestBox : MonoBehaviour
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
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -8);
    }

    // Destroy oneself
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}