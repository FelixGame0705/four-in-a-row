using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipIntoBoardCollider : MonoBehaviour
{
    public int row;
    public LayConfig lay;
    float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 5f;
        gameObject.AddComponent<AudioSource>().PlayOneShot(lay.audioSend);
        Invoke("DestroySelf", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer<0) Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other != null)
        {

            DestroySelf();
        }
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
