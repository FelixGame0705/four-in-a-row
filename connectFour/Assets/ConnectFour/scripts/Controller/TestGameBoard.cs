using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameBoard : MonoBehaviour
{
    [SerializeField] public GameObject cell_Prefab;
    public GameObject parent;
    public int rowNumber;
    public int columnNumber;
    Vector3 spawnPos;
    public Vector3 firstPos;
    public GameObject[,] board;
    
    public LayConfig lay;
    public bool isInto = false;
    public int columnPos;
    public int rowPos;
   
    private void Start()
    {
        board = new GameObject[columnNumber, rowNumber];
        GameBoard.Instance.SetColumn(columnNumber);
        GameBoard.Instance.SetRow(rowNumber);




        SpawnMap();
        
        
       
        // TurnOn();
    }
    private void Update()
    {
      //  AISoulution();
    }
    void SpawnMap()
    {
        for (int i = 0; i < columnNumber; i++)
        {
            for (int j = 0; j < rowNumber; j++)
            {
                spawnPos = new Vector3(firstPos.x + i , firstPos.y + j , 0);
                GameObject gameObject = Instantiate(cell_Prefab, spawnPos, Quaternion.identity, parent.transform) as GameObject;              
                
                gameObject.GetComponent<CheckTriggerController>().columnPos = i;
                gameObject.GetComponent<CheckTriggerController>().rowPos = j;

                gameObject.GetComponent<CheckTriggerController>().index = j + i * rowNumber ;

                if (GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.ONE_PLAY)
                {
                    UpdatePlayerPref(ref gameObject, i, j, gameObject.GetComponent<CheckTriggerController>().index);
                }
                else
                {
                    UpdatePlayerPrefTwoPlayer(ref gameObject, i, j, gameObject.GetComponent<CheckTriggerController>().index);
                }
                board[i, j] = gameObject;
               
            }
        }
        
        
       GameBoard.Instance.SetColumnRow(board);
        //AISoulution();
        
    }
    
    private void UpdatePlayerPref(ref GameObject gameObject,int i, int j, int k)
    {
              
            if (PlayerPrefs.GetInt(GameBoard.ColumnNumPos + k) == i && PlayerPrefs.GetInt(GameBoard.RowNumPos + k) == j)
            {
            
                if (PlayerPrefs.GetInt(GameBoard.RMS_CHIP_STATUS + k) == 1)
                {
                gameObject.GetComponent<CheckTriggerController>().isCheck = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = lay.spr_Lay_Green;
                gameObject.layer = 6;

               
                }
                else if (PlayerPrefs.GetInt(GameBoard.RMS_CHIP_STATUS + k) == 2)
                {
                gameObject.GetComponent<CheckTriggerController>().isCheck = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = lay.spr_Lay_Orange;
                gameObject.layer = 7;
                }

            }

    }
    private void UpdatePlayerPrefTwoPlayer(ref GameObject gameObject, int i, int j, int k)
    {

        if (PlayerPrefs.GetInt(GameBoard.ColumnNumPos2 + k) == i && PlayerPrefs.GetInt(GameBoard.RowNumPos2 + k) == j)
        {

            if (PlayerPrefs.GetInt(GameBoard.RMS_CHIP_STATUS_TWO + k) == 2)
            {
                gameObject.GetComponent<CheckTriggerController>().isCheck = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = lay.spr_Lay_Orange;
                gameObject.layer = 7;
            }
            else if (PlayerPrefs.GetInt(GameBoard.RMS_CHIP_STATUS_TWO + k) == 3)
            {
                gameObject.GetComponent<CheckTriggerController>().isCheck = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = lay.spr_Lay_Yellow;
                gameObject.layer = 6;
            }

        }

    }
    
   





}