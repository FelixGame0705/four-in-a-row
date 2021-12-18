using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMenuSound : MonoBehaviour
{
    
    public AudioClip soundButton;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        gameObject.GetComponent<Button>().onClick.AddListener(OnPlaySound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnPlaySound()
    {
        
        gameObject.GetComponent<AudioSource>().PlayOneShot(soundButton);
    }
}
