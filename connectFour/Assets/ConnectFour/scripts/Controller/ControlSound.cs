using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSound : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Camera;
    private void Update()
    {
        TurnSound();
    }
    void TurnSound()
    {

        if (GameSetup.Instance.GetSound() == 1)
        {
            Camera.GetComponent<AudioListener>().enabled = true;
        }
        else
        {
            Camera.GetComponent<AudioListener>().enabled = false;
        }




    }
}
