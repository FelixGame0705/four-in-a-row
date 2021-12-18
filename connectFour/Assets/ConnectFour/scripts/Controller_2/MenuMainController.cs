using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuMainController : MonoBehaviour
{
    [Header("Button Menu")]
    [SerializeField] Button BtnOnePlayer;
    [SerializeField] Button BtnTwoPlayer;
    [SerializeField] Button BtnStats;
    [SerializeField] Button BtnOptions;
    [Header("Menu Objects")]
    [SerializeField] GameObject SelectionMenu;
    [SerializeField] GameObject StatsMenu;
    [SerializeField] GameObject OptionMenu;
    // Start is called before the first frame update
    void Start()
    {
        BtnOnePlayer.onClick.AddListener(loadMenuSelection_OnePlayer);
        BtnTwoPlayer.onClick.AddListener(loadMenuSelection_TwoPlayer);
        BtnStats.onClick.AddListener(loadStatsMenu);
        BtnOptions.onClick.AddListener(loadOptionsMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void loadMenuSelection_OnePlayer()
    {
        SelectionMenu.SetActive(true);
        GameSetup.Instance.SetCurrentSelecteGameMode(GameSetup.GAME_MODE.ONE_PLAY);
        
    }
    private void loadMenuSelection_TwoPlayer()
    {
        SelectionMenu.SetActive(true);
        GameSetup.Instance.SetCurrentSelecteGameMode(GameSetup.GAME_MODE.TWO_PLAY);
    }
    private void loadStatsMenu()
    {
        StatsMenu.SetActive(true);
    }
    private void loadOptionsMenu()
    {
        OptionMenu.SetActive(true);
    }
}
