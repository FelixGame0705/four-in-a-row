using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Thuy scripts
public class UIController : MonoBehaviour
{
    [Header("MAIN MENU")]
    public Button onePlayer;
    public Button twoPlayer;
    public Button stats;
    public Button options;

    [Header("GAME SELECTION MENU")]
    public Button backToMain;
    public Button newGame;
    public Button resumeGame;

    [Header("GAME OPTIONS MENU")]
    public Button backToMain_Op;
    //public Button material_Plastic;
    //public Button material_Wood;
    //public Button soundControl;
    public GameObject materialWood;
    public GameObject materialPlastic;
    [SerializeField] Toggle soundCtr;
    [SerializeField] Dropdown materials;
    private int saveSound;
    private string Game_Sound="s";
    private int saveMaterial;
    private string Game_Material;
        

    [Header("GAME MENUS")]
    public GameObject gameSelectionMenu;
    public GameObject gameLevelMenu;
    public GameObject gameOptionsMenu;
    public GameObject gameStats;
    public GameObject gameMainMenu;
    public Button moreGame;
    public Button info;
    public static bool isCheckmenuOne = false;
    private bool mainMenuActive = false;
    private bool onePlayerBtnOnClick = false;
    //private bool twoPlayerBtnOnClick = false;
    private transitionMenu player = new transitionMenu();
    private int columnBoard = 7;
    private int rowBoard = 6;
   

    // Start is called before the first frame update
    void Start()
    {
        
        onePlayer.onClick.AddListener(OnClickToOnePlayer);
        twoPlayer.onClick.AddListener(OnClickToTwoPlayer);
        stats.onClick.AddListener(OnClickStats);
        options.onClick.AddListener(OnClickOptions);
        moreGame.onClick.AddListener(MoreGame);
        info.onClick.AddListener(Information);
        backToMain.onClick.AddListener(OnClickMainMenu);
        newGame.onClick.AddListener(PlayerMenu);
        resumeGame.onClick.AddListener(OnClickToGamePlay);
        backToMain_Op.onClick.AddListener(OnClickMainMenu);

        soundCtr.GetComponent<Toggle>().isOn = true;
        
        //if (PlayerPrefs.HasKey(Game_Material))
        //{
        //    saveMaterial = PlayerPrefs.GetInt(Game_Material);
        //    if(saveMaterial == 0)
        //    {
        //        materials.value = 0;
        //    }
        //    else if(saveMaterial == 1)
        //    {
        //        materials.value = 1;
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SwitchToPlastic()
    {
        materialPlastic.SetActive(true);
        materialWood.SetActive(false);
       
    }

    public void SwitchToWood()
    {
        materialWood.SetActive(true);
        materialPlastic.SetActive(false);
        
    }

   
    public void PlayerMenu()
    {
        NewGamePlay();
        gameLevelMenu.SetActive(true);

       

        
    }

    public void OnClickToGamePlay()
    {
        
        SceneManager.LoadScene("GamePlay");
        
    }

    //Main Menu Controller
    public void MoreGame()
    {
        
    }

    public void Information()
    {
        
    }
    public void OnClickMainMenu()
    {
        if (!mainMenuActive)
        {

            gameSelectionMenu.SetActive(false);
            gameStats.SetActive(false);
            gameOptionsMenu.SetActive(false);
        }
        gameMainMenu.SetActive(true);

    }

    public void OnClickToOnePlayer()
    {
        isCheckmenuOne = true;
        gameSelectionMenu.SetActive(true);
        onePlayerBtnOnClick = true;
        GameSetup.Instance.SetCurrentSelecteGameMode(GameSetup.GAME_MODE.ONE_PLAY);
        
    }

    public void OnClickToTwoPlayer()
    {
        isCheckmenuOne = false;
        gameSelectionMenu.SetActive(true);
        onePlayerBtnOnClick = false;
        GameSetup.Instance.SetCurrentSelecteGameMode(GameSetup.GAME_MODE.TWO_PLAY);
        
    }

    public void DifficultSelection()
    {
        if (!onePlayerBtnOnClick)
        {
            player.ChangeMainMenuToOnePlayerMenu();
        }
        player.ChangeMainMenuToTwoPlayerMenu();
    }

    public void OnClickStats()
    {
        gameStats.SetActive(true);
        
    }

    public void OnClickOptions()
    {
        gameOptionsMenu.SetActive(true);
        
    }

    public void OnChangeToggleSound()
    {
        
        if(soundCtr.isOn==true)
        {
            saveSound = 1;
            GameSetup.Instance.SetSound(saveSound);
        }
        else
        {
            saveSound = 0;
            GameSetup.Instance.SetSound(saveSound);
        }
        PlayerPrefs.SetInt(Game_Sound, saveSound);
    }

    public void OnChangeMaterial()
    {
        
        if(materials.value == 0)
        {
            SwitchToPlastic();
            saveMaterial = 0;
        }
        else
        {
            SwitchToWood();
            saveMaterial = 1;
        }
        PlayerPrefs.SetInt(Game_Material, saveMaterial);
        UpdateBoardType();
    }
    public void UpdateBoardType()
    {
        if (materials.value == 0)
        {
            OptionSetup.Instance.SetBoardType(OptionSetup.BOARDTYPE.Plastic);
        }
        else
        {
            OptionSetup.Instance.SetBoardType(OptionSetup.BOARDTYPE.Wood);
        }
        
    }
    public void NewGamePlay()
    {
        GameBoard.Instance.SetGameStatus(GameBoard.GAME_STATUS.NORMAL);
        if (GameSetup.Instance.GetCurrentSelectedGameMode() == GameSetup.GAME_MODE.ONE_PLAY)
        {
            for (int i = 0; i < columnBoard; i++)
            {
                for (int j = 0; j < rowBoard; j++)
                {
                    int index = j + i * 6;
                    
                    PlayerPrefs.DeleteKey(GameBoard.RMS_CHIP_STATUS + index);
                    PlayerPrefs.DeleteKey(GameBoard.ColumnNumPos + index);
                    PlayerPrefs.DeleteKey(GameBoard.RowNumPos + index);
                }
            }
        }
        else
        {
            for (int i = 0; i < columnBoard; i++)
            {
                for (int j = 0; j < rowBoard; j++)
                {
                    
                    int index = j + i * rowBoard;
                    PlayerPrefs.DeleteKey(GameBoard.RMS_CHIP_STATUS_TWO + index);
                    PlayerPrefs.DeleteKey(GameBoard.ColumnNumPos2 + index);
                    PlayerPrefs.DeleteKey(GameBoard.RowNumPos2 + index);
                }
            }
        }
        GameBoard.Instance.SetDefaultData();
        PlayerPrefs.DeleteKey(GameBoard.FirstPlayer);
    }
   



}

//end of Thuy
