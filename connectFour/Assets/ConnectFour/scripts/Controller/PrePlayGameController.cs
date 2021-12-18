using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PrePlayGameController : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] Button Btn_Back;
    [SerializeField] Button Btn_Play;
    [SerializeField] GameObject MenuPlayer;
    [SerializeField] GameObject Selector;
    [SerializeField] GameObject Slider_level;

    [Header("Image")]
    [SerializeField] Image Lay1_Playr;
    [SerializeField] Image Lay2_Playr;

    [SerializeField] Image Color_Lay1;
    [SerializeField] Image Color_Lay2;

    [Header("Game Objects")]
    [SerializeField] GameObject FirstMove_lay1;
    [SerializeField] GameObject FirstMove_lay2;
    [SerializeField] GameObject FirstMove_Rand;
    
    [SerializeField] GameObject Name_SinglePlayer;
    [SerializeField] GameObject Name_TwoPlayer;

    Animator animator;
     
    [SerializeField] Button Swap_lay;
    
    [SerializeField] InputField ipfName1;
    [SerializeField] InputField ipfName2;
    // Start is called before the first frame update
    GameSetup.COLOR_SELECT LaySelected;
    //GameSetup.FIRST_MOVE_TYPE LayFirstMove;
    //bool Swap_clicked = false;
    public LayConfig layConfig;
    private void OnEnable()
    {
        UpdateChooseColorLayGame();     
    }
    void Start()
    {

        SetNameOnInput();
        animator = Selector.GetComponent<Animator>();
        Swap_lay.GetComponent<Button>().onClick.AddListener(SetSwapChooseColorLayGame);
        FirstMove_lay1.GetComponent<Button>().onClick.AddListener(SetLayFirstMove1);
        FirstMove_lay2.GetComponent<Button>().onClick.AddListener(SetLayFirstMove2);
        FirstMove_Rand.GetComponent<Button>().onClick.AddListener(SetLayFirstMoveRandom);
        Btn_Back.onClick.AddListener(BackToMainMenu);
        Btn_Play.onClick.AddListener(PlayGame);
        Slider_level.GetComponent<Slider>().value = PlayerPrefs.GetInt(GameSetup.RMS_DIFFICULT_ONE_PLAY);
       // Slider_level.GetComponent<Slider>().onValueChanged.AddListener(SaveValueSlider);
       
        UpdateFirstMove();

    }


    // Update is called once per frame
    void Update()
    {
        SetSlider();
        SaveValueSlider();
        SetHeader();
    }
    public void SetHeader()
    {
        if (GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.ONE_PLAY)
        {
            Name_SinglePlayer.SetActive(true);
            Name_TwoPlayer.SetActive(false);
        }
        else
        {
            Name_SinglePlayer.SetActive(false);
            Name_TwoPlayer.SetActive(true);
        }
    }
   public void SetSwapChooseColorLayGame()
    {       
        if(GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.ONE_PLAY){
            
            if (LaySelected == GameSetup.COLOR_SELECT.GREEN) { LaySelected = GameSetup.COLOR_SELECT.ORANGE; }
            else { LaySelected = GameSetup.COLOR_SELECT.GREEN; }
            GameSetup.Instance.SetCurrentColorSelected((GameSetup.COLOR_SELECT)LaySelected);

        }
        else if((GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.TWO_PLAY))
        {
            
            if (LaySelected == GameSetup.COLOR_SELECT.YELLOW) { LaySelected = GameSetup.COLOR_SELECT.ORANGE; }
            else { LaySelected = GameSetup.COLOR_SELECT.YELLOW; }
            GameSetup.Instance.SetCurrentColorSelectedTwoPlayer((GameSetup.COLOR_SELECT)LaySelected);

        }
        UpdateChooseColorLayGame();

        //Swap_clicked = true;
    }
    public void UpdateFirstMove()
    {
        if (GameSetup.Instance.GetCurrentFirstMoveType() == GameSetup.FIRST_MOVE_TYPE.GREEN)
        {
            SetLayFirstMove1();
        }
        else if (GameSetup.Instance.GetCurrentFirstMoveType() == GameSetup.FIRST_MOVE_TYPE.ORANGE)
        {
            SetLayFirstMove2();
            
        } 
        else
        {
            SetLayFirstMoveRandom();
        }
        
    }
    public void SetName()
    {
        if (GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.ONE_PLAY)
        {
            GameSetup.Instance.SetCurrentNamePlayer1ModeSinglePlayer(ipfName1.text);
            GameSetup.Instance.SetCurrentNamePlayer2ModeSinglePlayer(ipfName2.text);
            //PlayerPrefs.SetString(GameSetup.RMS_NAME_PLAYER1_SINGLE_PLAYER, ipfName1.text);
            //PlayerPrefs.SetString(GameSetup.RMS_NAME_PLAYER2_SINGLE_PLAYER, ipfName2.text);           
        }
        else
        {
            GameSetup.Instance.SetCurrentNamePlayer1ModeTwoPlayer(ipfName1.text);
            GameSetup.Instance.SetCurrentNamePlayer2ModeTwoPlayer(ipfName2.text);
            //PlayerPrefs.SetString(GameSetup.RMS_NAME_PLAYER1_TWO_PLAYER, ipfName1.text);
            //PlayerPrefs.SetString(GameSetup.RMS_NAME_PLAYER2_TWO_PLAYER, ipfName2.text);
        }
    }
    public void SetLevel()
    {
        Slider_level.SetActive(true);
        SaveValueSlider();
    }

    public void BackToMainMenu()
    {
        //MenuMain.SetActive(true);
        MenuPlayer.SetActive(false);
    }
    public void PlayGame()
    {

        SceneManager.LoadScene("GamePlay");
    }
    private void SaveValueSlider()
    {
        if (Slider_level.GetComponent<Slider>().value == 0)
        {
            GameSetup.Instance.SetCurrentLevelGame(GameSetup.LEVEL_GAME.EASY);
        }
        else if (Slider_level.GetComponent<Slider>().value == 1)
        {
            GameSetup.Instance.SetCurrentLevelGame(GameSetup.LEVEL_GAME.MEDIUM);

        }
        else
        {
            GameSetup.Instance.SetCurrentLevelGame(GameSetup.LEVEL_GAME.HARD);
        }
    }

    public void SetLayFirstMove1()
    {
        animator.SetTrigger("Select1"); //play cái select_1
        if (GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.ONE_PLAY)
        {
            GameSetup.Instance.SetCurrentFirstMoveType(GameSetup.FIRST_MOVE_TYPE.GREEN);
        }
        else
        {
            GameSetup.Instance.SetCurrentFirstMoveTypeTwoPlayer(GameSetup.FIRST_MOVE_TYPE.ORANGE);
        }
    }

    public void SetLayFirstMoveRandom()
    {
        animator.SetTrigger("Select0"); //play random 
        if (GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.ONE_PLAY)
        {
            GameSetup.Instance.SetCurrentFirstMoveType(GameSetup.FIRST_MOVE_TYPE.RANDOMLY);
        }
        else
        {
            GameSetup.Instance.SetCurrentFirstMoveTypeTwoPlayer(GameSetup.FIRST_MOVE_TYPE.RANDOMLY);
        }
        

    }

    public void SetLayFirstMove2()
    {
        animator.SetTrigger("Select2"); //play cái select_2
        if (GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.ONE_PLAY)
        {
            GameSetup.Instance.SetCurrentFirstMoveType( GameSetup.FIRST_MOVE_TYPE.ORANGE);
        }
        else
        {
            GameSetup.Instance.SetCurrentFirstMoveTypeTwoPlayer(GameSetup.FIRST_MOVE_TYPE.YELLOW);
        }
    }
    private void UpdateChooseColorLayGame()
    {
        if (GameSetup.Instance.GetCurrentColorSelected() == GameSetup.COLOR_SELECT.GREEN && GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.ONE_PLAY)
        {
            Color_Lay1.sprite = layConfig.spr_Lay_Green;
            Color_Lay2.sprite = layConfig.spr_Lay_Orange;
            Lay1_Playr.sprite = layConfig.spr_Lay_Green;
            Lay2_Playr.sprite = layConfig.spr_Lay_Orange;
            FirstMove_lay2.GetComponent<Image>().sprite = layConfig.spr_Lay_Orange;
            FirstMove_Rand.GetComponent<Image>().sprite = layConfig.spr_Lay_Random_Single_Player;
            LaySelected = GameSetup.COLOR_SELECT.GREEN;
            //Debug.Log( EventSystem.current.currentSelectedGameObject.name);
            // if (Swap_clicked == true)
           // GameSetup.Instance.SetCurrentColorSelected(GameSetup.COLOR_SELECT.ORANGE);
        }
        else if (GameSetup.Instance.GetCurrentColorSelected() == GameSetup.COLOR_SELECT.ORANGE && GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.ONE_PLAY)
        {
            Color_Lay1.sprite = layConfig.spr_Lay_Orange;
            Color_Lay2.sprite = layConfig.spr_Lay_Green;
            Lay1_Playr.sprite = layConfig.spr_Lay_Orange;
            Lay2_Playr.sprite = layConfig.spr_Lay_Green;
            FirstMove_lay2.GetComponent<Image>().sprite = layConfig.spr_Lay_Orange;
            FirstMove_Rand.GetComponent<Image>().sprite = layConfig.spr_Lay_Random_Single_Player;
            LaySelected = GameSetup.COLOR_SELECT.ORANGE;          
           // GameSetup.Instance.SetCurrentColorSelected(GameSetup.COLOR_SELECT.GREEN);

        }
        else if (GameSetup.Instance.GetCurrentColorSelectedTwoPlayer() == GameSetup.COLOR_SELECT.ORANGE && GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.TWO_PLAY)
        {
            Color_Lay1.sprite = layConfig.spr_Lay_Orange;
            Color_Lay2.sprite = layConfig.spr_Lay_Yellow;
            Lay1_Playr.sprite = layConfig.spr_Lay_Orange;
            Lay2_Playr.sprite = layConfig.spr_Lay_Yellow;
            LaySelected = GameSetup.COLOR_SELECT.ORANGE;
            FirstMove_lay1.GetComponent<Image>().sprite = layConfig.spr_Lay_Orange;
            FirstMove_lay2.GetComponent<Image>().sprite = layConfig.spr_Lay_Yellow;
            FirstMove_Rand.GetComponent<Image>().sprite = layConfig.spr_Lay_Random_Two_Player;
            //  if (Swap_clicked == true)
            //   GameSetup.Instance.SetCurrentColorSelectedTwoPlayer(GameSetup.COLOR_SELECT.YELLOW);
        }
        else if (GameSetup.Instance.GetCurrentColorSelectedTwoPlayer() == GameSetup.COLOR_SELECT.YELLOW && GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.TWO_PLAY)
        {
            Color_Lay1.sprite = layConfig.spr_Lay_Yellow;
            Color_Lay2.sprite = layConfig.spr_Lay_Orange;
            Lay1_Playr.sprite = layConfig.spr_Lay_Yellow;
            Lay2_Playr.sprite = layConfig.spr_Lay_Orange;
            LaySelected = GameSetup.COLOR_SELECT.YELLOW;
            FirstMove_lay1.GetComponent<Image>().sprite = layConfig.spr_Lay_Orange;
            FirstMove_lay2.GetComponent<Image>().sprite = layConfig.spr_Lay_Yellow;
            FirstMove_Rand.GetComponent<Image>().sprite = layConfig.spr_Lay_Random_Two_Player;
            // if (Swap_clicked == true)
            

        }
    }
    public void SetSlider()
    {
        if(GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.TWO_PLAY)
        Slider_level.SetActive(false);
        
    }
    private void SetNameOnInput()
    {
        if (GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.ONE_PLAY)
        {
           ipfName1.GetComponent<InputField>().text = GameSetup.Instance.GetCurrentNamePlayer1ModeSinglePlayer();
           ipfName2.GetComponent<InputField>().text = GameSetup.Instance.GetCurrentNamePlayer2ModeSinglePlayer();
        }
        else
        {
            ipfName1.GetComponent<InputField>().text = GameSetup.Instance.GetCurrentNamePlayer1ModeTwoPlayer();
            ipfName2.GetComponent<InputField>().text = GameSetup.Instance.GetCurrentNamePlayer2ModeTwoPlayer();
        }
    }
}
