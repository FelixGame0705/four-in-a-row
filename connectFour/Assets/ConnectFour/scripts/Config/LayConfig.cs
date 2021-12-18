using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "LayConfig", menuName = "GameConfiguration/LayConfig", order = 1)]
public class LayConfig : ScriptableObject
{
    
   [Header("Sprites of gameObjects")]
    public Sprite spr_Lay_Green;
    public Sprite spr_Lay_Orange;
    public Sprite spr_Lay_Yellow;
    public Sprite spr_Lay_Random_Single_Player;
    public Sprite spr_Lay_Random_Two_Player;
    public AudioClip audioColission;
    public AudioClip audioSend;
    


    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
