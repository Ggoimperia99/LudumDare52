using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedNumber : MonoBehaviour
{
    [SerializeField] Player player;

    // Cache
    Text seedAmount;

    // Start is called before the first frame update
    void Start()
    {
        seedAmount = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //seedAmount.text = "Seeds: " + player.GetSeedAmount().ToString();
    }
}
