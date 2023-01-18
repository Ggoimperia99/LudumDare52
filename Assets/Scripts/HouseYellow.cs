using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseYellow : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] Sprite colourSprite;

    // Cache
    Animator houseYellowAnim;
    SpriteRenderer yellowRenderer;

    // Start is called before the first frame update
    void Start()
    {
        houseYellowAnim = GetComponent<Animator>();
        yellowRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TriggerGlowAnim()
    {
        houseYellowAnim.SetTrigger("GlowTrigger");
    }

    public void TriggerNormalAnim()
    {
        houseYellowAnim.SetTrigger("NormalTrigger");
    }

    public void TriggerColourChange()
    {
        houseYellowAnim.SetTrigger("ColourTrigger");
    }

    public void ChangeColourHouse()
    {
        yellowRenderer.sprite = colourSprite;
        houseYellowAnim.SetTrigger("NormalTrigger");
    }
}
