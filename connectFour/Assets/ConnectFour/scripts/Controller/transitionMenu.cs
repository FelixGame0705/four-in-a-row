using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class transitionMenu : MonoBehaviour
{
    //tien begin
    [Header("Button")]
    
    [SerializeField] Button StatsToMainMenu;
    

    
    [SerializeField] GameObject MenuPlayer;
    
    [SerializeField] GameObject MenuStats;


    [SerializeField] Sprite spr_one_Player;
    [SerializeField] Sprite spr_two_Player;
    [SerializeField] Sprite spr_Chip_Select_1;
    [SerializeField] Sprite spr_Chip_Select_2;

    [SerializeField] Sprite spr_one_Layer;
    [SerializeField] Sprite spr_two_Layer;

    public bool isMenuPlay1 = false;

   
   

    //tien end

    // Start is called before the first frame update
    void Start()
    {
        
        StatsToMainMenu.onClick.AddListener(ChangeStatsToMainMenu);
        //MenuOnePlayer.onClick.AddListener(ChangeMainMenuToOnePlayerMenu);
        //MenuTwoPlayer.onClick.AddListener(ChangeMainMenuToTwoPlayerMenu);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //begin tien
    //public void Change1PlayerMenuToMainMenu()
    //{
    //    //MenuMain.SetActive(true);
    //    MenuPlayer.SetActive(false);

    //}

    //public void Change1PlayerMenuToStats()
    //{
    //    SceneManager.LoadScene("GamePlay");
    //}

    public void ChangeStatsToMainMenu()
    {
        MenuStats.SetActive(false);
        //MenuMain.SetActive(true);
    }
    public void ChangeMainMenuToOnePlayerMenu()
    {
        isMenuPlay1 = true;
        MenuPlayer.SetActive(true);
        //MenuMain.SetActive(false);
        MenuPlayer.transform.Find("Img_OnePlayer_Tiltle").GetComponent<Image>().sprite = spr_one_Player;
        MenuPlayer.transform.Find("Img_Playr_1").Find("Playr_1_Chip").GetComponent<Image>().sprite = spr_one_Layer;
        MenuPlayer.transform.Find("Img_Color").Find("Playr_1_Chip").GetComponent<Image>().sprite = spr_one_Layer;
        MenuPlayer.transform.Find("Img_First_Move").Find("Playr_1_Chip").GetComponent<Image>().sprite = spr_one_Layer;
        MenuPlayer.transform.Find("Img_First_Move").Find("Img_Chip_Select").GetComponent<Image>().sprite = spr_Chip_Select_1;

        
        

    }
    public void ChangeMainMenuToTwoPlayerMenu()
    {
        isMenuPlay1 = false;
        MenuPlayer.SetActive(true);
        //MenuMain.SetActive(false);

        //Slider.SetActive(false);
        MenuPlayer.transform.Find("Img_OnePlayer_Tiltle").GetComponent<Image>().sprite = spr_two_Player;
        MenuPlayer.transform.Find("Img_Playr_1").Find("Playr_1_Chip").GetComponent<Image>().sprite = spr_two_Layer;
        MenuPlayer.transform.Find("Img_Color").Find("Playr_1_Chip").GetComponent<Image>().sprite = spr_two_Layer;
        MenuPlayer.transform.Find("Img_First_Move").Find("Playr_1_Chip").GetComponent<Image>().sprite = spr_two_Layer;
        MenuPlayer.transform.Find("Img_First_Move").Find("Img_Chip_Select").GetComponent<Image>().sprite = spr_Chip_Select_2;

       
        
    }
    //end tien

}
