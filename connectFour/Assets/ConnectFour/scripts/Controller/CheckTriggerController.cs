using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTriggerController : MonoBehaviour
{

    // Start is called before the first frame update
    public int index;
    public int columnNumber;
    public int rowNumber;
    public bool isCheck;
    public int rowPos;
    public int columnPos;
    public LayConfig layConfig;
    
    
   
    
    public bool isTeam1=false;
    void Start()
    {
       
        columnNumber = GameBoard.Instance.column;
        rowNumber = GameBoard.Instance.row;
       
    }

    // Update is called once per frame
    void Update()
    {
        check();
        TurnOn();
        
        //  if (rowPos == rowNumber - 1) return;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        //if (rowPos  == rowNumber--) return;
        if (other != null)
            {
            
            gameObject.AddComponent<AudioSource>();
            
            gameObject.GetComponent<AudioSource>().PlayOneShot(layConfig.audioColission);
            gameObject.GetComponent<SpriteRenderer>().sprite = other.GetComponent<SpriteRenderer>().sprite;
            if(other.GetComponent<SpriteRenderer>().sprite == layConfig.spr_Lay_Green|| other.GetComponent<SpriteRenderer>().sprite == layConfig.spr_Lay_Yellow)
            {
                gameObject.layer = 6;
            }
            else
            {
                gameObject.layer = 7;
            }
            
            isCheck = true;
    

            // GameBoard.Instance.SaveChips();
            //GameBoard.Instance.SaveChip_(index, gameObject);
            if (gameObject.GetComponent<SpriteRenderer>().sprite != null)
            {
                if (GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.ONE_PLAY)
                {

                    GameBoard.Instance.SaveChip_(index, gameObject);
                }
                else
                {
                    GameBoard.Instance.SaveChip_Two(index, gameObject);
                }
            }
            
            
         
        }
        
    }
     
    
    void check()
    {
        if (rowPos == 0) gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
    private void TurnOn()
    {
        for (int j = 0; j < rowNumber-1; j++)
        {
            for (int i = 0; i < columnNumber; i++)
            {
                if (GameBoard.Instance.GetColumnRow(i, j).GetComponent<CheckTriggerController>().isCheck == true)
                {
                    GameBoard.Instance.GetColumnRow(i, j+1).GetComponent<BoxCollider2D>().enabled = true;                   
                }
            }
        }
    }
    public void TurnOnUpCell(int i, int j)
    {
        GameBoard.Instance.GetColumnRow(i, j + 1).GetComponent<BoxCollider2D>().enabled = true;
        
        
    }
   


}
