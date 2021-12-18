using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard 
{
    GameObject[,] cell;
    public int[,] AIData;
    public int row;
    public int column;

    public int depthAI;
    public List<GameObject> listChip;
    public GameObject[] ChipArrays;

    public bool _PlayFistSwapOnePlayer = true;
    public const string ColumnNumPos = "ColumnNumPos";

    public const string FirstPlayer = "FPKey";
    public const string RowNumPos = "RowNumPos";
    public const string RMS_CHIP_STATUS = "ChipStatus";
    public const string RMS_CHIP_STATUS_TWO = "ChipStatus2";
    public const string ColumnNumPos2 = "ColumnNumPos2";

    public bool Countinue = true;
    public const string RowNumPos2 = "RowNumPos2";

    public const string RMS_STATUS_GAME = "StatusGame";
    // Start is called before the first frame update
    private GameBoard() { }
    private static GameBoard instance;
    public enum GAME_STATUS
    {
        WIN, DRAW, LOSE, NORMAL
    }
    
    public static GameBoard Instance
    {
        get{ 
        if (instance == null)
            {
                instance = new GameBoard();
                GameBoard.Instance.Init();
            }
            return instance;
        }
    }
   
    
    private void Init()
    {
        cell = new GameObject[column, row];
        Countinue = new bool();
        listChip = new List<GameObject>();
        ChipArrays = new GameObject[42];        
        AIData = new int[,] {{0,0,0,0,0,0 },
        {0,0,0,0,0,0 },
        {0,0,0,0,0,0 },
        {0,0,0,0,0,0 },
        {0,0,0,0,0,0 },
        {0,0,0,0,0,0 },
        {0,0,0,0,0,0}};
        SetGameStatus(GAME_STATUS.NORMAL);
       
    }
    public void SetColumnRow(GameObject [,]_cell)
    {
        cell=_cell;
    }
    public GameObject GetColumnRow(int i, int j)
    {
        if (i < 0 || i >= GameBoard.Instance.column || j < 0 || j >= GameBoard.Instance.row) return null;
        
        return cell[i, j];
    }
    public GameObject[,] GetBoard()
    {
        return cell;
    }
    public void SetColumn(int column)
    {
        this.column = column;
    }
    public void SetRow(int row)
    {
        this.row = row;
    }
  
   
    public void AddChip(GameObject gameObject)
    {
        listChip.Add(gameObject);
    }
   public IEnumerable<GameObject> GetChips()
    {
        
        foreach(GameObject item in listChip)
        {
            yield return item;
        }
    }
    
        public void SaveChip_(int i, GameObject gameObject)
        {
        ChipArrays[i] = gameObject;
        //PlayerPrefs.SetInt(NumPos, i);
        PlayerPrefs.SetInt(RowNumPos + i, gameObject.GetComponent<CheckTriggerController>().rowPos);
        PlayerPrefs.SetInt(ColumnNumPos + i, gameObject.GetComponent<CheckTriggerController>().columnPos);
        
            if (gameObject.GetComponent<SpriteRenderer>().sprite == gameObject.GetComponent<CheckTriggerController>().layConfig.spr_Lay_Green)
            {
                PlayerPrefs.SetInt(RMS_CHIP_STATUS + i, 1);
            }
            else if (gameObject.GetComponent<SpriteRenderer>().sprite == gameObject.GetComponent<CheckTriggerController>().layConfig.spr_Lay_Orange)
            {
                PlayerPrefs.SetInt(RMS_CHIP_STATUS + i, 2);
            }
            else if(gameObject.GetComponent<SpriteRenderer>().sprite == gameObject.GetComponent<CheckTriggerController>().layConfig.spr_Lay_Yellow)
            {
                PlayerPrefs.SetInt(RMS_CHIP_STATUS + i, 3);
            }
        
        }
    public void SaveChip_Two(int i, GameObject gameObject)
    {
        ChipArrays[i] = gameObject;
        //PlayerPrefs.SetInt(NumPos, i);
        PlayerPrefs.SetInt(RowNumPos2 + i, gameObject.GetComponent<CheckTriggerController>().rowPos);
        PlayerPrefs.SetInt(ColumnNumPos2 + i, gameObject.GetComponent<CheckTriggerController>().columnPos);

        if (gameObject.GetComponent<SpriteRenderer>().sprite == gameObject.GetComponent<CheckTriggerController>().layConfig.spr_Lay_Green)
        {
            PlayerPrefs.SetInt(RMS_CHIP_STATUS_TWO + i, 1);
        }
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == gameObject.GetComponent<CheckTriggerController>().layConfig.spr_Lay_Orange)
        {
            PlayerPrefs.SetInt(RMS_CHIP_STATUS_TWO + i, 2);
        }
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == gameObject.GetComponent<CheckTriggerController>().layConfig.spr_Lay_Yellow)
        {
            PlayerPrefs.SetInt(RMS_CHIP_STATUS_TWO + i, 3);
        }

    }

    public void  AddArrays(GameObject gameObject, int i)
    {
        ChipArrays[i] = gameObject;
    }
    #region TeamWin
    GAME_STATUS _status = GAME_STATUS.WIN;
    public GAME_STATUS GetGameStatus()
    {
        return _status;
    }
    public void SetGameStatus(GAME_STATUS status)
    {
        _status = status;
        PlayerPrefs.SetInt(RMS_STATUS_GAME, _status==GAME_STATUS.WIN?10:_status == GAME_STATUS.DRAW?0:-10);
    }

    #endregion
    
    public void SetContinue(bool Continue)
    {
        this.Countinue = Continue;
    }
    public bool getContinue()
    {
        return this.Countinue;
    }
   
    
    public void SetDefaultData()
    {
        AIData = new int[,] {{0,0,0,0,0,0 },
        {0,0,0,0,0,0 },
        {0,0,0,0,0,0 },
        {0,0,0,0,0,0 },
        {0,0,0,0,0,0 },
        {0,0,0,0,0,0 },
        {0,0,0,0,0,0}};
    }

    public void SetPlayFirstSwapOnePlayer(bool PlayFistSwapOnePlayer)
    {
        _PlayFistSwapOnePlayer = PlayFistSwapOnePlayer;
        PlayerPrefs.SetInt(FirstPlayer, _PlayFistSwapOnePlayer == false ?0:1) ;

    }
    public bool GetPlayFirstSwapOnePlayer()
    {
        if (PlayerPrefs.GetInt(FirstPlayer) == 0)
        {
            _PlayFistSwapOnePlayer = false;
        }
        else
        {
            _PlayFistSwapOnePlayer= true;
        }
        return _PlayFistSwapOnePlayer;
    }



}
