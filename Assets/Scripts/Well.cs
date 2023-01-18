using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : MonoBehaviour
{
    // Cache
    Animator wellAnim;

    // Start is called before the first frame update
    void Start()
    {
        wellAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseWell()
    {
        wellAnim.SetTrigger("WaterWell");
    }

    public void UnUseWell()
    {
        wellAnim.SetTrigger("NormalWell");
    }
}
