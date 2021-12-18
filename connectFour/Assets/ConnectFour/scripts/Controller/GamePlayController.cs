using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject gameItem;
    [SerializeField] GameObject gameItem2;
    [SerializeField] LayConfig layConfig;
    [SerializeField] GameObject ChipPosition;
    [SerializeField] GameObject Player1Chip;
    [SerializeField] GameObject Player2Chip;
    [SerializeField] GameObject NamePlayer1;
    [SerializeField] GameObject NamePlayer2;
    [SerializeField] static float time = 2.0f;
    [SerializeField] GameObject BoardGameWood;
    [SerializeField] GameObject BoardGamePlastic;
    [SerializeField] Button Btn_SubMenu;
    [SerializeField] GameObject SubMenuGroup;
    float minX = -3.6f;
    float maxX = 3.6f;
    float Timer = 0;
   
    bool player1FirstMove = true;





    private void OnEnable()
    {
        UpdateBoardType();
    }
    void Start()
    {

        
        SetName();
        SetColor();
        if(PlayerPrefs.HasKey(GameBoard.FirstPlayer)==false)
        SetFirstMove();

        Btn_SubMenu.onClick.AddListener(OnSubMenu);

    }

    // Update is called once per frame
    void Update()
    {

        Choose_Mode();

    }

    private void CreateChips()
    {
        // SetChipsSprite();
        if (Input.GetMouseButtonDown(0))
        {
            SafeBoard();
            Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (spawnPos.x < minX || spawnPos.x > maxX) return;

            if (spawnPos.y < -4 || spawnPos.y > 4) return;
            if (GameBoard.Instance.GetColumnRow(Mathf.RoundToInt(spawnPos.x) + 3, 5).GetComponent<SpriteRenderer>().sprite != null) return;

            if (GameBoard.Instance.GetPlayFirstSwapOnePlayer() == true)
            {
                GameObject newObject = Instantiate(gameItem, new Vector3(Mathf.RoundToInt(spawnPos.x), ChipPosition.transform.position.y, 0), Quaternion.identity) as GameObject;
                GameBoard.Instance.SetPlayFirstSwapOnePlayer(false);


            }
            else
            {
                GameObject newObject = Instantiate(gameItem2, new Vector3(Mathf.RoundToInt(spawnPos.x), ChipPosition.transform.position.y, 0), Quaternion.identity) as GameObject;
                GameBoard.Instance.SetPlayFirstSwapOnePlayer(true);
            }
        }
    }
    private void SetFirstMove()
    {
        if (GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.ONE_PLAY)
        {
            if (GameSetup.Instance.GetCurrentFirstMoveType() == GameSetup.FIRST_MOVE_TYPE.ORANGE && GameSetup.Instance.GetCurrentColorSelected() == GameSetup.COLOR_SELECT.ORANGE)
            {
                GameBoard.Instance.SetPlayFirstSwapOnePlayer(true);

            }
            else if (GameSetup.Instance.GetCurrentFirstMoveType() == GameSetup.FIRST_MOVE_TYPE.ORANGE && GameSetup.Instance.GetCurrentColorSelected() == GameSetup.COLOR_SELECT.GREEN)
            {
                GameBoard.Instance.SetPlayFirstSwapOnePlayer(false);
            }
            else if (GameSetup.Instance.GetCurrentFirstMoveType() == GameSetup.FIRST_MOVE_TYPE.GREEN && GameSetup.Instance.GetCurrentColorSelected() == GameSetup.COLOR_SELECT.ORANGE)
            {
                GameBoard.Instance.SetPlayFirstSwapOnePlayer(false);
            }
            else
            {
                int i = Random.Range(0, 2);
                if (i == 0)
                {
                    GameBoard.Instance.SetPlayFirstSwapOnePlayer(true);
                }
                else GameBoard.Instance.SetPlayFirstSwapOnePlayer(false);
            }
        }
        else
        {
            if (GameSetup.Instance.GetCurrentFirstMoveTypeTwoPlayer() == GameSetup.FIRST_MOVE_TYPE.YELLOW && GameSetup.Instance.GetCurrentColorSelectedTwoPlayer() == GameSetup.COLOR_SELECT.YELLOW)
            {
                GameBoard.Instance.SetPlayFirstSwapOnePlayer(true);
            }
            else if (GameSetup.Instance.GetCurrentFirstMoveTypeTwoPlayer() == GameSetup.FIRST_MOVE_TYPE.YELLOW && GameSetup.Instance.GetCurrentColorSelectedTwoPlayer() == GameSetup.COLOR_SELECT.ORANGE)
            {
                GameBoard.Instance.SetPlayFirstSwapOnePlayer(false);
            }
            else if (GameSetup.Instance.GetCurrentFirstMoveTypeTwoPlayer() == GameSetup.FIRST_MOVE_TYPE.ORANGE && GameSetup.Instance.GetCurrentColorSelectedTwoPlayer() == GameSetup.COLOR_SELECT.YELLOW)
            {
                GameBoard.Instance.SetPlayFirstSwapOnePlayer(false);
            }
            else
            {
                int i = Random.Range(0, 2);
                if (i == 0)
                {
                    GameBoard.Instance.SetPlayFirstSwapOnePlayer(true);
                }
                else GameBoard.Instance.SetPlayFirstSwapOnePlayer(false);
            }
        }
    }
    private void SetColor()
    {
        if (GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.ONE_PLAY)
        {
            if (GameSetup.Instance.GetCurrentColorSelected() == GameSetup.COLOR_SELECT.GREEN)
            {
                gameItem.GetComponent<SpriteRenderer>().sprite = layConfig.spr_Lay_Green;
                gameItem2.GetComponent<SpriteRenderer>().sprite = layConfig.spr_Lay_Orange;
                Player1Chip.GetComponent<Image>().sprite = layConfig.spr_Lay_Green;
                Player2Chip.GetComponent<Image>().sprite = layConfig.spr_Lay_Orange;
            }
            else if (GameSetup.Instance.GetCurrentColorSelected() == GameSetup.COLOR_SELECT.ORANGE)
            {
                gameItem.GetComponent<SpriteRenderer>().sprite = layConfig.spr_Lay_Orange;
                gameItem2.GetComponent<SpriteRenderer>().sprite = layConfig.spr_Lay_Green;
                Player1Chip.GetComponent<Image>().sprite = layConfig.spr_Lay_Orange;
                Player2Chip.GetComponent<Image>().sprite = layConfig.spr_Lay_Green;
            }
        }
        else
        {
            if (GameSetup.Instance.GetCurrentColorSelectedTwoPlayer() == GameSetup.COLOR_SELECT.ORANGE)
            {
                gameItem.GetComponent<SpriteRenderer>().sprite = layConfig.spr_Lay_Orange;
                gameItem2.GetComponent<SpriteRenderer>().sprite = layConfig.spr_Lay_Yellow;
                Player1Chip.GetComponent<Image>().sprite = layConfig.spr_Lay_Orange;
                Player2Chip.GetComponent<Image>().sprite = layConfig.spr_Lay_Yellow;
            }
            else if (GameSetup.Instance.GetCurrentColorSelectedTwoPlayer() == GameSetup.COLOR_SELECT.YELLOW)
            {
                gameItem.GetComponent<SpriteRenderer>().sprite = layConfig.spr_Lay_Yellow;
                gameItem2.GetComponent<SpriteRenderer>().sprite = layConfig.spr_Lay_Orange;
                Player1Chip.GetComponent<Image>().sprite = layConfig.spr_Lay_Yellow;
                Player2Chip.GetComponent<Image>().sprite = layConfig.spr_Lay_Orange;
            }
        }

    }
    private void CreateChipsMachine()
    {
        // SetChipsSprite();
        if (Input.GetMouseButtonDown(0))
        {
            SafeBoard();
            Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (spawnPos.x < minX || spawnPos.x > maxX) return;

            if (spawnPos.y < -4 || spawnPos.y > 4) return;
            if (GameBoard.Instance.GetColumnRow(Mathf.RoundToInt(spawnPos.x) + 3, 5).GetComponent<SpriteRenderer>().sprite != null) return;

            if (GameBoard.Instance.GetPlayFirstSwapOnePlayer() == true)
            {

                GameObject newObject = Instantiate(gameItem, new Vector3(Mathf.RoundToInt(spawnPos.x), ChipPosition.transform.position.y, 0), Quaternion.identity) as GameObject;
                int n = isArgee(GameBoard.Instance.AIData, Mathf.RoundToInt(spawnPos.x) + 3);
                GameBoard.Instance.AIData[Mathf.RoundToInt(spawnPos.x) + 3, n] = 2;
                GameBoard.Instance.SetPlayFirstSwapOnePlayer(false);

                Timer = time;
            }

        }
        Timer -= Time.deltaTime;
        if (Timer > 0) return;
        if (GameBoard.Instance.GetPlayFirstSwapOnePlayer() == false)
        {


            int k_random = AIResult();

            GameObject newObject = Instantiate(gameItem2, new Vector3(ChipPosition.transform.position.x + k_random, ChipPosition.transform.position.y, 0), Quaternion.identity) as GameObject;

            int n = isArgee(GameBoard.Instance.AIData, k_random);
            GameBoard.Instance.AIData[k_random, n] = 1;
            GameBoard.Instance.SetPlayFirstSwapOnePlayer(true);
            Timer = 0.1f;



        }
    }

    private void Choose_Mode()
    {

        if (GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.ONE_PLAY)
        {
            CreateChipsMachine();
        }
        else
        {
            CreateChips();

        }
    }
    private void SetName()
    {
        if (GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.ONE_PLAY)
        {
            NamePlayer1.GetComponent<Text>().text = GameSetup.Instance.GetCurrentNamePlayer1ModeSinglePlayer();
            NamePlayer2.GetComponent<Text>().text = GameSetup.Instance.GetCurrentNamePlayer2ModeSinglePlayer();
        }
        else
        {
            NamePlayer1.GetComponent<Text>().text = GameSetup.Instance.GetCurrentNamePlayer1ModeTwoPlayer();
            NamePlayer2.GetComponent<Text>().text = GameSetup.Instance.GetCurrentNamePlayer2ModeTwoPlayer();
        }
    }

    private int AIResult()
    {

        int[,] testBoard = GameBoard.Instance.AIData;
        int depth = 0;

        if (testBoard[0, 0] == 0 && testBoard[1, 0] == 0 && testBoard[2, 0] == 0 && testBoard[3, 0] == 0 && testBoard[4, 0] == 0 && testBoard[5, 0] == 0 && testBoard[6, 0] == 0)
        {
            return Random.Range(0, 7);
        }
        if (GameSetup.Instance.GetCurrentLevelGame() == GameSetup.LEVEL_GAME.EASY)
        {
            depth = 1;
        }
        else if (GameSetup.Instance.GetCurrentLevelGame() == GameSetup.LEVEL_GAME.MEDIUM)
        {
            depth = 3;
        }
        else if (GameSetup.Instance.GetCurrentLevelGame() == GameSetup.LEVEL_GAME.HARD)
        {
            depth = 7;

        }

        return AI.bestMove(testBoard, depth).column;
    }
    int isArgee(int[,] board, int column)
    {
        for (int row = 0; row < GameBoard.Instance.row; row++)
        {
            // Debug.Log(column + "  " + row);
            //if (board[column, GameBoard.Instance.row - 1] != 0) continue;
            if (row == 0 && board[column, row] == 0) return row;
            if (row > 0 && board[column, row] == 0)
            {
                if (board[column, row - 1] != 0)
                {

                    return row;
                }
            }



        }
        return 0;

    }

    void UpdateBoardType()
    {
        if (OptionSetup.Instance.GetBoardType() == OptionSetup.BOARDTYPE.Wood)
        {
            BoardGameWood.SetActive(true);
        }
        else
        {
            BoardGamePlastic.SetActive(true);
        }
    }
    void OnSubMenu()
    {
        SubMenuGroup.SetActive(true);
        maxX = -1000;
        
        Time.timeScale = 0;
    }
    void SafeBoard()
    {
        if (Time.timeScale == 1)
        {

            maxX = 3.6f;

        }

    }
}
