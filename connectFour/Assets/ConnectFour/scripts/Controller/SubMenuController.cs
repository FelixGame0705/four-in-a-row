using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SubMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] GameObject SubMenuGroup;
    [SerializeField] Button Btn_Resume;
    [SerializeField] Button Btn_NewGame;
    [SerializeField] GameObject StatsMenu;
    [SerializeField] Button Btn_Stats;
    [SerializeField] Button Btn_BackToMain;
    [SerializeField] GameObject PopWin;
    [SerializeField] GameObject PopLose;
    [SerializeField] GameObject PopDraw;
    UIController uIController = new UIController();
    void Start()
    {

        GameBoard.Instance.SetContinue(true);
        Btn_Resume.onClick.AddListener(OnResume);
        Btn_NewGame.onClick.AddListener(OnNewGame);
        Btn_Stats.onClick.AddListener(OnStats);
        Btn_BackToMain.onClick.AddListener(BackMain);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnResume()
    {
        Time.timeScale = 1;
        SubMenuGroup.SetActive(false);
    }
    public void OnNewGame()
    {
      
      
        PopWin.SetActive(false);
        PopLose.SetActive(false);
        PopDraw.SetActive(false);
        if (GameBoard.Instance.GetGameStatus() == GameBoard.GAME_STATUS.LOSE)
        {
            GameSetup.Instance.SetNumberLose(GameSetup.Instance.GetNumberLose()+1);
        }
        Time.timeScale = 1;
        uIController.NewGamePlay();
        
        GameBoard.Instance.SetGameStatus(GameBoard.GAME_STATUS.NORMAL);
        GameBoard.Instance.SetContinue(false);
        GameBoard.Instance.SetDefaultData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        
   
    }
    void OnStats()
    {
        StatsMenu.SetActive(true);
        Time.timeScale = 1;
    }
    void BackMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameMenu");
        
        
    }
    
    
}
