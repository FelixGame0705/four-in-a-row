using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWin : MonoBehaviour
{
    // Start is called before the first frame update
   
    //public GameObject parent;
    
    public LayConfig lay;
    public LayerMask layer;
    public LayerMask layer2;
    public int NumberWin;
    public GameObject PopWin;
    public GameObject PopLose;
    public GameObject PopDraw;
    public GameObject CreateChip;
    
    

    private void Start()
    {
        GameBoard.Instance.SetContinue(true);
    }
    public void Update()
    {
        WinShow();
    }

    public void WinShow()
    {
        
        if (GameBoard.Instance.getContinue() == false) return;
        
        if (GameBoard.Instance.GetGameStatus() == GameBoard.GAME_STATUS.WIN)
        {
            PopWin.SetActive(true);
            
            return;
           
        }
        else if(GameBoard.Instance.GetGameStatus() == GameBoard.GAME_STATUS.LOSE)
        {
            PopLose.SetActive(true);
            
            return;
        }
        else if(GameBoard.Instance.GetGameStatus() == GameBoard.GAME_STATUS.DRAW)
        {
            PopDraw.SetActive(true);
            
            return;
        }
        TheCheckWin();
        
    }
    
    public void TheCheckWin()
    {
        
        for (int i = 0; i < GameBoard.Instance.column; i++)
        {
            for (int j = 0; j < GameBoard.Instance.row; j++)
            {
                if (j <= GameBoard.Instance.row-4)
                {
                    if (GameBoard.Instance.GetColumnRow(i, j).layer == 6 && GameBoard.Instance.GetColumnRow(i, j + 1).layer == 6 && GameBoard.Instance.GetColumnRow(i, j + 2).layer == 6 && GameBoard.Instance.GetColumnRow(i, j + 3).layer == 6)
                    {
                        SetTeamWin();
                        break;
                       
                    }
                    else if (GameBoard.Instance.GetColumnRow(i, j).layer == 7 && GameBoard.Instance.GetColumnRow(i, j + 1).layer == 7 && GameBoard.Instance.GetColumnRow(i, j + 2).layer == 7 && GameBoard.Instance.GetColumnRow(i, j + 3).layer == 7)
                    {

                        SetTeamLose();
                        break;


                    }
                }
                if (i <= GameBoard.Instance.column - 4) 
                {
                    if (GameBoard.Instance.GetColumnRow(i, j).layer == 6 && GameBoard.Instance.GetColumnRow(i + 1, j).layer == 6 && GameBoard.Instance.GetColumnRow(i + 2, j).layer == 6 && GameBoard.Instance.GetColumnRow(i + 3, j).layer == 6)
                    {
                        SetTeamWin();
                        break;
                        
                    }
                    else if (GameBoard.Instance.GetColumnRow(i, j).layer == 7 && GameBoard.Instance.GetColumnRow(i + 1, j).layer == 7 && GameBoard.Instance.GetColumnRow(i + 2, j).layer == 7 && GameBoard.Instance.GetColumnRow(i + 3, j).layer == 7)
                    {
                        SetTeamLose();
                        break;

                    }
                }
                if (i >= GameBoard.Instance.column-4 && j <= GameBoard.Instance.row - 4) 
                {
                    if (GameBoard.Instance.GetColumnRow(i, j).layer == 6 && GameBoard.Instance.GetColumnRow(i - 1, j + 1).layer == 6 && GameBoard.Instance.GetColumnRow(i - 2, j + 2).layer == 6 && GameBoard.Instance.GetColumnRow(i - 3, j + 3).layer == 6)
                    {
                        SetTeamWin();
                        break;
                        
                    }
                    else if (GameBoard.Instance.GetColumnRow(i, j).layer == 7 && GameBoard.Instance.GetColumnRow(i - 1, j + 1).layer == 7 && GameBoard.Instance.GetColumnRow(i - 2, j + 2).layer == 7 && GameBoard.Instance.GetColumnRow(i - 3, j + 3).layer == 7)
                    {
                        SetTeamLose();
                        break;

                    }
                }
                if(i<= GameBoard.Instance.column - 4 && j<= GameBoard.Instance.row - 4)
                {
                    if (GameBoard.Instance.GetColumnRow(i, j).layer == 6 && GameBoard.Instance.GetColumnRow(i + 1, j + 1).layer == 6 && GameBoard.Instance.GetColumnRow(i + 2, j + 2).layer == 6 && GameBoard.Instance.GetColumnRow(i + 3, j + 3).layer == 6)
                    {
                        SetTeamWin();
                        break;
                    }
                    else if (GameBoard.Instance.GetColumnRow(i, j).layer == 7 && GameBoard.Instance.GetColumnRow(i + 1, j + 1).layer == 7 && GameBoard.Instance.GetColumnRow(i + 2, j + 2).layer == 7 && GameBoard.Instance.GetColumnRow(i + 3, j + 3).layer == 7)
                    {
                        SetTeamLose();
                        break;
                    }
                }
                if (GameBoard.Instance.GetColumnRow(0,5 ).GetComponent<SpriteRenderer>().sprite != null
                    && GameBoard.Instance.GetColumnRow(1, 5).GetComponent<SpriteRenderer>().sprite != null
                    && GameBoard.Instance.GetColumnRow(2, 5).GetComponent<SpriteRenderer>().sprite != null
                    && GameBoard.Instance.GetColumnRow(3, 5).GetComponent<SpriteRenderer>().sprite != null
                    && GameBoard.Instance.GetColumnRow(4, 5).GetComponent<SpriteRenderer>().sprite != null
                    && GameBoard.Instance.GetColumnRow(5, 5).GetComponent<SpriteRenderer>().sprite != null
                    && GameBoard.Instance.GetColumnRow(6, 5).GetComponent<SpriteRenderer>().sprite != null
                    )
                {
                    GameBoard.Instance.SetGameStatus(GameBoard.GAME_STATUS.DRAW);
                    GameSetup.Instance.SetNumberDraw(GameSetup.Instance.GetNumberDraw() + 1);
                }


            }
        }
        
        
        
        }
    
    void SetTeamWin()
    {
        
        if (GameSetup.Instance.GetCurrentColorSelected() == GameSetup.COLOR_SELECT.GREEN  || GameSetup.Instance.GetCurrentColorSelectedTwoPlayer() == GameSetup.COLOR_SELECT.YELLOW)
        {
            
            GameBoard.Instance.SetGameStatus(GameBoard.GAME_STATUS.WIN);
            if (GameSetup.Instance.GetCurrentColorSelected() == GameSetup.COLOR_SELECT.GREEN)
            GameSetup.Instance.SetNumberWin(GameSetup.Instance.GetNumberWin() + 1);
            
        }
        else if (GameSetup.Instance.GetCurrentColorSelected() == GameSetup.COLOR_SELECT.ORANGE || GameSetup.Instance.GetCurrentColorSelectedTwoPlayer() == GameSetup.COLOR_SELECT.ORANGE)
        {
        
            GameBoard.Instance.SetGameStatus(GameBoard.GAME_STATUS.LOSE);
            if (GameSetup.Instance.GetCurrentColorSelected() == GameSetup.COLOR_SELECT.ORANGE)
            GameSetup.Instance.SetNumberLose(GameSetup.Instance.GetNumberLose() + 1);
            
        }

        SetCreateChip();

       
    }
    void SetTeamLose()
    {
        
        if (GameSetup.Instance.GetCurrentColorSelected() == GameSetup.COLOR_SELECT.ORANGE || GameSetup.Instance.GetCurrentColorSelectedTwoPlayer() == GameSetup.COLOR_SELECT.YELLOW)
        {
            GameBoard.Instance.SetGameStatus(GameBoard.GAME_STATUS.WIN);
            if(GameSetup.Instance.GetCurrentColorSelected() == GameSetup.COLOR_SELECT.ORANGE)
            GameSetup.Instance.SetNumberWin(GameSetup.Instance.GetNumberWin() + 1);
            
        }
        else if (GameSetup.Instance.GetCurrentColorSelected() == GameSetup.COLOR_SELECT.GREEN || GameSetup.Instance.GetCurrentColorSelectedTwoPlayer() == GameSetup.COLOR_SELECT.ORANGE)
        {
            GameBoard.Instance.SetGameStatus(GameBoard.GAME_STATUS.LOSE);
            if (GameSetup.Instance.GetCurrentColorSelected() == GameSetup.COLOR_SELECT.GREEN)
            GameSetup.Instance.SetNumberLose(GameSetup.Instance.GetNumberLose() + 1);
            

        }
        
        SetCreateChip();
        
    }
    void SetCreateChip()
    {
        CreateChip.SetActive(false);
    }
    

}
