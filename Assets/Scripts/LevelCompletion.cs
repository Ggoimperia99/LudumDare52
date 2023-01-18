using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletion : MonoBehaviour
{
    // Level of Completion
    private int thingsColoured = 0;

    // Update is called once per frame
    void Update()
    {
        if(thingsColoured == 3)
        {
            SceneManager.LoadScene(1);
        }
    }

    // Add a completion point
    public void AddCompletedColour()
    {
        thingsColoured += 1;
    }
}
