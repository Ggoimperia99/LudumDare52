using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBlue : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] Sprite colourSprite;

    // Cache
    Animator houseBlueAnim;
    SpriteRenderer blueRenderer;

    // Start is called before the first frame update
    void Start()
    {
        houseBlueAnim = GetComponent<Animator>();
        blueRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TriggerGlowAnim()
    {
        houseBlueAnim.SetTrigger("GlowTrigger");
    }

    public void TriggerNormalAnim()
    {
        houseBlueAnim.SetTrigger("NormalTrigger");
    }

    public void TriggerColourChange()
    {
        houseBlueAnim.SetTrigger("ColourTrigger");
    }

    public void ChangeColourHouse()
    {
        blueRenderer.sprite = colourSprite;
        houseBlueAnim.SetTrigger("NormalTrigger");
    }
}
