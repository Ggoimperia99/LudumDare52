using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseRed : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] Sprite colourSprite;

    // Cache
    Animator houseRedAnim;
    SpriteRenderer redRenderer;

    // Start is called before the first frame update
    void Start()
    {
        houseRedAnim = GetComponent<Animator>();
        redRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TriggerGlowAnim()
    {
        houseRedAnim.SetTrigger("GlowTrigger");
    }

    public void TriggerNormalAnim()
    {
        houseRedAnim.SetTrigger("NormalTrigger");
    }

    public void TriggerColourChange()
    {
        houseRedAnim.SetTrigger("ColourTrigger");
    }

    public void ChangeColourHouse()
    {
        redRenderer.sprite = colourSprite;
        houseRedAnim.SetTrigger("NormalTrigger");
    }
}
